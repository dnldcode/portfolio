using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace hw13
{
	class Program
	{
		public delegate void Search(String path, String word);
		static public List<String> results = new List<String>();
		static void Main(String[] args)
		{
			String file = "log.dat";
			String path = Directory.GetCurrentDirectory() + @"\" + file; 
			Console.Write("Введите путь и слово : ");
			Search S = searchFileByWord;
			IAsyncResult A = S.BeginInvoke(Console.ReadLine(), Console.ReadLine(), null, null);
			S.EndInvoke(A);
			StreamWriter sw = File.AppendText(path);
			foreach(String s in results)
				sw.WriteLine(s);
			sw.Close();
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
			catch (Exception e)
			{
				Console.WriteLine(" Ошибка : " + e.Message);
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
				{
					Console.WriteLine(s);
					results.Add(s);
				}
			}
		}
	}
}