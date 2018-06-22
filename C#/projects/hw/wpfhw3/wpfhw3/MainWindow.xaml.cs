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

namespace wpfhw3
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		int operate = 0;
		double answer;
		public MainWindow()
		{
			InitializeComponent();
		}

		private void button_Click(object sender, RoutedEventArgs e)
		{
			String temp = label1.Content.ToString();
			Button tempButton = (Button)sender;
			if (temp.Length == 13)
				return;
			if (temp == "0" && temp.Length == 1 || Double.Parse(temp) == answer && operate != 0)
				label1.Content = "";
			label1.Content += tempButton.Content.ToString();
		}

		private void buttonDouble_Click(object sender, RoutedEventArgs e)
		{
			String temp = label1.Content.ToString();
			if (temp == "" || temp.IndexOf(",") != -1)
				return;
			label1.Content += ",";
		}

		private void buttonClear_Click(object sender, RoutedEventArgs e)
		{
			label1.Content = "0";
			answer = 0;
			label1.FontSize = 35;
			operate = 0;
		}

		private void buttonRemoveAt_Click(object sender, RoutedEventArgs e)
		{
			String temp = label1.Content.ToString();
			if (temp.Length != 0)
			{
				label1.Content = temp.Remove(temp.Length - 1);
				if (label1.Content.ToString().Length == 0)
					label1.Content = "0";
			}
		}

		private void buttonAct_Click(object sender, RoutedEventArgs e)
		{
			Logic();
			if (sender == buttonPlus)
				operate = 1;
			else if (sender == buttonMinus)
				operate = 2;
			else if (sender == buttonMult)
				operate = 3;
			else if (sender == buttonDiv)
				operate = 4;
			else if (sender == buttonSqrt && answer != 0)
			{
				double temp = Double.Parse(label1.Content.ToString());
				answer = Math.Pow(temp, 2);
				label1.Content = answer.ToString();
				operate = 0;
			}
			if (answer.ToString().Length >= 13)
			{
				label1.Content = "Переполнение";
				answer = 0;
				operate = 0;
			}

		}
		
		private void Logic()
		{
			try
			{
				double temp = Double.Parse(label1.Content.ToString());
				if (operate == 0)
					answer = temp;
				else if (operate == 1)//+
					answer += temp;
				else if (operate == 2)//-
					answer -= temp;
				else if (operate == 3)//*
					answer *= temp;
				else if (operate == 4)// /
					answer /= temp;
				label1.Content = answer.ToString();
			}
			catch {	return;	}
		}

		private void buttonIs_Click(object sender, RoutedEventArgs e)
		{
			Logic();
			operate = 0;
		}
	}
}
