using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace hw15
{
	class Program
	{
		static void Main(String[] args)
		{
			Console.Write(" Введите путь и слово : ");
			String file = "log.dat";
			String path = Directory.GetCurrentDirectory() + @"\" + file;

			StreamWriter sw = File.AppendText(path);
			searchWord(Console.ReadLine(), Console.ReadLine(), sw);
			sw.Close();
		}
		static void searchWord(String path, String word, StreamWriter sw)
		{
			String[] directory;
			String[] files;
			try
			{
				directory = Directory.GetDirectories(path);
				files = Directory.GetFiles(path);
			}
			catch
			{
				Console.WriteLine("Ошибка прав.");
				return;
			}
			foreach(String s in directory)
			{
				searchWord(s, word, sw);
			}
			foreach(String s in files)
			{
				String[] lines;
				lines = File.ReadAllLines(s);
				foreach(String sa in lines)
				{
					if(sa.ToLower().Contains(word.ToLower()))
					{
						Console.WriteLine(s);
						sw.WriteLine(s);
						break;
					}
				}
			}
		}
	}
}