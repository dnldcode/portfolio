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
	public partial class AdminPanel : Form
	{
		private String currentLogin = "";
		private DbConnection cn;
		private DbDataAdapter A;
		private DbCommand cmd;
		private DbDataReader dbR;
		private DataSet dataSet = new DataSet();
		private String[] TableNames =
			{
					"Films", "Sessions", "Genres", "Cinemas"
			};
		private int currentId;
		DataGridViewComboBoxColumn filmGenre;
		DataGridViewComboBoxColumn sessionsFilm;
		DataGridViewComboBoxColumn sessionsCinema;
		AddingSessionsForm asf;
		public bool isConnected = false;
		public AdminPanel()
		{
			InitializeComponent();

			this.cn = Connection.getInstance().connection;
			this.cmd = this.cn.CreateCommand();
			this.A = Connection.getInstance().adapter;
			this.A.SelectCommand = cmd;

			try
			{
				LoadTables();
			}
			catch
			{
				MessageBox.Show("Ошибка соединения. Попробуйте пожалуйста позже.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				isConnected = false;
				this.Close();
				return;
			}

			this.BackColor = Color.GhostWhite;

			this.currentLoginLabel.Text = this.currentLogin;
			this.StartPosition = FormStartPosition.CenterParent;
			tableLayoutPanel3.BackColor = Color.LightGray;
			tableLayoutPanel4.BackColor = Color.White;
			logoutLink.BackColor = Color.White;
			tableLayoutPanel7.BackColor = Color.White;
			label2.BackColor = Color.White;
			this.FormClosing += AdminPanel_FormClosing;
			dataGridView1.BackgroundColor = Color.White;
			splitContainer1.BackColor = Color.LightGray;

			isConnected = true;
			//FilmsColumn
			filmGenre = new DataGridViewComboBoxColumn();
			filmGenre.Name = "genre";
			filmGenre.FlatStyle = FlatStyle.Flat;
			filmGenre.DataSource = this.dataSet.Tables["Genres"];
			filmGenre.ValueMember = "id";
			filmGenre.DisplayMember = "name";
			filmGenre.DataPropertyName = "id_genre";
			//SessionsColumns
			//Film
			sessionsFilm = new DataGridViewComboBoxColumn();
			sessionsFilm.Name = "films";
			sessionsFilm.FlatStyle = FlatStyle.Flat;
			sessionsFilm.DataSource = this.dataSet.Tables["Films"];
			sessionsFilm.ValueMember = "id";
			sessionsFilm.DisplayMember = "name";
			sessionsFilm.DataPropertyName = "id_film";
			//Cinema
			sessionsCinema = new DataGridViewComboBoxColumn();
			sessionsCinema.Name = "cinema";
			sessionsCinema.FlatStyle = FlatStyle.Flat;
			sessionsCinema.DataSource = this.dataSet.Tables["Cinemas"];
			sessionsCinema.ValueMember = "id";
			sessionsCinema.DisplayMember = "name";
			sessionsCinema.DataPropertyName = "id_cinema";
		}

		private void AdminPanel_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (saveNotification())
			{
				e.Cancel = true;
				return;
			}
			if (e.CloseReason == CloseReason.UserClosing)
				this.DialogResult = DialogResult.Cancel;
		}

		private void logoutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (saveNotification())
				return;
			this.DialogResult = DialogResult.Abort;
		}

		private bool saveNotification()
		{
			if (dataSet.Tables[TableNames[currentId]].GetChanges() != null)
			{
				DialogResult dr = MessageBox.Show(String.Format("Вы хотите сохранить изменения в таблице \"{0}\"?", TableNames[currentId]), "Предупреждение.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
				if (dr == DialogResult.Yes)
					return !SaveInfo();
				else if (dr == DialogResult.Cancel)
					return true;
			}
			return false;
		}

		private void buttons_Click(object sender, EventArgs e)
		{
			if (saveNotification())
				return;

			LoadTables();
			if (sender == button1)
				this.currentId = 0;
			else if (sender == button2)
				this.currentId = 1;
			else if (sender == button3)
				this.currentId = 2;
			else if (sender == button4)
				this.currentId = 3;

			addSessionButton.Visible = this.currentId == 1;
			if (this.dataGridView1.DataSource == this.dataSet.Tables[TableNames[currentId]])
				return;
			this.dataGridView1.Columns.Clear();
			this.dataGridView1.DataSource = this.dataSet.Tables[TableNames[currentId]];

			if (sender == button1)
			{
				this.dataGridView1.Columns.Add(filmGenre);
				this.dataGridView1.Columns["id_genre"].Visible = false;
			}
			else if (sender == button2)
			{
				this.dataGridView1.Columns.Add(sessionsFilm);
				this.dataGridView1.Columns.Add(sessionsCinema);
				this.dataGridView1.Columns["id_film"].Visible = false;
				this.dataGridView1.Columns["id_cinema"].Visible = false;
			}
		}

		private void goBackButton_Click(object sender, EventArgs e)
		{
			if (saveNotification())
				return;
			this.DialogResult = DialogResult.OK;
			this.Hide();
		}

		private void LoadTables()
		{
			dataSet.Clear();
			foreach (String name in TableNames)
			{
				this.cmd.CommandText = "SELECT * FROM " + name + " ORDER BY id ASC";
				this.A.Fill(this.dataSet, name);
			}
		}

		private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			SaveInfo();
		}

		private bool SaveInfo()
		{
			if (dataSet.Tables[TableNames[currentId]].GetChanges() == null)
				return true;
			if (dataSet.Tables.Count == 0)
				return true;
			cn.Open();
			bool error = false;
			foreach (DataRow DR in dataSet.Tables[TableNames[currentId]].Rows)
			{
				if (currentId == 0)
				{
					if (DR.RowState != DataRowState.Deleted && DR[1].ToString().Trim() == "")
					{
						error = true;
						continue;
					}
					if (DR.RowState == DataRowState.Added)
						cmd.CommandText = String.Format("INSERT INTO Films (name, id_genre, lasting) VALUES ('{0}', {1}, {2})", DR[1], DR[2], DR[3]);
					else if (DR.RowState == DataRowState.Modified)
						cmd.CommandText = String.Format("UPDATE Films SET name = '{0}', id_genre = {1}, lasting = {2} WHERE id = {3}", DR[1], DR[2], DR[3], DR[0]);
					else if (DR.RowState == DataRowState.Deleted)
						cmd.CommandText = "DELETE Films WHERE id =" + DR[0, DataRowVersion.Original];
				}
				else if (currentId == 1)
				{
					if (DR.RowState == DataRowState.Added)
						cmd.CommandText = String.Format("INSERT INTO Sessions (id_film, id_cinema, date, start_time) VALUES ({0}, {1}, '{2}', '{3}')", DR[1], DR[2], DR[3], DR[4]);
					else if (DR.RowState == DataRowState.Modified)
						cmd.CommandText = String.Format("UPDATE Sessions SET id_film = {0}, id_cinema = {1}, date = convert(datetime, '{2}', 105), start_time = '{3}' WHERE id = {4}", DR[1], DR[2], DR[3], DR[4], DR[0]);
					else if (DR.RowState == DataRowState.Deleted)
						cmd.CommandText = "DELETE Sessions WHERE id =" + DR[0, DataRowVersion.Original];
				}
				else if (currentId == 2)
				{
					if (DR.RowState != DataRowState.Deleted && DR[1].ToString().Trim() == "")
					{
						error = true;
						continue;
					}
					if (DR.RowState == DataRowState.Added)
						cmd.CommandText = String.Format("INSERT INTO Genres (name) VALUES ('{0}')", DR[1]);
					else if (DR.RowState == DataRowState.Modified)
						cmd.CommandText = String.Format("UPDATE Genres SET name = '{0}' WHERE id = {1}", DR[1], DR[0]);
					else if (DR.RowState == DataRowState.Deleted)
						cmd.CommandText = "DELETE Genres WHERE id =" + DR[0, DataRowVersion.Original];
				}
				else if (currentId == 3)
				{
					if (DR.RowState != DataRowState.Deleted && DR[1].ToString().Trim() == "")
					{
						error = true;
						continue;
					}
					if (DR.RowState == DataRowState.Added)
						cmd.CommandText = String.Format("INSERT INTO Cinemas (name, rows, rowplaces) VALUES ('{0}', {1}, {2})", DR[1], DR[2], DR[3]);
					else if (DR.RowState == DataRowState.Modified)
					{
						this.cmd.CommandText = "SELECT SoldTickets.row, SoldTickets.rowplace FROM SoldTickets, Cinemas, Sessions WHERE SoldTickets.id_session = Sessions.id AND Sessions.id_cinema = Cinemas.id AND Cinemas.id = " + DR[0];
						this.dbR = this.cmd.ExecuteReader();
						int temp1, temp2;
						int q = 0;
						while (this.dbR.Read())
						{
							temp1 = this.dbR.GetInt32(0);
							temp2 = this.dbR.GetInt32(1);
							if (temp1 > ((int)DR[2] - 1) || temp2 > ((int)DR[3] - 1))
							{
								MessageBox.Show("Невозможно изменить размеры зала, т.к места уже забронированны.", "Ошибка");
								q = 1;
								break;
							}
						}
						this.dbR.Close();
						if (q != 1)
							cmd.CommandText = String.Format("UPDATE Cinemas SET name = '{0}', rows = {1}, rowplaces = {2} WHERE id = {3}", DR[1], DR[2], DR[3], DR[0]);
					}
					else if (DR.RowState == DataRowState.Deleted)
						cmd.CommandText = "DELETE Cinemas WHERE id =" + DR[0, DataRowVersion.Original];
				}
				if (DR.RowState == DataRowState.Added || DR.RowState == DataRowState.Modified || DR.RowState == DataRowState.Deleted)
				{
					try
					{
						cmd.ExecuteNonQuery();
					}
					catch
					{
						error = true;
					}
				}
			}
			cn.Close();

			if (!error)
				LoadTables();
			else
			{
				MessageBox.Show("Ошибка сохранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (currentId == 1)
			{
				String temp = "";
				for (int i = 0; i < 4; i++)
					temp += dataGridView1[i, dataGridView1.CurrentCell.RowIndex].Value.ToString();
				if (temp == "")
					this.addSessionButton_Click(null, null);
			}
		}

		private void addSessionButton_Click(object sender, EventArgs e)
		{
			asf = new AddingSessionsForm();
			if (asf.ShowDialog() == DialogResult.OK)
				LoadTables();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (saveNotification())
				return;
			LoadTables();
		}
	}
}