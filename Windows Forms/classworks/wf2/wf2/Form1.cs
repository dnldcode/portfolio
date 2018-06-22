using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace wf2
{
	public partial class Form1 : Form
	{
		Panel P;
		int x1, y1, x2, y2;
		public Form1()
		{
			InitializeComponent();
			this.MouseDown += Form1_MouseDown;
			this.MouseUp += Form1_MouseUp;
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			Random R = new Random();
			x2 = e.X;
			y2 = e.Y;
			P = new Panel();
			if (x1 > x2 && y1 > y2)
				P.Location = new Point(x2, y2);
			else if (x1 < x2 && y1 > y2)
				P.Location = new Point(x2 + (x1 - x2), y2);
			else if (x1 > x2 && y1 < y2)
				P.Location = new Point(x2, y2 + (y1 - y2));
			else
				P.Location = new Point(x1, y1);

			P.Size = new Size(Math.Abs(x2 - x1), Math.Abs(y2 - y1));
			P.BackColor = Color.FromArgb(R.Next(0,256), R.Next(0, 256), R.Next(0, 256), R.Next(0, 256));
			P.TabIndex = 0;
			Controls.Add(P);
			Controls.SetChildIndex(P, 0);
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			x1 = e.X;
			y1 = e.Y;
		}
	}
}