using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HWn4._2
{
	class Program
	{
		static void Main(string[] args)
		{
			Square[] figures = new Square[6];
			figures[0] = new Square(5);
			figures[1] = new Rhombus(3);
			figures[2] = new Rectangle(3, 5);
			figures[3] = new Parallelogram(12, 6);
			figures[4] = new Triangle(15, 20);
			figures[5] = new Trapeze(10, 18);
			for (int i = 0; i < figures.Length; i++)
				figures[i].show();
		}
	}
	class Square
	{
		protected double side1;
		public double Side1
		{
			set
			{
				if (side1 < 0)
					side1 *= -1;
				side1 = value;
			}
			get
			{
				return side1;
			}
		}
		public Square(double side1 = 1)
		{
			Side1 = side1;
		}
		virtual public void show()
		{
			for (int i = 0; i < (int)side1 * 2; i++)
			{
				for (int j = 0; j < (int)side1 * 2; j++)
				{
					if (i == 0 || j == 0 || i == (int)side1 * 2 - 1 || j == (int)side1 * 2 - 1)
						Console.Write(" *");
					else
						Console.Write("  ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
	class Rhombus : Square
	{
		public Rhombus(double side1) : base(side1)
		{
		}
		public override void show()
		{
			int m = (int)side1 * 2, n = m * 2 + 1;
			for (int i = 0; i < m; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (j == m + i || j == m - i)
						Console.Write("*");
					else
						Console.Write(" ");
				}
				Console.WriteLine();
			}
			for (int i = m; i < n; i++)
			{
				for (int j = 0; j < n; j++)
				{
					if (j == m + n - i - 1 || j == i - m)
						Console.Write("*");
					else
						Console.Write(" ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}

	class Rectangle : Rhombus
	{
		protected double side2;
		public double Side2
		{
			set
			{
				if (side2 < 0)
					side2 *= -1;
				side2 = value;
				if (side1 == side2)
					side2++;
			}
			get
			{
				return side2;
			}
		}
		public Rectangle(double side1, double side2) : base(side1)
		{
			Side2 = side2;
		}
		public override void show()
		{
			for (int i = 0; i < (int)side1 * 2; i++)
			{
				for (int j = 0; j < (int)side2 * 2; j++)
				{
					if (i == 0 || j == 0 || i == (int)side1 * 2 - 1 || j == (int)side2 * 2 - 1)
						Console.Write(" *");
					else
						Console.Write("  ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
	class Parallelogram : Rectangle
	{
		public Parallelogram(double side1, double side2) : base(side1, side2) { }
		public override void show()
		{
			for (int i = 0; i < side2; i++)
			{
				for (int j = 0; j < side1 + side2; j++)
				{
					if (j >= side2 - i && j < side1 + side2 - i)
						Console.Write("* ");
					else
						Console.Write("  ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}

	class Triangle : Parallelogram
	{
		protected double side3;
		public double Side3
		{
			set
			{
				if (side3 < 0)
					side3 *= -1;
				side3 = value;
			}
			get
			{
				return side3;
			}
		}
		public Triangle(double side1, double side2, double side3 = 0) : base(side1, side2)
		{
			Side3 = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2));
		}
		public override void show()
		{
			for (int i = 0; i < side1/2; i++)
			{
				for (int j = 0; j < side2 + 1; j++)
				{
					if (j < side2/2- i || j > side2/2 + i - 2 || j < i - side1)
						Console.Write("  ");
					else
						Console.Write("* ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
	class Trapeze : Triangle
	{
		public Trapeze(double side1, double side2, double side3 = 0) : base(side1, side2, side3) { }
		public override void show()
		{
			for (int i = 0; i < (side2 - side1) / 2 + 1; i++)
			{
				for (int j = 0; j < side2; j++)
				{
					if (j >= (side2 - side1) / 2 - i && j < (side2 - side1) / 2 + side1 + i)
						Console.Write("* ");
					else
						Console.Write("  ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();
		}
	}
}