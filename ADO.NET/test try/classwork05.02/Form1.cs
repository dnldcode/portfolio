using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace classwork05._02
{
	public partial class Form1 : Form
	{
		private DbConnection cn;
		private DbDataAdapter A;
		private DataSet dataSet;
		public Form1()
		{
			InitializeComponent();
			String[] tblNames =
			{
				"Authors", "Themes", "Press", "Faculties"
			};
			this.cn = new OleDbConnection();
			this.cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Library.accdb";

			DbCommand cmdSel = this.cn.CreateCommand();
			this.A = new OleDbDataAdapter((OleDbCommand)cmdSel);
			this.dataSet = new DataSet();

			foreach(String tblName in tblNames)
			{
				cmdSel.CommandText = "SELECT * FROM " + tblName;
				this.A.Fill(this.dataSet, tblName);
			}
			this.dataGridView1.DataSource = this.dataSet.Tables[tblNames[0]];
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			//	DbCommand cmdIns = this.cn.CreateCommand();
			//	cmdIns.CommandText = "INSERT INTO Themes(name) VALUES(@name)";
			//	DbParameter P1 = cmdIns.CreateParameter();
			//	P1.DbType = DbType.String;
			//	P1.ParameterName = "@name";
			//	P1.SourceColumn = "name";
			//	cmdIns.Parameters.Add(P1);
			//	this.A.InsertCommand = cmdIns;

			//	DbCommand cmdDel = this.cn.CreateCommand();
			//	cmdDel.CommandText = "DELETE FROM Themes WHERE id = @id";
			//	DbParameter P2 = cmdDel.CreateParameter();
			//	P2.DbType = DbType.Int32;
			//	P2.ParameterName = "@id";
			//	P2.SourceColumn = "id";
			//	cmdDel.Parameters.Add(P2);
			//	this.A.DeleteCommand = cmdDel;

			//	DbCommand cmdUpd = this.cn.CreateCommand();
			//	cmdUpd.CommandText = "UPDATE Themes SET name = @name WHERE id = @id";
			//	DbParameter P3 = cmdUpd.CreateParameter();
			//	P3.DbType = DbType.String;
			//	P3.ParameterName = "@name";
			//	P3.SourceColumn = "name";
			//	DbParameter P4 = cmdUpd.CreateParameter();
			//	P4.DbType = DbType.Int32;
			//	P4.ParameterName = "@id";
			//	P4.SourceColumn = "id";
			//	cmdUpd.Parameters.Add(P3);
			//	cmdUpd.Parameters.Add(P4);
			//	this.A.UpdateCommand = cmdUpd;

			//	this.A.Update(this.dataSet, "Themes");

			DbCommand cmdInsAuth = this.cn.CreateCommand();
			cmdInsAuth.CommandText = "INSERT INTO Authors(FirstName, LastName) VALUES(@fname, @lname)";
			DbParameter P5 = cmdInsAuth.CreateParameter();
			P5.DbType = DbType.String;
			P5.ParameterName = "@fname";
			P5.SourceColumn = "FirstName";
			cmdInsAuth.Parameters.Add(P5);
			DbParameter P6 = cmdInsAuth.CreateParameter();
			P6.DbType = DbType.String;
			P6.ParameterName = "@lname";
			P6.SourceColumn = "LastName";
			cmdInsAuth.Parameters.Add(P6);
			this.A.InsertCommand = cmdInsAuth;

			DbCommand cmdDelAuth = this.cn.CreateCommand();
			cmdDelAuth.CommandText = "DELETE FROM Authors WHERE id = @id";
			DbParameter P7 = cmdDelAuth.CreateParameter();
			P7.DbType = DbType.Int32;
			P7.ParameterName = "@id";
			P7.SourceColumn = "id";
			cmdDelAuth.Parameters.Add(P7);
			this.A.DeleteCommand = cmdDelAuth;

			DbCommand cmdUpdAuth = this.cn.CreateCommand();
			cmdUpdAuth.CommandText = "UPDATE Authors SET FirstName = @fname, LastName = @lname WHERE id = @id";
			DbParameter P8 = cmdUpdAuth.CreateParameter();
			P8.DbType = DbType.String;
			P8.ParameterName = "@fname";
			P8.SourceColumn = "FirstName";
			cmdUpdAuth.Parameters.Add(P8);
			DbParameter P9 = cmdUpdAuth.CreateParameter();
			P9.DbType = DbType.String;
			P9.ParameterName = "@lname";
			P9.SourceColumn = "LastName";
			cmdUpdAuth.Parameters.Add(P9);
			DbParameter P10 = cmdUpdAuth.CreateParameter();
			P10.DbType = DbType.Int32;
			P10.ParameterName = "@id";
			P10.SourceColumn = "id";
			cmdUpdAuth.Parameters.Add(P10);
			this.A.UpdateCommand = cmdUpdAuth;

			this.A.Update(this.dataSet, "Authors");
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = this.dataSet.Tables[this.toolStripComboBox1.SelectedItem.ToString()];
		}
	}
}