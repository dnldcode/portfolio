using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartDialogWindows
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void MenuItemBackColor_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			CD.Color = this.BackColor;
			CD.SolidColorOnly = true;
			if (CD.ShowDialog() == DialogResult.OK)
			{
				this.BackColor = CD.Color;
			}

		}

		private void MenuItemChooseFolder_CLick(object sender, EventArgs e)
		{
			FolderBrowserDialog FBD = new FolderBrowserDialog();
			FBD.RootFolder = Environment.SpecialFolder.CommonProgramFiles;
			if (FBD.ShowDialog() == DialogResult.OK)
				MessageBox.Show("Выбран путь : " + FBD.SelectedPath);
		}

		private void MenuItemFont_Click(object sender, EventArgs e)
		{
			FontDialog FD = new FontDialog();
			FD.Font = this.Font;
			FD.ShowApply = true;
			FD.Apply += FD_Apply;
			FD.ShowColor = true;
			FD.ShowDialog();
			//if (FD.ShowDialog() == DialogResult.OK)
			//	this.Font = FD.Font;
		}

		private void FD_Apply(object sender, EventArgs e)
		{
			FontDialog FD = (FontDialog)sender;
			this.Font = FD.Font;
			this.ForeColor = FD.Color;
		}

		private void MenuItemOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog OFD = new OpenFileDialog();
		}
	}
}