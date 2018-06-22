using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hwrelations
{
	public partial class Form1 : Form
	{
		DataSet DS;
		public Form1()
		{
			InitializeComponent();
			dataGridView1.BackgroundColor = dataGridView2.BackgroundColor = Color.White;

			DS = new DataSet();
			SqlConnection cn = new SqlConnection();
			cn.ConnectionString = @"Data Source=DESKTOP-O4TTQ30;Initial Catalog=master;Integrated Security=True";
			SqlCommand cmd = cn.CreateCommand();
			cmd.CommandText = "SELECT * FROM Countries";
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			da.Fill(DS, "Countries");
			cmd.CommandText = "SELECT * FROM Cities";
			da.Fill(DS, "Cities");

			dataGridView2.ColumnCount = 1;
			dataGridView2.Columns[0].Name = "Город";

			


			DataRelation DR1 = new DataRelation("CityCountryRelation", DS.Tables["Countries"].Columns["id"], DS.Tables["Cities"].Columns["id_country"], true);
			DS.Relations.Add(DR1);
			dataGridView1.DataSource = DS.Tables["Countries"];

		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			dataGridView2.Rows.Clear();
			try
			{
				DataRow[] childRows = DS.Tables["Countries"].Rows[(int)((DataTable)this.dataGridView1.DataSource).Rows[dataGridView1.SelectedCells[0].RowIndex][0] - 1].GetChildRows(DS.Relations["CityCountryRelation"]);
				for (int i = 0; i < childRows.Length; i++)
					dataGridView2.Rows.Add(childRows[i]["name"]);
			}
			catch { }
		}
	}
}