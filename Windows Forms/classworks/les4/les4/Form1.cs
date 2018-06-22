using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace les4
{
	public partial class Form1 : Form
	{
		private Point ptBeg;
		public Form1()
		{
			InitializeComponent();

			this.MouseDown += Form1_MouseDown;
			this.MouseUp += Form1_MouseUp;
			this.MouseMove += Form1_MouseMove;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			if(sender is Form1)
			{
				this.Text = e.Location.ToString();
			}
			else
			{
				Control C = (Control)sender;
				this.Text = String.Format("{0} ,{1}", e.Location.X + C.Left, e.Location.Y + C.Top);
			}
		}

		private void Form1_MouseUp(object sender, MouseEventArgs e)
		{
			Panel P = new Panel();
			Random R = new Random();
			P.Top = this.ptBeg.X;
			P.Left = this.ptBeg.Y;
			P.Width = e.X - this.ptBeg.X;
			P.Height = e.Y - this.ptBeg.Y;
			P.BackColor = Color.FromArgb(R.Next(0, 256), R.Next(0, 256), R.Next(0, 256));
			P.MouseMove += Form1_MouseMove;
			this.Controls.Add(P);
			this.Controls.SetChildIndex(P, 0);
		}

		private void Form1_MouseDown(object sender, MouseEventArgs e)
		{
			this.ptBeg = e.Location;
		}
	}
}
