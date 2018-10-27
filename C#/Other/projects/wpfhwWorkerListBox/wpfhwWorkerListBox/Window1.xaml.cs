using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpfhwWorkerListBox
{
	/// <summary>
	/// Логика взаимодействия для Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Worker temp;
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

				int age = Int32.Parse(textBox3.Text);
				temp = new Worker(textBox1.Text, textBox2.Text, age, radioButtonMan.IsChecked == true);
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
