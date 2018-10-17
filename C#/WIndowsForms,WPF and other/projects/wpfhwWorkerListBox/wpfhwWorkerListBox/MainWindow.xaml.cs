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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace wpfhwWorkerListBox
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		BinaryFormatter formatter = new BinaryFormatter();
		public MainWindow()
		{
			InitializeComponent();

			Random R = new Random();
			AllWorkers temp;
			using (FileStream fs = new FileStream("workers.dat", FileMode.Open))
			{
				temp = (AllWorkers)formatter.Deserialize(fs);
			}
			for (int i = 0; i < temp.workers.Count; i++)
				listBox1.Items.Add(temp.workers[i]);
			this.Closing += MainWindow_Closing;
		}

		private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			AllWorkers temp = new AllWorkers(listBox1);
			using (FileStream fs = new FileStream("workers.dat", FileMode.Create))
			{
				formatter.Serialize(fs, temp);
			}
		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{
			int index = listBox1.SelectedIndex;
			if (index != -1)
				listBox1.Items.RemoveAt(index);
			else
				MessageBox.Show("Работник не выбран!","Ошибка");
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
			Window1 window = new Window1();
			window.Title = "Adding";
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
					MessageBox.Show("Работник не выбран!", "Ошибка");
				else
				{
					Worker tempWorker = (Worker)this.listBox1.SelectedItem;
					Window1 window = new Window1();
					window.textBox1.Text = tempWorker.Surname;
					window.textBox2.Text = tempWorker.Name;
					window.textBox3.Text = tempWorker.Age.ToString();
					if (tempWorker.Sex == true)
						window.radioButtonMan.IsChecked = true;
					else
						window.radioButtonWoman.IsChecked = true;

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
	[Serializable]
	public class Worker
	{
		public String Surname { get; set; }
		public String Name { get; set; }
		public int Age { get; set; }
		public bool Sex { get; set; }
		public String Icon { get; set; }
		public Worker(String surname, String name, int age, bool sex)
		{
			this.Surname = surname;
			this.Name = name;
			this.Age = age;
			this.Sex = sex;
			this.Icon = "Resources/";
			if (sex == true)
				this.Icon += "iconMan.png";
			else
				this.Icon += "womanIcon.png";

		}
	}
	[Serializable]
	public class AllWorkers
	{
		public List<Worker> workers = new List<Worker>();
		public AllWorkers(ListBox lb)
		{
			for (int i = 0; i < lb.Items.Count; i++)
			{
				Worker temp = (Worker)lb.Items[i];
				workers.Add(temp);
			}
		}
	}
}
