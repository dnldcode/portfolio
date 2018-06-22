using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Telegram
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;
	
		}


		private void buttonAccept_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void textBox1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				this.buttonAccept_Click(null, null);
		}
	}
}
