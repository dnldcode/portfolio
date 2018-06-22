using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace les4._3
{
	public partial class Form1 : Form
	{
		private RadioButton[] arrB1;
		private RadioButton[] arrB2;
		private String[] values1 = { "Winter", "Spring", "Summer", "Autumn" };
		private String[] values2 = { "Square", "Romb", "Triangle" };
		public Form1()
		{
			InitializeComponent();
			arrB1 = new RadioButton[] { this.radioButton1, this.radioButton2, this.radioButton3, this.radioButton4 };
			arrB2 = new RadioButton[] { this.radioButton5, this.radioButton6, this.radioButton7 };

		}
		private void GB1click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.values1.Length; i++)
				if (sender == this.arrB1[i])
				{
					MessageBox.Show(this.values1[i]);
					break;
				}
		}
		private void GB2click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.values2.Length; i++)
				if (sender == this.arrB2[i])
				{
					MessageBox.Show(this.values2[i]);
					break;
				}
		}
	}
}