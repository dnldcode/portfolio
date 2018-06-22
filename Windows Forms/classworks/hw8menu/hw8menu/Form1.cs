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

			ToolStripMenuItem file = new ToolStripMenuItem("File");
			ToolStripMenuItem edit = new ToolStripMenuItem("Edit");
			ToolStripMenuItem windows = new ToolStripMenuItem("Windows");

			file.DropDownItems.Add(new ToolStripMenuItem("Open"));
			file.DropDownItems.Add(new ToolStripMenuItem("Save As"));
			file.DropDownItems.Add(new ToolStripMenuItem("Exit"));
			file.DropDownItems.Add(new ToolStripMenuItem("Save"));
			file.DropDownItems.Add(new ToolStripMenuItem("New"));

			edit.DropDownItems.Add(new ToolStripMenuItem("Copy"));
			edit.DropDownItems.Add(new ToolStripMenuItem("Cut"));
			edit.DropDownItems.Add(new ToolStripMenuItem("Redo"));
			edit.DropDownItems.Add(new ToolStripMenuItem("Paste"));
			edit.DropDownItems.Add(new ToolStripMenuItem("Undo"));
			edit.DropDownItems.Add(new ToolStripMenuItem("Find"));

			windows.DropDownItems.Add(new ToolStripMenuItem("Tile"));
			windows.DropDownItems.Add(new ToolStripMenuItem("Minimize All"));
			windows.DropDownItems.Add(new ToolStripMenuItem("Next"));
			windows.DropDownItems.Add(new ToolStripMenuItem("Cascade"));
			windows.DropDownItems.Add(new ToolStripMenuItem("Arrange Icons"));

			menuStrip1.Items.Add(file);
			menuStrip1.Items.Add(edit);
			menuStrip1.Items.Add(windows);
			menuStrip1.Items.Add(new ToolStripMenuItem("Settings"));

			foreach (ToolStripMenuItem tsmi in menuStrip1.Items)
				foreach (ToolStripMenuItem tsmi2 in tsmi.DropDownItems)
					tsmi2.Visible = false;

			menuStrip1.Items[3].Click += Form1_Click;

			this.FormClosing += Form1_FormClosing;
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			f2.Serialize();
		}

		private void Form1_Click(object sender, EventArgs e)
		{

			if (f2.ShowDialog() == DialogResult.OK)
			{
				int i = 0, j;
				foreach (ToolStripMenuItem tsmi in menuStrip1.Items)
				{
					j = 0;
					foreach (ToolStripMenuItem tsmi2 in tsmi.DropDownItems)
						tsmi2.Visible = f2.vs.menu[i][j++];
					i++;
				}
				menuStrip1.Items[0].Visible = f2.vs.menu[0][5];
				menuStrip1.Items[1].Visible = f2.vs.menu[1][6];
				menuStrip1.Items[2].Visible = f2.vs.menu[2][5];
			}
		}
	}
}
