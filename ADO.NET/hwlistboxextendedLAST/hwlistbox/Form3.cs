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
	public partial class Form3 : Form
	{
		public String genre;
		public Form3()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(textBox1.Text.Trim() == "")
			{
				MessageBox.Show("Поле не заполнено", "Ошибка");
				return;
			}
			genre = textBox1.Text;
			this.Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			genre = null;
			this.Close();
		}
	}
}
