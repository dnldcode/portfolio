using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw5
{
	class Program
	{
		static void Main(string[] args)
		{
			Document doc = new Document("Book", -13);
			LaserPrinter l1 = new LaserPrinter();
			MatrixPrinter mp = new MatrixPrinter();
			CopyCenter cc = new CopyCenter(mp);
			cc.CenterPrint(doc);
		}
	}
	class Document
	{
		protected String header;
		public String Header
		{
			get
			{
				return this.header;
			}
			set
			{
				header = value;
			}
		}
		protected int numOfPages;
		public int NumOfPages
		{
			get
			{
				return numOfPages;
			}
			set
			{
				if (value < 0)
					value *= -1;
				numOfPages = value;
			}
		}
		public Document(String header = "Noname", int num = 0)
		{
			Header = header;
			NumOfPages = num;
		}
	}
	class CopyCenter
	{
		Printer p;
		public CopyCenter(Printer p1)
		{
			p = p1;
		}
		public void CenterPrint(Document doc)
		{
			p.Print(doc);
			Console.WriteLine(" с помощью " + p.GetType());		
		}
	}
	abstract class Printer
	{
		public virtual void Print(Document doc)
		{
			Console.Write("Файл '{0}' с {1}ью страницами распечатан", doc.Header, doc.NumOfPages);
		}
	}
	class MatrixPrinter : Printer { }
	class JetPrinter : Printer { }
	class LaserPrinter : Printer { }
	class ColorPrinter : Printer { }
}