using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace les18
{
	//public delegate int calc(int a, int b);
	class Program
	{
		//static int sum(int a, int b)
		//{
		//	for (int i = 0; i < 10; i++)
		//	{
		//		Console.WriteLine(" Calculating...");
		//		Thread.Sleep(750);
		//	}
		//	return a + b;
		//}
		//static void getResult(IAsyncResult A)
		//{
		//	Console.WriteLine(" Можно забирать результат");
		//	calc C = (calc)A.AsyncState;
		//	int res = C.EndInvoke(A);
		//	Console.WriteLine("res =" + res);
		//}
		static void Main(string[] args)
		{
			//#1
			//	calc C = sum;
			//	IAsyncResult A = C.BeginInvoke(7, 8, null, null);
			//	while(A.IsCompleted == false)
			//	{
			//		Console.WriteLine(" Ожидание завершения работы метода sum");
			//		Thread.Sleep(1000);
			//	}
			//	int res = C.EndInvoke(A);
			//	Console.WriteLine("res = " + res);

			//#2
			//calc C = sum;
			//IAsyncResult A = C.BeginInvoke(7, 8, null, null);
			//A.AsyncWaitHandle.WaitOne();
			//Console.WriteLine(" Ready");
			//	int res = C.EndInvoke(A);
			//Console.WriteLine(" res = " + res);

			//#3
			//calc C = sum;
			//IAsyncResult A = C.BeginInvoke(7, 8, Program.getResult, C);
			//while(Console.KeyAvailable == false)
			//{
			//	Console.WriteLine(" Первичный поток работает");
			//	Thread.Sleep(500);
			//}

			//#4
			//Rectangle R1 = new Rectangle(2,2,7,5);
			//R1.show();
			//Console.ReadKey();
			//for(int i = 0; i < 10;i++)
			//{
			//	R1.move(1, 1);
			//	Thread.Sleep(500);
			//}

			//#5
			//Rectangle R1 = new Rectangle(2, 2, 10, 3);
			//R1.show();
			//Rectangle R2 = new Rectangle(15,7,4,3);
			//R2.show();
			//Rectangle R3 = new Rectangle(40, 15, 10, 7);
			//R3.show();

			//Mover mover = new Mover();
			//mover.MM = R1.move;
			//mover.MM += R2.move;
			//mover.MM += R3.move;
			//mover.MM += Program.moveWindow;
			//mover.run();
			Console.WriteLine("textColor : " + ConfigurationManager.AppSettings["textColor"]);
			Console.WriteLine("backGroundColor : " + ConfigurationManager.AppSettings["backgroundColor"]);
			Console.ReadKey();
		}
		static void moveWindow(int deltaX, int deltaY)
		{
			Console.WindowWidth += deltaX;
			Console.WindowHeight += deltaY;
		}
	}
	class Rectangle
	{
		private int x, y, width, height;
		public Rectangle(int x,int y,int width,int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}
		private void hide()
		{
			for (int i = 0; i < this.height; i++)
			{
				Console.CursorLeft = this.x;
				Console.CursorTop = this.y + i;
				for (int j = 0; j < this.width; j++)
				{
					Console.Write(" ");
				}
			}
		}
		public void show()
		{
			for (int i = 0; i < this.height; i++)
			{
				Console.CursorLeft = this.x;
				Console.CursorTop = this.y + i;
				for (int j = 0; j < this.width; j++)
				{
					Console.Write("*");
				}
			}
		}
		public void move(int deltaX, int deltaY)
		{
			int newX = this.x + deltaX;
			int newY = this.y + deltaY;
			if(newX >= 0 && newX + this.width <= 80 && newY >=0 && newY +this.height < 80)
			{
				this.hide();
				this.x = newX;
				this.y = newY;
				this.show();
			}
		}
	}
	public delegate void makeMove(int dX, int dY);
	public class Mover
	{
		public makeMove MM;
		public void run()
		{
			bool isRun = true;
			while (isRun)
			{
				ConsoleKeyInfo CKI = Console.ReadKey();
				switch (CKI.Key)
				{
					case ConsoleKey.Escape:
						isRun = false;
						break;
					case ConsoleKey.UpArrow:
						this.MM(0, -1);
						break;
					case ConsoleKey.DownArrow:
						this.MM(0, 1);
						break;
					case ConsoleKey.LeftArrow:
						this.MM(-1, 0);
						break;
					case ConsoleKey.RightArrow:
						this.MM(1, 0);
						break;
				}
			}
		}
	}
}