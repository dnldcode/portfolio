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

namespace WPLes4._1listboxes
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			List<Product> products = new List<Product>();
			products.Add(new Product("Snickers 1", 5.5, 22));
			products.Add(new Product("Snickers 2", 12.5, 23));
			products.Add(new Product("Snickers 3", 6.5, 14));
			products.Add(new Product("Snickers 4", 2.5, 24));
			products.Add(new Product("Snickers 5", 19.5, 34));

			foreach(Product p in products)
			{
				StackPanel SP = new StackPanel();
				SP.Orientation = Orientation.Horizontal;
				SP.HorizontalAlignment = HorizontalAlignment.Left;

				Label lbName = new Label();
				lbName.Width = 200;
				lbName.Foreground = Brushes.Green;
				lbName.FontSize = 32;
				lbName.Content = p.Name;
				SP.Children.Add(lbName);

				Label lbPrice = new Label();
				lbPrice.Width = 100;
				lbPrice.Foreground = Brushes.Green;
				lbPrice.FontSize = 32;
				lbPrice.Content = p.Price;
				SP.Children.Add(lbPrice);

				Label lbWeight = new Label();
				lbWeight.Width = 100;
				lbWeight.Foreground = Brushes.Green;
				lbWeight.FontSize = 32;
				lbWeight.Content = p.Weight;
				SP.Children.Add(lbWeight);

				this.listBox1.Items.Add(SP);
			}
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

		}

		private void btnEdt_Click(object sender, RoutedEventArgs e)
		{

		}
	}
	public class Product
	{
		public String Name { get; set; }
		public double Price { get; set; }
		public int Weight { get; set; }
		public Product(String name,double price, int weight)
		{
			this.Name = name;
			this.Price = price;
			this.Weight = weight;
		}
	}
}
