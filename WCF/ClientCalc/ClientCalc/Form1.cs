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

namespace ClientCalc
{
	public partial class Form1 : Form
	{
		NetworkStream NS;
		String action = "None";
		public Form1()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterScreen;

			try
			{
				TcpClient client = new TcpClient("192.168.0.106", 5000);
				Console.WriteLine("Клиент успешно подключился к серверу.");
				NS = client.GetStream();
			}
			catch (Exception e)
			{
				MessageBox.Show("Ошибка : " + e.Message, "Невозможно подключится", MessageBoxButtons.OK, MessageBoxIcon.Error);
				this.Close();
			}
		}

		private void buttonResult_Click(object sender, EventArgs e)
		{
			byte[] buf = new byte[1024];
			MemoryStream MS = new MemoryStream();
			String str = String.Format("{0}|{1}|{2}", this.action, this.textBox1.Text, this.textBox2.Text);
			try
			{
				byte[] a = Encoding.UTF8.GetBytes(str);
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


				if (result == "ACTIONERROR")
					MessageBox.Show("Не введено действие - " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if (result == "ZERODIVERROR")
					MessageBox.Show("Невозможно деление на нуль - " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if (result == "FORMERROR")
					MessageBox.Show("Невозможная форма отправки данных(файл поврежден) - " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if (result == "VALUELENGTHERROR")
					MessageBox.Show("Недопустимая длина строки - " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else if (result == "VALUEERROR")
					MessageBox.Show("Недопустимое значение числа - " + result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				else
				{
					string[] temp = result.Split('|');
					if (temp[0] == this.action + "OK" && temp.Length == 2)
						textBox3.Text = temp[1];
					else
					{
						MessageBox.Show("Соединение разорвано.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						NS.Close();
					}
				}

				MS.SetLength(0);
			}
			catch (Exception ee)
			{
				MessageBox.Show("Разрыв соединения с сервером : " + ee.Message, "Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}

		private void buttons_Click(object sender, EventArgs e)
		{
			if (sender == buttonPlus)
				this.action = "PLUS";
			else if (sender == buttonMinus)
				this.action = "MINUS";
			else if (sender == buttonDiv)
				this.action = "DIV";
			else if (sender == buttonMult)
				this.action = "MULT";
		}
	}
}
