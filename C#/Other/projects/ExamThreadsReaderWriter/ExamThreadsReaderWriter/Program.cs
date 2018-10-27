using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExamThreadsReaderWriter
{
	class Program
	{
		static public Basket basket = new Basket();
		static public EventWaitHandle ewh = new EventWaitHandle(true, EventResetMode.ManualReset);
		static void Main(string[] args)
		{
			Semaphore S = new Semaphore(3, 3);
			Writer writer1 = new Writer(S, 1);
			Writer writer2 = new Writer(S, 2);

			Reader reader1 = new Reader(S, 1);
			Reader reader2 = new Reader(S, 2);
			Reader reader3 = new Reader(S, 3);

			Random R = new Random();
			for (int i = 0; i < 50; i++)
				basket.addBall(new Ball(R.Next(0, 9)));

			Thread t1 = new Thread(writer1.run);
			t1.IsBackground = true;
			t1.Start();

			Thread t2 = new Thread(writer2.run);
			t2.IsBackground = true;
			t2.Start();

			Thread t3 = new Thread(reader1.run);
			t3.IsBackground = true;
			t3.Start();

			Thread t4 = new Thread(reader2.run);
			t4.IsBackground = true;
			t4.Start();

			Thread t5 = new Thread(reader3.run);
			t5.IsBackground = true;
			t5.Start();

			Console.ReadKey(false);
		}
	}

	class Ball
	{
		private int ColorId;
		public int colorId
		{
			get
			{
				return this.ColorId;
			}
			set
			{
				if (value >= 0 && value < 9)
					this.ColorId = value;
			}
		}
		public Ball(int colorId)
		{
			if (colorId >= 0 && colorId < 9)
				this.colorId = colorId;
		}
	}

	class Basket
	{
		public List<Ball> basket = new List<Ball>(100);
		public Basket() { }

		public int getBallsCount()
		{
			return this.basket.Count;
		}
		public List<Ball> getBalls()
		{
			return this.basket;
		}

		public void addBall(Ball ball)
		{
			if (this.getBallsCount() < 100)
				basket.Add(ball);
		}

		public void removeBall(Ball ball)
		{
			basket.Remove(ball);
		}
	}

	class Writer
	{
		private Semaphore S;
		private int num;
		private String[] arr = new String[9] { "красного", "зеленого", "голубого", "белого", "черного", "желтого", "фиолетового", "оранжевого", "синего" };
		private String[] arr1 = new String[9] { "красный", "зеленый", "голубой", "белый", "черный", "желтый", "фиолетовый", "оранжевый", "синий" };

		public Writer(Semaphore S, int n)
		{
			this.S = S;
			if (n > 0)
				this.num = n;
		}
		public void run()
		{
			Random R = new Random();
			while (true)
			{
				lock (Program.basket)
				{
					Program.ewh.Reset();
					this.S.WaitOne();
					this.S.WaitOne();
					this.S.WaitOne();
					Program.ewh.Set();
					Console.WriteLine("\nПисатель #{0} начал свою работу", this.num);
					List<Ball> list = Program.basket.getBalls();
					for (int i = 0; i < Program.basket.getBallsCount(); i++)
					{
						int q = R.Next(0, 11);
						if (q >= 0 && q <= 4)
						{
							int temp = R.Next(0, 9);
							Thread.Sleep(200);
							Console.WriteLine("Писатель #{0} : у шара #{1} изменен цвет с {2} на {3} цвет", this.num, (i + 1), arr[list[i].colorId], arr1[temp]);
							list[i].colorId = temp;
						}
					}

					int qq = R.Next(0, (Program.basket.getBallsCount() / 10));
					while (qq != 0)
					{
						Ball b = Program.basket.getBalls()[R.Next(0, (Program.basket.getBallsCount()) - 1)];
						Program.basket.removeBall(b);
						Thread.Sleep(50);
						Console.WriteLine("Писатель #{0} : удален шар {1} цвета", this.num, this.arr[b.colorId]);
						qq--;
					}

					for (int i = 0; i < R.Next(0, (100 - Program.basket.getBallsCount())); i++)
					{
						Ball b = new Ball(R.Next(0, 9));
						Program.basket.addBall(b);
						Thread.Sleep(200);
						Console.WriteLine("Писатель #{0} : добавлен шар {1} цвета", this.num, this.arr[b.colorId]);
					}

					Console.WriteLine("Писатель #{0} завершил свою работу\n", this.num);
					this.S.Release();
					this.S.Release();
					this.S.Release();
					Thread.Sleep(10);
				}
			}
		}
	}
	class Reader
	{
		private Semaphore S;
		private int num;
		private String[] arr = new String[9] { "красный", "зеленый", "голубой", "белый", "черный", "желтый", "фиолетовый", "оранжевый", "синий" };
		public Reader(Semaphore S, int n)
		{
			this.S = S;
			if (n > 0)
				this.num = n;
		}
		public void run()
		{
			while (true)
			{
				Program.ewh.WaitOne();
				this.S.WaitOne();
				Console.WriteLine("Читатель #{0} начал работу", this.num);
				int q = 1;
				foreach (Ball b in Program.basket.getBalls())
				{
					Thread.Sleep(100);
					Console.WriteLine("Читатель #{0} : Шар #{1} имеет {2} цвет", this.num, q++, this.arr[b.colorId]);
				}
				Console.WriteLine("Читатель #{0} завершил работу.", this.num);
				this.S.Release();
				Thread.Sleep(10);
			}
		}
	}
}
