using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Les3
{
    class Program
    {
        static void Main(string[] args)
        {
			//MyPoint3D P1 = new MyPoint3D(3, 5, 7);
			//P1.X = 12;
			//P1.Y = 22;
			//P1.ShowPoint();
			//MyPoint P = new MyPoint3D(15, 57, 79);
			//P.ShowPoint();
			//P.test();
			//Object G = new Object();
			//if(G is MyPoint3D)
			//	((MyPoint3D)G).ShowPoint();
			//else
			//	Console.WriteLine("Приведение к типу Point3D невозможно.");
			//if (P is MyPoint3D)
			//	((MyPoint3D)P).ShowPoint();
			//else
			//	Console.WriteLine("Приведение к типу Point3D невозможно.");
			//MyPoint3D m1 = G as MyPoint3D;
			//if (m1 != null)
			//	((MyPoint3D)G).ShowPoint();
			//else
			//	Console.WriteLine("Приведение к типу невозможно");

		}
    }
    class MyPoint
    {
        protected int x;
        protected int y;
        public MyPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
            Console.WriteLine("MyPoint : constr");
        }
        public void setX(int x)
        {
			this.x = x;
        }
        public void setY(int y)
        {
            this.y = y;
        }
        public void ShowPoint()
        {
            Console.WriteLine("x = {0}, y = {1}", this.x, this.y);
        }
        public MyPoint()
        {
            Console.WriteLine("MyPoint : Default constr");
        }
        public int X
        {
            set
            {
                Console.WriteLine("setter for X");
                this.x = value;
            }
            get
            {
                Console.WriteLine("getter for X");
                return this.x;
            }
        }
        public int Y
        {
            set
            {
                Console.WriteLine("setter for Y");
                this.y = value;
            }
            get
            {
                Console.WriteLine("getter for Y");
                return this.y;
            }
        }
		public void test()
		{
			Console.WriteLine("Test method");
		}
		public virtual void greeting()
		{
			Console.WriteLine("Hello World!");
		}
    }
    class MyPoint3D : MyPoint
    {
        private int z;
        public void setZ(int z)
        {
            this.z = z;
        }
        public MyPoint3D(int x, int y, int z) : base(x,y)
        {
            this.z = z;
        }
        public new void ShowPoint()
        {
            Console.WriteLine("x = {0}, y = {1}, z = {2}", this.x, this.y, this.z);
        }
		public override void greeting()
		{
			Console.WriteLine("C# is good, but not the best");
		}
	}
}