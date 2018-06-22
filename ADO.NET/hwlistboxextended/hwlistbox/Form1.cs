using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hwlistbox
{
	public partial class Form1 : Form
	{
		Form2 f2 = new Form2();
		SqlConnection cn;
		public Form1()
		{
			InitializeComponent();

			cn = new SqlConnection();
			cn.ConnectionString = @"Data Source=10.3.21.100;Initial Catalog=sp2822;User ID=sp2822user;Password=sp2822pswd";

			SqlCommand cmd = (SqlCommand)cn.CreateCommand();
			cmd.CommandText = "SELECT * FROM product09701";

			listView1.View = View.List;

			cn.Open();
			SqlDataReader R = cmd.ExecuteReader();

			while (R.Read())
				listView1.Items.Add(R.GetString(1) + " " + R.GetFloat(2) + " " + R.GetInt32(3));
			this.FormClosing += Form1_FormClosing;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			cn.Close();
		}

		private void button_add(object sender, EventArgs e)
		{
			f2.Text = "Adding";
			try
			{
				f2.ShowDialog();
				SqlCommand cmd = (SqlCommand)cn.CreateCommand();
				cmd.CommandText = String.Format("INSERT INTO product09701(name, price, weight) VALUES('{0}', {1}, {2})", f2.f2product.Name, f2.f2product.Price, f2.f2product.Weight);
				cmd.Connection = cn;

				
				cmd.ExecuteNonQuery();
				
			}
			catch(Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void button_edit(object sender, EventArgs e)
		{
			//try
			//{
			//	if (listView1.SelectedIndex != -1)
			//	{
			//		f2.Text = "Editing";
			//		Product temp = (Product)listView1.SelectedItem;
			//		f2.textBox1.Text = temp.Name;
			//		f2.textBox2.Text = temp.Price.ToString();
			//		f2.textBox3.Text = temp.Weight.ToString();
			//		try
			//		{
			//			f2.ShowDialog();
			//			listView1.Items[listView1.SelectedIndex] = f2.f2product;
			//		}
			//		catch { return; }
			//	}
			//	else
			//		MessageBox.Show("Продукт не выбран");
			//}
			//catch { }
		}

		private void button_delete(object sender, EventArgs e)
		{
			//if (listView1.SelectedIndex != -1)
			//{
			//	if (MessageBox.Show("Вы точно хотите удалить выбранный элемент?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
			//		listView1.Items.RemoveAt(listView1.SelectedIndex);
			//}
			//else
			//	MessageBox.Show("Продукт не выбран");
		}
	}
	public class Product
	{
		public String Name { get; set; }
		public double Price { get; set; }
		public int Weight { get; set; }
		public Product(String name = "", double price = 0, int weight = 0)
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
