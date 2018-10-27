using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFLes4._2listboxes
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			for (int i = 0; i < 2; i++)
				this.listBox1.Items.Add(new Product("Snickers " + i, 12.5 + i * 10, 45 + i % 5));
		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{
			int index = listBox1.SelectedIndex;
			if (index == -1)
				MessageBox.Show("Элемент не выбран из списка");
			else
				listBox1.Items.RemoveAt(index);
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			//this.listBox1.Items.Add(new Product("Mars" + listBox1.Items.Count, 13.9, 40));
			Window1 window = new Window1();
			if (window.ShowDialog() == true)
			{
				listBox1.Items.Add(window.temp);
			}
		}

		private void btnEdt_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				int index = this.listBox1.SelectedIndex;
				if (index == -1)
					MessageBox.Show("Элемент не выбран из списка");
				else
				{
					Product tempProduct = (Product)this.listBox1.SelectedItem;
					Window1 window = new Window1();
					window.textBox1.Text = tempProduct.Name;
					window.textBox2.Text = tempProduct.Price.ToString();
					window.textBox3.Text = tempProduct.Weight.ToString();
					if (window.ShowDialog() == true)
						listBox1.Items[index] = window.temp;
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}
	}
	public class Product
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
	}
}
