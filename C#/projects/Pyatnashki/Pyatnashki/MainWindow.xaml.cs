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

namespace Pyatnashki
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Button[,] buttons = new Button[4,4];
		List<int> nums = new List<int>();
		Random R = new Random();
		Grid grid;
		public MainWindow()
		{
			InitializeComponent();

			grid = new Grid();
			RowDefinition RD = new RowDefinition();
			RD.Height = new GridLength(50);
			grid.RowDefinitions.Add(RD);
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.RowDefinitions.Add(new RowDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			grid.ColumnDefinitions.Add(new ColumnDefinition());
			this.Content = grid;

			InitField();
		}

		private void Buttons_Click(object sender, RoutedEventArgs e)
		{
			Button temp = (Button)sender;
			try
			{
				int x = (int)temp.GetValue(Grid.RowProperty) - 1;
				int y = (int)temp.GetValue(Grid.ColumnProperty);
				if (x != 3)
					if (buttons[x + 1, y].Content.ToString() == "0")
						Swap(temp, 1, 0);
				if (x != 0)
					if (buttons[x - 1, y].Content.ToString() == "0")
						Swap(temp, -1, 0);
				if (y != 3)
					if (buttons[x, y + 1].Content.ToString() == "0")
						Swap(temp, 0, 1);
				if (y != 0)
					if (buttons[x, y - 1].Content.ToString() == "0")
						Swap(temp, 0, -1);
			}
			catch { return; }

			if (IsWon())
			{
				MessageBox.Show("You won");
				InitField();
			}
		}

		private void Swap(Button temp, int x1, int y1)
		{
			int x = (int)temp.GetValue(Grid.RowProperty) - 1;
			int y = (int)temp.GetValue(Grid.ColumnProperty);

				buttons[x, y].SetValue(Grid.RowProperty, x + x1 + 1);
				buttons[x, y].SetValue(Grid.ColumnProperty, y + y1);

				Button b = buttons[x, y];
				buttons[x, y] = buttons[x + x1, y + y1];
				buttons[x + x1, y + y1] = b;		
		}

		private void InitField()
		{
			this.grid.Children.Clear();
			nums.Clear();
			for (int i = 0; i < 15; i++)
				nums.Add(i + 1);
			for (int i = 0; i < 15; i++)
				nums.Reverse(i, R.Next(i, 15) - i);

			int q = 0;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					buttons[i, j] = new Button();
					buttons[i, j].SetValue(Grid.RowProperty, i + 1);
					buttons[i, j].SetValue(Grid.ColumnProperty, j);
					this.grid.Children.Add(buttons[i, j]);
					if (q != 15)
					{
						buttons[i, j].Content = nums[q++];
						buttons[i, j].Click += Buttons_Click;
						buttons[i, j].Margin = new Thickness(3);
					}
					else
					{
						buttons[i, j].Content = "0";
						buttons[i, j].Visibility = Visibility.Collapsed;
					}
				}
			}
			Button restart = new Button();
			restart.SetValue(Grid.RowProperty, 0);
			restart.SetValue(Grid.ColumnProperty, 1);
			restart.SetValue(Grid.ColumnSpanProperty, 2);
			restart.Width = 125;
			restart.Height = 40;
			restart.Click += Restart_Click;
			restart.Content = "Restart";
			grid.Children.Add(restart);
		}

		private void Restart_Click(object sender, RoutedEventArgs e)
		{
			InitField();
		}

		private bool IsWon()
		{
			int q = 1;
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (q != 16)
						if (buttons[i, j].Content.ToString() != q++.ToString())
							return false;
				}
			}
			return true;
		}
	}
}
