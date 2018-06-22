using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wcfTelegramClient
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosing += LoginForm_FormClosing;
			button1.Enabled = false;
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
				this.button1_Click(null, null);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Yes;
		}

		private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				DialogResult = DialogResult.No;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			button1.Enabled = (textBox1.Text.Trim() != "");
		}
	}
}
