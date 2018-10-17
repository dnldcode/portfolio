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
	public partial class Form2 : Form
	{
		public List<ToolStripMenuItem> menu = new List<ToolStripMenuItem>(3);
		public List<ToolStripMenuItem> prev = new List<ToolStripMenuItem>(3);
		public Form2()
		{
			InitializeComponent();

			menu.Add(new ToolStripMenuItem("File"));
			menu.Add(new ToolStripMenuItem("Edit"));
			menu.Add(new ToolStripMenuItem("Windows"));

			menu[0].DropDownItems.Add(new ToolStripMenuItem("Open"));
			menu[0].DropDownItems.Add(new ToolStripMenuItem("Save As"));
			menu[0].DropDownItems.Add(new ToolStripMenuItem("Exit"));
			menu[0].DropDownItems.Add(new ToolStripMenuItem("Save"));
			menu[0].DropDownItems.Add(new ToolStripMenuItem("New"));

			menu[1].DropDownItems.Add(new ToolStripMenuItem("Copy"));
			menu[1].DropDownItems.Add(new ToolStripMenuItem("Cut"));
			menu[1].DropDownItems.Add(new ToolStripMenuItem("Redo"));
			menu[1].DropDownItems.Add(new ToolStripMenuItem("Paste"));
			menu[1].DropDownItems.Add(new ToolStripMenuItem("Undo"));
			menu[1].DropDownItems.Add(new ToolStripMenuItem("Find"));

			menu[2].DropDownItems.Add(new ToolStripMenuItem("Tile"));
			menu[2].DropDownItems.Add(new ToolStripMenuItem("Minimize All"));
			menu[2].DropDownItems.Add(new ToolStripMenuItem("Next"));
			menu[2].DropDownItems.Add(new ToolStripMenuItem("Cascade"));
			menu[2].DropDownItems.Add(new ToolStripMenuItem("Arrange Icons"));

			foreach(ToolStripMenuItem tsmi in menu)
				foreach(ToolStripMenuItem tsmi2 in tsmi.DropDownItems)
					tsmi2.Visible = false;
		}

		private void FileChanged(object sender, EventArgs e)
		{
			//if (sender == fileCB1)
			//	menu[0].DropDownItems[0].Visible = fileCB1.Checked;
			//else if (sender == fileCB2)
			//	menu[0].DropDownItems[1].Visible = fileCB2.Checked;
			//else if (sender == fileCB3)
			//	menu[0].DropDownItems[2].Visible = fileCB3.Checked;
			//else if (sender == fileCB4)
			//	menu[0].DropDownItems[3].Visible = fileCB4.Checked;
			//else if (sender == fileCB5)
			//	menu[0].DropDownItems[4].Visible = fileCB5.Checked;
		}

		private void EditChanged(object sender, EventArgs e)
		{
			//if (sender == editCB1)
			//	menu[1].DropDownItems[0].Visible = editCB1.Checked;
			//else if (sender == editCB2)
			//	menu[1].DropDownItems[1].Visible = editCB2.Checked;
			//else if (sender == editCB3)
			//	menu[1].DropDownItems[2].Visible = editCB3.Checked;
			//else if (sender == editCB4)
			//	menu[1].DropDownItems[3].Visible = editCB4.Checked;
			//else if (sender == editCB5)
			//	menu[1].DropDownItems[4].Visible = editCB5.Checked;
			//else if (sender == editCB6)
			//	menu[1].DropDownItems[5].Visible = editCB6.Checked;
		}

		private void WindowsChanged(object sender, EventArgs e)
		{
			//if (sender == windowsCB1)
			//	menu[2].DropDownItems[0].Visible = windowsCB1.Checked;
			//if (sender == windowsCB2)
			//	menu[2].DropDownItems[1].Visible = windowsCB2.Checked;
			//if (sender == windowsCB3)
			//	menu[2].DropDownItems[2].Visible = windowsCB3.Checked;
			//if (sender == windowsCB4)
			//	menu[2].DropDownItems[3].Visible = windowsCB4.Checked;
			//if (sender == windowsCB5)
			//	menu[2].DropDownItems[4].Visible = windowsCB5.Checked;
		}

		private void checkBoxChecking(object sender, EventArgs e)
		{
			if (sender == checkBox1Access)
				groupBox1.Enabled = checkBox1Access.Checked;
			else if (sender == checkBox2Access)
				groupBox2.Enabled = checkBox2Access.Checked;
			else if (sender == checkBox3Access)
				groupBox3.Enabled = checkBox3Access.Checked;		
		}

		private void buttonOK(object sender, EventArgs e)
		{
			menu[0].DropDownItems[0].Visible = fileCB1.Checked;
			menu[0].DropDownItems[1].Visible = fileCB2.Checked;
			menu[0].DropDownItems[2].Visible = fileCB3.Checked;
			menu[0].DropDownItems[3].Visible = fileCB4.Checked;
			menu[0].DropDownItems[4].Visible = fileCB5.Checked;

			menu[1].DropDownItems[0].Visible = editCB1.Checked;
			menu[1].DropDownItems[1].Visible = editCB2.Checked;
			menu[1].DropDownItems[2].Visible = editCB3.Checked;
			menu[1].DropDownItems[3].Visible = editCB4.Checked;
			menu[1].DropDownItems[4].Visible = editCB5.Checked;

			menu[1].DropDownItems[5].Visible = editCB6.Checked;
			menu[2].DropDownItems[0].Visible = windowsCB1.Checked;
			menu[2].DropDownItems[1].Visible = windowsCB2.Checked;
			menu[2].DropDownItems[2].Visible = windowsCB3.Checked;
			menu[2].DropDownItems[3].Visible = windowsCB4.Checked;
			menu[2].DropDownItems[4].Visible = windowsCB5.Checked;

			menu[0].Visible = checkBox1Access.Checked;
			menu[1].Visible = checkBox2Access.Checked;
			menu[2].Visible = checkBox3Access.Checked;
			this.Close();
		}

		private void buttonCancel(object sender, EventArgs e)
		{
			fileCB1.Checked = prev[0].DropDownItems[0].Visible;
			fileCB2.Checked = prev[0].DropDownItems[1].Visible;
			fileCB3.Checked = prev[0].DropDownItems[2].Visible;
			fileCB4.Checked = prev[0].DropDownItems[3].Visible;
			fileCB5.Checked = prev[0].DropDownItems[4].Visible;

			editCB1.Checked = prev[1].DropDownItems[0].Visible;
			editCB2.Checked = prev[1].DropDownItems[1].Visible;
			editCB3.Checked = prev[1].DropDownItems[2].Visible;
			editCB4.Checked = prev[1].DropDownItems[3].Visible;
			editCB5.Checked = prev[1].DropDownItems[4].Visible;
			editCB6.Checked = prev[1].DropDownItems[5].Visible;

			windowsCB1.Checked = prev[2].DropDownItems[0].Visible;
			windowsCB2.Checked = prev[2].DropDownItems[1].Visible;
			windowsCB3.Checked = prev[2].DropDownItems[2].Visible;
			windowsCB4.Checked = prev[2].DropDownItems[3].Visible;
			windowsCB5.Checked = prev[2].DropDownItems[4].Visible;

			checkBox1Access.Checked = prev[0].Visible;
			checkBox2Access.Checked = prev[1].Visible;
			checkBox3Access.Checked = prev[2].Visible;
			this.Close();
		}
	}
}