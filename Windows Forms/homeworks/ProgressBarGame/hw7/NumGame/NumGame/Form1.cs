using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NumGame
{
	public partial class Form1 : Form
	{
		static Button button;
		static List<int> nums = new List<int>();
		public int count = 0;
		public Form1()
		{
			InitializeComponent();

			comboBox1.SelectedIndex = 0;
			this.panel1.Enabled = false;
			this.timer1.Tick += Timer1_Tick;
		}

		private void Timer1_Tick(object sender, EventArgs e)
		{
			if(progressBar1.Maximum > progressBar1.Value)
				this.progressBar1.Value++;
			else
			{
				makeField();
				MessageBox.Show("Вы проиграли.", "Поражение");
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
				makeField();
				this.button1.Text = "Старт";
		}

		private void randList(int n)
		{
			Random R = new Random();
			nums.Clear();
			for (int i = 0; i < n; i++)
				nums.Add(i + 1);
			for (int i = 0; i < n; i++)
				nums.Reverse(i, R.Next(0, nums.Count - i + 1));
		}

		private void makeField()
		{
			this.progressBar1.Value = 0;
			this.timer1.Stop();
			this.panel1.Enabled = false;
			count = 0;
			int a = 0, b = 0;
			if (comboBox1.SelectedIndex == 0)
			{
				a = b = 4;
				progressBar1.Maximum = 100;
			}
			if (comboBox1.SelectedIndex == 1)
			{
				a = b = 6;
				progressBar1.Maximum = 650;
			}
			if (comboBox1.SelectedIndex == 2)
			{
				a = 7;
				b = 9;
				progressBar1.Maximum = 1500;
			}
			if (comboBox1.SelectedIndex == 3)
			{
				a = 10;
				b = 12;
				progressBar1.Maximum = 6000;
			}
			randList(a * b);
			int posx = 10, posy = 20;
			this.panel1.Controls.Clear();
			for (int i = 0; i < a; i++)
			{
				for (int j = 0; j < b; j++)
				{
					button = new Button();
					button.Location = new System.Drawing.Point(posx, posy);
					button.Size = new System.Drawing.Size(35, 35);
					button.Click += button_Click;
					button.FlatStyle = FlatStyle.Flat;
					this.panel1.Controls.Add(button);
					posx += 35;
				}
				posx = 10;
				posy += 35;
			}
		}

		private void button_Start(object sender, EventArgs e)
		{
			if (progressBar1.Value == 0)
			{
				this.button1.Text = "Стоп";
				this.timer1.Start();
				int q = 0;
				foreach (Button b in panel1.Controls)
					b.Text = nums[q++].ToString();
				this.panel1.Enabled = true;
			}
			else
			{
				this.button1.Text = "Старт";
				makeField();
			}
		}
		private void button_Click(object sender, EventArgs e)
		{
			Button b = (Button)sender;
			if (Int32.Parse(b.Text) == this.count + 1)
			{
				this.count++;
				b.Enabled = false;
			}
			else
			{
				makeField();
				MessageBox.Show("Вы проиграли.", "Поражение");
			}
			if (this.count == nums.Count)
			{
				int res = progressBar1.Value;
				makeField();
				MessageBox.Show("Вы победили!", "Победа");
			}
		}
	}
}