using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace les4._2
{
	public partial class Form1 : Form
	{
		private String[] arrGB1Values = {
		"Red", "Green", "Blue", "Yellow", "Orange"	};
		private String[] arrGB2Values = {
		"Monday", "Tuesday", "Wednesday", "Thursday", "Friday",
		"Saturday", "Sunday" };
		public Form1()
		{
			InitializeComponent();
			GroupBox GB1 = new GroupBox();
			GB1.Location = new Point(20, 20);
			GB1.Size = new Size(150, 180);
			for(int i = 0; i < 5;i++)
			{
				RadioButton RB = new RadioButton();
				RB.Text = this.arrGB1Values[i];
				RB.Location = new Point(20, 20 + 30 * i);
				GB1.Controls.Add(RB);
				RB.Click += RB1_Click;
				RB.Tag = (Object)i;
			}
			this.Controls.Add(GB1);

			GroupBox GB2 = new GroupBox();
			GB2.Location = new Point(170, 20);
			GB2.Size = new Size(150, 230);
			for (int i = 0; i < 7; i++)
			{
				RadioButton RB = new RadioButton();
				RB.Text = this.arrGB2Values[i];
				RB.Location = new Point(20, 20 + 30 * i);
				GB2.Controls.Add(RB);
				RB.Click += RB2_Click;
				RB.Tag = (Object)i;
			}
			this.Controls.Add(GB2);

			GB1.Text = "Group one";
			GB2.Text = "Group two";
		}

		private void RB1_Click(object sender, EventArgs e)
		{
			if(sender is RadioButton)
			{
				RadioButton RB = (RadioButton)sender;
				MessageBox.Show(this.arrGB1Values[(int)RB.Tag]);
			}
		}
		private void RB2_Click(object sender, EventArgs e)
		{
			if (sender is RadioButton)
			{
				RadioButton RB = (RadioButton)sender;
				MessageBox.Show(this.arrGB2Values[(int)RB.Tag]);
			}
		}
	}
}
