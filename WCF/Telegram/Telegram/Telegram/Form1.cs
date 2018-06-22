using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Telegram
{
	public partial class Form1 : Form
	{
		LoginForm lf = new LoginForm();
		TcpClient client;
		NetworkStream NS;
		delegate void ReloadList();
		Thread threadUsersOnline;
		Thread threadLoadMessages;
		public Form1()
		{
			InitializeComponent();
			int port;

			if (!int.TryParse(ConfigurationManager.AppSettings["port"], out port))
			{
				MessageBox.Show("Недопустимый порт", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}

			try
			{
				client = new TcpClient(ConfigurationManager.AppSettings["ip"], port);
				NS = client.GetStream();
			}
			catch (Exception ee)
			{
				MessageBox.Show("Невозможно подключится к серверу : " + ee.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
				return;
			}

			while (true)
			{
				if (lf.ShowDialog() == DialogResult.OK)
				{
					String[] result = sendToServer("LOGIN|" + lf.textBox1.Text).Split('|');
					if (result[0] == "LOGINOK")
						break;
					else if (result[0] == "LOGINERROR")
					{
						MessageBox.Show(result[1], "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						if (result[1] == "Пустая строка")
							lf.textBox1.Text = "";
					}
				}
				else
				{
					this.Close();
					break;
				}
			}

			threadUsersOnline = new Thread(refreshOnlineUsers);
			threadUsersOnline.IsBackground = true;
			threadUsersOnline.Start();

			threadLoadMessages = new Thread(refreshMessages);
			threadLoadMessages.IsBackground = true;
			threadLoadMessages.Start();
		}

		private void refreshU()
		{
			onlineList.Items.Clear();
			String[] str = sendToServer("USERLIST|").Split('|');
			if (str[0] == "USERLISTOK")
			{
				foreach (String s in str[1].Split('^'))
					onlineList.Items.Add(s);
			}
			else
				CloseConnection();
		}

		private void refreshOnlineUsers()
		{
			Thread.Sleep(100);
			ReloadList rol = refreshU;
			while (true)
			{
				onlineList.Invoke(rol);
				Thread.Sleep(5000);
			}
		}

		private void refreshM()
		{
			String[] str = sendToServer("MSGLIST|" + messagesList.Items.Count).Split('|');
			if (str[0] == "MSGLISTOK")
			{
				foreach (String s in str[1].Split('&'))
					if (s != "")
						messagesList.Items.Add(s.Split('^')[1]);
			}
			else
				CloseConnection();
		}

		private void refreshMessages()
		{
			Thread.Sleep(100);
			ReloadList rol = refreshM;
			while (true)
			{
				messagesList.Invoke(rol);
				Thread.Sleep(3000);
			}
		}

		private void buttonSEND_Click(object sender, EventArgs e)
		{
			String[] result = this.sendToServer("NEWMSG|" + this.textBoxMessage.Text).Split('|');
			if (result[0] != "NEWMSGOK")
			{
				if (result[0] == "NOLOGIN")
					MessageBox.Show(result[1], "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if (result[0] == "NEWMSGERROR")
				{
					MessageBox.Show(result[1], "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					if (result[1] == "Пустое сообщение")
						textBoxMessage.Text = "";
				}
				else if (result[0] != "Null String")
					CloseConnection();
			}
			else
			{
				if (result[0] == "NEWMSGOK")
				{
					//messagesList.Items.Add(lf.textBox1.Text + " : " + this.textBoxMessage.Text);
					textBoxMessage.Text = "";
				}
				else
					CloseConnection();
			}
		}

		private void CloseConnection()
		{
			MessageBox.Show("Соединение с сервером разорвано", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			NS.Close();
			this.Close();
		}

		private String sendToServer(String temp)
		{
			lock (this)
			{
				byte[] buf = new byte[1024];
				MemoryStream MS = new MemoryStream();
				if (temp.Trim() == "")
					return "Null String";
				try
				{
					byte[] a = Encoding.UTF8.GetBytes(temp);
					NS.Write(a, 0, a.Length);
					do
					{
						int cnt = NS.Read(buf, 0, buf.Length);
						if (cnt == 0)
							throw new Exception("0 bytes recieved");
						MS.Write(buf, 0, cnt);
					}
					while (NS.DataAvailable);
					return Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Length);
				}
				catch (Exception ee)
				{
					KillThreads();
					MessageBox.Show("Разрыв соединения с сервером : " + ee.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.Close();
					return "";
				}
			}
		}

		private void KillThreads()
		{
			threadUsersOnline.Abort();
			threadLoadMessages.Abort();
		}

		private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				this.buttonSEND_Click(null, null);
		}
	}
}