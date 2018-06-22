using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StartDialogWindows
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			this.сохранитьToolStripMenuItem.Enabled = false;

			writingField.ScrollBars = ScrollBars.Both;
			writingField.Font = new Font(writingField.Font.FontFamily, 11, writingField.Font.Style);
		}

		private void MenuItemExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void MenuItemSave_Click(object sender, EventArgs e)
		{
			///Save
		}

		private void MenuItemOpen_Click(object sender, EventArgs e)
		{
			OpenFileDialog OFD = new OpenFileDialog();
			OFD.InitialDirectory = "C:";	
			OFD.Filter = "Текстовые документы (*.txt) |*.txt|Все файлы(*.*)|*.*";
			if (OFD.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (OFD.OpenFile() != null)
						using (StreamReader sr = new StreamReader(OFD.FileName))						
							writingField.Text = sr.ReadToEnd();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error : " + ex.Message);
				}
			}
		}

		private void MenuItemFont_Click(object sender, EventArgs e)
		{
			FontDialog FD = new FontDialog();
			FD.Font = this.writingField.Font;
			FD.ShowApply = true;
			FD.Apply += FD_Apply;
			try
			{
				if (FD.ShowDialog() == DialogResult.OK)
					this.writingField.Font = FD.Font;
			}
			catch { return; }
		}

		private void FD_Apply(object sender, EventArgs e)
		{
			FontDialog FD = (FontDialog)sender;
			try
			{
				this.writingField.Font = FD.Font;
			}
			catch { return; }
		}

		private void MenuItemBackGroundColor_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			CD.Color = this.writingField.BackColor;
			if (CD.ShowDialog() == DialogResult.OK)
				this.writingField.BackColor = CD.Color;
		}

		private void MenuItemForeColor_Click(object sender, EventArgs e)
		{
			ColorDialog CD = new ColorDialog();
			CD.Color = this.writingField.ForeColor;
			if (CD.ShowDialog() == DialogResult.OK)
				this.writingField.ForeColor = CD.Color;
		}
	}
}