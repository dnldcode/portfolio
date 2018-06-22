using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				TcpClient client = new TcpClient("192.168.0.106", 5000);
				Console.WriteLine("Клиент успешно подключился к серверу.");
				NetworkStream NS = client.GetStream();
				byte[] buf = new byte[1024];
				MemoryStream MS = new MemoryStream();
				while (true)
				{
					Console.WriteLine("Введите строку. Пустая строка - выход : ");
					String str = Console.ReadLine();
					if (str.Length == 0)
						break;

					Console.WriteLine("Выберите действие : ");
					Console.WriteLine("1 - UPPER\n2 - LOWER\n3 - REVERSE\nelse - nothing");

					switch (Console.ReadLine())
					{
						case "1":
							str = str.Insert(0, "UPPER|");
							break;
						case "2":
							str = str.Insert(0, "LOWER|");
							break;
						case "3":
							str = str.Insert(0, "REVERSE|");
							break;
						default:
							break;
					}

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
						if (result.Split('|').Length > 1 && str.Split('|').Length > 1)
							if (result.Split('|')[0] != (str.Split('|')[0] + "OK"))
							{
								Console.WriteLine("Соединение разорвано");
								NS.Close();
								continue;
							}
							else
								result = result.Remove(0, str.Split('|')[0].Length + 3);

						Console.WriteLine("Получено от сервера : {0}", result);
						MS.SetLength(0);
					}
					catch (Exception e)
					{
						Console.WriteLine("Разрыв соединения с сервером : {0}", e.Message);
						break;
					}
				}
				NS.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Ошибка : {0}", e.Message);
			}
		}
	}
}
