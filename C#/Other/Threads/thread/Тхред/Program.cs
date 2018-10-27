using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Тхред
{
	class Program
	{
		static void Main(string[] args)
		{
			//#1
			//thrOne TO = new thrOne();
			//Thread T = new Thread(TO.run);
			//T.Start();

			//while (true)
			//{
			//	Console.ReadKey(true);
			//	Console.WriteLine("Тхред стопед");
			//	TO.suspendWork();

			//	Console.ReadKey(true);
			//	Console.WriteLine("Тхред континьюд зе ворк");
			//	TO.resumeWork();
			//}
			//#2
			//ThrTwo TT1 = new ThrTwo("Hello World!", 10, 1000);
			//ThrTwo TT2 = new ThrTwo("Android forever!", 20, 759);

			//Thread T1 = new Thread(TT1.run);
			//Thread T2 = new Thread(TT2.run);

			//T1.Start();
			//T2.Start();
			//#3
			MyArray MA = new MyArray();
			ThrThree TH1 = new ThrThree(1, 500, MA);
			ThrThree TH2 = new ThrThree(2, 500, MA);

			Thread T1 = new Thread(TH1.run);
			Thread T2 = new Thread(TH2.run);

			T1.Start();
			T2.Start();

			T1.Join();
			T2.Join();

			MA.showArray();
		}
	}
	class thrOne
	{
		private bool isPause = false;
		public void run()
		{
			while (true)
			{
				Console.WriteLine("1. Пекарь месит тесто");
				Thread.Sleep(1000);
				this.checkPause();

				Console.WriteLine("2. Пекарь открывает дверь духовки");
				Thread.Sleep(1000);
				this.checkPause();

				Console.WriteLine("3. Пекарь впустил газку");
				Thread.Sleep(1000);

				Console.WriteLine("4. Пекарь зажигает газ");
				Thread.Sleep(1000);
				this.checkPause();

				Console.WriteLine("5. Пекарь ставит тесто в духовку");
				Thread.Sleep(1000);

				Console.WriteLine("6. Пекарь закрывает дверь духовки");
				Thread.Sleep(1000);
				this.checkPause();

			}
		}
		public void suspendWork()
		{
			this.isPause = true;
		}
		public void resumeWork()
		{
			this.isPause = false;
		}
		private void checkPause()
		{
			while (this.isPause)
				Thread.Sleep(100);
		}
	}
	class ThrTwo
	{
		private String msg;
		private int cnt;
		private int delay;

		public ThrTwo(String msg, int cnt, int delay)
		{
			this.msg = msg;
			this.cnt = cnt;
			this.delay = delay;
		}

		public void run()
		{
			for (int i = 0; i < this.cnt; i++)
			{
				Console.WriteLine(this.msg);
				Thread.Sleep(this.delay);
			}
		}
	}
	class MyArray
	{
		private int[] A = new int[1000];
		private int index = 0;
		public void fillArray(int value, int cnt)
		{
			for (int i = 0; i < cnt; i++)
				this.A[this.index++] = value;
		}
		public void showArray()
		{
			for (int i = 0; i < this.A.Length; i++)
			{
				Console.WriteLine(this.A[i]);
				if (i % 49 == 0)
					Console.WriteLine();
			}
		}
	}
	class ThrThree
	{
		private int value;
		private int count;
		private MyArray MA;
		public ThrThree(int value, int count, MyArray MA)
		{
			this.value = value;
			this.count = count;
			this.MA = MA;
		}
		public void run()
		{
			lock (this.MA)
				this.MA.fillArray(this.value, this.count);
			
		}
	}
}