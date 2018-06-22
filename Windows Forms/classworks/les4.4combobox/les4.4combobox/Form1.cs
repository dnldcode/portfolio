using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace les4._4combobox
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			ComboBox CB = new ComboBox();
			CB.Location = new Point(20, 20);
			CB.Size = new Size(120, 25);
			this.Controls.Add(CB);

			CB.Items.Add("Январь");
			CB.Items.Add("Февраль");
			CB.Items.Add("Март");
			CB.Items.Add("Апрель");
			CB.Items.Add("Май");
			CB.Items.Add("Июнь");
			CB.Items.Add("Июль");
			CB.Items.Add("Август");
			CB.Items.Add("Сентябрь");
			CB.Items.Add("Октябрь");
			CB.Items.Add("Ноябрь");
			CB.Items.Add("Декабрь");
			CB.SelectedIndex = 0;
			CB.SelectedIndexChanged += CB_SelectedIndexChanged;
		}

		private void CB_SelectedIndexChanged(object sender, EventArgs e)
		{
			ComboBox CB = (ComboBox)sender;
			MessageBox.Show("Index =" + CB.SelectedIndex + "\nValue = " + CB.SelectedItem);
		}
	}
}
