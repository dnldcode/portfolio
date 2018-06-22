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
	public partial class TicketBooking : Form
	{
		private DbConnection cn;
		private DbDataReader dbR;
		private DbCommand cmd;
		private int rows, rowplaces;
		private List<Button>[] buttons;
		public String status;
		public String sessionId;

		public TicketBooking()
		{
			InitializeComponent();

			this.StartPosition = FormStartPosition.CenterParent;
		}

		private void TicketBooking_Load(object sender, EventArgs e)
		{
			this.cn = Connection.getInstance().connection;
			this.cmd = this.cn.CreateCommand();
			tableLayoutPanel1.Controls.Clear();
			cn.Open();
			this.cmd.CommandText = "SELECT Cinemas.rows, Cinemas.rowplaces, Cinemas.name, Films.name, Sessions.date, Sessions.start_time FROM Cinemas, Sessions, Films WHERE Sessions.id_cinema = Cinemas.id AND Sessions.id_film = Films.id AND Sessions.id = " + sessionId;
			this.dbR = this.cmd.ExecuteReader();
			this.dbR.Read();
			rows = this.dbR.GetInt32(0);
			rowplaces = this.dbR.GetInt32(1) + 1;
			infoLabel.Text = String.Format("Кинотеатр : {0}, Фильм : {1}, Дата : {2}, Время {3}", this.dbR.GetString(2), this.dbR.GetString(3), this.dbR.GetDateTime(4).ToShortDateString(), ((TimeSpan)this.dbR.GetValue(5)).ToString());
			this.Size = new Size(rowplaces * 50, rows * 40);
			this.dbR.Close();
			this.cn.Close();

			tableLayoutPanel1.ColumnCount = rowplaces;
			tableLayoutPanel1.RowCount = rows;

			tableLayoutPanel1.RowStyles.Clear();
			tableLayoutPanel1.ColumnStyles.Clear();

			buttons = new List<Button>[rows];
			for (int i = 0; i < rows; i++)
			{
				buttons[i] = new List<Button>();
				for (int j = 0; j < rowplaces; j++)
				{
					if (j != 0)
					{
						tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, (90 / rowplaces)));
						Button b = new Button();
						b.Text = j.ToString();
						b.Tag = String.Format("{0};{1}", i, j - 1);
						b.Click += B_Click;
						b.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom;
						b.TabStop = false;
						if (this.status == "Admin")
							b.Enabled = false;
						buttons[i].Add(b);
					}
					else
					{
						tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40));
						Label l = new Label();
						l.Text = (i + 1).ToString();
						l.Anchor = AnchorStyles.Right;
						l.Padding = new Padding(5);
						l.BackColor = Color.White;
						tableLayoutPanel1.Controls.Add(l, j, i);
					}
				}
				tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, (100 / rows)));
			}
			LoadPlaces();
		}

		private void LoadPlaces()
		{
			for (int i = 0; i < rows; i++)
				for (int j = 1; j < rowplaces; j++)
					tableLayoutPanel1.Controls.Add(buttons[i][j - 1], j, i);

			cn.Open();
			this.cmd.CommandText = "SELECT * FROM SoldTickets WHERE SoldTickets.id_session = " + sessionId;
			this.dbR = this.cmd.ExecuteReader();
			int temp1, temp2;
			while (this.dbR.Read())
			{
				temp1 = this.dbR.GetInt32(2);
				temp2 = this.dbR.GetInt32(3);
				if (this.status == "Guest")
					buttons[temp1][temp2].Enabled = false;
				else if(this.status == "Admin")
					buttons[temp1][temp2].Enabled = true;
			}
			this.dbR.Close();
			this.cn.Close();
		}

		private void B_Click(object sender, EventArgs e)
		{
			String[] ind = ((Button)sender).Tag.ToString().Split(';');
			cn.Open();
			if (this.status == "Guest")
			{
				if (MessageBox.Show(String.Format("Вы уверены, что хотите забронировать место : ряд - {0}, место - {1}?", Convert.ToInt32(ind[0]) + 1, Convert.ToInt32(ind[1]) + 1), "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					cn.Close();
					return;
				}
				this.cmd.CommandText = String.Format("INSERT INTO SoldTickets(id_session, row, rowplace) VALUES({0}, {1}, {2})", sessionId, ind[0], ind[1]);
			}
			else if (this.status == "Admin")
			{
				if (MessageBox.Show(String.Format("Вы уверены, что хотите снять бронь с места : ряд - {0}, место - {1}?", Convert.ToInt32(ind[0]) + 1, Convert.ToInt32(ind[1]) + 1), "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
				{
					cn.Close();
					return;
				}
				this.cmd.CommandText = String.Format("DELETE SoldTickets WHERE id_session = {0} AND row = {1} AND rowplace = {2}", sessionId, ind[0], ind[1]);
			}
			this.cmd.ExecuteNonQuery();
			((Button)sender).Enabled = false;
			cn.Close();
		}
	}
}