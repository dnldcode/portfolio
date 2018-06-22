using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hw3._2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.MouseMove += Form1_MouseMove;
		}

		private void Form1_MouseMove(object sender, MouseEventArgs e)
		{
			Random R = new Random();

			if (button1.Location.X < 0)
				button1.Location = new Point(button1.Location.X + button1.Width + 25, button1.Location.Y);
			if (button1.Location.X > this.ClientSize.Width - button1.Width)
				button1.Location = new Point(button1.Location.X - button1.Width - 25, button1.Location.Y);
			if (button1.Location.Y < 0)
				button1.Location = new Point(button1.Location.X, button1.Location.Y + button1.Height + 25);
			if (button1.Location.Y > this.ClientSize.Height - button1.Height)
				button1.Location = new Point(button1.Location.X, button1.Location.Y - button1.Height - 25);

			if (e.X > button1.Bounds.Location.X - 6 && e.X < button1.Bounds.Location.X && e.Y > button1.Bounds.Location.Y - 6 && e.Y < button1.Bounds.Location.Y)
				button1.Location = new Point(button1.Location.X + 5, button1.Location.Y + 5);
			if (e.X > button1.Bounds.Location.X - 6 && e.X < button1.Bounds.Location.X && e.Y > button1.Bounds.Location.Y + button1.Size.Height && e.Y < button1.Bounds.Location.Y + button1.Size.Height + 6)
				button1.Location = new Point(button1.Location.X + 5, button1.Location.Y - 5);
			if (e.X > button1.Bounds.Location.X + button1.Size.Width && e.X < button1.Bounds.Location.X + button1.Size.Width + 6 && e.Y > button1.Bounds.Location.Y - 6 && e.Y < button1.Bounds.Location.Y)
				button1.Location = new Point(button1.Location.X - 5, button1.Location.Y + 5);
			if (e.X > button1.Bounds.Location.X + button1.Size.Width && e.X < button1.Bounds.Location.X + button1.Size.Width + 6 && e.Y > button1.Bounds.Location.Y + button1.Size.Height && e.Y < button1.Bounds.Location.Y + button1.Size.Height + 6)
				button1.Location = new Point(button1.Location.X - 5, button1.Location.Y - 5);
			if (e.X < button1.Bounds.Location.X + button1.Size.Width + 5 && e.X > button1.Bounds.Location.X + button1.Size.Width && e.Y < button1.Top + button1.Size.Height && e.Y > button1.Top)
				button1.Location = new Point(button1.Location.X - 5, button1.Location.Y);
			if (e.X > button1.Bounds.Location.X - 5 && e.X < button1.Bounds.Location.X && e.Y < button1.Top + button1.Size.Height && e.Y > button1.Top)
				button1.Location = new Point(button1.Location.X + 5, button1.Location.Y);
			if (e.Y > button1.Bounds.Location.Y - 5 && e.Y < button1.Bounds.Location.Y && e.X > button1.Bounds.Location.X && e.X < button1.Bounds.Location.X + button1.Size.Width)
				button1.Location = new Point(button1.Location.X, button1.Location.Y + 5);
			if (e.Y < button1.Bounds.Location.Y + button1.Size.Height + 5 && e.Y > button1.Bounds.Location.Y + button1.Size.Height && e.X > button1.Bounds.Location.X && e.X < button1.Bounds.Location.X + button1.Size.Width)
				button1.Location = new Point(button1.Location.X, button1.Location.Y - 5);
		}
	}
}