using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRelationTest
{
	class Program
	{
		static void Main(string[] args)
		{
			DataSet DS = new DataSet();
			OleDbConnection cn = new OleDbConnection();
			cn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\09701\Desktop\CountriesCities.accdb";
			OleDbCommand cmdSel = cn.CreateCommand();
			cmdSel.CommandText = "SELECT * FROM Countries";

			OleDbDataAdapter da = new OleDbDataAdapter(cmdSel);
			da.Fill(DS, "Countries");
			cmdSel.CommandText = "SELECT * FROM Cities";
			da.Fill(DS, "Cities");
			DataRelation DR1 = new DataRelation("CityCountryRelation", DS.Tables["Countries"].Columns["id"], DS.Tables["Cities"].Columns["id_country"], true);
			DS.Relations.Add(DR1);

			foreach(DataRow r in DS.Tables["Countries"].Rows)
			{
				DataRow[] childRows = r.GetChildRows(DS.Relations["CityCountryRelation"]);

				Console.WriteLine("Страна : {0}", r["name"]);
				for(int i = 0; i < childRows.Length; i++)
					Console.WriteLine("\tГород : {0}", childRows[i]["name"]);
				Console.WriteLine("===========");
			}

		}
	}
}