using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hw4._1cities
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			//ComboBox CB = new ComboBox();
			//CB.Location = new Point(20, 20);
			//CB.Size = new Size(120, 25);
			//this.Controls.Add(CB);

			//CB = new ComboBox();
			//CB.Location = new Point(200, 20);
			//CB.Size = new Size(120, 25);
			//this.Controls.Add(CB);
			comboBox1.Items.Add("Великобритания");
			comboBox1.Items.Add("Украина");
			comboBox1.Items.Add("Япония");
			comboBox1.Items.Add("Испания");
			comboBox1.Items.Add("Дания");
			comboBox1.SelectedIndex = 0;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox CB = (ComboBox)sender;
			if(CB.SelectedIndex == 0)
			{
				comboBox2.Items.Clear();
				comboBox2.Items.Add("Лондон");
				comboBox2.Items.Add("Манчестер");
				comboBox2.Items.Add("Ливерпуль");
				comboBox2.Items.Add("Оксфорд");
				comboBox2.Items.Add("Эдинбург");
				comboBox2.Items.Add("Бирмингем");
				comboBox2.Items.Add("Кембридж");
				comboBox2.Items.Add("Глазго");
				comboBox2.Items.Add("Йорк");
				comboBox2.Items.Add("Кардифф");
				comboBox2.SelectedIndex = 0;
			}
			else if (CB.SelectedIndex == 1)
			{
				comboBox2.Items.Clear();
				comboBox2.Items.Add("Киев");
				comboBox2.Items.Add("Харьков");
				comboBox2.Items.Add("Одесса");
				comboBox2.Items.Add("Львов");
				comboBox2.Items.Add("Запорожье");
				comboBox2.Items.Add("Днепр");
				comboBox2.Items.Add("Винница");
				comboBox2.Items.Add("Ивано-Франковск");
				comboBox2.Items.Add("Хмельницкий");
				comboBox2.Items.Add("Тернополь");
				comboBox2.SelectedIndex = 0;
			}
			else if (CB.SelectedIndex == 2)
			{
				comboBox2.Items.Clear();
				comboBox2.Items.Add("Токио");
				comboBox2.Items.Add("Иокогама");
				comboBox2.Items.Add("Осака");
				comboBox2.Items.Add("Нагоя");
				comboBox2.Items.Add("Саппоро");
				comboBox2.Items.Add("Кобе");
				comboBox2.Items.Add("Киото");
				comboBox2.Items.Add("Фукуока");
				comboBox2.Items.Add("Кавасаки");
				comboBox2.Items.Add("Сайтама");
				comboBox2.SelectedIndex = 0;
			}
			else if (CB.SelectedIndex == 3)
			{
				comboBox2.Items.Clear();
				comboBox2.Items.Add("Мадрид");
				comboBox2.Items.Add("Барселона");
				comboBox2.Items.Add("Севилья");
				comboBox2.Items.Add("Гаранада");
				comboBox2.Items.Add("Малага");
				comboBox2.Items.Add("Толедо");
				comboBox2.Items.Add("Кордова");
				comboBox2.Items.Add("Бильбао");
				comboBox2.Items.Add("Валенсия");
				comboBox2.Items.Add("Сарагоса");
				comboBox2.SelectedIndex = 0;
			}
			else if (CB.SelectedIndex == 4)
			{
				comboBox2.Items.Clear();
				comboBox2.Items.Add("Копенгаген");
				comboBox2.Items.Add("Оденсе");
				comboBox2.Items.Add("Орхус");
				comboBox2.Items.Add("Ольборг");
				comboBox2.Items.Add("Роскилле");
				comboBox2.Items.Add("Хельсингёр");
				comboBox2.Items.Add("Эсбьерг");
				comboBox2.Items.Add("Биллунн");
				comboBox2.Items.Add("Силькеборг");
				comboBox2.Items.Add("Хиллерёд");
				comboBox2.SelectedIndex = 0;
			}
			label1.Text = comboBox1.SelectedItem.ToString();
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			label3.Text = comboBox2.SelectedItem.ToString();
		}
	}
}