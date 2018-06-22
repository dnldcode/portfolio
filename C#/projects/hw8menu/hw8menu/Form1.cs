using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hw8menu
{
	public partial class Form1 : Form
	{
		Form2 f2 = new Form2();
		public Form1()
		{
			InitializeComponent();

			menuStrip1.Items.Add(new ToolStripMenuItem("File"));
			menuStrip1.Items.Add(new ToolStripMenuItem("Edit"));
			menuStrip1.Items.Add(new ToolStripMenuItem("Windows"));
			menuStrip1.Items.Add(new ToolStripMenuItem("Settings"));
			menuStrip1.Items[3].Click += Form1_Click;
		}

		private void Form1_Click(object sender, EventArgs e)
		{
			List<ToolStripMenuItem> temp = new List<ToolStripMenuItem>(3);
			temp.Clear();
			temp.Add((ToolStripMenuItem)menuStrip1.Items[0]);
			temp.Add((ToolStripMenuItem)menuStrip1.Items[1]);
			temp.Add((ToolStripMenuItem)menuStrip1.Items[2]);
			f2.prev = temp;

			//f2.prev.Clear();
			//f2.prev = f2.menu;

			f2.ShowDialog();

			for (int i = 0; i < 3; i++)
			{
				this.menuStrip1.Items.RemoveAt(i);
				this.menuStrip1.Items.Insert(i, f2.menu[i]);
			}
		}
	}
}
