using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace hw14
{
	class Program
	{
		static bool sort;
		static void Main(string[] args)
		{
			String path = Directory.GetCurrentDirectory() + @"\" + "log.dat";
			StreamWriter sw;
			List<Worker> listOfWorkers = new List<Worker>();
			string n;
			while (true)
			{
				Console.Clear();
				Console.WriteLine("\n 1. Добавить сотрудника");
				Console.WriteLine(" 2. Удалить сотрудника по индексу");
				Console.WriteLine(" 3. Вывести всех сотрудников");
				Console.WriteLine(" 4. Вывести сотрудников по подстроке");
				Console.WriteLine(" 5. Отсортировать по возрасту");
				Console.WriteLine(" 6. Отсортировать по фамилии");
				Console.WriteLine(" 7. Выход");
				Console.Write("\n Ответ : ");
				n = Console.ReadLine();

				switch (n)
				{
					case "1":
						Console.Clear();

						Worker temp = new Worker();
						Console.Write(" Введите фамилию : ");
						temp.Surname = Console.ReadLine();
						Console.Write(" Введите имя: ");
						temp.Name = Console.ReadLine();
						try
						{
							Console.Write(" Введите возраст : ");
							temp.Age = Int32.Parse(Console.ReadLine());
						}
						catch (FormatException fe)
						{
							Console.WriteLine(" Ошибка : " + fe.Message);
							continue;
						}
						Console.Write(" Введите должность : ");
						temp.Position = Console.ReadLine();

						Console.WriteLine("\n Добавить введенного работника?(1 - да)");
						Console.Write(" Ответ : ");
						n = Console.ReadLine();

						if (n == "1")
						{
							listOfWorkers.Add(temp);
							sw = File.AppendText(path);
							sw.WriteLine(temp + " (added)");
							sw.Close();
						}
						break;
					case "2":
						Console.Clear();
						if (listOfWorkers.Count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Удаление невозможно.");
							Console.ReadKey();
							continue;
						}
						Console.WriteLine("\n Список работников : ");
						int q = 0;
						foreach (Worker w in listOfWorkers)
							Console.WriteLine(w + ", index : " + q++);
						try
						{
							Console.Write("\n Введите индекс работника, которого хотите удалить : ");
							listOfWorkers.RemoveAt(Int32.Parse(Console.ReadLine()));
						}
						catch
						{
							Console.WriteLine("\n Ошибка ввода. Проверьте вводимый индекс на существование.");
							Console.ReadKey();
							continue;
						}
						Console.WriteLine("\n Сотрудник удален.");
						Console.ReadKey();
						break;
					case "3":
						Console.Clear();
						Console.WriteLine("\n Список работников : ");
						if (listOfWorkers.Count() == 0)
						{
							Console.WriteLine("\n Ничего не найдено.");
							Console.ReadKey();
							continue;
						}
						foreach (Worker w in listOfWorkers)
							Console.WriteLine(w);
						Console.ReadKey();
						break;
					case "4":
						Console.Clear();
						if (listOfWorkers.Count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Вывод невозможен.");
							Console.ReadKey();
							continue;
						}
						Console.WriteLine("\n Список работников : ");
						foreach (Worker w in listOfWorkers)
							Console.WriteLine(w);
						String temp1;
						Console.Write("\n Введите подстроку : ");
						temp1 = Console.ReadLine();
						Console.WriteLine("\n Результаты поиска фамилий по подстроке " + temp1 + " : ");
						foreach (Worker w in listOfWorkers)
							if (w.Surname.Contains(temp1))
								Console.WriteLine(w);
						Console.ReadKey();
						break;
					case "5":
						Console.Clear();
						if (listOfWorkers.Count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Сортировка невозможна.");
							Console.ReadKey();
							continue;
						}
						sort = true;
						listOfWorkers.Sort();
						Console.WriteLine("\n Отсортированный список работников по возрасту : ");
						foreach (Worker w in listOfWorkers)
							Console.WriteLine(w);
						Console.ReadKey();
						break;
					case "6":
						Console.Clear();
						if (listOfWorkers.Count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Сортировка невозможна.");
							Console.ReadKey();
							continue;
						}
						sort = false;
						listOfWorkers.Sort();
						Console.WriteLine("\n Отсортированный список работников по фамилии : ");
						foreach (Worker w in listOfWorkers)
							Console.WriteLine(w);
						Console.ReadKey();
						break;
					case "7":
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("\n Введено неверное значение.");
						Console.ReadKey();
						break;
				}
			}
		}
		class Worker : IComparable
		{
			private String surname;
			public String Surname
			{
				get
				{
					return this.surname;
				}
				set
				{
					this.surname = value;
				}
			}
			private String name;
			public String Name
			{
				get
				{
					return this.name;
				}
				set
				{
					this.name = value;
				}
			}
			private int age;
			public int Age
			{
				get
				{
					return this.age;
				}
				set
				{
					if (value < 0)
						value *= -1;
					this.age = value;
				}
			}
			private String position;
			public String Position
			{
				get
				{
					return this.position;
				}
				set
				{
					this.position = value;
				}
			}
			public Worker(String surname = "Unknown", String name = "Unknown", int age = 0, String position = "Unknown")
			{
				this.Surname = surname;
				this.Name = name;
				this.Age = age;
				this.Position = position;
			}
			public override string ToString()
			{
				return String.Format("\n Фамилия - {0}, имя - {1}\n Возраст - {2}, должность - {3}", this.Surname, this.Name, this.Age, this.Position);
			}
			public int CompareTo(object obj)
			{
				if (obj is Worker)
				{
					Worker m = (Worker)obj;
					if (sort)
						return (int)this.Age - m.Age;
					else
						return (int)String.Compare(this.Surname, m.Surname);
				}
				return -1;
			}
		}
	}
}