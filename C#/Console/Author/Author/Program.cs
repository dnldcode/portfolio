using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Author
{
	class Program
	{
		static void Main(string[] args)
		{
			Library library = new Library();
			String n;
			library.Random();
			while (true)
			{
				Console.Clear();
				Console.WriteLine("\n 1. Добавить автора");
				Console.WriteLine(" 2. Удалить автора");
				Console.WriteLine(" 3. Добавить книгу(к автору)");
				Console.WriteLine(" 4. Удалить книгу");
				Console.WriteLine(" 5. Вывести полную информацию по библиотеке");
				Console.WriteLine(" 6. Вывести книги конкретного автора.");
				Console.WriteLine(" 7. Вывести книги конкретной тематики.");
				Console.WriteLine(" 8. Выход");
				Console.Write("\n Ответ : ");
				n = Console.ReadLine();
				switch (n)
				{
					case "1":
						Console.Clear();
						Author tempAuthor = new Author();
						Console.WriteLine(" Добавление автора");

						Console.Write("\n Введите фамилию автора : ");
						tempAuthor.Surname = Console.ReadLine();
						Console.Write("\n Введите имя автора : ");
						tempAuthor.Name = Console.ReadLine();
						while (true)
						{
							try
							{
								Console.Write("\n Введите год рождения автора : ");
								tempAuthor.DateOfBirth = Int32.Parse(Console.ReadLine());
							}
							catch (FormatException fe)
							{
								Console.WriteLine(" Ошибка : " + fe.Message);
								continue;
							}
							break;
						}
						library.AddAuthor(tempAuthor);
						Console.WriteLine("\n Автор успешно добавлен");
						Console.ReadKey();
						break;
					case "2":
						Console.Clear();
						if (library.getLength() == 0)
						{
							Console.WriteLine("\n Библиотека пуста, использование невозможно.");
							Console.ReadKey();
							break;
						}
						Console.WriteLine(" Удаление автора");
						library.Show();
						int count;
						while (true)
						{
							try
							{
								Console.Write("\n Введите индекс автора для удаления : ");
								count = Int32.Parse(Console.ReadLine());
							}
							catch (FormatException fe)
							{
								Console.WriteLine("\n Ошибка : " + fe.Message);
								continue;
							}
							break;
						}
						if (count >= 0 && count < library.getLength())
						{
							library.DeleteAuthor(count);
							Console.WriteLine(" Автор успешно удален по индексу " + count);
						}
						else
							Console.WriteLine("\n Введенного индекса не существует.");

						Console.ReadKey();
						break;
					case "3":
						Console.Clear();
						if (library.getLength() == 0)
						{
							Console.WriteLine("\n Библиотека пуста, использование невозможно.");
							Console.ReadKey();
							break;
						}
						Book tempBook = new Book();
						Console.WriteLine(" Добавление книги к автору");
						library.Show();
						Console.Write("\n Введите название книги : ");
						tempBook.Name = Console.ReadLine();
						Console.Write("\n Введите тематику книги : ");
						tempBook.Subject = Console.ReadLine();
						while (true)
						{
							try
							{
								Console.Write("\n Введите год выпуска книги : ");
								tempBook.YearOfIssue = Int32.Parse(Console.ReadLine());
							}
							catch (FormatException fe)
							{
								Console.WriteLine("\n Ошибка : " + fe.Message);
								continue;
							}
							break;
						}
						Console.Write("\n Введите издание книги : ");
						tempBook.Edition = Console.ReadLine();
						int tempIn;
						while (true)
						{
							try
							{
								Console.Write("\n Введите индекс автора : ");
								tempIn = Int32.Parse(Console.ReadLine());
							}
							catch (FormatException fe)
							{
								Console.WriteLine("\n Ошибка : " + fe.Message);
								continue;
							}
							if (!(tempIn >= 0 && tempIn < library.getLength()))
							{
								Console.WriteLine(" Введенного индекса не существует.");
								continue;
							}
							break;
						}
						library.AddBook(tempIn, tempBook);
						Console.WriteLine("\n Книга успешно добавлена к автору с индексом " + tempIn);
						Console.ReadKey();
						break;
					case "4":
						Console.Clear();
						if (library.getLength() == 0)
						{
							Console.WriteLine("\n Библиотека пуста, использование невозможно.");
							Console.ReadKey();
							break;
						}
						Console.WriteLine(" Удаление книги");
						library.Show();
						int inAuthTemp, inBookTemp;
						while (true)
						{
							try
							{
								Console.Write("\n Введите индекс автора : ");
								inAuthTemp = Int32.Parse(Console.ReadLine());
							}
							catch (FormatException fe)
							{
								Console.Write("\n Ошибка : " + fe.Message);
								continue;
							}
							if (!(inAuthTemp >= 0 && inAuthTemp < library.getLength()))
							{
								Console.WriteLine(" Введенного индекса не существует.");
								continue;
							}
							break;
						}

						while (true)
						{
							try
							{
								Console.Write("\n Введите индекс книги : ");
								inBookTemp = Int32.Parse(Console.ReadLine());
							}
							catch (FormatException fe)
							{
								Console.WriteLine("\n Ошибка : " + fe.Message);
								continue;
							}
							if (!(inBookTemp >= 0 && inBookTemp < library.getBooksLength(inAuthTemp)))
							{
								Console.WriteLine(" Введенного индекса не существует.");
								continue;
							}
							break;
						}
						library.DeleteBook(inAuthTemp, inBookTemp);
						Console.WriteLine("\n Книга с индеком {0} успешно удалена у автора с индексом {1}", inBookTemp, inAuthTemp);
						Console.ReadKey();
						break;
					case "5":
						Console.Clear();
						if (library.getLength() == 0)
						{
							Console.WriteLine("\n Библиотека пуста, использование невозможно.");
							Console.ReadKey();
							break;
						}
						library.Show();
						Console.ReadKey();
						break;
					case "6":
						Console.Clear();
						if (library.getLength() == 0)
						{
							Console.WriteLine("\n Библиотека пуста, использование невозможно.");
							Console.ReadKey();
							break;
						}
						Console.Write("\n Введите автора : ");
						library.SearchAuthor(Console.ReadLine());

						Console.ReadKey();
						break;
					case "7":
						Console.Clear();
						if (library.getLength() == 0)
						{
							Console.WriteLine("\n Библиотека пуста, использование невозможно.");
							Console.ReadKey();
							break;
						}
						Console.Write("\n Введите тематику : ");
						library.SearchSubject(Console.ReadLine());

						Console.ReadKey();
						break;
					case "8":
						Environment.Exit(0);
						break;
				}
			}
		}
	}

	class Author
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
		private int dateOfBirth;
		public int DateOfBirth
		{
			get
			{
				return this.dateOfBirth;
			}
			set
			{
				if (value < 0)
					value *= -1;
				this.dateOfBirth = value;
			}
		}
		public Author(String surname = "Unknown", String name = "Unknown", int dateOfBirth = 0)
		{
			this.Surname = surname;
			this.Name = name;
			this.DateOfBirth = dateOfBirth;
		}
		public override string ToString()
		{
			return String.Format(" Фамилия - {0}, имя - {1}, дата рождения - {2}г. ", this.surname, this.name, this.dateOfBirth);
		}
	}
	class Book
	{
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
		private String subject;//Тематика
		public String Subject
		{
			get
			{
				return this.subject;
			}
			set
			{
				this.subject = value;
			}
		}
		private int yearOfIssue;
		public int YearOfIssue
		{
			get
			{
				return this.yearOfIssue;
			}
			set
			{
				this.yearOfIssue = value;
			}
		}
		private String edition;//Издание
		public String Edition
		{
			get
			{
				return this.edition;
			}
			set
			{
				this.edition = value;
			}
		}
		public Book(String name = "Unknown", String subject = "Unknown", int yearOfIssue = 0, String edition = "Unknown")
		{
			this.Name = name;
			this.Subject = subject;
			this.YearOfIssue = yearOfIssue;
			this.Edition = edition;
		}
		public override string ToString()
		{
			return String.Format(" Имя - {0}, тематика - {1}, год выпуска - {2}, издание {3}", this.name, this.subject, this.yearOfIssue, this.edition);
		}
	}
	class Library
	{
		private Dictionary<Author, List<Book>> library = new Dictionary<Author, List<Book>>();

		public void Add(Author a, List<Book> b)
		{
			try
			{
				this.library.Add(a, b);
			}
			catch (ArgumentException ae)
			{
				Console.WriteLine(" Ошибка : " + ae.Message);
				Console.ReadKey();
			}
		}
		public void AddAuthor(Author a)
		{
			this.library.Add(a, new List<Book>());
		}
		public void DeleteAuthor(int index)
		{
			ICollection<Author> Authors = this.library.Keys;
			int q = 0;
			foreach (Author a in Authors)
			{
				if (q++ == index)
				{
					this.library.Remove(a);
					break;
				}
			}
		}
		public long getLength()
		{
			return library.LongCount();
		}
		public long getBooksLength(int index)
		{
			int count = 0;
			ICollection<Author> Authors = this.library.Keys;
			ICollection<Book> Books;
			int q = 0;
			foreach (Author a in Authors)
			{
				if (q++ == index)
				{
					Books = this.library[a];
					foreach (Book b in Books)
					{
						count++;
					}
					break;
				}
			}
			Console.WriteLine(count);
			return count;
		}
		public void AddBook(int index, Book b)
		{
			ICollection<Author> Authors = this.library.Keys;
			int q = 0;
			foreach (Author a in Authors)
			{
				if (q++ == index)
				{
					this.library[a].Add(b);
					break;
				}
			}
		}
		public void DeleteBook(int index, int bIndex)
		{
			ICollection<Author> Authors = this.library.Keys;
			ICollection<Book> Books;
			int q = 0;
			foreach (Author a in Authors)
			{
				if (q++ == index)
				{
					Books = this.library[a];
					int z = 0;
					foreach (Book b in Books)
					{
						if (z++ == bIndex)
						{
							Books.Remove(b);
							break;
						}
					}
				}
			}
		}
		public void Show()
		{
			ICollection<Author> Authors = this.library.Keys;
			int q = 0, z;
			foreach (Author a in Authors)
			{
				Console.WriteLine("\n {0}. {1}, книги автора :", q++, a);
				ICollection<Book> Books = this.library[a];
				if (Books.Count == 0)
				{
					Console.WriteLine("\tКниги у данного автора не найдены.");
					continue;
				}
				z = 0;
				foreach (Book b in Books)
				{
					Console.WriteLine("\t{0}. {1}", z++, b);
				}
			}
		}
		public void SearchAuthor(String temp)
		{
			ICollection<Author> Authors = this.library.Keys;
			ICollection<Book> Books;
			int q = 0;
			foreach (Author a in Authors)
			{
				if (a.Surname.Contains(temp) == true || a.Name.Contains(temp) == true)
				{
					q++;
					Books = this.library[a];
					Console.WriteLine("\n Книги автора {0} {1} : ", a.Surname, a.Name);
					foreach (Book b in Books)
					{
						Console.WriteLine("\t{0}", b);
					}
				}
			}
			if (q == 0)
				Console.WriteLine("\n Автор не найден!");
		}
		public void SearchSubject(String temp1)
		{
			ICollection<Author> Authors = this.library.Keys;
			ICollection<Book> Books;
			int q = 0;
			bool z = false;
			foreach (Author a in Authors)
			{
				Console.WriteLine("\n Книги автора {0} {1} : ", a.Surname, a.Name);
				Books = this.library[a];
				z = false;
				foreach (Book b in Books)
				{
					if (b.Subject.Contains(temp1) == true)
					{
						Console.WriteLine("\t{0}", b);
						q++;
						z = true;
					}
				}
				if (z == false)
					Console.WriteLine("\tНет книг введенного жанра.");

			}
		}
		public void Random()
		{
			String[] surname = new String[10] { "Hensley", "Conley", "King", "Kelly", "Dorsey", "Bell", "Hamilton", "Young", "Sullivan", "Lynch" };
			String[] name = new String[10] { "Hector", "Conley", "Beverly", "Daniel", "Dorsey", "Edward", "Buck", "Franklin", "Steven", "Michael" };
			String[] books = new String[25] {"Война и мир", "Дети полуночи", "Великий Гэтсби", "Унесенные ветром", "Над пропастью во ржи"
												, "Сын Америки", "	Миссис Дэллоуэй", "Дивный новый мир", "Сто лет одиночества", "Распад"
												, "Грозди гнева", "Возлюбленная", "Уловка-22", "Миддлмарч", "Путешествия Гулливера"
												, "Кентерберийские рассказы", "Божественная комедия", "Гордость и предубеждение", "Иллиада и Одиссея"
												, "К маяку", "Невидимка", "Шум и ярость", "Лолита", "Улисс", "1984"};
			String[] ganre = new String[5] { "Роман", "Эпос", "Повесть", "Трагедия", "Комедия" };
			Random R = new Random();
			for (int i = 0; i < 5; i++)
			{
				AddAuthor(new Author(surname[R.Next(0, 10)], name[R.Next(0, 10)], R.Next(1000, 2001)));
				for (int j = 0; j < R.Next(1,4); j++)
				{
					AddBook(i, new Book(books[R.Next(0,25)], ganre[R.Next(0,5)], R.Next(1000,2001), "Unknown"));
				}
			}
		}
	}
}