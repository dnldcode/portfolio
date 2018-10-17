using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace les18
{
	class Program
	{
		static void Main(string[] args)
		{
			String textColor = ConfigurationManager.AppSettings["textColor"];
			String backgroundColor = ConfigurationManager.AppSettings["backgroundColor"];

			string[] colors = {
				"Black", "DarkBlue", "DarkGreen", "DarkCyan", "DarkRed",
				"DarkMagenta", "DarkYellow", "Gray", "DarkGray", "Blue",
				"Green", "Cyan", "Red", "Magenta", "Yellow", "White"
			};
			int a = 0;
			foreach(string clr in colors)
			{
				if(String.Compare(textColor, clr, true) == 0)
				{
					Console.ForegroundColor = (ConsoleColor)a;
				}
				if (String.Compare(backgroundColor, clr, true) == 0)
				{
					Console.BackgroundColor = (ConsoleColor)a;
				}
				a++;
			}
			Console.Clear();
			Console.WriteLine("test");
			Console.ReadLine();
			Console.ResetColor();
		}
	}
}