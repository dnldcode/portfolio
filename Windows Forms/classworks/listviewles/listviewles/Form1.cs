using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace listviewles
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			this.listView1.View = View.List;
			this.listView1.LargeImageList = this.imageList1;
			this.listView1.SmallImageList = this.imageList2;
			for (int i = 0; i < 50; i++)
			{
				ListViewItem LVI = new ListViewItem("Hello " + i, i % 3);
				LVI.SubItems.Add("World" + i);
				LVI.SubItems.Add("Forever" + i);
				this.listView1.Items.Add(LVI);
			}

			this.listView1.Columns.Add("Первый");
			this.listView1.Columns.Add("Второй");
			this.listView1.Columns.Add("Третий");

			this.listView1.View = View.Details;
			this.listView1.GridLines = true;
			this.listView1.FullRowSelect = true;
			this.listView1.ListViewItemSorter = 
		}
	}
}
