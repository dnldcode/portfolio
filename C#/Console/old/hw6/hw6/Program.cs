using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw6
{
	class Program
	{
		static void Main(string[] args)
		{
			//#1
			//String text;
			//Console.Write(" Введите строку : ");
			//text = Console.ReadLine();
			//while (text.Contains("  ") || text.Contains("..") || text.Contains(",,"))
			//{
			//	text = text.Replace("  ", " ");
			//	text = text.Replace("..", ".");
			//	text = text.Replace(",,", ",");
			//}
			//String[] textAr = text.Split(' ', ',', '.');
			//Console.WriteLine("Кол-во слов - " + textAr.Length);

			//#2
			//String text, subtext;
			//Console.Write(" Введите строку : ");
			//text = Console.ReadLine();
			//Console.Write(" Введите подстроку : ");
			//subtext = Console.ReadLine();

			//int count = 0, index = 0;
			//while ((index = text.IndexOf(subtext, index) + 1) != 0)
			//	count++;
			//Console.WriteLine(count);

			//#3
			Faction [] arrF = { new Faction(1, 3),
								new Faction(7, 9),
								new Faction(1, 4),
								new Faction(3, 1),
								new Faction(1, 4),
								new Faction(22, 7),
								new Faction(13, 4),
							};
			Array.Sort(arrF);
			for (int i = 0; i < arrF.Length; i++)
				Console.WriteLine(arrF[i]);
		}
	}
	class Faction : IComparable
	{
		private double numerator;
		public double Numerator
		{
			get
			{
				return numerator;
			}
			set
			{
				numerator = value;
			}
		}
		private double denominator;
		public double Denominator
		{
			get
			{
				return denominator;
			}
			set
			{
				if (value == 0)
					value = 1;
				denominator = value;
			}
		}
		public Faction(double num, double denom)
		{
			Numerator = num;
			Denominator = denom;
		}
		public override string ToString()
		{
			return String.Format("{0}/{1}", this.Numerator, this.Denominator);
		}
		static public Faction operator +(Faction f1, Faction f2)
		{
			return new Faction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
		}
		static public Faction operator -(Faction f1, Faction f2)
		{
			return new Faction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
		}
		static public Faction operator *(Faction f1, Faction f2)
		{
			return new Faction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
		}
		static public Faction operator /(Faction f1, Faction f2)
		{
			return new Faction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
		}
		static public bool operator == (Faction f1, Faction f2)
		{
			return (double)f1.Numerator / f1.Denominator == (double)f2.Numerator / f2.Denominator;
		}
		static public bool operator !=(Faction f1, Faction f2)
		{
			return (double)f1.Numerator / f1.Denominator != (double)f2.Numerator / f2.Denominator;
		}
		static public bool operator >(Faction f1, Faction f2)
		{
			return (double)f1.Numerator / f1.Denominator > (double)f2.Numerator / f2.Denominator;
		}
		static public bool operator <(Faction f1, Faction f2)
		{
			return (double)f1.Numerator / f1.Denominator < (double)f2.Numerator / f2.Denominator;
		}

		// Потому что попросил компилятор.
		public override bool Equals(object obj)
		{
			if (obj is Faction)
			{
				Faction m = (Faction)obj;
				return (double)this.Numerator / this.Denominator == (double)m.Numerator / m.Denominator;
			}
			return false;
		}
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}
		////
		public int CompareTo(object obj)
		{
			if (obj is Faction)
			{
				Faction m = (Faction)obj;
				return (int)(this.Numerator * 10.0 / this.Denominator -  m.Numerator * 10.0/ m.Denominator);
			}
			return -1;
		}
	}
}