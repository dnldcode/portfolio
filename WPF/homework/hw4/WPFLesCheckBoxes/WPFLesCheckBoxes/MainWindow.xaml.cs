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

namespace WPFLesCheckBoxes
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private Dictionary<CheckBox, String> dict1 = new Dictionary<CheckBox, String>();
		private Dictionary<RadioButton, String> dict2 = new Dictionary<RadioButton, String>();
		private Dictionary<RadioButton, String> dict3 = new Dictionary<RadioButton, String>();
		public MainWindow()
        {
            InitializeComponent();
			this.dict1.Add(this.cbCpp, "C++");
			this.dict1.Add(this.cbCSharp, "C#");
			this.dict1.Add(this.cbWpf, "Wpf");
			this.dict1.Add(this.cbPhp, "PHP");

			this.dict2.Add(this.rbRed, "Red");
			this.dict2.Add(this.rbGreen, "Green");
			this.dict2.Add(this.rbBlue, "Blue");

			this.dict3.Add(this.rbLaser, "LaserPrinter");
			this.dict3.Add(this.rbInk, "InkPrinter");
			this.dict3.Add(this.rb3D, "3DPrinter");
		}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
			ICollection<CheckBox> keys1 = this.dict1.Keys;
			ICollection<RadioButton> keys2 = this.dict2.Keys;
			ICollection<RadioButton> keys3 = this.dict3.Keys;
			String str = "";
			foreach(CheckBox cb in keys1)
				str += dict1[cb] + " : " + ((cb.IsChecked == true) ? "Выбран" : "Не выбран") + "\n";
			str += "\n";
			foreach (RadioButton rb in keys2)
				if (rb.IsChecked == true)
				{
					str += "Выбран цвет : " + dict2[rb] + "\n";
					break;
				}
			str += "\n";
			foreach (RadioButton rb in keys3)
				if (rb.IsChecked == true)
				{
					str += "Выбран принтер : " + dict3[rb] + "\n";
					break;
				}

		MessageBox.Show(str);
        }
    }
}
