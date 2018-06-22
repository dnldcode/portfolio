using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegeditExam
{
	public partial class Form1 : Form
	{
		Form2 f2 = new Form2();
		Form3 f3 = new Form3();
		public Form1()
		{
			InitializeComponent();

			textBox1.Text = "Компьютер";
			treeView1.Nodes.Add(new TreeNode("Компьютер", 1, 1));
			treeView1.Nodes[0].Expand();
			addNode(Registry.ClassesRoot);
			addNode(Registry.CurrentUser);
			addNode(Registry.LocalMachine);
			addNode(Registry.Users);
			addNode(Registry.CurrentConfig);
			treeView1.Nodes[0].Nodes[1].Expand();
			this.StartPosition = FormStartPosition.CenterScreen;

			listView1.View = View.Details;
			listView1.Columns.Add("Имя", 150);
			listView1.Columns.Add("Тип", 150);
			listView1.Columns.Add("Значение", 175);
		}

		private void addNode(RegistryKey rkey)
		{
			treeView1.Nodes[0].Nodes.Add(new TreeNode(rkey.Name));
			if (rkey.SubKeyCount != 0)
				treeView1.Nodes[0].Nodes[treeView1.Nodes[0].Nodes.Count - 1].Nodes.Add(new TreeNode("?"));
		}

		private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode tn = e.Node;
			fillNode(tn);
		}

		private void fillNode(TreeNode tn, bool b = false)
		{
			if (tn.Text != "Компьютер" && tn.Nodes.Count == 1 || b)
			{
				String path = tn.FullPath;
				tn.Nodes.Clear();
				RegistryKey rk = this.GetRegistryKey(path);
				if (rk == null)
					return;
				foreach (String ss in rk.GetSubKeyNames())
				{
					tn.Nodes.Add(ss);
					try
					{
						if (rk.OpenSubKey(ss).SubKeyCount != 0)
							tn.Nodes[tn.Nodes.Count - 1].Nodes.Add(new TreeNode("?"));
					}
					catch { }
				}
				rk.Close();
			}
		}

		private RegistryKey GetRegistryKey(String path)
		{
			try
			{
				if (path.Contains("HKEY_CLASSES_ROOT"))
				{
					path = path.Replace(@"Компьютер\HKEY_CLASSES_ROOT", "");
					if (path != "" && path[0] == '\\')
						path = path.Remove(0, 1);
					return Registry.ClassesRoot.OpenSubKey(path);
				}
				else if (path.Contains("HKEY_CURRENT_USER"))
				{
					path = path.Replace(@"Компьютер\HKEY_CURRENT_USER", "");
					if (path != "" && path[0] == '\\')
						path = path.Remove(0, 1);
					return Registry.CurrentUser.OpenSubKey(path, true);
				}
				else if (path.Contains("HKEY_LOCAL_MACHINE"))
				{
					path = path.Replace(@"Компьютер\HKEY_LOCAL_MACHINE", "");
					if (path != "" && path[0] == '\\')
						path = path.Remove(0, 1);
					return Registry.LocalMachine.OpenSubKey(path, true);
				}
				else if (path.Contains("HKEY_USERS"))
				{
					path = path.Replace(@"Компьютер\HKEY_USERS", "");
					if (path != "" && path[0] == '\\')
						path = path.Remove(0, 1);
					return Registry.Users.OpenSubKey(path);
				}
				else if (path.Contains("HKEY_CURRENT_CONFIG"))
				{
					path = path.Replace(@"Компьютер\HKEY_CURRENT_CONFIG", "");
					if (path != "" && path[0] == '\\')
						path = path.Remove(0, 1);
					return Registry.CurrentConfig.OpenSubKey(path);
				}
				return null;
			}
			catch
			{
				return null;
			}
		}

		private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			listView1.Items.Clear();
			textBox1.Text = e.Node.FullPath;
			RegistryKey rkey = this.GetRegistryKey(e.Node.FullPath);
			if (rkey == null)
				return;
			ListViewItem lvi = new ListViewItem("(по умолчанию)");
			lvi.SubItems.Add("REG_SZ");
			lvi.SubItems.Add("(значение не присвоено)");
			listView1.Items.Add(lvi);
			foreach (String s in rkey.GetValueNames())
			{
				lvi = new ListViewItem(s);
				RegistryValueKind rvk = rkey.GetValueKind(s);
				switch (rvk)
				{
					case RegistryValueKind.Binary:
						lvi.SubItems.Add("REG_BINARY");
						String s1 = "";
						foreach (Byte b in (Byte[])rkey.GetValue(s))
							s1 += b.ToString() + " ";
						lvi.SubItems.Add(s1);
						break;
					case RegistryValueKind.DWord:
						lvi.SubItems.Add("REG_DWORD");
						break;
					case RegistryValueKind.ExpandString:
						lvi.SubItems.Add("REG_EXPAND_SZ");
						break;
					case RegistryValueKind.MultiString:
						lvi.SubItems.Add("REG_MULTI_SZ");
						String s2 = "";
						foreach (String str in (String[])rkey.GetValue(s))
							s2 += str + " ";
						lvi.SubItems.Add(s2);
						break;
					case RegistryValueKind.None:
						lvi.SubItems.Add("(значение не присвоено)");
						break;
					case RegistryValueKind.QWord:
						lvi.SubItems.Add("REG_QWORD");
						break;
					case RegistryValueKind.String:
						lvi.SubItems.Add("REG_SZ");
						break;
					case RegistryValueKind.Unknown:
						lvi.SubItems.Add("REG_RESOURCE_LIST");
						break;
				}
				lvi.SubItems.Add(rkey.GetValue(s).ToString());
				listView1.Items.Add(lvi);
			}
			rkey.Close();
		}

		private void contextMenuStrip1_Opened(object sender, EventArgs e)
		{
			if (treeView1.SelectedNode.Text == "Компьютер")
				contextMenuStrip1.Enabled = false;
			else
				contextMenuStrip1.Enabled = true;
		}

		private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
			try
			{
				f3.textBox1.Text = "";
				if (f3.ShowDialog() == DialogResult.OK)
				{
					if (rkey == null)
						return;
					foreach (String ss in rkey.GetSubKeyNames())
					{
						if (ss == f3.textBox1.Text)
						{
							MessageBox.Show("Невозможно создать раздел с данным именем, так как данное имя уже занято", "Ошибка создания раздела", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
					}
					rkey.CreateSubKey(f3.textBox1.Text);
				}
				else
					return;
			}
			catch
			{
				MessageBox.Show("Не удается создать раздел. Ошибка при записи в реестр.", "Ошибка при создании реестра", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			fillNode(this.treeView1.SelectedNode, true);
			treeView1.SelectedNode.Expand();
			rkey.Close();
		}

		private void contextMenuStrip2_Opened(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0 || listView1.SelectedItems[0] == listView1.Items[0])
			{
				добавитьToolStripMenuItem1.Visible = true;
				удалитьToolStripMenuItem1.Visible = false;
				изменитьToolStripMenuItem.Visible = false;
			}
			else if (listView1.SelectedItems.Count > 1)
			{
				добавитьToolStripMenuItem1.Visible = false;
				удалитьToolStripMenuItem1.Visible = true;
				изменитьToolStripMenuItem.Visible = false;
			}
			else if (listView1.SelectedItems.Count == 1)
			{
				добавитьToolStripMenuItem1.Visible = false;
				удалитьToolStripMenuItem1.Visible = true;
				изменитьToolStripMenuItem.Visible = true;
			}
		}

		private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.Parent.FullPath);
			try
			{
				if (MessageBox.Show("Вы уверены что хотите удалить раздел " + System.IO.Path.GetFileName(this.GetRegistryKey(this.treeView1.SelectedNode.FullPath).Name) + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					rkey.DeleteSubKeyTree(System.IO.Path.GetFileName(this.GetRegistryKey(this.treeView1.SelectedNode.FullPath).Name));
					fillNode(this.treeView1.SelectedNode.Parent, true);
					rkey.Close();
				}
			}
			catch { MessageBox.Show("Невозможно удалить раздел", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}

		private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
			if (MessageBox.Show("Вы уверены что хотите удалить параметр/ы " + listView1.SelectedItems[0].SubItems[0].Text + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				foreach (ListViewItem lvi in listView1.SelectedItems)
				{
					rkey.DeleteValue(lvi.SubItems[0].Text);
					listView1.Items.Remove(lvi);
				}
			}
			rkey.Close();
		}

		private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
		{
			f2.textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
			if (listView1.SelectedItems[0].SubItems[1].Text == "REG_MULTI_SZ")
			{
				f2.tableLayoutPanel1.Controls.Remove(f2.textBox2);
				f2.tableLayoutPanel1.Controls.Add(f2.richTextBox1);
				f2.tableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 135F);
				f2.Size = new Size(f2.Size.Width, f2.Size.Height + 100);
				f2.richTextBox1.Text = listView1.SelectedItems[0].SubItems[2].Text.Replace(' ', '\n');
			}
			else
				f2.textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
			if (f2.ShowDialog() == DialogResult.OK)
			{
				RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
				if (listView1.SelectedItems[0].SubItems[1].Text == "REG_BINARY")
				{
					string[] s = f2.textBox2.Text.Split(' ');
					byte[] b = new byte[s.Length];
					try
					{
						for (int i = 0; i < s.Length; i++)
							b[i] = Convert.ToByte(s[i]);
					}
					catch
					{
						MessageBox.Show("Невозможно выполнить сохранение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					rkey.SetValue(f2.textBox1.Text, b, RegistryValueKind.Binary);
				}
				else if (listView1.SelectedItems[0].SubItems[1].Text == "REG_MULTI_SZ")
				{
					string[] s = f2.richTextBox1.Text.Split('\n');

					rkey.SetValue(f2.textBox1.Text, s, RegistryValueKind.MultiString);
				}
				else if (listView1.SelectedItems[0].SubItems[1].Text == "REG_DWORD")
				{
					try
					{
						rkey.SetValue(f2.textBox1.Text, Convert.ToInt32(f2.textBox2.Text), RegistryValueKind.DWord);
					}
					catch
					{
						MessageBox.Show("Невозможно выполнить сохранение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else if (listView1.SelectedItems[0].SubItems[1].Text == "REG_QWORD")
				{
					try
					{
						rkey.SetValue(f2.textBox1.Text, Convert.ToInt32(f2.textBox2.Text), RegistryValueKind.QWord);
					}
					catch
					{
						MessageBox.Show("Невозможно выполнить сохранение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
				}
				else if (listView1.SelectedItems[0].SubItems[1].Text == "REG_EXPAND_SZ")
					rkey.SetValue(f2.textBox1.Text, f2.textBox2.Text, RegistryValueKind.ExpandString);
				else
					rkey.SetValue(f2.textBox1.Text, f2.textBox2.Text);

				if (f2.textBox1.Text != listView1.SelectedItems[0].SubItems[0].Text)
				{
					rkey.DeleteValue(listView1.SelectedItems[0].SubItems[0].Text);
					listView1.SelectedItems[0].SubItems[0].Text = f2.textBox1.Text;
				}
				if (listView1.SelectedItems[0].SubItems[1].Text == "REG_MULTI_SZ")
					listView1.SelectedItems[0].SubItems[2].Text = f2.richTextBox1.Text.Replace('\n', ' ');
				else
					listView1.SelectedItems[0].SubItems[2].Text = f2.textBox2.Text;

				rkey.Close();
			}
			if (listView1.SelectedItems[0].SubItems[1].Text == "REG_MULTI_SZ")
			{
				f2.tableLayoutPanel1.Controls.Remove(f2.richTextBox1);
				f2.tableLayoutPanel1.Controls.Add(f2.textBox2);
				f2.tableLayoutPanel1.RowStyles[3] = new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F);
				f2.Size = new Size(f2.Size.Width, f2.Size.Height - 100);
			}
		}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			изменитьToolStripMenuItem_Click(null, null);
		}

		private String getName()
		{
			String str = "Новый параметр #1";
			int n = 1;
			while (true)
			{
				bool q = false;
				foreach (ListViewItem lv in listView1.Items)
				{
					if (lv.SubItems[0].Text == str)
					{
						q = true;
						break;
					}
				}
				if (q)
				{
					str = "Новый параметр #" + (++n).ToString();
					continue;
				}
				break;
			}
			return str;
		}

		private void строковыйПараметрToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
				String str = this.getName();
				rkey.SetValue(str, "", RegistryValueKind.String);
				ListViewItem lvi = new ListViewItem(str);
				lvi.SubItems.Add("REG_SZ");
				lvi.SubItems.Add("");
				listView1.Items.Add(lvi);
				rkey.Close();
			}
			catch
			{
				MessageBox.Show("Невозможно выполнить действие!", "Ошибка выполенния", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void двоичныйПараметрToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
				String str = this.getName();
				rkey.SetValue(str, new byte[0], RegistryValueKind.Binary);
				ListViewItem lvi = new ListViewItem(str);
				lvi.SubItems.Add("REG_BINARY");
				lvi.SubItems.Add("");
				listView1.Items.Add(lvi);
				rkey.Close();
			}
			catch
			{
				MessageBox.Show("Невозможно выполнить действие!", "Ошибка выполенния", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void параметрDWORD32БитаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
				String str = this.getName();
				rkey.SetValue(str, new int(), RegistryValueKind.DWord);
				ListViewItem lvi = new ListViewItem(str);
				lvi.SubItems.Add("REG_DWORD");
				lvi.SubItems.Add("0");
				listView1.Items.Add(lvi);
				rkey.Close();
			}
			catch
			{
				MessageBox.Show("Невозможно выполнить действие!", "Ошибка выполенния", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void параметрQWORD64БитаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
				String str = this.getName();
				rkey.SetValue(str, new int(), RegistryValueKind.QWord);
				ListViewItem lvi = new ListViewItem(str);
				lvi.SubItems.Add("REG_QWORD");
				lvi.SubItems.Add("0");
				listView1.Items.Add(lvi);
				rkey.Close();
			}
			catch
			{
				MessageBox.Show("Невозможно выполнить действие!", "Ошибка выполенния", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void мультистроковыйПараметрToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
				String str = this.getName();
				rkey.SetValue(str, new string[0], RegistryValueKind.MultiString);
				ListViewItem lvi = new ListViewItem(str);
				lvi.SubItems.Add("REG_MULTI_SZ");
				lvi.SubItems.Add("");
				listView1.Items.Add(lvi);
				rkey.Close();
			}
			catch
			{
				MessageBox.Show("Невозможно выполнить действие!", "Ошибка выполенния", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void расширяемыйСтроковыйПараметрToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				RegistryKey rkey = this.GetRegistryKey(this.treeView1.SelectedNode.FullPath);
				String str = this.getName();
				rkey.SetValue(str, "", RegistryValueKind.ExpandString);
				ListViewItem lvi = new ListViewItem(str);
				lvi.SubItems.Add("REG_EXPAND_SZ");
				lvi.SubItems.Add("");
				listView1.Items.Add(lvi);
				rkey.Close();
			}
			catch
			{
				MessageBox.Show("Невозможно выполнить действие!", "Ошибка выполенния", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}