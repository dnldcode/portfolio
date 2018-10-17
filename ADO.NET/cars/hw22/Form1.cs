using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hw22
{
	public partial class Form1 : Form
	{
		SqlConnection cn;
		SqlCommand cmd;
		DataTable DT;
		List<int> deleted = new List<int>();
		public Form1()
		{
			InitializeComponent();
			cn = new SqlConnection();
			cn.ConnectionString = @"Data Source=DESKTOP-O4TTQ30;Initial Catalog=temp;Integrated Security=True";

			DT = new DataTable();
			DT.TableName = "Cars";
			DataColumn id = new DataColumn("id", typeof(int));
			id.Caption = "Ид";
			id.AutoIncrement = true;
			DT.Columns.Add(id);
			DataColumn marka = new DataColumn("marka", typeof(string));
			marka.Caption = "Марка";
			DT.Columns.Add(marka);
			DataColumn model = new DataColumn("model", typeof(string));
			model.Caption = "Модель";
			DT.Columns.Add(model);
			DataColumn year = new DataColumn("year", typeof(int));
			year.Caption = "Год";
			DT.Columns.Add(year);
			DataColumn color = new DataColumn("color", typeof(string));
			color.Caption = "Цвет";
			DT.Columns.Add(color);

			cn.Open();
			cmd = (SqlCommand)cn.CreateCommand();
			cmd.CommandText = "SELECT * FROM car";
			SqlDataReader R = cmd.ExecuteReader();
			while (R.Read())
			{
				DataRow DR = DT.NewRow();
				DR["id"] = R.GetInt32(0);
				DR["marka"] = R.GetString(1);
				DR["model"] = R.GetString(2);
				DR["year"] = R.GetInt32(3);
				DR["color"] = R.GetString(4);

				DT.Rows.Add(DR);
			}
			R.Close();
			cn.Close();
			DT.AcceptChanges();
			this.dataGridView1.DataSource = DT;
			this.dataGridView1.BackgroundColor = Color.White;
		}

		private void saveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (DT.Rows.Count <= 0)
			{
				MessageBox.Show("Изменений нет");
				return;
			}
			cn.Open();
			foreach (DataRow DR in DT.Rows)
			{
				try
				{
					if (DR.RowState == DataRowState.Added)
					{
						if (DR[1].ToString().Trim() == "" || DR[2].ToString().Trim() == ""  || DR[3].ToString().Trim() == "" || DR[4].ToString().Trim() == "")
						{
							MessageBox.Show("При добавлении не все поля были заполнены в строке : " + DR[0]);
							continue;
						}
						cmd.CommandText = String.Format("INSERT INTO Car (marka, model, year, color) VALUES ('{0}', '{1}', {2}, '{3}')", DR[1], DR[2], DR[3], DR[4]);
						cmd.ExecuteNonQuery();
					}
					else if (DR.RowState == DataRowState.Modified)
					{
						cmd.CommandText = String.Format("UPDATE Car SET marka = '{0}', model = '{1}', year = {2}, color = '{3}' WHERE id = {4}", DR[1], DR[2], DR[3], DR[4], DR[0]);
						cmd.ExecuteNonQuery();
					}
					else if (DR.RowState == DataRowState.Deleted)
					{
						cmd.CommandText = "DELETE Car WHERE id =" + DR[0, DataRowVersion.Original];
						cmd.ExecuteNonQuery();
					}
				}
				catch(Exception ee)
				{
					MessageBox.Show("Error : " + ee.Message);
				}
			}
			deleted.Clear();
			((DataTable)(this.dataGridView1.DataSource)).AcceptChanges();
			cn.Close();
			MessageBox.Show("Access");
		}
	}
}
