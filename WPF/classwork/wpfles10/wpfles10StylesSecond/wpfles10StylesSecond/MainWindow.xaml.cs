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

namespace wpfles10StylesSecond
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		public void Control_MouseEnter(Object sender, MouseEventArgs e)
		{
			Control C = (Control)sender;
			if (C == null) return;
			C.Background = new SolidColorBrush(Colors.Yellow);
		}
		public void Control_MouseLeave(Object sender, MouseEventArgs e)
		{
			Control C = (Control)sender;
			if (C == null) return;
			C.Background = new SolidColorBrush(Colors.White);
		}
	}
}
