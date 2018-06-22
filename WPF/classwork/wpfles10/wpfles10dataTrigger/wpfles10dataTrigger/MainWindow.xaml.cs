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

namespace wpfles10dataTrigger
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			Random R = new Random();
			for (int i = 0; i < 50; i++)
			{
				this.listBox1.Items.Add(
					new Product()
					{
						Name = "Product" + R.Next(100, 1000),
						Price = R.Next(100, 1000) / (double)10,
						Weight = R.Next(1, 50) * 10,
						isBeverage = (R.Next(0, 2) == 1)
					});
			}
		}
	}
	class Product
	{
		public String Name { get; set; }
		public double Price { get; set; }
		public int Weight { get; set; }
		public bool isBeverage { get; set; }
	}
}