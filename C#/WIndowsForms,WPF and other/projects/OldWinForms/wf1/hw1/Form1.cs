using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hw1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, EventArgs e)
		{
			if (sender == this.button5)
			{
				textBox1.Text = "";
				textBox2.Text = "";
				return;
			}
			double a, b;
			try
			{
				a = Double.Parse(textBox1.Text);
				b = Double.Parse(textBox2.Text);
			}
			catch(FormatException fe)
			{
				MessageBox.Show(" Ошибка : " + fe.Message);
				return;
			}
			if (sender == this.button1)
			{
				label4.Text = (a + b).ToString();
			}
			else if (sender == this.button2)
			{
				label4.Text = (a - b).ToString();
			}
			else if (sender == this.button3)
			{
				label4.Text = (a * b).ToString();
			}
			else if (sender == this.button4)
			{
				if (b == 0)
				{
					MessageBox.Show(" Ошибка : Знаменатель не может быть нулем");
					return;
				}
				label4.Text = (a / b).ToString();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			double a, b;
			try
			{
				a = Double.Parse(textBox1.Text);
				b = Double.Parse(textBox2.Text);
			}
			catch (FormatException fe)
			{
				MessageBox.Show(" Ошибка : " + fe.Message);
				return;
			}
			label4.Text = (a + b).ToString();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			double a, b;
			try
			{
				a = Double.Parse(textBox1.Text);
				b = Double.Parse(textBox2.Text);
			}
			catch (FormatException fe)
			{
				MessageBox.Show(" Ошибка : " + fe.Message);
				return;
			}
			label4.Text = (a - b).ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			double a, b;
			try
			{
				a = Double.Parse(textBox1.Text);
				b = Double.Parse(textBox2.Text);
			}
			catch (FormatException fe)
			{
				MessageBox.Show(" Ошибка : " + fe.Message);
				return;
			}
			label4.Text = (a * b).ToString();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			double a, b;
			try
			{
				a = Double.Parse(textBox1.Text);
				b = Double.Parse(textBox2.Text);
			}
			catch (FormatException fe)
			{
				MessageBox.Show(" Ошибка : " + fe.Message);
				return;
			}
			if (b == 0)
			{
				MessageBox.Show(" Ошибка : Знаменатель не может быть нулем");
				return;
			}
			label4.Text = (a / b).ToString();
		}
		private void button5_Click(object sender, EventArgs e)
		{
			textBox1.Text = "";
			textBox2.Text = "";
		}
	}
}