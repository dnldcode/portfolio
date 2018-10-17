using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinemasExam
{
	public partial class AdminPanel : Form
	{
		private String currentLogin;
		EditDataBaseForm edb;
		public AdminPanel(String login)
		{
			InitializeComponent();
			this.BackColor = Color.GhostWhite;
			this.currentLogin = login;
			this.currentLoginLabel.Text = this.currentLogin;
			this.StartPosition = FormStartPosition.CenterParent;
			tableLayoutPanel3.BackColor = Color.LightGray;
			tableLayoutPanel4.BackColor = Color.White;
			logoutLink.BackColor = Color.White;
			tableLayoutPanel6.BackColor = Color.LightGray;
			tableLayoutPanel7.BackColor = Color.White;
			label2.BackColor = Color.White;
			edb = new EditDataBaseForm();
			this.FormClosing += AdminPanel_FormClosing;
		}

		private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				this.DialogResult = DialogResult.Cancel;
		}

		private void logoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.DialogResult = DialogResult.Abort;
		}

		private void buttons_Click(object sender, EventArgs e)
		{
			edb = new EditDataBaseForm();
			if (sender == button1)
				edb.ind = 0;
			else if (sender == button2)
				edb.ind = 1;
			else if (sender == button3)
				edb.ind = 2;
			else if (sender == button4)
				edb.ind = 3;
			edb.Show();
		}

		private void goBackButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}
	}
}
