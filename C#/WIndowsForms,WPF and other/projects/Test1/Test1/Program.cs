using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test1
{
	class Program
	{
		static void Main(string[] args)
		{
			int a = Convert.ToInt32(Console.ReadLine());
			int b = Convert.ToInt32(Console.ReadLine());
			double c = a / (b * 9);
			Console.Write(c + 1 + " ");
			double d = (a % (b * 9)) / b;
			Console.Write(d + 1);
		}
	}
}
