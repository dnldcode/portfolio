using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsLes1
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(sender == this.button1)
			{
				MessageBox.Show("Text : " + textBox1.Text);
				textBox1.Text = "";
			}
			if (sender == this.button2)
			{
				MessageBox.Show("Text : " + textBox2.Text);
				textBox1.Text = "";
			}
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void button_Click(object sender, EventArgs e)
		{

		}
	}
}
