using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lesMenu
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			MainMenu menu = new MainMenu();
			MenuItem menuFile = new MenuItem("File");
			menu.MenuItems.Add(menuFile);
			MenuItem menuEdit = new MenuItem("Edit");
			menu.MenuItems.Add(menuEdit);

			this.Menu = menu;

			MenuItem menuFileOpen = new MenuItem("Open");
			menuFile.MenuItems.Add(menuFileOpen);
			MenuItem menuFileSave = new MenuItem("Save");
			menuFile.MenuItems.Add(menuFileSave);

			MenuItem menuEditCopy = new MenuItem("Copy");
			menuEdit.MenuItems.Add(menuEditCopy);
			MenuItem menuEditPastre = new MenuItem("Paste");
			menuEdit.MenuItems.Add(menuEditPastre);
			menuFileOpen.Click += Form_MenuClick;
			menuFileOpen.Tag = (object)1;
			menuFileSave.Click += Form_MenuClick;
			menuFileSave.Tag = (object)2;
			menuEditCopy.Click += Form_MenuClick;
			menuEditPastre.RadioCheck = false;
			menuEditCopy.Tag = (object)3;
			menuEditPastre.Click += Form_MenuClick;
			menuEditPastre.Tag = (object)4;
			menuEditCopy.Shortcut = Shortcut.CtrlC;
			menuEditCopy.ShowShortcut = true;

		}

		private void Form_MenuClick(object sender, EventArgs e)
		{
			if (sender is MenuItem)
			{
				int tag = (int)((MenuItem)sender).Tag;
				switch (tag)
				{
					case 1:
						{
							MessageBox.Show("1");
							break;
						}
					case 2:
						{
							MessageBox.Show("2");
							break;
						}
				}

			}
		}
	}
}
