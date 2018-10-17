using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WcfXOClient
{
	public partial class LogIn : Form
	{
		public LogIn()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterScreen;
			this.FormClosing += LogIn_FormClosing;
			this.BackColor = Color.White;
		}

		private void LogIn_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				this.DialogResult = DialogResult.Cancel;
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
		}

		private void textBoxInput_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Enter)
				this.buttonOK_Click(null, null);
		}
	}
}
