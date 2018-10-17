using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les19._1
{
	class Program
	{
		public delegate void dispatcher();
		class Aeroplan
		{
			//private dispatcher D;
			public event dispatcher D;
			public void addDispetcher(dispatcher d)
			{
				this.D += d;
			}
			public void removeDispatcher(dispatcher d)
			{
				this.D -= d;
			}

			public void fly()
			{
				ConsoleKeyInfo CKI;
				do
				{
					CKI = Console.ReadKey(true);
					if(D != null)
					{
						D();
					}


				} while (CKI.Key != ConsoleKey.Escape);
			}
		}
		class Dispatcher	// Класс диспетчер
		{
			private String city;	// Город в котором расположен диспетчер
			private String name;    // Имя диспетчера
			public Dispatcher(String city, String name)
			{
				this.city = city;
				this.name = name;
			}
			public void workMessage()
			{
				Console.WriteLine("Город : {0}, диспетчер {1} : Погодные условия нормальные. Полет контролируется.", this.city, this.name);
			}
		}
		class Terrorist
		{
			public void terrorAction()
			{
				Console.WriteLine(" Немедленно лететь в ИГ! Иначе взорвем самолет!");
			}
		}
		static void Main(string[] args)
		{
			Dispatcher D1 = new Dispatcher("Киев", "Петров");
			Dispatcher D2 = new Dispatcher("Черкассы", "Шевченко");
			Dispatcher D3 = new Dispatcher("Запорожье", "Бывалый");
			Aeroplan A = new Aeroplan();
			A.addDispetcher(D1.workMessage);
			A.addDispetcher(D2.workMessage);
			A.addDispetcher(D3.workMessage);
			Terrorist BenLaden = new Terrorist();
			A.addDispetcher(BenLaden.terrorAction);
			A.fly();
		}
	}
}
