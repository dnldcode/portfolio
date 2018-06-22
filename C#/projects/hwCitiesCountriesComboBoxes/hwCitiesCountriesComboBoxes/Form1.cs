using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hwCitiesCountriesComboBoxes
{
	public partial class Form1 : Form
	{
		private SqlDataAdapter A;
		private DataSet DS;
		private SqlConnection cn;
		SqlCommand cmdInsCt;
		SqlCommand cmdDelCt;
		SqlCommand cmdUpdCt;
		SqlCommand cmdInsC;
		SqlCommand cmdDelC;
		SqlCommand cmdUpdC;
		private DataTable dt = new DataTable("Countries");
		public Form1()
		{
			InitializeComponent();

			this.DS = new DataSet();
			this.cn = new SqlConnection();
			this.cn.ConnectionString = @"Data Source=DESKTOP-O4TTQ30;Initial Catalog=master;Integrated Security=True";

			Load();
			SqlParameter P;
			//Countries
			cmdInsCt = this.cn.CreateCommand();
			cmdInsCt.CommandText = "INSERT INTO Countries(name) VALUES(@name)";
			P = cmdInsCt.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdInsCt.Parameters.Add(P);

			cmdDelCt = this.cn.CreateCommand();
			cmdDelCt.CommandText = "DELETE FROM Countries WHERE id = @id";
			P = cmdDelCt.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDelCt.Parameters.Add(P);

			cmdUpdCt = this.cn.CreateCommand();
			cmdUpdCt.CommandText = "UPDATE Countries SET name = @name WHERE id = @id";
			P = cmdUpdCt.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpdCt.Parameters.Add(P);
			P = cmdUpdCt.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpdCt.Parameters.Add(P);
			//Cities
			cmdInsC = this.cn.CreateCommand();
			cmdInsC.CommandText = "INSERT INTO Cities(name, id_country) VALUES(@name1, @id_country)";
			P = cmdInsC.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name1";
			P.SourceColumn = "name";
			cmdInsC.Parameters.Add(P);
			P = cmdInsC.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_country";
			P.SourceColumn = "id_country";
			cmdInsC.Parameters.Add(P);	

			cmdDelC = this.cn.CreateCommand();
			cmdDelC.CommandText = "DELETE FROM Cities WHERE id = @id";
			P = cmdDelC.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDelC.Parameters.Add(P);

			cmdUpdC = this.cn.CreateCommand();
			cmdUpdC.CommandText = "UPDATE Cities SET name = @name, id_country = @id_country WHERE id = @id";
			P = cmdUpdC.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpdC.Parameters.Add(P);
			P = cmdUpdC.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id_country";
			P.SourceColumn = "id_country";
			cmdUpdC.Parameters.Add(P);
			P = cmdUpdC.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpdC.Parameters.Add(P);
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Load();
			this.dataGridView1.DataSource = this.DS.Tables[this.toolStripComboBox1.SelectedItem.ToString()];
			if(toolStripComboBox1.SelectedIndex == 1)
			{
				DataSet temp = new DataSet();
				SqlCommand cmdSel = (SqlCommand)this.cn.CreateCommand();
				this.A = new SqlDataAdapter(cmdSel);
				foreach (String table in toolStripComboBox1.Items)
				{
					cmdSel.CommandText = "SELECT * FROM " + table;
					this.A.Fill(temp, table);
				}
				DataGridViewComboBoxColumn cbcol = new DataGridViewComboBoxColumn();
				cbcol.Name = "country";
				cbcol.FlatStyle = FlatStyle.Flat; //стиль комбобокса
				cbcol.DataSource = temp.Tables["Countries"]; // из какой таблицы данные
				cbcol.ValueMember = "id"; //столбец из которого берутся значения для сохранения
				cbcol.DisplayMember = "name"; // значение для отображения
				cbcol.DataPropertyName = "id_country"; //столбец, данные которого должны использоваться для столбца комбобокса
				this.dataGridView1.Columns.Add(cbcol); // добавляем стобец в DataGridView
				this.dataGridView1.Columns["id_country"].Visible = false; //столбец внешнего делаем невидимым
			}
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			if (toolStripComboBox1.SelectedIndex == 0)
			{
				this.A.InsertCommand = cmdInsCt;
				this.A.DeleteCommand = cmdDelCt;
				this.A.UpdateCommand = cmdUpdCt;
				try
				{
					this.A.Update(this.DS, "Countries");
				}
				catch
				{
					MessageBox.Show("Нарушение связей");
				}
			}
			else
			{
				this.A.InsertCommand = cmdInsC;
				this.A.DeleteCommand = cmdDelC;
				this.A.UpdateCommand = cmdUpdC;
				try
				{
					this.A.Update(this.DS, "Cities");
				}
				catch
				{
					MessageBox.Show("Нарушение связей");
				}
			}
			Load();
		}
		private void Load()
		{
			DS.Clear();
			SqlCommand cmdSel = (SqlCommand)this.cn.CreateCommand();
			this.A = new SqlDataAdapter(cmdSel);
			foreach (String table in toolStripComboBox1.Items)
			{
				cmdSel.CommandText = "SELECT * FROM " + table;
				this.A.Fill(this.DS, table);
			}
		}

		private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message);
		}
	}
}