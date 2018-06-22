using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TcpListenterNotCLass
{
	class Program
	{
		static void Main(string[] args)
		{
			int port;

			if (!int.TryParse(ConfigurationManager.AppSettings["port"], out port))
			{
				Console.WriteLine("Недопустимый порт");
				return;
			}

			ServerThread ST = new ServerThread(ConfigurationManager.AppSettings["ip"], port);
			Console.WriteLine("Сервер включен");
			Thread T = new Thread(ST.run);
			T.IsBackground = true;
			T.Start();

			while (!Console.KeyAvailable)
				Thread.Sleep(500);
		}
	}
	class ServerThread
	{
		String host;
		int port;
		public static List<String> messages = new List<String>();
		public static List<String> online = new List<String>();
		public ServerThread(String host, int port)
		{
			this.host = host;
			this.port = port;
		}
		public void run()
		{
			try
			{
				TcpListener server = new TcpListener(IPAddress.Parse(this.host), this.port);
				server.Start();
				while (true)
				{
					TcpClient client = server.AcceptTcpClient();
					Console.WriteLine("Подключение : " + client.Client.RemoteEndPoint);

					ReadWriteThread RWT = new ReadWriteThread(client);
					Thread T = new Thread(RWT.run);
					T.IsBackground = true;
					T.Start();
				}
			}
			catch
			{
				Console.WriteLine("Ошибка подключения");
			}
		}
	}
	class ReadWriteThread
	{
		TcpClient client;
		String nickname = "";
		public ReadWriteThread(TcpClient client)
		{
			this.client = client;
			this.nickname = client.Client.RemoteEndPoint.ToString();
		}
		public void run()
		{
			MemoryStream MS = new MemoryStream();
			try
			{
				byte[] buf = new byte[1024];
				NetworkStream NS = client.GetStream();
				while (true)
				{
					do
					{
						int cnt = NS.Read(buf, 0, buf.Length);
						if (cnt == 0)
							throw new Exception("0 bytes recieved");
						MS.Write(buf, 0, cnt);
					}
					while (NS.DataAvailable);
					String str = Encoding.UTF8.GetString(MS.GetBuffer(), 0, (int)MS.Length);
					Console.WriteLine("Получено от клиента {0} : {1}", nickname, str);
					MS.SetLength(0);
					String answMessage = "";

					String[] m = str.Split('|');
					if (m.Length == 2)
					{
						if (m[0] == "LOGIN")
						{
							if (!ServerThread.online.Contains(m[1]))
							{
								if (m[1].Length >= 25)
									answMessage = "LOGINERROR|Недопустимая длина(макс 25)";
								else if (m[1].Trim() == "")
									answMessage = "LOGINERROR|Пустая строка";
								else
								{
									ServerThread.online.Add(m[1]);
									this.nickname = m[1];
									answMessage = "LOGINOK";
								}
							}
							else
								answMessage = "LOGINERROR|Такой логин уже есть";
						}
						else
						if (!ServerThread.online.Contains(nickname) || nickname == client.Client.RemoteEndPoint.ToString())
							answMessage = "NOLOGIN|Невозможно начать работу, не введен логин";
						else
						{
							if (m[0] == "NEWMSG")
							{
								if (m[1].Length >= 25)
									answMessage = "NEWMSGERROR|Недопустимая длина сообщения(макс 25)";
								else if (m[1].ToLower().Contains("флюиды"))
									answMessage = "NEWMSGERROR|Недопустимое слово в сообщении";
								else if (m[1].Trim() == "")
									answMessage = "NEWMSGERROR|Пустое сообщение";
								else
								{
									ServerThread.messages.Add(this.nickname + " : " + m[1]);
									answMessage = "NEWMSGOK";
								}
							}
							else if (m[0] == "USERLIST")
							{
								answMessage = "USERLISTOK|";
								foreach (String s in ServerThread.online)
									answMessage += s + "^";
								answMessage = answMessage.Remove(answMessage.Length - 1, 1);
							}
							else if (m[0] == "MSGLIST")
							{
								answMessage = "MSGLISTOK|";
								if (ServerThread.messages.Count != Convert.ToInt32(m[1]))
								{
									for (int i = Convert.ToInt32(m[1]); i < ServerThread.messages.Count; i++)
										answMessage += String.Format("{0}^{1}&", i, ServerThread.messages[i]);
									answMessage = answMessage.Remove(answMessage.Length - 1, 1);
								}
								Console.WriteLine("Кол-во сообщений : " + ServerThread.messages.Count);
							}
						}
					}
					else
					{
						answMessage = "FORMERROR|Недопустимая форма";
					}

					byte[] a = Encoding.UTF8.GetBytes(answMessage);
					NS.Write(a, 0, a.Length);
					Console.WriteLine("Отправлено клиенту {0} : {1}", nickname, answMessage);
				}
			}
			catch
			{
				Console.WriteLine("Разрыв соединения : {0}", nickname);
				if (nickname != "")
					ServerThread.online.Remove(nickname);
			}
		}
	}
}