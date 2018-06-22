using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Common;

namespace CinemasExam
{
	public partial class Form1 : Form
	{
		private DbConnection cn;
		private DbDataAdapter A;
		public DbDataReader dbR;
		public DbCommand cmd;
		private String status;
		private LoginForm lf;
		private AdminPanel ap;
		private String currentLogin;
		public Form1()
		{
			InitializeComponent();

			DbProviderFactory DPF = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["database"]);
			this.cn = DPF.CreateConnection();
			this.cn.ConnectionString = ConfigurationManager.AppSettings["connection_string"];
			cmd = this.cn.CreateCommand();
			this.A = DPF.CreateDataAdapter();
			Connection.getInstance(cn, A);
			this.A.SelectCommand = cmd;
			tableLayoutPanel3.BackColor = Color.LightGray;
			tableLayoutPanel5.BackColor = Color.LightGray;
			tableLayoutPanel6.BackColor = Color.White;
			this.StartPosition = FormStartPosition.CenterScreen;

			//this.setStatus("Guest");
			this.setStatus("Admin", "GOD");

			this.BackColor = Color.GhostWhite;
			tableLayoutPanel4.BackColor = Color.White;
			hoursTextBox.MaxLength = 2;
			hoursTextBox.TextAlign = HorizontalAlignment.Center;
			minutesTextBox.MaxLength = 2;
			minutesTextBox.TextAlign = HorizontalAlignment.Center;

			resultListView.View = View.Details;
			resultListView.GridLines = true;
			resultListView.FullRowSelect = true;
			resultListView.Columns.Add("Фильм", 170, HorizontalAlignment.Left);
			resultListView.Columns.Add("Жанр", 150, HorizontalAlignment.Left);
			resultListView.Columns.Add("Кинотеатр", 120, HorizontalAlignment.Left);
			resultListView.Columns.Add("Дата", 100, HorizontalAlignment.Left);
			resultListView.Columns.Add("Время", 100, HorizontalAlignment.Left);

			dayComboBox.SelectedIndex = monthComboBox.SelectedIndex = yearComboBox.SelectedIndex = 0;
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			if (status != "Admin")
			{
				lf = new LoginForm();
				if (lf.ShowDialog() == DialogResult.Yes)
					this.setStatus("Admin", lf.login);
				else
					return;
			}
			if (status == "Admin")
			{
				ap = new AdminPanel(this.currentLogin);
				this.Hide();
				DialogResult dr = ap.ShowDialog();
				if (dr == DialogResult.Cancel)
				{
					this.Close();
				}
				else if (dr == DialogResult.Abort)
					this.setStatus("Guest");
				cinemaCheckBox.Checked = timeCheckBox.Checked = dateCheckBox.Checked = genreCheckBox.Checked = false;
				this.Show();
			}
		}

		private void setStatus(String status, String login = "Unknown")
		{
			this.status = status;
			if (status == "Guest")
			{
				this.statusLabel.Text = "Гость";
				loginButton.Text = "Авторизация";
			}
			else if (status == "Admin")
			{
				this.statusLabel.Text = "Администратор";
				loginButton.Text = "Зайти в Админ-панель";
			}
			this.currentLogin = login;
		}

		private void buttonSearch_Click(object sender, EventArgs e)
		{
			cn.Open();
			cmd = cn.CreateCommand();
			cmd.CommandText = "SELECT Films.name, Genres.Name, Cinemas.name, Sessions.date, Sessions.start_time FROM Films, Cinemas, Sessions, Genres WHERE Sessions.id_film = Films.id AND Sessions.id_cinema = Cinemas.id AND Films.id_genre = Genres.id ";
			if (timeCheckBox.Checked && minutesTextBox.Text != "" && hoursTextBox.Text != "")
			{
				int temp = Convert.ToInt32(hoursTextBox.Text);
				cmd.CommandText += String.Format("AND(start_time >= '{0}:{1}' AND start_time <= '{2}:{1}') ", temp - 1, Convert.ToInt32(minutesTextBox.Text), temp + 1);
			}
			if (dateCheckBox.Checked)
			{
				cmd.CommandText += String.Format("AND date = '{0}.{1}.{2}' ", dayComboBox.SelectedIndex + 1, monthComboBox.SelectedIndex + 1, yearComboBox.SelectedItem);
			}
			if (genreCheckBox.Checked && genreComboBox.SelectedIndex != -1)
				cmd.CommandText += "AND Genres.name = '" + genreComboBox.SelectedItem.ToString() + "' ";
			if (cinemaCheckBox.Checked && cinemaComboBox.SelectedIndex != -1)
				cmd.CommandText += "AND Cinemas.name = '" + cinemaComboBox.SelectedItem.ToString() + "' ";

			dbR = cmd.ExecuteReader();
			resultListView.Items.Clear();
			while (dbR.Read())
			{
				ListViewItem lvi = new ListViewItem(dbR.GetString(0));
				lvi.SubItems.Add(dbR.GetString(1));
				lvi.SubItems.Add(dbR.GetString(2));
				lvi.SubItems.Add(dbR.GetDateTime(3).ToShortDateString());
				lvi.SubItems.Add(((TimeSpan)dbR.GetValue(4)).ToString());
				resultListView.Items.Add(lvi);

			}
			dbR.Close();
			cn.Close();
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if (sender == timeCheckBox)
				hoursTextBox.Enabled = minutesTextBox.Enabled = timeCheckBox.Checked;
			else if (sender == dateCheckBox)
			{
				dayComboBox.Enabled = monthComboBox.Enabled = yearComboBox.Enabled = dateCheckBox.Checked;
			}
			else 
			{
				cn.Open();
				cmd = cn.CreateCommand();
				if (sender == genreCheckBox)
				{
					genreComboBox.Enabled = genreCheckBox.Checked;
					genreComboBox.SelectedIndex = -1;
					cmd.CommandText = "SELECT * FROM Genres ORDER BY 1 ASC";
					genreComboBox.Items.Clear();

				}
				else
				{
					cinemaComboBox.Enabled = cinemaCheckBox.Checked;
					cinemaComboBox.SelectedIndex = -1;
					cmd.CommandText = "SELECT * FROM Cinemas ORDER BY 1 ASC";
					cinemaComboBox.Items.Clear();
				}
				dbR = cmd.ExecuteReader();
				while (dbR.Read())
				{
					if (sender == genreCheckBox)
						genreComboBox.Items.Add(dbR.GetString(1));
					else
						cinemaComboBox.Items.Add(dbR.GetString(1));
				}
				dbR.Close();
				cn.Close();
			}
		}

		private void hoursTextBox_Leave(object sender, EventArgs e)
		{
			if (hoursTextBox.Text == "")
				return;
			if(Convert.ToInt32(hoursTextBox.Text) > 23)
			{
				MessageBox.Show("Ошибка ввода времени", "Ошибка");
				hoursTextBox.Text = "";
			}
		}

		private void hoursTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < 48 || e.KeyChar >= 59) && e.KeyChar != 8)
				e.Handled = true;
		}

		private void minutesTextBox_Leave(object sender, EventArgs e)
		{
			if (minutesTextBox.Text == "")
				return;
			if (Convert.ToInt32(minutesTextBox.Text) > 59)
			{
				MessageBox.Show("Ошибка ввода времени", "Ошибка");
				minutesTextBox.Text = "";
			}
		}

	}
	class Connection
	{
		private static Connection instance;

		public DbConnection connection { get; private set; }
		public DbDataAdapter adapter { get; private set; }

		protected Connection(DbConnection name, DbDataAdapter adaptername)
		{
			this.connection = name;
			this.adapter = adaptername;
		}

		public static Connection getInstance(DbConnection name = null, DbDataAdapter adaptername = null)
		{
			if (instance == null)
				instance = new Connection(name, adaptername);
			return instance;
		}
	}
}