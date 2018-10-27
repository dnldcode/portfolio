using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace hw3Buttons
{
	public partial class Form1 : Form
	{
		EventWaitHandle handle1;
		EventWaitHandle handle2;
		EventWaitHandle handle3;
		Thread t1, t2, t3;
		public Form1()
		{
			InitializeComponent();

			this.Load += Form1_Load;
			this.FormClosing += Form1_FormClosing;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			try
			{
				this.t1.Abort();
				//this.T2.Interrupt();
				//this.T3.Interrupt();
				//this.T4.Interrupt();
			}
			catch { }
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			handle1 = new EventWaitHandle(true, EventResetMode.AutoReset/*работают поочереди*/ /*EventResetMode.ManualReset/*работают одновременно*/);
			handle2 = new EventWaitHandle(false, EventResetMode.AutoReset);
			handle3 = new EventWaitHandle(false, EventResetMode.AutoReset);

			t1 = new Thread(this.runButton1);
			t1.IsBackground = true;
			t1.Start();
			t2 = new Thread(this.runButton2);
			t2.IsBackground = true;
			t2.Start();
			t3 = new Thread(this.runButton3);
			t3.IsBackground = true;
			t3.Start();
		}

		private void runButton1()
		{
			while(true)
			{
				handle1.WaitOne();
				if (button1.Location.X == 0)
				{
					Thread.Sleep(100);
					while (this.button1.Location.X != this.Size.Width - this.button1.Size.Width)
					{
						this.button1.Invoke(new Action(() =>
						{
							Thread.Sleep(5);
							this.button1.Left++;
						}));
					}
					handle2.Set();
				}
				else if (button1.Location.X == this.Size.Width - this.button1.Size.Width)
				{
					Thread.Sleep(100);
					while (this.button1.Location.X != 0)
					{
						this.button1.Invoke(new Action(() =>
						{
							Thread.Sleep(5);
							this.button1.Left--;
						}));
					}
					handle2.Set();
				}
			}
		}
		private void runButton2()
		{
			while (true)
			{
				handle2.WaitOne();
				if (button2.Location.X == 0)
				{
					Thread.Sleep(100);
					while (this.button2.Location.X != this.Size.Width - this.button2.Size.Width)
					{
						this.button2.Invoke(new Action(() =>
						{
							Thread.Sleep(5);
							this.button2.Left++;
						}));
					}
					handle3.Set();
				}
				else if (button2.Location.X == this.Size.Width - this.button2.Size.Width)
				{
					Thread.Sleep(100);
					while (this.button2.Location.X != 0)
					{
						this.button2.Invoke(new Action(() =>
						{
							Thread.Sleep(5);
							this.button2.Left--;
						}));
					}
					handle3.Set();
				}
				else
					MessageBox.Show(String.Format("LocationX : {0}, SizeWitdth {1}, button2Size : {2}", button2.Location.X, this.Size.Width, this.button2.Size.Width));
			}
		}

		private void runButton3()
		{
			while (true)
			{
				handle3.WaitOne();
				if (button3.Location.X == 0)
				{
					Thread.Sleep(100);
					while (this.button3.Location.X != this.Size.Width - this.button3.Size.Width)
					{
						this.button3.Invoke(new Action(() =>
						{
							Thread.Sleep(5);
							this.button3.Left++;
						}));
					}
					handle1.Set();
				}
				else if (button3.Location.X == this.Size.Width - this.button3.Size.Width)
				{
					Thread.Sleep(100);
					while (this.button3.Location.X != 0)
					{
						this.button3.Invoke(new Action(() =>
						{
							Thread.Sleep(5);
							this.button3.Left--;
						}));
					}
					handle1.Set();
				}
			}
		}
	}
}