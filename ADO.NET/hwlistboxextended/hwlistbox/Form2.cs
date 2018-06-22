using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hwlistbox
{
	public partial class Form2 : Form
	{
		public Product f2product;
		public Form2()
		{
			InitializeComponent();
			this.FormClosing += Form2_FormClosing;
		}

		private void Form2_FormClosing(object sender, FormClosingEventArgs e)
		{
			errorProvider1.SetError(textBox1, "");
			errorProvider1.SetError(textBox2, "");
			errorProvider1.SetError(textBox3, "");
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
		}

		private void buttonOK(object sender, EventArgs e)
		{
			String name;
			double price;
			int weight;

			try
			{
				name = textBox1.Text;
				if (textBox2.Text.IndexOf(".") != -1)
					textBox2.Text = textBox2.Text.Replace(".", ",");
				price = Double.Parse(textBox2.Text);
				weight = Int32.Parse(textBox3.Text);
				f2product = new Product(name, price, weight);
			}
			catch (FormatException fe)
			{
				MessageBox.Show("Error : " + fe.Message);
				return;
			}
			this.Close();
		}

		private void buttonCancel(object sender, EventArgs e)
		{
			f2product = null;
			this.Close();
		}

		private void leave1(object sender, EventArgs e)
		{
			if(textBox1.Text == "")
				errorProvider1.SetError(textBox1, "Не введено название");
			else
				errorProvider1.SetError(textBox1, "");
		}

		private void leave2(object sender, EventArgs e)
		{
			double res;
			if (textBox2.Text == "" || Double.TryParse(textBox2.Text, out res) != true)
				errorProvider1.SetError(textBox2, "Введено не корректное значение");
			else
				errorProvider1.SetError(textBox2, "");
		}

		private void leave3(object sender, EventArgs e)
		{
			int res;
			if (textBox3.Text == "" || Int32.TryParse(textBox3.Text, out res) != true)
				errorProvider1.SetError(textBox3, "Введено не корректное значение");
			else
				errorProvider1.SetError(textBox3, "");
		}
	}
}
