using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newMenu
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

		
		}

		private void changed(object sender, EventArgs e)
		{
			//if (this.toolStripComboBox1.SelectedText != "")
				this.BackColor = Color.FromName(this.toolStripComboBox1.SelectedItem.ToString());
		}

	}
}
