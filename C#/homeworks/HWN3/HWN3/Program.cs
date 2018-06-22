using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HWN3
{
    public class Program
    {
        public static void Main()
        {
		}
    }
    public class Time
    {
        private int hh = 0;
        public int H
        {
            set
            {
                hh = value % 24;
            }
            get
            {
                return this.hh;
            }
        }
        private int mm = 0;
        public int M
        {
            set
            {
                H += (value / 60);
                mm = value % 60;
            }
            get
            {
                return this.mm;
            }
        }
        private int ss = 0;
        public int S
        {
            set
            {
                H += (value / 3600);
                M += (value % 3600 / 60);
                ss = value % 60;
            }
            get
            {
                return this.ss;
            }
        }
        public Time(int hh = 0, int mm = 0, int ss = 0)
        {
            if (hh < 0)
                hh *= -1;
			if (mm < 0)
				mm *= -1;
			if (ss < 0)
				ss *= -1;
			this.H = hh;
            this.M = mm;
            this.S = ss;
        }
        public Time(int ss = 0)
        {
            if (ss < 0)
                ss *= -1;
            this.S = ss;
        }
		public Time()
		{
			this.H = 0;
			this.M = 0;
			this.S = 0;
		}
		public void showTime()
		{
			Console.WriteLine("H - {0}, M - {1}, S - {2}", this.H, this.M, this.S);
		}
		public Time addTime(Time anTime)
        {
			return new Time((this.S + this.M * 60 + this.H * 3600) + (anTime.S + anTime.M * 60 + anTime.H * 3600));
		}
		public Time subTime(Time anTime)
		{
			return new Time(Math.Abs((this.S + this.M * 60 + this.H * 3600) - (anTime.S + anTime.M * 60 + anTime.H * 3600)));
		}
		public int compareTime(Time anTime)
		{
			int n1 = this.S + this.M * 60 + this.H * 3600, n2 = anTime.S + anTime.M * 60 + anTime.H * 3600;
			if (n1 == n2)
				return 0;
			if (n1 > n2)
				return 1;
			else
				return -1;
		}
	}
}