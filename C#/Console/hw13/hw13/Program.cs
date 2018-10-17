using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace hw13
{
	class Program
	{
		static void Main(String[] args)
		{
			//Console.Write("Введите путь : ");
			//searchDirectory(Console.ReadLine());
			Console.Write("Введите путь и слово : ");
			searchFileByWord(Console.ReadLine(), Console.ReadLine());
		}
		static void searchDirectory(String path)
		{
			String[] directories;
			try
			{
				directories = Directory.GetDirectories(path);
			}
			catch (Exception e)
			{
				Console.WriteLine(" Ошибка : " + e.Message);
				return;
			}
			foreach(String s in directories)
			{
				Console.WriteLine(s);
				searchDirectory(s);
			}
		}
		static void searchFileByWord(String path, String word)
		{
			String[] directories;
			String[] files;
			try
			{
				directories = Directory.GetDirectories(path);
				files = Directory.GetFiles(path);
			}
			catch
			{
				Console.WriteLine("Ошибка в доступе.");
				return;
			}
			foreach (String s in directories)
			{
				searchFileByWord(s, word);
			}
			foreach (String s in files)
			{
				String[] split = s.Split('\\');
				if (split[split.Length - 1].ToLower().Contains(word.ToLower()))
					Console.WriteLine(s);
			}
		}
	}
}