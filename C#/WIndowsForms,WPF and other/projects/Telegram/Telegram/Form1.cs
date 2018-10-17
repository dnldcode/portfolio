using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Telegram
{
	public partial class Form1 : Form
	{
		LoginForm lf = new LoginForm();
		TcpClient client;
		NetworkStream NS;
		public Form1()
		{
			InitializeComponent();

			try
			{
				client = new TcpClient("192.168.0.106", 5000);
				NS = client.GetStream();
			}
			catch
			{
				MessageBox.Show("Невозможно подключится к серверу", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void buttonSEND_Click(object sender, EventArgs e)
		{
			byte[] buf = new byte[1024];
			MemoryStream MS = new MemoryStream();
			String temp = textBoxMessage.Text;
			if (temp.Trim() == "")
				return;
			try
			{
				byte[] a = Encoding.UTF8.GetBytes("NEWMSG|" + temp);
				NS.Write(a, 0, a.Length);
				do
				{
					int cnt = NS.Read(buf, 0, buf.Length);
					if (cnt == 0)
						throw new Exception("0 bytes recieved");
					MS.Write(buf, 0, cnt);
				}
				while (NS.DataAvailable);
				String result = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Length);

				MessageBox.Show(result);
				MS.SetLength(0);
			}
			catch (Exception ee)
			{
				MessageBox.Show("Разрыв соединения с сервером : " + ee.Message);
				return;
			}
		}
	}
}