using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.OleDb;

namespace DataSet_
{
	public partial class Form1 : Form
	{
		private DbConnection cn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library.accdb");
		private DbDataAdapter DA;
		private DataSet DS;
		private String[] tblNames =
			{
				"Authors", "Themes", "Press", "Faculties"
			};
		private Dictionary<String, DbCommand> commands = new Dictionary<string, DbCommand>();
		public Form1()
		{
			InitializeComponent();
			//#region Блок
			//this.cn = new OleDbConnection();
			//this.cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Library.accdb";

			//DbCommand cmdSel = this.cn.CreateCommand();
			//cmdSel.CommandText = "Select * from Themes";

			//this.DA = new OleDbDataAdapter((OleDbCommand)cmdSel);
			//this.DS = new DataSet();

			//this.DA.Fill(this.DS, "Themes");
			//this.dataGridView1.DataSource = this.DS.Tables["Themes"];
			//#endregion

			DbCommand cmdSel = this.cn.CreateCommand();
			this.DA = new OleDbDataAdapter((OleDbCommand)cmdSel);
			this.DS = new DataSet();
			foreach (String tblname in tblNames)
			{
				cmdSel.CommandText = "SELECT * FROM " + tblname;
				this.DA.Fill(this.DS, tblname);
			}

			this.toolStripComboBox1.SelectedIndex = 0;

			DbCommand cmd;

			// Press
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "INSERT INTO Press (name) VALUES (@name)";
			this.commands.Add("PressIns", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "UPDATE Press SET name = @name WHERE id = @id";
			this.commands.Add("PressUpd", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "DELETE FROM Press WHERE id = @id";
			this.commands.Add("PressDel", cmd);

			// Faculties
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "INSERT INTO Faculties (name) VALUES (@name)";
			this.commands.Add("FacultiesIns", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "UPDATE Faculties SET name = @name WHERE id = @id";
			this.commands.Add("FacultiesUpd", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "DELETE FROM Faculties WHERE id = @id";
			this.commands.Add("FacultiesDel", cmd);

			// Themes
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "INSERT INTO Themes (name) VALUES (@name)";
			this.commands.Add("ThemesIns", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "UPDATE Themes SET name = @name WHERE id = @id";
			this.commands.Add("ThemesUpd", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "DELETE FROM Themes WHERE id = @id";
			this.commands.Add("ThemesDel", cmd);

			// Authors
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "INSERT INTO Authors (FirstName, LastName) VALUES (@FirstName, @LastName)";
			this.commands.Add("AuthorsIns", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "UPDATE Authors SET FirstName = @FirstName, LastName = @LastName WHERE id = @id";
			this.commands.Add("AuthorsUpd", cmd);
			cmd = this.cn.CreateCommand();
			cmd.CommandText = "DELETE FROM Authors WHERE id = @id";
			this.commands.Add("AuthorsDel", cmd);


			DbParameter pm;
			
			// Press
			/* Insert Into Press @name */
			pm = this.commands["PressIns"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@name";
			pm.SourceColumn = "name";
			this.commands["PressIns"].Parameters.Add(pm);
			/* Update Press Set name = @name Where id = @id*/
			pm = this.commands["PressUpd"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@name";
			pm.SourceColumn = "name";
			this.commands["PressUpd"].Parameters.Add(pm);
			pm = this.commands["PressUpd"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["PressUpd"].Parameters.Add(pm);
			pm = this.commands["PressDel"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["PressDel"].Parameters.Add(pm);

			// Faculties
			/* Insert Into Faculties @name */
			pm = this.commands["FacultiesIns"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@name";
			pm.SourceColumn = "name";
			this.commands["FacultiesIns"].Parameters.Add(pm);
			/* Update Faculties Set name = @name Where id = @id*/
			pm = this.commands["FacultiesUpd"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@name";
			pm.SourceColumn = "name";
			this.commands["FacultiesUpd"].Parameters.Add(pm);
			pm = this.commands["FacultiesUpd"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["FacultiesUpd"].Parameters.Add(pm);
			pm = this.commands["FacultiesDel"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["FacultiesDel"].Parameters.Add(pm);

			// Themes
			/* Insert Into Themes @name */
			pm = this.commands["ThemesIns"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@name";
			pm.SourceColumn = "name";
			this.commands["ThemesIns"].Parameters.Add(pm);
			/* Update Themes Set name = @name Where id = @id*/
			pm = this.commands["ThemesUpd"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@name";
			pm.SourceColumn = "name";
			this.commands["ThemesUpd"].Parameters.Add(pm);
			pm = this.commands["ThemesUpd"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["ThemesUpd"].Parameters.Add(pm);
			pm = this.commands["ThemesDel"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["ThemesDel"].Parameters.Add(pm);

			// Authors
			/* Insert Into Authors @FirstName, @LastName */
			pm = this.commands["AuthorsIns"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@FirstName";
			pm.SourceColumn = "FirstName";
			this.commands["AuthorsIns"].Parameters.Add(pm);
			pm = this.commands["AuthorsIns"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@LastName";
			pm.SourceColumn = "LastName";
			this.commands["AuthorsIns"].Parameters.Add(pm);
			/* Update Authors Set @FirstName, @LastName Where @id */
			pm = this.commands["AuthorsUpd"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@FirstName";
			pm.SourceColumn = "FirstName";
			this.commands["AuthorsUpd"].Parameters.Add(pm);
			pm = this.commands["AuthorsUpd"].CreateParameter();
			pm.DbType = DbType.String;
			pm.ParameterName = "@LastName";
			pm.SourceColumn = "LastName";
			this.commands["AuthorsUpd"].Parameters.Add(pm);
			pm = this.commands["AuthorsUpd"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["AuthorsUpd"].Parameters.Add(pm);
			/* Delete From Authors Where @id */
			pm = this.commands["AuthorsDel"].CreateParameter();
			pm.DbType = DbType.Int32;
			pm.ParameterName = "@id";
			pm.SourceColumn = "id";
			this.commands["AuthorsDel"].Parameters.Add(pm);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			foreach (String table in this.tblNames)
			{
				this.DA.InsertCommand = this.commands[table + "Ins"];
				this.DA.UpdateCommand = this.commands[table + "Upd"];
				this.DA.DeleteCommand = this.commands[table + "Del"];
				this.DA.Update(this.DS, table);
			}
		}

		private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
		{
			if (this.toolStripComboBox1.SelectedItem == null)
				return;
			String tblName = this.toolStripComboBox1.SelectedItem.ToString();
			this.dataGridView1.DataSource = this.DS.Tables[tblName];
		}
	}
}
