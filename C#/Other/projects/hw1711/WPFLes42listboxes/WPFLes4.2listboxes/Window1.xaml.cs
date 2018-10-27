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
using System.Windows.Shapes;

namespace WPFLes4._2listboxes
{
	/// <summary>
	/// Логика взаимодействия для Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Product temp;
		public Window1()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
				{
					MessageBox.Show("Поля не заполнены");
					return;
				}

				double price = Double.Parse(textBox2.Text.Replace(".", ","));
				int weight = Int32.Parse(textBox3.Text);
				temp = new Product(textBox1.Text, price, weight);
			}
			catch (FormatException fe)
			{
				MessageBox.Show(fe.Message);
				return;
			}
			DialogResult = true;
		}
	}
}
