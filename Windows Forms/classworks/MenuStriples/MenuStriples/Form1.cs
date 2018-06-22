using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuStriples
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			MenuStrip mainMenu = new MenuStrip();
			this.Controls.Add(mainMenu);

			ToolStripMenuItem menuFile = new ToolStripMenuItem("File");
			mainMenu.Items.Add(menuFile);
			ToolStripMenuItem menuEdit = new ToolStripMenuItem("Edit");
			mainMenu.Items.Add(menuEdit);

			ToolStripMenuItem menuFileOPen = new ToolStripMenuItem("Open");
			menuFile.DropDownItems.Add(menuFileOPen);

			ToolStripMenuItem menuFileSave = new ToolStripMenuItem("Save");
			menuFile.DropDownItems.Add(menuFileSave);

		}
	}
}
