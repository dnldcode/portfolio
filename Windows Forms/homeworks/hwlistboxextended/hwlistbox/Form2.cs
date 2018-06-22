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
		public Form2()
		{
			InitializeComponent();

			
		}

		private void buttonOK(object sender, EventArgs e)
		{
			Form1 f1 = this.Owner as Form1;
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
				if (f1.addOrEdit)
					f1.listBox1.Items.Add(new Product(name, price, weight));
				else
					f1.listBox1.Items[f1.listBox1.SelectedIndex] = new Product(name, price, weight);
			}
			catch (FormatException fe)
			{
				MessageBox.Show("Error : " + fe.Message);
			}
			this.Close();
		}

		private void buttonCancel(object sender, EventArgs e)
		{
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
			if (textBox2.Text == "" || Double.TryParse(textBox2.Text, out double res) != true)
				errorProvider1.SetError(textBox2, "Введено не корректное значение");
			else
				errorProvider1.SetError(textBox2, "");
		}

		private void leave3(object sender, EventArgs e)
		{
			if (textBox3.Text == "" || Int32.TryParse(textBox3.Text, out int res) != true)
				errorProvider1.SetError(textBox3, "Введено не корректное значение");
			else
				errorProvider1.SetError(textBox3, "");
		}
	}
}
