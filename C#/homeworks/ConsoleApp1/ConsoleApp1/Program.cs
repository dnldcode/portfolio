using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//DZ
//№1
//Пользователь вводит предложение, необходимо подсчитать количество слов.
//№2
//Пользователь вводит строку и подстроку.Неоьходимо подсчитать, сколько раз подстрока встречается в строке.
//№3
//Написать класс дробь.Реализовать калькулятор дробей в виде перегрузки соответствующих операторов. Так же, перегрузить
//операторы срванения: =, !=, <, >.
namespace hhWW
{
	class Fraction
	{
		private int numerator;
		public int Numenator
		{
			get
			{
				return this.numerator;
			}
			set
			{
				this.numerator = value;
			}
		}
		private int denumerator;
		public int Denumenator
		{
			get
			{
				return this.denumerator;
			}
			set
			{

				if (value != 0)

					this.denumerator = value;
				else
					Console.WriteLine();
			}
		}
		public Fraction(int num, int dem)
		{
			this.Numenator = num;
			this.Denumenator = dem;
		}

		//Перегрузка операций

		//Calc
		public static Fraction operator +(Fraction a, Fraction b)
		{
			Fraction c = new Fraction(1, 1);
			c.Denumenator = getLeastCommonMultiple(a.Denumenator, b.Denumenator);
			int addMultFirst = c.Denumenator / a.Denumenator;
			int addMultSec = c.Denumenator / b.Denumenator;
			c.Numenator = a.Numenator * addMultFirst + b.Numenator * addMultSec;
			return c;
		}
		public static Fraction operator -(Fraction a, Fraction b)
		{
			Fraction c = new Fraction(1, 1);
			c.Denumenator = getLeastCommonMultiple(a.Denumenator, b.Denumenator);
			int addMultFirst = c.Denumenator / a.Denumenator;
			int addMultSec = c.Denumenator / b.Denumenator;
			c.Numenator = a.Numenator * addMultFirst - b.Numenator * addMultSec;
			return c;
		}
		public static Fraction operator *(Fraction a, Fraction b)
		{
			Fraction c = new Fraction(1, 1);
			c.Numenator = a.Numenator * b.Numenator;
			c.Denumenator = a.Denumenator * b.Denumenator;
			return c;
		}
		public static Fraction operator /(Fraction a, Fraction b)
		{
			Fraction c = new Fraction(1, 1);
			c.Numenator = a.Numenator * b.Denumenator;
			c.Denumenator = a.Denumenator * b.Numenator;
			return c;
		}

		//Equals

		public static bool operator !=(Fraction a, Fraction b)
		{
			if (a.Equals(b))
				return false;
			else
				return true;
		}
		public static bool operator ==(Fraction a, Fraction b)
		{
			if (a.Equals(b))
				return true;
			else
				return false;
		}
		public static bool operator >(Fraction a, Fraction b)
		{
			if ((a.Numenator / a.Denumenator) * 10 > (b.Numenator / b.Denumenator) * 10)
				return true;
			else
				return false;
		}

		public static bool operator <(Fraction a, Fraction b)
		{
			if ((a.Numenator / a.Denumenator) * 10 < (b.Numenator / b.Denumenator) * 10)
				return true;
			else
				return false;
		}



		//Методы реализующие функционал класса Fraction
		public Fraction addFraction(Fraction a)
		{
			return this + a;
		}
		public Fraction minFraction(Fraction a)
		{
			return this - a;
		}
		public Fraction multFraction(Fraction a)
		{
			return this * a;
		}
		public Fraction delFraction(Fraction a)
		{
			return this / a;
		}
		public bool equalFraction(Fraction a)
		{
			return this == a;
		}
		public bool notEqualFraction(Fraction a)
		{
			return this != a;
		}
		public bool moreThenFraction(Fraction a)
		{
			return this > a;
		}
		public bool lessThenFraction(Fraction a)
		{
			return this < a;
		}



		public override string ToString()
		{
			return Numenator.ToString() + "/" + Denumenator.ToString();
		}

		//
		private static int getGreatestCommonDivisor(int a, int b) //НОД
		{
			while (b != 0)
			{
				int temp = b;
				b = a % b;
				a = temp;
			}
			return a;
		}
		private static int getLeastCommonMultiple(int a, int b) //НОК
		{
			return a * b / getGreatestCommonDivisor(a, b);
		}


	}

	class Program
	{

		static void Main(string[] args)
		{
			////#1

			//Console.Write("Введите что-нибудь: ");
			//String text = Console.ReadLine();
			//while(text.Contains("  "))
			//{
			//    text = text.Replace("  ", " ");
			//}
			//char sep = ' ';
			//String[] textMass = text.Split(sep);
			//Console.WriteLine("Вы вывели {0} слов.", textMass.Length);


			////#2

			//Console.Write("Введите строку: ");
			//String str = Console.ReadLine();
			//Console.Write("Введите ключ для поиска: ");
			//String podstr = Console.ReadLine();
			//int count = 0; int index = 0;
			//while ((index = str.IndexOf(podstr, index) + 1) != 0)
			//    count++;
			//Console.WriteLine("Найдено {0} повторений(ния).", count);


			//#3
			Fraction f1 = new Fraction(5, 2);
			Fraction f2 = new Fraction(2, 7);
			Fraction f3 = f1.addFraction(f2);
			bool a = f1.lessThenFraction(f2);
			Console.WriteLine(a);
			//Console.WriteLine(f1.ToString() + " + " + f2.ToString() + " = " + f3.ToString());



		}
	}
}

