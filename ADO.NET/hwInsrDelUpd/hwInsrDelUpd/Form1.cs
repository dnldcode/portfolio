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

namespace hwInsrDelUpd
{
	public partial class Form1 : Form
	{
		private SqlConnection cn;
		private SqlDataAdapter A;
		SqlCommand cmdSel;
		private DataSet dataSet;
		public Form1()
		{
			InitializeComponent();

			this.cn = new SqlConnection();
			this.cn.ConnectionString = @"Data Source=10.3.21.100;Initial Catalog=sp2822;User ID=sp2822user;Password=sp2822pswd";
			cmdSel = this.cn.CreateCommand();
			this.A = new SqlDataAdapter(cmdSel);
			this.dataSet = new DataSet();
			foreach (String tblName in toolStripComboBox1.Items)
			{
				cmdSel.CommandText = "SELECT * FROM " + tblName + " ORDER BY id DESC";
				this.A.Fill(this.dataSet, tblName);
			}
		}

		private void Load()
		{
			dataSet.Clear();
			foreach (String tblName in toolStripComboBox1.Items)
			{
				cmdSel.CommandText = "SELECT * FROM " + tblName + " ORDER BY id DESC";
				this.A.Fill(this.dataSet, tblName);
			}
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			Load();
			this.dataGridView1.DataSource = this.dataSet.Tables[this.toolStripComboBox1.SelectedItem.ToString()];
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			SqlCommand cmdIns;
			SqlCommand cmdDel;
			SqlCommand cmdUpd;
			SqlParameter P;

			//Themes
			cmdIns = this.cn.CreateCommand();
			cmdIns.CommandText = "INSERT INTO Themes(name) VALUES(@name)";
			P = cmdIns.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdIns.Parameters.Add(P);
			this.A.InsertCommand = cmdIns;

			cmdDel = this.cn.CreateCommand();
			cmdDel.CommandText = "DELETE FROM Themes WHERE id = @id";
			P = cmdDel.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDel.Parameters.Add(P);
			this.A.DeleteCommand = cmdDel;

			cmdUpd = this.cn.CreateCommand();
			cmdUpd.CommandText = "UPDATE Themes SET name = @name WHERE id = @id";
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpd.Parameters.Add(P);
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpd.Parameters.Add(P);
			this.A.UpdateCommand = cmdUpd;

			this.A.Update(this.dataSet, "Themes");
			//Authors
			cmdIns = this.cn.CreateCommand();
			cmdIns.CommandText = "INSERT INTO Authors(FirstName, LastName) VALUES(@fname, @lname)";
			P = cmdIns.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@fname";
			P.SourceColumn = "FirstName";
			cmdIns.Parameters.Add(P);
			P = cmdIns.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@lname";
			P.SourceColumn = "LastName";
			cmdIns.Parameters.Add(P);
			this.A.InsertCommand = cmdIns;

			cmdDel = this.cn.CreateCommand();
			cmdDel.CommandText = "DELETE FROM Authors WHERE id = @id";
			P = cmdDel.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDel.Parameters.Add(P);
			this.A.DeleteCommand = cmdDel;

			cmdUpd = this.cn.CreateCommand();
			cmdUpd.CommandText = "UPDATE Authors SET FirstName = @fname, LastName = @lname WHERE id = @id";
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@fname";
			P.SourceColumn = "FirstName";
			cmdUpd.Parameters.Add(P);
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@lname";
			P.SourceColumn = "LastName";
			cmdUpd.Parameters.Add(P);
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpd.Parameters.Add(P);
			this.A.UpdateCommand = cmdUpd;

			this.A.Update(this.dataSet, "Authors");
			//Press
			cmdIns = this.cn.CreateCommand();
			cmdIns.CommandText = "INSERT INTO Press(name) VALUES(@name)";
			P = cmdIns.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdIns.Parameters.Add(P);
			this.A.InsertCommand = cmdIns;

			cmdDel = this.cn.CreateCommand();
			cmdDel.CommandText = "DELETE FROM Press WHERE id = @id";
			P = cmdDel.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDel.Parameters.Add(P);
			this.A.DeleteCommand = cmdDel;

			cmdUpd = this.cn.CreateCommand();
			cmdUpd.CommandText = "UPDATE Press SET name = @name WHERE id = @id";
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpd.Parameters.Add(P);
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpd.Parameters.Add(P);
			this.A.UpdateCommand = cmdUpd;

			this.A.Update(this.dataSet, "Press");
			//Faculties
			cmdIns = this.cn.CreateCommand();
			cmdIns.CommandText = "INSERT INTO Faculties(name) VALUES(@name)";
			P = cmdIns.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdIns.Parameters.Add(P);
			this.A.InsertCommand = cmdIns;

			cmdDel = this.cn.CreateCommand();
			cmdDel.CommandText = "DELETE FROM Faculties WHERE id = @id";
			P = cmdDel.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdDel.Parameters.Add(P);
			this.A.DeleteCommand = cmdDel;

			cmdUpd = this.cn.CreateCommand();
			cmdUpd.CommandText = "UPDATE Faculties SET name = @name WHERE id = @id";
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.String;
			P.ParameterName = "@name";
			P.SourceColumn = "name";
			cmdUpd.Parameters.Add(P);
			P = cmdUpd.CreateParameter();
			P.DbType = DbType.Int32;
			P.ParameterName = "@id";
			P.SourceColumn = "id";
			cmdUpd.Parameters.Add(P);
			this.A.UpdateCommand = cmdUpd;

			this.A.Update(this.dataSet, "Faculties");
			Load();
		}
	}
}
