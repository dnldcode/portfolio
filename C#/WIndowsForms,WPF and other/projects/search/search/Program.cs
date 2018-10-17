using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace search
{
	class Program
	{
		static Thread T;
		static String word;
		static void Main(string[] args)
		{
			while (true)
			{
				Console.WriteLine("Введите путь к файлу : ");
				String search = Console.ReadLine();
				Console.WriteLine("Введите имя : ");
				word = Console.ReadLine();
				Search s = new Search(word);
				T = new Thread(s.search);
				T.IsBackground = true;
				T.Start(search);
			}
		}
	}
	class Search
	{
		List<String> fileList = new List<String>();
		String word;
		public Search(string word)
		{
			this.word = word;
		}
		public void search(Object path)
		{
			fileList.Clear();
			Console.WriteLine("Поиск начат.");
			searchFunc(path);
			Console.WriteLine("\nСписок найденных файлов : \n");
			foreach(String s in fileList)
				Console.WriteLine(s);
		}
		private void searchFunc(Object path)
		{
			string[] folders;
			string[] files;
			try
			{
				folders = Directory.GetDirectories(path.ToString());
				files = Directory.GetFiles(path.ToString());

				foreach (String s in folders)
					searchFunc(s);
				foreach (String s in files)
				{
					if (Path.GetFileName(s).ToLower().Contains(word.ToLower()))
						fileList.Add(s);
				}
			}
			catch { }
		}
	}
}