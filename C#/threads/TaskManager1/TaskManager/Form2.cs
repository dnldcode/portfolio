using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TaskManager
{
	public partial class Form2 : Form
	{
		public Form2()
		{
			InitializeComponent();
			listView1.View = View.Details;
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.MultiSelect = false;
			this.StartPosition = FormStartPosition.CenterParent;
		}
	}
}
