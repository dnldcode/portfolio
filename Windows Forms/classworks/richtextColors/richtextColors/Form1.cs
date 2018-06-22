using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace richtextColors
{
	public partial class Form1 : Form
	{
		private static String[] keyWords =
					{
						" for ", " if ", " else ", " while ", " do ", " switch ",
						" case ", " break ", " int ", " double ", " this " , " public ", " class ", " private ",
						" using " , " namespace ", " String ", " string"
					};
		private static char[] symbols =
					{
						'!', '@', '"', '$', '%', '^', '&', '*', '(', ')', ';', ':',
						'\"', '<', '>', '?', '\n' , '\t' , '.', ','
					};
		public Form1()
		{
			InitializeComponent();

			this.richTextBox1.Font = new Font("Courier New", 12, FontStyle.Regular);
		}

		private void richTextBox1_TextChanged(object sender, EventArgs e)
		{
			String S = this.richTextBox1.Text;
			S = " " + S + " ";
			for (int i = 0; i < symbols.Length; i++)
				S = S.Replace(symbols[i], ' ');
			int cursorPos = this.richTextBox1.SelectionStart;

			this.richTextBox1.Enabled = false;
			this.richTextBox1.Select(0, S.Length - 2);
			this.richTextBox1.SelectionColor = Color.Black;
			Color blue = Color.Blue;
			for (int i = 0; i < Form1.keyWords.Length; i++)
			{
				int index = 0;
				while (true)
				{
					index = S.IndexOf(Form1.keyWords[i], index);
					if (index == -1)
						break;
					this.richTextBox1.SelectionStart = index;
					this.richTextBox1.SelectionLength = keyWords[i].Length - 2;
					this.richTextBox1.SelectionColor = blue;
					index += Form1.keyWords[i].Length - 1;
				}
			}
			this.richTextBox1.SelectionStart = cursorPos;
			this.richTextBox1.SelectionLength = 0;
			this.richTextBox1.SelectionColor = Color.Black;
			this.richTextBox1.Enabled = true;
			this.richTextBox1.Focus();
		}
	}
}