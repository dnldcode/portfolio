using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinemasExam
{
	public partial class LoginForm : Form
	{
		public String login;
		private DbConnection cn;
		private DbDataReader dbR;
		private DbCommand cmd;
		public LoginForm()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;
			loginInput.MaxLength = 16;
			passwordInput.PasswordChar = '*';
			passwordInput.CharacterCasing = CharacterCasing.Lower;
			passwordInput.MaxLength = 16;
			this.BackColor = Color.GhostWhite;
		}

		private void buttonLogin_Click(object sender, EventArgs e)
		{
			if(loginInput.Text.Trim() == "" || passwordInput.Text.Trim() == "")
			{
				MessageBox.Show("Не все поля заполнены", "Ошибка");
				return;
			}
			if (loginInput.Text.Length < 4)
			{
				MessageBox.Show("Минимальнай длина логина - 4 символа", "Ошибка");
				return;
			}
			if (passwordInput.Text.Length < 4)
			{
				MessageBox.Show("Минимальнай длина пароля - 4 символа", "Ошибка");
				return;
			}
			login = loginInput.Text;
			String password = passwordInput.Text.GetHashCode().ToString();

			this.cn = Connection.getInstance().connection;
			cn.Open();
			this.cmd = this.cn.CreateCommand();
			this.cmd.CommandText = "SELECT * FROM Admins";
			this.dbR = this.cmd.ExecuteReader();
			bool success = false;
			while (this.dbR.Read())
			{			
				if(this.dbR.GetString(1) == login && this.dbR.GetString(2) == password)
				{
					success = true;
					break;
				}
			}
			this.dbR.Close();
			this.cn.Close();
			if (success)
				this.DialogResult = DialogResult.Yes;
			else
			{
				MessageBox.Show("Пароль или логин не совпадают. Попробуйте снова.", "Ошибка");
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void LoginForm_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyData == Keys.Enter)
			{
				this.buttonLogin_Click(null, null);
			}
		}
	}
}
