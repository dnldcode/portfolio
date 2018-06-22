using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace hw18
{
	public delegate void dispatcher();
	class Program
	{
		static public bool sort;
		static public String file = "logs.dat";
		
		static void Main(string[] args)
		{
			ListOfWorkers low = new ListOfWorkers();
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
				Console.WriteLine(" 7. Показать логи");
				Console.WriteLine(" 8. Выход");
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
							low.addWorker(temp);
							low.Dispatcher += temp.workerAdded;
							low.notify();
							low.Dispatcher -= temp.workerAdded;
						}
						break;
					case "2":
						Console.Clear();
						if (low.count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Удаление невозможно.");
							Console.ReadKey();
							continue;
						}
						Console.WriteLine("\n Список работников : ");
						low.showWorkers();
						try
						{
							Console.Write("\n Введите индекс работника, которого хотите удалить : ");
							int index = Int32.Parse(Console.ReadLine());
							Worker w = low.getWorkerByIndex(index);
							low.removeAt(index);
							low.Dispatcher += w.workerDeleted;
							low.notify();
							low.Dispatcher -= w.workerDeleted;
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
						if (low.count() == 0)
						{
							Console.WriteLine("\n Ничего не найдено.");
							Console.ReadKey();
							continue;
						}
						low.showWorkers();
						Console.ReadKey();
						break;
					case "4":
						Console.Clear();
						if (low.count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Вывод невозможен.");
							Console.ReadKey();
							continue;
						}
						Console.WriteLine("\n Список работников : ");
						low.showWorkers();
						String temp1;
						Console.Write("\n Введите подстроку : ");
						temp1 = Console.ReadLine();
						Console.WriteLine("\n Результаты поиска фамилий по подстроке " + temp1 + " : ");
						low.searchBySurname(temp1);
						Console.ReadKey();
						break;
					case "5":
						Console.Clear();
						if (low.count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Сортировка невозможна.");
							Console.ReadKey();
							continue;
						}
						sort = true;
						low.sort();
						Console.WriteLine("\n Отсортированный список работников по возрасту : ");
						low.showWorkers();
						Console.ReadKey();
						break;
					case "6":
						Console.Clear();
						if (low.count() == 0)
						{
							Console.WriteLine("\n Не найдено работников. Сортировка невозможна.");
							Console.ReadKey();
							continue;
						}
						sort = false;
						low.sort();
						Console.WriteLine("\n Отсортированный список работников по фамилии : ");
						low.showWorkers();
						Console.ReadKey();
						break;
					case "7":
						Console.Clear();
						ListOfWorkers.showLogs.showLogs();
						Console.ReadKey();
						break;
					case "8":
						Environment.Exit(0);
						break;
					default:
						Console.WriteLine("\n Введено неверное значение.");
						Console.ReadKey();
						break;
				}
			}
		}
	}
	class ListOfWorkers
	{
		public delegate void dispatcher();
		static private List<Worker> listOfWorkers = new List<Worker>();
		public event dispatcher Dispatcher;
		static public Logs logs = new Logs(Program.file);
		static public ShowLogs showLogs = new ShowLogs(Program.file);
		public void notify()
		{
			Dispatcher();
		}
		public void addWorker(Worker w)
		{
			listOfWorkers.Add(w);
		}
		public void removeAt(int n)
		{
			listOfWorkers.RemoveAt(n);
		}
		public int count()
		{
			return listOfWorkers.Count();
		}
		public void showWorkers()
		{
			int q = 0;
			foreach (Worker w in listOfWorkers)
				Console.WriteLine(w + ", index : " + q++);
		}
		public void searchBySurname(String temp)
		{
			foreach (Worker w in listOfWorkers)
				if (w.Surname.Contains(temp))
					Console.WriteLine(w);
		}
		public Worker getWorkerByIndex(int index)
		{
			return listOfWorkers[index];
		}
		public void sort()
		{
			listOfWorkers.Sort();
		}
	}
	class Logs
	{
		String path;
		public Logs(String file)
		{
			path = Directory.GetCurrentDirectory() + @"/" + file;
		}
		public void addLog(Worker w, String change)
		{
			StreamWriter sw = File.AppendText(path);
			sw.WriteLine("{0} ({1})", w, change);
			sw.Close();
		}
	}
	class ShowLogs
	{
		String path;
		public ShowLogs(String file)
		{
			path = Directory.GetCurrentDirectory() + @"/" + file;
		}
		public void showLogs()
		{
			String[] lines = File.ReadAllLines(path);
			foreach(String s in lines)
			{
				Console.WriteLine(s);
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
		public void workerAdded()
		{
			ListOfWorkers.logs.addLog(this, "added");
		}
		public void workerDeleted()
		{
			ListOfWorkers.logs.addLog(this, "deleted");
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
				if (Program.sort)
					return (int)this.Age - m.Age;
				else if (!Program.sort)
					return (int)String.Compare(this.Surname, m.Surname);
			}
			return -1;
		}
	}
}