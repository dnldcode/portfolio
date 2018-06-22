using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hwlistbox
{
	public partial class Form4 : Form
	{
		public String name;
		public String selectedGenre;
		public Form4()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Trim() == "")
			{
				MessageBox.Show("Поле не заполнено", "Ошибка");
				return;
			}
			name = textBox1.Text;
			selectedGenre = comboBox1.SelectedItem.ToString();
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			name = null;
			this.Close();
		}
	}
}
