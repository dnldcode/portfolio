using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegeditExam
{
	public partial class Form3 : Form
	{
		public Form3()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text != "")
				this.DialogResult = DialogResult.OK;
			else
				MessageBox.Show("Указанное имя раздела пусто. Попробуйте ввести другое и попробывать снова.", "Ошибка при именовании раздела", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
