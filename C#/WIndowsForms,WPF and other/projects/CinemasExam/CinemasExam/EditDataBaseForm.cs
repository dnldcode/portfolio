using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CinemasExam
{
	public partial class EditDataBaseForm : Form
	{
		private String[] names =
						{
							"Films", "Sessions", "Genres", "Cinemas"
						};
		private DbConnection cn;
		private DbDataAdapter A;
		private DbCommand cmd;
		private DataSet DS = new DataSet();
		public int ind;
		DbCommand cmdInsGenres;
		DbCommand cmdDelGenres;
		DbCommand cmdUpdGenres;
		DbCommand cmdInsCinemas;
		DbCommand cmdDelCinemas;
		DbCommand cmdUpdCinemas;
		DbCommand cmdInsFilms;
		DbCommand cmdDelFilms;
		DbCommand cmdUpdFilms;
		DbCommand cmdInsSessions;
		DbCommand cmdDelSessions;
		DbCommand cmdUpdSessions;
		DataGridViewComboBoxColumn filmGenre;
		public EditDataBaseForm()
		{
			InitializeComponent();
			dataGridView1.BackgroundColor = Color.LightGray;
			this.StartPosition = FormStartPosition.CenterParent;

			this.cn = Connection.getInstance().connection;
			this.A = Connection.getInstance().adapter;
			this.cmd = cn.CreateCommand();
			this.A.SelectCommand = cmd;
			DbParameter P;
			//Genres
			cmdInsGenres = this.cn.CreateCommand();
			cmdInsGenres.CommandText = "INSERT INTO Genres(name) VALUES(@name)";
			P = cmdInsGenres.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdInsGenres.Parameters.Add(P);

			cmdDelGenres = this.cn.CreateCommand();
			cmdDelGenres.CommandText = "DELETE FROM Genres WHERE id = @id";
			P = cmdDelGenres.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDelGenres.Parameters.Add(P);

			cmdUpdGenres = this.cn.CreateCommand();
			cmdUpdGenres.CommandText = "UPDATE Genres SET name = @name WHERE id = @id";
			P = cmdUpdGenres.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpdGenres.Parameters.Add(P);
			P = cmdUpdGenres.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpdGenres.Parameters.Add(P);
			//Cinemas
			cmdInsCinemas = this.cn.CreateCommand();
			cmdInsCinemas.CommandText = "INSERT INTO Cinemas(name, rows, rowplaces) VALUES(@name, @rows, @rowplaces)";
			P = cmdInsCinemas.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdInsCinemas.Parameters.Add(P);
			P = cmdInsCinemas.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@rows";
			P.SourceColumn = "rows";
			cmdInsCinemas.Parameters.Add(P);
			P = cmdInsCinemas.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@rowplaces";
			P.SourceColumn = "rowplaces";
			cmdInsCinemas.Parameters.Add(P);

			cmdDelCinemas = this.cn.CreateCommand();
			cmdDelCinemas.CommandText = "DELETE FROM Cinemas WHERE id = @id";
			P = cmdDelCinemas.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDelCinemas.Parameters.Add(P);

			cmdUpdCinemas = this.cn.CreateCommand();
			cmdUpdCinemas.CommandText = "UPDATE Cinemas SET name = @name, rows = @rows, rowplaces = @rowplaces WHERE id = @id";
			P = cmdUpdCinemas.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpdCinemas.Parameters.Add(P);
			P = cmdUpdCinemas.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@rows";
			P.SourceColumn = "rows";
			cmdUpdCinemas.Parameters.Add(P);
			P = cmdUpdCinemas.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@rowplaces";
			P.SourceColumn = "rowplaces";
			cmdUpdCinemas.Parameters.Add(P);
			P = cmdUpdCinemas.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpdCinemas.Parameters.Add(P);
			//Films
			cmdInsFilms = this.cn.CreateCommand();
			cmdInsFilms.CommandText = "INSERT INTO Films(name, id_genre, lasting) VALUES(@name, @id_genre, @lasting)";
			P = cmdInsFilms.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdInsFilms.Parameters.Add(P);
			P = cmdInsFilms.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_genre";
			P.SourceColumn = "id_genre";
			cmdInsFilms.Parameters.Add(P);
			P = cmdInsFilms.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@lasting";
			P.SourceColumn = "lasting";
			cmdInsFilms.Parameters.Add(P);

			cmdDelFilms = this.cn.CreateCommand();
			cmdDelFilms.CommandText = "DELETE FROM Films WHERE id = @id";
			P = cmdDelFilms.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDelFilms.Parameters.Add(P);

			cmdUpdFilms = this.cn.CreateCommand();
			cmdUpdFilms.CommandText = "UPDATE Films SET name = @name, id_genre = @id_genre, lasting = @lasting WHERE id = @id";
			P = cmdUpdFilms.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpdFilms.Parameters.Add(P);
			P = cmdUpdFilms.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_genre";
			P.SourceColumn = "id_genre";
			cmdUpdFilms.Parameters.Add(P);
			P = cmdUpdFilms.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@lasting";
			P.SourceColumn = "lasting";
			cmdUpdFilms.Parameters.Add(P);
			P = cmdUpdFilms.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpdFilms.Parameters.Add(P);
			//Sessions
			cmdInsSessions = this.cn.CreateCommand();
			cmdInsSessions.CommandText = "INSERT INTO Sessions(id_film, id_cinema, date, start_time) VALUES(@id_film, @id_cinema, @date, @start_time)";
			P = cmdInsSessions.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_film";
			P.SourceColumn = "id_film";
			cmdInsSessions.Parameters.Add(P);
			P = cmdInsSessions.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_cinema";
			P.SourceColumn = "id_cinema";
			cmdInsSessions.Parameters.Add(P);
			P = cmdInsSessions.CreateParameter();
			P.DbType = DbType.Date;
			P.ParameterName = "@date";
			P.SourceColumn = "date";
			cmdInsSessions.Parameters.Add(P);
			P = cmdInsSessions.CreateParameter();
			P.DbType = DbType.Time;
			P.ParameterName = "@start_time";
			P.SourceColumn = "start_time";
			cmdInsSessions.Parameters.Add(P);

			cmdDelSessions = this.cn.CreateCommand();
			cmdDelSessions.CommandText = "DELETE FROM Sessions WHERE id = @id";
			P = cmdDelSessions.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDelSessions.Parameters.Add(P);

			cmdUpdSessions = this.cn.CreateCommand();
			cmdUpdSessions.CommandText = "UPDATE Genres SET id_film = @id_film, id_cinema = @id_cinema, date = @date, start_time = @start_time WHERE id = @id";
			P = cmdUpdSessions.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_film";
			P.SourceColumn = "id_film";
			cmdUpdSessions.Parameters.Add(P);
			P = cmdUpdSessions.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_cinema";
			P.SourceColumn = "id_cinema";
			cmdUpdSessions.Parameters.Add(P);
			P = cmdUpdSessions.CreateParameter();
			P.DbType = DbType.Date;
			P.ParameterName = "@date";
			P.SourceColumn = "date";
			cmdUpdSessions.Parameters.Add(P);
			P = cmdUpdSessions.CreateParameter();
			P.DbType = DbType.DateTime;
			P.ParameterName = "@start_time";
			P.SourceColumn = "start_time";
			cmdUpdSessions.Parameters.Add(P);
			P = cmdUpdSessions.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpdSessions.Parameters.Add(P);
			//ComboBoxes
			LoadTable();
			filmGenre = new DataGridViewComboBoxColumn();
			filmGenre.Name = "genre";
			filmGenre.FlatStyle = FlatStyle.Flat;
			filmGenre.DataSource = this.DS.Tables["Genres"];
			filmGenre.ValueMember = "id";
			filmGenre.DisplayMember = "name";
			filmGenre.DataPropertyName = "id_genre";
		}

		private void LoadTable()
		{
			DS.Clear();
			foreach (String tblName in names)
			{
				cmd.CommandText = "SELECT * FROM " + tblName + " ORDER BY id ASC";
				this.A.Fill(this.DS, tblName);
			}
		}

		private void saveButton_Click(object sender, EventArgs e)
		{
			if (ind == 0)
			{
				this.A.InsertCommand = cmdInsFilms;
				this.A.DeleteCommand = cmdDelFilms;
				this.A.UpdateCommand = cmdUpdFilms;
			}
			else if (ind == 1)
			{
				this.A.InsertCommand = cmdInsSessions;
				this.A.DeleteCommand = cmdDelSessions;
				this.A.UpdateCommand = cmdUpdSessions;
			}
			else if (ind == 2)
			{
				this.A.InsertCommand = cmdInsGenres;
				this.A.DeleteCommand = cmdDelGenres;
				this.A.UpdateCommand = cmdUpdGenres;
			}
			else if (ind == 3)
			{
				this.A.InsertCommand = cmdInsCinemas;
				this.A.DeleteCommand = cmdDelCinemas;
				this.A.UpdateCommand = cmdUpdCinemas;
			}
			this.A.Update(this.DS, names[ind]);
			LoadTable();
		}

		private void EditDataBaseForm_Load(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = null;
			this.dataGridView1.DataSource = this.DS.Tables[names[ind]];
			this.Text = names[ind];
			if (ind == 0)
			{
				this.dataGridView1.Columns.Add(filmGenre);
				this.dataGridView1.Columns["id_genre"].Visible = false;
			}
			else if (ind == 1)
			{
				
			}
			else if (ind == 2)
			{
				
			}
			else if (ind == 3)
			{
				
			}
		}

		private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			//String temp;
			//for (int i = 0; i < 4; i++)
			//MessageBox.Show(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString());

		}
	}
}