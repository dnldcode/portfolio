using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace DbFactoryhw
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
				"Authors", "Books", "Categories", "Departments", "Faculties", "Groups", "Libs", "Press",
				"S_Cards", "T_Cards", "Students", "Teachers", "Themes"
			};
			DbProviderFactory DPF = DbProviderFactories.GetFactory(ConfigurationManager.AppSettings["db"]);
			this.cn = DPF.CreateConnection();
			this.cn.ConnectionString = ConfigurationManager.AppSettings["connectingString"];
			DbCommand cmd = this.cn.CreateCommand();
			this.A = DPF.CreateDataAdapter();
			this.A.SelectCommand = cmd;
			this.dataSet = new DataSet();
			foreach (String tblName in tblNames)
			{
				cmd.CommandText = "SELECT * FROM " + tblName;
				this.A.Fill(this.dataSet, tblName);
			}
		}

		private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.dataGridView1.DataSource = this.dataSet.Tables[this.toolStripComboBox1.SelectedItem.ToString()];
		}
	}
}
