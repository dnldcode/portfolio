using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ContextMenuLes
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			ContextMenu menu = new ContextMenu();

			MenuItem menuOpen = new MenuItem("Open");
			menuOpen.Tag = "Open";
			menu.MenuItems.Add(menuOpen);

			MenuItem menuFormat = new MenuItem("Format C:");
			menuFormat.Tag = "Format";
			menu.MenuItems.Add(menuFormat);

			menuOpen.Click += ContextMenu_Click;
			menuFormat.Click += ContextMenu_Click;

			this.ContextMenu = menu;
		}

		private void ContextMenu_Click(object sender, EventArgs e)
		{
			if (sender is MenuItem)
			{
				MenuItem mi = (MenuItem)sender;
				switch (mi.Tag.ToString())
				{
					case "Open":
						OpenFileDialog OFD = new OpenFileDialog();
						OFD.ShowDialog();
						break;
					case "Format":
						Process.Start("ping.exe", "10.3.0.5");
						break;
				}
			}
		}
	}
}
