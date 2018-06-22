using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
			ServerThread ST = new ServerThread("192.168.0.106", 5000);
			Thread T = new Thread(ST.run);
			T.IsBackground = true;
			T.Start();
			Console.WriteLine("Сервер запущен.");
			while (!Console.KeyAvailable)
				Thread.Sleep(500);
		}
	}
	class ServerThread
	{
		String host;
		int port;

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
					T.Start(client.Client.RemoteEndPoint);
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
		public ReadWriteThread(TcpClient client)
		{
			this.client = client;
		}
		public void run(Object ip)
		{
			String strInfo = client.Client.RemoteEndPoint.ToString();
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
					Console.WriteLine("Получено от клиента {0} : {1}", ip, str);
					MS.SetLength(0);
					String[] split = str.Split('|');
					String newStr = "";
					if (split.Length > 1)
					{
						for (int i = 1; i < split.Length; i++)
						{
							if (split[0].ToUpper() == "REVERSE")
								newStr += new String(split[i].Reverse().ToArray());
							else
								newStr += split[i];
							if (i != split.Length - 1)
								newStr += "|";
						}
						switch (split[0].ToUpper())
						{
							case "UPPER":
								newStr = split[0] + "OK|" + newStr.ToUpper();
								break;
							case "LOWER":
								newStr = split[0] + "OK|" + newStr.ToLower();
								break;
							case "REVERSE":
								newStr = split[0] + "OK|" + newStr;
								break;
							default:
								newStr = str;
								break;
						}
					}
					else
						newStr = str;
					byte[] a = Encoding.UTF8.GetBytes(newStr);
					NS.Write(a, 0, a.Length);
					Console.WriteLine("Отправлено клиенту {0} : {1}", ip, newStr);
				}
			}
			catch
			{
				Console.WriteLine("Разрыв соединения : {0}", strInfo);
			}
		}
	}
}