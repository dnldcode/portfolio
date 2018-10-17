using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hw7
{
	class Program
	{
		static void Main(string[] args)
		{
			using (DynamicArray test = new DynamicArray())
				test.Dispose();
		}
	}
	class DynamicArray : IDisposable
	{
		int[] array = new int[0];

		public void addValue(int value)
		{
			int[] arrTemp = new int[array.Length + 1];
			for (int i = 0; i < array.Length; i++)
				arrTemp[i] = array[i];
			this.array = arrTemp;
			array[arrTemp.Length - 1] = value;
		}
		public void insertValue(int value, int index)
		{
			if(index < 0 || index > array.Length - 1)
			{
				Console.WriteLine("Вы вышли за границу доступных индексов");
				return;
			}
			int[] arrTemp = new int[array.Length + 1];
			for (int i = 0; i < array.Length; i++)
				arrTemp[i] = array[i];
			this.array = arrTemp;
			int temp;
			for (int i = array.Length - 1; i > index; i--)
			{
				temp = array[i - 1];
				array[i - 1] = array[i];
				array[i] = temp;
			}
			array[index] = value;
		}
		public void remove(int index)
		{
			if (index < 0 || index > array.Length - 1)
			{
				Console.WriteLine("Вы вышли за границу доступных индексов");
				return;
			}
			int temp;
			for (int i = index; i < array.Length - 1; i++)
			{
				temp = array[i + 1];
				array[i + 1] = array[i];
				array[i] = temp;
			}
			int[] arrTemp = new int[array.Length - 1];
			for (int i = 0; i < arrTemp.Length; i++)
				arrTemp[i] = array[i];
			this.array = arrTemp;
		}
		public int getSize()
		{
			return array.Length;
		}
		public int this[int index]
		{
			get
			{
				return this.array[index];
			}
		}
		public override string ToString()
		{
			for (int i = 0; i < array.Length; i++)
				Console.Write(array[i] + " ");
			return String.Format("\n");
		}
		public void Dispose()
		{
			Console.WriteLine("Dispose made");
			array = null;
		}
	}
}