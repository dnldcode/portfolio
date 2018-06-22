using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace RozetkaParse
{
	class Program
	{
		static public String content;
		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("\n\tВведите имя для поиска : ");
				String text = Console.ReadLine();
				Console.WriteLine();
				try
				{
					HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://rozetka.com.ua/search/?text=" + text);
					HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
					if (webResponse.StatusCode == HttpStatusCode.OK)
					{
						Stream recieveStream = webResponse.GetResponseStream();
						StreamReader readStream = new StreamReader(recieveStream, Encoding.UTF8);
						content = readStream.ReadToEnd();
						recieveStream.Close();
						String startString = "<div class=\"g-i-tile g-i-tile-catalog\"";
						String endString = "var price = {price: 0};";
						while (true)
						{
							if (content.IndexOf(endString) <= 0)
								break;
							int temp = Convert.ToInt32(Regex.Match(Uri.UnescapeDataString(Regex.Match(content, "(?<=pricerawjson = ')(.*)(?=';)").ToString()), "(?<=\"price\":)(.*)(?=,\"status)").ToString());
							Match m = Regex.Match(content.Remove(0, content.IndexOf(startString)), "(?<=title=\")(.*)(?=\")");
							Console.WriteLine("Товар : {0}\nЦена : {1}\n", m, temp == 0 ? "Нет в наличии" : temp.ToString() + " грн");
							content = content.Remove(0, content.IndexOf(endString) + endString.Length);
						}
					}
					else
						Console.WriteLine("Получен ответ : {0}", webResponse.StatusCode);
					webResponse.Close();
				}
				catch (Exception ee)
				{
					Console.WriteLine("Error : {0}", ee.Message);
				}
			}
		}
	}
}
