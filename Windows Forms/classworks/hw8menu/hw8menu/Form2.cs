using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace hw8menu
{
	public partial class Form2 : Form
	{
		public ViewSettings vs = new ViewSettings();
		static String path = "viewsetting.dat";
		BinaryFormatter formatter = new BinaryFormatter();
		public Form2()
		{
			InitializeComponent();

			Deserialize();
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
			vs.menu[0][0] = fileCB1.Checked;
			vs.menu[0][1] = fileCB2.Checked;
			vs.menu[0][2] = fileCB3.Checked;
			vs.menu[0][3] = fileCB4.Checked;
			vs.menu[0][4] = fileCB5.Checked;

			vs.menu[1][0] = editCB1.Checked;
			vs.menu[1][1] = editCB2.Checked;
			vs.menu[1][2] = editCB3.Checked;
			vs.menu[1][3] = editCB4.Checked;
			vs.menu[1][4] = editCB5.Checked;
			vs.menu[1][5] = editCB6.Checked;

			vs.menu[2][0] = windowsCB1.Checked;
			vs.menu[2][1] = windowsCB2.Checked;
			vs.menu[2][2] = windowsCB3.Checked;
			vs.menu[2][3] = windowsCB4.Checked;
			vs.menu[2][4] = windowsCB5.Checked;

			vs.menu[0][5] = checkBox1Access.Checked;
			vs.menu[1][6] = checkBox2Access.Checked;
			vs.menu[2][5] = checkBox3Access.Checked;

			this.Close();
		}

		private void buttonCancel(object sender, EventArgs e)
		{
			this.Close();
		}

		public void Serialize()
		{
			using (FileStream fs = new FileStream(path, FileMode.Create))
				formatter.Serialize(fs, vs);
		}
		private void Deserialize()
		{
			using (FileStream fs = new FileStream(path, FileMode.Create))
			{				
				vs = (ViewSettings)formatter.Deserialize(fs);			
			}
				// Проблема в том, что не десериализирует
			fileCB1.Checked = vs.menu[0][0];
			fileCB2.Checked = vs.menu[0][1];
			fileCB3.Checked = vs.menu[0][2];
			fileCB4.Checked = vs.menu[0][3];
			fileCB5.Checked = vs.menu[0][4];
			editCB1.Checked = vs.menu[1][0];
			editCB2.Checked = vs.menu[1][1];
			editCB3.Checked = vs.menu[1][2];
			editCB4.Checked = vs.menu[1][3];
			editCB5.Checked = vs.menu[1][4];
			editCB6.Checked = vs.menu[1][5];
			windowsCB1.Checked = vs.menu[2][0];
			windowsCB2.Checked = vs.menu[2][1];
			windowsCB3.Checked = vs.menu[2][2];
			windowsCB4.Checked = vs.menu[2][3];
			windowsCB5.Checked = vs.menu[2][4];
			groupBox1.Enabled = checkBox1Access.Checked = vs.menu[0][5];
			groupBox2.Enabled = checkBox2Access.Checked = vs.menu[1][6];
			groupBox3.Enabled = checkBox3Access.Checked = vs.menu[2][5];
		}
	}
	[Serializable]
	public class ViewSettings
	{
		public List<List<bool>> menu = new List<List<bool>>();
	}
}