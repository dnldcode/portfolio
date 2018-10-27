using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Steamworks;

namespace HoursFarm
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void startClick(object sender, EventArgs e)
		{
			Environment.SetEnvironmentVariable("SteamAppID", "252490");
			SteamAPI.InitSafe();
		}
	}
}