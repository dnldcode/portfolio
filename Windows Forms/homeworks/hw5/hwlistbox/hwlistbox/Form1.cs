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
	public partial class Form1 : Form
	{
		public bool addOrEdit;
		public Form1()
		{
			InitializeComponent();

			Random R = new Random();
			for (int i = 0; i < 10; i++)
			{
				listBox1.Items.Add(new Product("Snickers " + (i + 1), 12.5 + i, 45 + i % 10));
			}
			tableLayoutPanel4.Visible = false;

		}

		private void button_add(object sender, EventArgs e)
		{
			tableLayoutPanel4.Visible = true;
			textBox1.Text = "";
			textBox2.Text = "";
			textBox3.Text = "";
			addOrEdit = true;
		}

		private void button_edit(object sender, EventArgs e)
		{
			if (listBox1.SelectedIndex != -1)
			{
				tableLayoutPanel4.Visible = true;
				Product temp = (Product)listBox1.SelectedItem;
				textBox1.Text = temp.Name;
				textBox2.Text = temp.Price.ToString();
				textBox3.Text = temp.Weight.ToString();
				addOrEdit = false;
			}
		}

		private void button_delete(object sender, EventArgs e)
		{
			if(listBox1.SelectedIndex != -1)
				listBox1.Items.RemoveAt(listBox1.SelectedIndex);
		}

		private void button_ok(object sender, EventArgs e)
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
				if (addOrEdit)
					this.listBox1.Items.Add(new Product(name, price, weight));
				else
				{
					this.listBox1.Items[listBox1.SelectedIndex] = new Product(name, price, weight);
					tableLayoutPanel4.Visible = false;
				}
			}
			catch (FormatException fe)
			{
				MessageBox.Show("Error : " + fe.Message);
			}
		}

		private void button_cancel(object sender, EventArgs e)
		{
			tableLayoutPanel4.Visible = false;
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!addOrEdit)
				tableLayoutPanel4.Visible = false;
		}
	}
	class Product
	{
		public String Name { get; set; }
		public double Price { get; set; }
		public int Weight { get; set; }
		public Product(String name, double price, int weight)
		{
			this.Name = name;
			this.Price = price;
			this.Weight = weight;
		}
		public override string ToString()
		{
			return String.Format(" Name : {0}, price : {1}, weight {2}", this.Name, this.Price, this.Weight);
		}
	}
}
