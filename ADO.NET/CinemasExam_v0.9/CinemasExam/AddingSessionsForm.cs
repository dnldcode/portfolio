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
	public partial class AddingSessionsForm : Form
	{
		private DbConnection cn;
		private DbCommand cmd;
		private DataSet dataSet = new DataSet();
		private DbDataReader dbR;
		public AddingSessionsForm()
		{
			InitializeComponent();

			this.cn = Connection.getInstance().connection;
			this.cmd = this.cn.CreateCommand();

			this.StartPosition = FormStartPosition.CenterParent;
			this.BackColor = Color.LightGray;
			tableLayoutPanel2.BackColor = Color.White;
			tableLayoutPanel3.BackColor = Color.White;
			tableLayoutPanel4.BackColor = Color.White;
			tableLayoutPanel5.BackColor = Color.White;
			tableLayoutPanel6.BackColor = Color.White;

			cn.Open();
			cmd = cn.CreateCommand();
			cmd.CommandText = "SELECT * FROM Cinemas ORDER BY 1 ASC";
			dbR = cmd.ExecuteReader();
			while (dbR.Read())
				cinemaComboBox.Items.Add(dbR.GetString(1));
			dbR.Close();
			cmd.CommandText = "SELECT * FROM Films ORDER BY 1 ASC";
			dbR = cmd.ExecuteReader();
			while (dbR.Read())
				filmComboBox.Items.Add(dbR.GetString(1));
			dbR.Close();

			cn.Close();
			cinemaComboBox.SelectedIndex = -1;
			filmComboBox.SelectedIndex = -1;

			timeTextBox.MaxLength = 5;
			daysTextBox.MaxLength = 2;
			timeTextBox.TextAlign = HorizontalAlignment.Center;
			daysTextBox.TextAlign = HorizontalAlignment.Center;
			this.FormClosing += AddingSessionsForm_FormClosing;
			dateTimePicker1.MinDate = DateTime.Now;
		}

		private void AddingSessionsForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				this.DialogResult = DialogResult.OK;
		}

		private void buttonAdd_Click(object sender, EventArgs e)
		{
			DateTime dt;
			TimeSpan ts;
			int days;
			String film, cinema;
			try
			{
				dt = dateTimePicker1.Value;
				ts = TimeSpan.Parse(timeTextBox.Text);
				days = Convert.ToInt32(daysTextBox.Text);
				film = filmComboBox.SelectedItem.ToString();
				cinema = cinemaComboBox.SelectedItem.ToString();
			}
			catch
			{
				MessageBox.Show("Ошибка ввода данных. Пожалуйста проверьте правильность написания информации.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			cn.Open();
			cmd = cn.CreateCommand();
			if (MessageBox.Show(String.Format("Вы точно хотите добавить прокат фильма \"{0}\" в кинотеатре \"{1}\" на {2} дней в {3} начиная с {4}?", film, cinema, days, ts, dt.ToShortDateString()), "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
				return;
			bool error;
			for (int i = 0; i < days; i++)
			{
				error = false;
				this.cmd.CommandText = "SELECT Sessions.id, Films.name, Cinemas.name, Sessions.date, Sessions.start_time, Films.lasting FROM Sessions, Films, Cinemas WHERE Sessions.id_film = Films.id AND Sessions.id_cinema = Cinemas.id AND Cinemas.name = '" + cinema + "' ";
				this.dbR = this.cmd.ExecuteReader();
				while (this.dbR.Read())
				{
					object t = dbR.GetValue(4);
					TimeSpan t2 = (TimeSpan)t;
					if ((t2 < ts && t2.TotalMinutes + dbR.GetInt32(5) > ts.TotalMinutes && dt.ToShortDateString() == dbR.GetDateTime(3).ToShortDateString())
					 ||	(t2 > ts && t2.TotalMinutes < ts.TotalMinutes + dbR.GetInt32(5) && dt.ToShortDateString() == dbR.GetDateTime(3).ToShortDateString()))
					{
						MessageBox.Show(String.Format("В {0} {1} уже идет фильм.", dt.ToShortDateString(), ts.ToString()), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						error = true;
						break;
					}
					else if (t2 == ts && dt.ToShortDateString() == dbR.GetDateTime(3).ToShortDateString())
					{
						MessageBox.Show(String.Format("Вы не можете добавить новый сеанс на {3} {0}, т.к. в это же время в кинотеатре {1} начинается другой сеанс показа \"{2}\"", ts.ToString(), dbR.GetString(2), cinema, dt), "Ошибка", MessageBoxButtons.OK);
						error = true;
						break;
					}
				}
				this.dbR.Close();
				if (error == false)
				{
					cmd.CommandText = String.Format("INSERT INTO Sessions(id_film, id_cinema, date, start_time) VALUES((SELECT Films.id FROM Films WHERE Films.name = '{0}'), (SELECT Cinemas.id FROM Cinemas where Cinemas.name = '{1}'), convert(datetime, '{2}', 105), '{3}')", film, cinema, dt.ToShortDateString(), ts.ToString());
					cmd.ExecuteNonQuery();
				}
				dt = dt.AddDays(1);
			}
			cn.Close();
		}

		private void daysTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if ((e.KeyChar < 48 || e.KeyChar >= 59) && e.KeyChar != 8)
				e.Handled = true;
		}

		private void timeTextBox_Leave(object sender, EventArgs e)
		{
			if (timeTextBox.Text == "")
				return;
			if (!timeTextBox.Text.Contains(":"))
			{
				timeTextBox.Text = "";
				MessageBox.Show("Неверный формат ввода времени", "Ошибка");
			}
		}

		private void daysTextBox_Leave(object sender, EventArgs e)
		{
			if (daysTextBox.Text != "")
			{
				if (Convert.ToInt32(daysTextBox.Text) == 0)
				{
					MessageBox.Show("Невозможно добавить на 0 дней", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					daysTextBox.Text = "";
				}
			}
		}
	}
}