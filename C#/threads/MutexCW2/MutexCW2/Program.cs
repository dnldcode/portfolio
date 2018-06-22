using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexCW2
{
	class Program
	{
		static void Main(string[] args)
		{
			Mutex M = new Mutex(false, "BillGates");
			while (!Console.KeyAvailable)
			{
				M.WaitOne();
				for (int i = 0; i < 5; i++)
				{
					Console.WriteLine("Hello {0}", i);
					Thread.Sleep(1000);
				}
				M.ReleaseMutex();
				Thread.Sleep(10);
			}
		}
	}
}
