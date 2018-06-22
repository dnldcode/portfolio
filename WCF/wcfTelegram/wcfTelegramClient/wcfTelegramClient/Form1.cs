using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wcfTelegramClient
{
	public partial class Form1 : Form
	{
		static public String name;
		public Thread onlineUsers;
		public Thread messages;
		public Thread activity;
		public Form1()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosing += Form1_FormClosing;

			Connection.MakeConnection();

			onlineUsers = new Thread(checkOnlineUsers);
			onlineUsers.IsBackground = true;
			onlineUsers.Start();
			messages = new Thread(checkMessages);
			messages.IsBackground = true;
			messages.Start();
			activity = new Thread(sendActivity);
			activity.IsBackground = true;
			activity.Start();
			this.Text = $"Telegram [{name}]";
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Connection.Disconnect();
		}

		private void buttonSEND_Click(object sender, EventArgs e)
		{
			String str = Connection.sendMessage(textBoxMessage.Text);
			if (str.Contains("ERROR"))
				MessageBox.Show(str.Split('|')[1], "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else
				textBoxMessage.Text = "";
		}

		public void checkMessages()
		{
			while(true)
			{
				foreach (String str in Connection.getMessages(listBoxMessages.Items.Count).Split('|')[1].Split('&'))
					listBoxMessages.Invoke(new Action(() => { if(str != "") listBoxMessages.Items.Add(str); }));
				Thread.Sleep(1000);
			}
		}

		public void checkOnlineUsers()
		{
			Thread.Sleep(10);
			while(true)
			{
				this.Invoke(new Action(() => { listBoxOnline.Items.Clear(); }));
				foreach (String str in Connection.getOnlineUsers().Split('^'))
					this.Invoke(new Action(() => { listBoxOnline.Items.Add(str); }));
				Thread.Sleep(3000);
			}
		}
		public void sendActivity()
		{
			while(true)
			{
				Connection.sendActivity();
				Thread.Sleep(10000);
			}
		}

		private void textBoxMessage_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
				this.buttonSEND_Click(null, null);
		}
	}
	static public class Connection
	{
		static public wcfTelegramServer.Telegram client;
		static public LoginForm login = new LoginForm();
		static public bool isConnecting = false;
		static public bool MakeConnection(bool isError = false)
		{
			Form1 f1 = Program.form1;
			if (f1 != null)
				f1.Hide();
			if (isError)
				MessageBox.Show("Невозможно подключиться, попробуйте позже.", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
			isConnecting = true;
			while (true)
			{
				client = (new ChannelFactory<wcfTelegramServer.Telegram>("MyConfig")).CreateChannel();
				if (login.ShowDialog() == DialogResult.Yes)
				{
					try
					{
						String[] strs = Login(login.textBox1.Text).Split('|');
						Form1.name = login.textBox1.Text;
						if (strs[0] == "ERROR")
						{
							MessageBox.Show(strs[1], "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
							continue;
						}
						else
						{
							if (f1 != null)
							{
								f1.Text = $"Telegram [{Form1.name}]";
								f1.listBoxMessages.Items.Clear();
								if (!f1.onlineUsers.IsAlive)
								{
									f1.onlineUsers = new Thread(f1.checkOnlineUsers);
									f1.onlineUsers.IsBackground = true;
									f1.onlineUsers.Start();
								}
								if (!f1.messages.IsAlive)
								{
									f1.messages = new Thread(f1.checkMessages);
									f1.messages.IsBackground = true;
									f1.messages.Start();
								}
								if (!f1.activity.IsAlive)
								{
									f1.activity = new Thread(f1.sendActivity);
									f1.activity.IsBackground = true;
									f1.activity.Start();
								}
								f1.Show();
							}
							isConnecting = false;
							return false;
						}
					}
					catch
					{
						MessageBox.Show("Невозможно подключиться, попробуйте позже.", "Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
						continue;
					}
				}
				else
				{
					Environment.Exit(0);
					return true;
				}
			}
		}
		static public String Login(String name)
		{
			return client.Login(name);
		}
		static public String sendMessage(String message)
		{
			try
			{
				return client.sendMessage(Form1.name, message);
			}
			catch
			{
				if (!Connection.isConnecting)
					Connection.MakeConnection(true);
			}
			return "";
		}
		static public String getOnlineUsers()
		{
			try
			{
				return client.getOnlineUsers();
			}
			catch
			{
				Program.form1.onlineUsers.Abort();
				Program.form1.onlineUsers.Join(500);
			}
			return "";
		}
		static public void Disconnect()
		{
			try
			{
				client.Disconnect(Form1.name);
			}
			catch { }
		}
		static public String getMessages(int n)
		{
			try
			{
				return client.getMessages(n);
			}
			catch
			{
				Program.form1.messages.Abort();
				Program.form1.messages.Join(500);
			}
			return "";
		}
		static public void sendActivity()
		{
			try
			{
				client.sendActivity(Form1.name);
			}
			catch
			{
				if(!Connection.isConnecting)
					Connection.MakeConnection(true);
			}
		}
	}
}

namespace wcfTelegramServer
{
	[ServiceContract]
	public interface Telegram
	{
		[OperationContract]
		String Login(String name);
		[OperationContract]
		String sendMessage(String userName, String message);
		[OperationContract]
		String getOnlineUsers();
		[OperationContract]
		String getMessages(int n);
		[OperationContract]
		void Disconnect(String name);
		[OperationContract]
		void sendActivity(String name);
	}
}