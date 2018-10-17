using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace test
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			int secs = 322;
			int min = 322 / 60;
			int sec = 322 % 60;
			label1.Text = String.Format("{0}:{1}", min, sec);
		}
	}
}
