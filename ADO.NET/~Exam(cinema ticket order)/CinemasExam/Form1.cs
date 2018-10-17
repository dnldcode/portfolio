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
using System.Net.NetworkInformation;

namespace CinemasExam
{
	public partial class Form1 : Form
	{
		private DbConnection cn;
		private DbDataAdapter A;
		private DbDataReader dbR;
		private DbCommand cmd;
		private String status;
		private LoginForm lf;
		private AdminPanel ap;
		private TicketBooking tb = new TicketBooking();
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

			ap = new AdminPanel();
			if (!ap.isConnected)
				this.Close();

			tableLayoutPanel3.BackColor = Color.LightGray;
			tableLayoutPanel5.BackColor = Color.LightGray;
			tableLayoutPanel6.BackColor = Color.White;
			this.StartPosition = FormStartPosition.CenterScreen;

			//this.setStatus("Guest");
			this.setStatus("Admin");

			this.BackColor = Color.GhostWhite;
			tableLayoutPanel4.BackColor = Color.White;
			hoursTextBox.MaxLength = 2;
			hoursTextBox.TextAlign = HorizontalAlignment.Center;
			minutesTextBox.MaxLength = 2;
			minutesTextBox.TextAlign = HorizontalAlignment.Center;

			resultListView.View = View.Details;
			resultListView.GridLines = true;
			resultListView.FullRowSelect = true;
			resultListView.Columns.Add("Номер сеанса", 55, HorizontalAlignment.Left);
			resultListView.Columns.Add("Фильм", 150, HorizontalAlignment.Left);
			resultListView.Columns.Add("Жанр", 130, HorizontalAlignment.Left);
			resultListView.Columns.Add("Длит.", 50, HorizontalAlignment.Left);
			resultListView.Columns.Add("Кинотеатр", 120, HorizontalAlignment.Left);
			resultListView.Columns.Add("Дата", 100, HorizontalAlignment.Left);
			resultListView.Columns.Add("Время", 100, HorizontalAlignment.Left);

			searchTextBox.MaxLength = 80;
			tableLayoutPanel10.BackgroundImage = Resource1.banner;
			tableLayoutPanel10.Click += TableLayoutPanel10_Click;
			dateTimePicker1.MinDate = DateTime.Now;
		}

		private void TableLayoutPanel10_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Вы точно хотите увидеть эти флюиды в действии?", "Подумайте", MessageBoxButtons.YesNo) == DialogResult.Yes)
				throw new SystemException();
		}

		private void loginButton_Click(object sender, EventArgs e)
		{
			if (status != "Admin")
			{
				lf = new LoginForm();
				if (lf.ShowDialog() == DialogResult.Yes)
				{
					MessageBox.Show("Привет, Билл!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.setStatus("Admin", lf.login);
				}
				else
					MessageBox.Show("Вы не Билл Гейтс", "Не успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
			if (status == "Admin")
			{
				ap.currentLoginLabel.Text = this.currentLogin;
				this.Hide();
				DialogResult dr = ap.ShowDialog();
				if(resultListView.Items.Count != 0)
					this.buttonSearch_Click(null, null);
				if (dr == DialogResult.Cancel)
					this.Close();
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
			cmd.CommandText = "SELECT Films.name, Genres.Name, Films.lasting, Cinemas.name, Sessions.date, Sessions.start_time, Sessions.id FROM Films, Cinemas, Sessions, Genres WHERE Sessions.id_film = Films.id AND Sessions.id_cinema = Cinemas.id AND Films.id_genre = Genres.id ";
			if (timeCheckBox.Checked && minutesTextBox.Text != "" && hoursTextBox.Text != "")
			{
				DateTime dt = DateTime.Parse(Convert.ToInt32(hoursTextBox.Text) + ":" + Convert.ToInt32(minutesTextBox.Text));

				DateTime dtm = dt.Subtract(new TimeSpan(1, 0, 0));
				cmd.CommandText += String.Format("AND start_time >= '{0}' ", dtm.ToShortTimeString());

				DateTime dtp = dt.AddHours(1);
				if (dt.Hour != 23 && dt.Hour != 0)
					cmd.CommandText += String.Format("AND start_time <= '{0}' ", dtp.ToShortTimeString());

			}
			if (dateCheckBox.Checked)
			{
				cmd.CommandText += String.Format("AND date = convert(datetime, '{0}', 105) ", dateTimePicker1.Value.ToShortDateString());
			}
			if (genreCheckBox.Checked && genreComboBox.SelectedIndex != -1)
				cmd.CommandText += "AND Genres.name = '" + genreComboBox.SelectedItem.ToString() + "' ";
			if (cinemaCheckBox.Checked && cinemaComboBox.SelectedIndex != -1)
				cmd.CommandText += "AND Cinemas.name = '" + cinemaComboBox.SelectedItem.ToString() + "' ";
			resultListView.Items.Clear();

			try
			{
				dbR = cmd.ExecuteReader();
				while (dbR.Read())
				{
					if (!dbR.GetString(0).ToLower().Contains(searchTextBox.Text.ToLower()))
						continue;
					ListViewItem lvi = new ListViewItem(dbR.GetInt32(6).ToString());
					lvi.SubItems.Add(dbR.GetString(0));
					lvi.SubItems.Add(dbR.GetString(1));
					lvi.SubItems.Add(dbR.GetInt32(2).ToString());
					lvi.SubItems.Add(dbR.GetString(3));
					lvi.SubItems.Add(dbR.GetDateTime(4).ToShortDateString());
					lvi.SubItems.Add(((TimeSpan)dbR.GetValue(5)).ToString());

					resultListView.Items.Add(lvi);
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
			finally
			{
				dbR.Close();
				cn.Close();
			}
			if (resultListView.Items.Count == 0)
				MessageBox.Show("По вашему запросу ничего не найдено", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void checkBox_CheckedChanged(object sender, EventArgs e)
		{
			if (sender == timeCheckBox)
				hoursTextBox.Enabled = minutesTextBox.Enabled = timeCheckBox.Checked;
			else if (sender == dateCheckBox)
				dateTimePicker1.Enabled = dateCheckBox.Checked;
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
			if (Convert.ToInt32(hoursTextBox.Text) > 23)
			{
				MessageBox.Show("Ошибка ввода времени", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				hoursTextBox.Text = "";
			}
			if (hoursTextBox.Text.Length == 1)
				hoursTextBox.Text = hoursTextBox.Text.Insert(0, "0");
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
				MessageBox.Show("Ошибка ввода времени", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				minutesTextBox.Text = "";
			}
			if (minutesTextBox.Text.Length == 1)
				minutesTextBox.Text = minutesTextBox.Text.Insert(0, "0");
		}

		private void resultListView_DoubleClick(object sender, EventArgs e)
		{
			if (resultListView.SelectedItems.Count == 0)
				return;
			tb.sessionId = resultListView.SelectedItems[0].SubItems[0].Text;
			tb.status = this.status;
			tb.ShowDialog();
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