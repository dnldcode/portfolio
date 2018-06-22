using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace test2
{
	public partial class Form1 : Form
	{
		[DllImport("steam_api64.dll")]
		public static extern bool SteamAPI_Init();
		public Form1()
		{
			InitializeComponent();

			comboBox1.Items.Add("Rust");
			comboBox1.Items.Add("CS:GO");
			comboBox1.Items.Add("CS 1.6");
			comboBox1.Items.Add("H1Z1");
			comboBox1.Items.Add("Digger Online");
			comboBox1.Items.Add("Dota 2");
			comboBox1.Items.Add("Hotline Miami");//219150
			comboBox1.Items.Add("Hotline Miami 2");//274170
			comboBox1.Items.Add("Ampersand");//410210
			comboBox1.Items.Add("Bad Rats");//34900
			comboBox1.Items.Add("Caster");//29800
			comboBox1.Items.Add("Condition Zero");//80
			comboBox1.Items.Add("Fallout");//38400
			comboBox1.Items.Add("Saints Row 2");//9480
			comboBox1.Items.Add("Unturned");//304930
			comboBox1.Items.Add("Dead Bits");//303390
			comboBox1.Items.Add("Defy Gravity Extended");//96100
			comboBox1.Items.Add("The Entente Gold");//285480
			comboBox1.Items.Add("Razortron 2000");//
			comboBox1.Items.Add("Sins Of The Demon RPG");//461640
			comboBox1.Items.Add("aMAZE 2");//628750
			comboBox1.Items.Add("Cyberhunt");//636150/
			comboBox1.Items.Add("Planes, Bullets and Vodka");//562360
			comboBox1.SelectedIndex = 0;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			String id = 730.ToString();
			comboBox1.Enabled = false;
			button1.Enabled = false;
			if (comboBox1.SelectedIndex == 0)
				id = 252490.ToString();
			else if (comboBox1.SelectedIndex == 1)
				id = 730.ToString();
			else if (comboBox1.SelectedIndex == 2)
				id = 10.ToString();
			else if (comboBox1.SelectedIndex == 3)
				id = 433850.ToString();
			else if (comboBox1.SelectedIndex == 4)
				id = 278970.ToString();
			else if (comboBox1.SelectedIndex == 5)
				id = 570.ToString();
			else if (comboBox1.SelectedIndex == 6)
				id = 219150.ToString();
			else if (comboBox1.SelectedIndex == 7)
				id = 274170.ToString();
			else if (comboBox1.SelectedIndex == 8)
				id = 410210.ToString();
			else if (comboBox1.SelectedIndex == 9)
				id = 34900.ToString();
			else if (comboBox1.SelectedIndex == 10)
				id = 29800.ToString();
			else if (comboBox1.SelectedIndex == 11)
				id = 80.ToString();
			else if (comboBox1.SelectedIndex == 12)
				id = 38400.ToString();
			else if (comboBox1.SelectedIndex == 13)
				id = 9480.ToString();
			else if (comboBox1.SelectedIndex == 14)
				id = 304930.ToString();
			else if (comboBox1.SelectedIndex == 15)
				id = 303390.ToString();
			else if (comboBox1.SelectedIndex == 16)
				id = 96100.ToString();
			else if (comboBox1.SelectedIndex == 17)
				id = 285480.ToString();
			else if (comboBox1.SelectedIndex == 18)
				id = 539720.ToString();
			else if (comboBox1.SelectedIndex == 19)
				id = 461640.ToString();
			else if (comboBox1.SelectedIndex == 20)
				id = 628750.ToString();
			else if (comboBox1.SelectedIndex == 21)
				id = 636150.ToString();
			else if (comboBox1.SelectedIndex == 22)
				id = 562360.ToString();

			this.Text = comboBox1.SelectedItem.ToString();
			Environment.SetEnvironmentVariable("SteamAppID", id);
			SteamAPI_Init();
		}
	}
}