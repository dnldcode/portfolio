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
using System.Collections;
using System.Diagnostics;

namespace Explorer
{
	public partial class Form1 : Form
	{
		static public bool isSorted = false;
		static public bool isSortedByNames = false;
		static public SortedDictionary<String, int> icons = new SortedDictionary<String, int>();
		List<String> copyFrom = new List<String>();
		List<String> fileName = new List<String>();
		Form2 f2 = new Form2();
		public Form1()
		{
			InitializeComponent();

			treeView1.BeforeExpand += TreeView1_BeforeExpand;
			treeView1.ImageList = imageList1;
			treeView1.NodeMouseClick += TreeView1_NodeMouseClick;
			String[] drivers = Directory.GetLogicalDrives();
			foreach (String drive in drivers)
			{
				TreeNode TN = new TreeNode(drive, 0, 1);
				treeView1.Nodes.Add(TN);
				this.fillNode(TN, drive);
			}
			//treeView1.SelectedNode = treeView1.Nodes[0];
			filePath.Text = treeView1.Nodes[0].Text;
			//filePath.Text = @"C:\Users\froze\Desktop\test";
			FillListView();
			explorerList.View = View.Details;
			explorerList.DoubleClick += ExplorerList_DoubleClick;
			explorerList.FullRowSelect = true;
			explorerList.ColumnClick += ExplorerList_ColumnClick;
		}

		private void ExplorerList_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			if (e.Column == 0)
			{
				this.explorerList.ListViewItemSorter = null;
				isSorted = false;
				isSortedByNames = !isSortedByNames;
				String[] paths = Directory.GetDirectories(filePath.Text);
				explorerList.Clear();
				String[] files = Directory.GetFiles(filePath.Text);
				FillListView();
			}
			else if (e.Column == 3 || e.Column == 1)
			{
				isSortedByNames = false;
				isSorted = !isSorted;
				this.explorerList.ListViewItemSorter = new ExplorerComparer(e.Column);
			}
		}
		class ExplorerComparer : IComparer
		{
			private int col;
			public ExplorerComparer()
			{
				col = 0;
			}
			public ExplorerComparer(int column)
			{
				col = column;
			}
			public int Compare(object x, object y)
			{
				if (Form1.isSorted)
				{
					if (col == 1)
						return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
					if (col == 3)
						return (Int32.Parse(((ListViewItem)y).SubItems[col].Tag.ToString()) - Int32.Parse(((ListViewItem)x).SubItems[col].Tag.ToString()));
				}
				else
				{
					if (col == 1)
						return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);

					if (col == 3)
						return (Int32.Parse(((ListViewItem)x).SubItems[col].Tag.ToString()) - Int32.Parse(((ListViewItem)y).SubItems[col].Tag.ToString()));
				}
				return 0;
			}
		}

		private void fillNode(TreeNode node, String path)
		{
			try
			{
				String[] dirs = Directory.GetDirectories(path);
				foreach (String dir in dirs)
				{
					if (new DirectoryInfo(dir).Attributes.HasFlag(FileAttributes.Hidden))
						continue;
					TreeNode TN = new TreeNode(Path.GetFileName(dir), 0, 1);
					node.Nodes.Add(TN);

					try
					{
						String[] subDirs = Directory.GetDirectories(dir);
						if (subDirs.Length > 0)
						{
							TreeNode tn = new TreeNode("?");
							TN.Nodes.Add(tn);
						}
					}
					catch { }
				}
			}
			catch { }
		}

		private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			node.Nodes.Clear();
			this.fillNode(node, node.FullPath);
		}

		private void prevButton_Click(object sender, EventArgs e)
		{
			isSorted = isSortedByNames = false;
			DirectoryInfo fi = new DirectoryInfo(filePath.Text);
			filePath.Text = fi.Parent.FullName;
			FillListView();
		}

		private void ExplorerList_DoubleClick(object sender, EventArgs e)
		{
			isSorted = isSortedByNames = false;
			try
			{
				String fname = Path.Combine(filePath.Text, explorerList.SelectedItems[0].Text);
				if (Directory.Exists(fname))
				{
					String temp = filePath.Text;
					filePath.Text = Path.Combine(fname);
					if (FillListView() == 1)
						filePath.Text = temp;
				}
				else
					Process.Start(fname);
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				filePath.Text = Path.Combine(e.Node.FullPath).Replace(@"\\", @"\");
				FillListView();
			}
		}

		private void TextBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				FillListView();
		}

		private int FillListView()
		{
			try
			{
				DirectoryInfo fi = new DirectoryInfo(filePath.Text);
				prevButton.Enabled = goBackButton.Enabled = !(filePath.Text == fi.Root.Name);
				String[] paths = Directory.GetDirectories(filePath.Text);
				String[] files = Directory.GetFiles(filePath.Text);
				explorerList.Clear();
				ColumnHeader name = new ColumnHeader();
				ColumnHeader date = new ColumnHeader();
				ColumnHeader type = new ColumnHeader();
				ColumnHeader length = new ColumnHeader();
				name.Text = "Имя";
				name.Width = 200;
				date.Text = "Дата изменения";
				date.Width = 120;
				type.Text = "Тип";
				type.Width = 120;
				length.Text = "Размер";
				length.Width = 120;
				explorerList.Columns.Add(name);
				explorerList.Columns.Add(date);
				explorerList.Columns.Add(type);
				explorerList.Columns.Add(length);

				if (isSortedByNames)
				{
					showFiles(files);
					showDirectories(paths);
				}
				else
				{
					showDirectories(paths);
					showFiles(files);
				}

				this.explorerList.SmallImageList = imageList1;
				this.explorerList.LargeImageList = imageList2;
				filePath.Text = filePath.Text.Replace("/", @"\");
				filePath.SelectionStart = filePath.Text.Length;

			}
			catch (Exception ee)
			{
				if (ee.GetType().ToString() == "System.IO.DirectoryNotFoundException")
				{
					DirectoryInfo fi = new DirectoryInfo(filePath.Text);
					filePath.Text = fi.Parent.FullName;
					FillListView();
				}
				else
					MessageBox.Show(ee.Message);
				return 1;
			}
			return 0;
		}

		static String BytesToString(long byteCount)
		{
			String[] suf = { " Б", " КБ", " МБ", " ГБ", " ТБ", " ПБ", " ЕБ" }; //
			if (byteCount == 0)
				return "0" + suf[0];
			long bytes = Math.Abs(byteCount);
			int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
			double num = Math.Round(bytes / Math.Pow(1024, place), 1);
			return (Math.Sign(byteCount) * num).ToString() + suf[place];
		}

		private void ListViewContextMenu_Opened(object sender, EventArgs e)
		{
			bool selected = (explorerList.SelectedItems.Count == 0);
			copy.Enabled = !selected;
			paste.Enabled = !(copyFrom.Count == 0);
			rename.Enabled = !selected;
			delete.Enabled = !selected;
			create.Enabled = selected;
		}

		private void ContextMenuLWRemove_Click(object sender, EventArgs e)
		{
			try
			{
				String answer;
				if (explorerList.SelectedItems.Count == 1)
					answer = String.Format("Вы действительно хотит удалить файл \"{0}\"", explorerList.SelectedItems[0].Text);
				else
					answer = String.Format("Вы действительно хотите удалить все элементы?({0})", explorerList.SelectedItems.Count);

				if (MessageBox.Show(answer, "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					foreach (ListViewItem lwi in explorerList.SelectedItems)
					{
						String path = Path.Combine(filePath.Text, lwi.Text);
						if (File.Exists(path))
							File.Delete(path);
						else
							Directory.Delete(path, true);
					}
					FillListView();
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void ContextMenuLWRename_Click(object sender, EventArgs e)
		{
			f2.textBox1.Text = explorerList.SelectedItems[0].Text;
			f2.label2.Text = filePath.Text.Replace(@"\\", @"\");
			f2.Text = "Переименование";
			f2.ShowDialog();
			String rename = f2.str;
			if (rename == "")
				return;
			try
			{
				String oldPath = Path.Combine(filePath.Text, explorerList.SelectedItems[0].Text);
				String newPath = Path.Combine(filePath.Text, rename);
				if (File.Exists(oldPath))
					File.Move(oldPath, newPath);
				else
					Directory.Move(oldPath, newPath);
				FillListView();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void CopyDir(string FromDir, string ToDir)
		{
			try
			{
				Directory.CreateDirectory(ToDir);
				foreach (string s1 in Directory.GetFiles(FromDir))
				{
					string s2 = ToDir + @"\" + Path.GetFileName(s1);
					File.Copy(s1, s2);
				}
				foreach (string s in Directory.GetDirectories(FromDir))
				{
					if (fileName[0] != Path.GetFileName(s))
						CopyDir(s, ToDir + @"\" + Path.GetFileName(s));
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void ContextMenuLWCopy_Click(object sender, EventArgs e)
		{
			try
			{
				copyFrom.Clear();
				fileName.Clear();

				foreach (ListViewItem lvi in explorerList.SelectedItems)
				{
					copyFrom.Add(Path.Combine(filePath.Text, lvi.Text));
					fileName.Add(lvi.Text);
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void ContextMenuLWPaste_Click(object sender, EventArgs e)
		{
			try
			{
				if (File.Exists(copyFrom[0]))
				{
					if (copyFrom.Count != 0)
						for (int i = 0; i < copyFrom.Count; i++)
						{
							try
							{
								File.Copy(copyFrom[i], Path.Combine(filePath.Text, fileName[i]), true);
							}
							catch
							{
								String temp = fileName[i];
								int a = 1;
								String fName = fileName[i].Insert(fileName[i].LastIndexOf("."), String.Format(" - копия({0})", a++));
								while (File.Exists(Path.Combine(filePath.Text, fName)))
									fName = fileName[i].Insert(fileName[i].LastIndexOf("."), String.Format(" - копия({0})", a++));

								File.Copy(copyFrom[i], Path.Combine(filePath.Text, fName), true);
								fileName[i] = temp;
							}
						}
				}
				else
				{
					for (int i = 0; i < copyFrom.Count; i++)
						CopyDir(copyFrom[i], Path.Combine(filePath.Text, fileName[i]));
				}
				FillListView();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void ContextMenuLWRefresh_Click(object sender, EventArgs e)
		{
			FillListView();
		}

		private void ContextMenuLWCreate_Click(object sender, EventArgs e)
		{
			try
			{
				f2.textBox1.Text = "";
				f2.label2.Text = filePath.Text.Replace(@"\\", @"\");
				f2.Text = "Создание каталога";
				f2.ShowDialog();
				String name = f2.str;
				if (name == null || name == "")
					return;
				Directory.CreateDirectory(Path.Combine(filePath.Text, name));
				FillListView();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}

		}

		private void ContextMenuTWCreateCatalog_Click(object sender, EventArgs e)
		{
			try
			{ 
			f2.textBox1.Text = "";
			f2.label2.Text = treeView1.SelectedNode.FullPath.Replace(@"\\",@"\");
			f2.Text = "Создание каталога";
			f2.ShowDialog();
			String name = f2.str;
			if (name == "" || name == null)
				return;
			Directory.CreateDirectory(Path.Combine(treeView1.SelectedNode.FullPath, name));
			treeView1.SelectedNode.Parent.Collapse();
			treeView1.SelectedNode.Expand();
			FillListView();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void ContextMenuTWRename_Click(object sender, EventArgs e)
		{
			try
			{ 
			f2.label2.Text = treeView1.SelectedNode.FullPath.Replace(@"\\", @"\");
			f2.Text = "Переименование";
			f2.textBox1.Text = treeView1.SelectedNode.Text;
			f2.ShowDialog();
			String rename = f2.str;
			if (rename == "" || rename == null)
				return;
			String oldPath = treeView1.SelectedNode.FullPath;
			String newPath = Path.Combine(treeView1.SelectedNode.Parent.FullPath, rename);
			if (File.Exists(oldPath))
				File.Move(oldPath, newPath);
			else
				Directory.Move(oldPath, newPath);
			treeView1.SelectedNode.Parent.Collapse();
			treeView1.SelectedNode.Expand();

			FillListView();
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}

		}

		private void ContextMenuTWDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show(String.Format("Уверены что хотите удалить \"{0}\"", treeView1.SelectedNode.Text), "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					Directory.Delete(treeView1.SelectedNode.FullPath, true);
					treeView1.SelectedNode.Parent.Collapse();
					treeView1.SelectedNode.Expand();
					FillListView();
				}
			}
			catch (Exception ee)
			{
				MessageBox.Show(ee.Message);
			}
		}

		private void toolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (sender == detailsToolStripMenuItem)
				explorerList.View = View.Details;
			else if (sender == largeIconToolStripMenuItem)
				explorerList.View = View.LargeIcon;
			else if (sender == listToolStripMenuItem)
				explorerList.View = View.List;
			else if (sender == smallIconToolStripMenuItem)
				explorerList.View = View.SmallIcon;
			else if (sender == tileToolStripMenuItem)
				explorerList.View = View.Tile;
		}

		private void goBackButton_Click(object sender, EventArgs e)
		{
			isSorted = isSortedByNames = false;
			DirectoryInfo fi = new DirectoryInfo(filePath.Text);
			filePath.Text = fi.Parent.FullName;
			FillListView();
		}

		private void showDirectories(String[] paths)
		{
			for (int i = 0; i < paths.Length; i++)
			{
				FileInfo info;
				if (isSortedByNames)
				{
					if (new DirectoryInfo(paths[paths.Length - i - 1]).Attributes.HasFlag(FileAttributes.Hidden))
						continue;
					info = new FileInfo(paths[paths.Length - i - 1]);
				}
				else
				{
					if (new DirectoryInfo(paths[i]).Attributes.HasFlag(FileAttributes.Hidden))
						continue;
					info = new FileInfo(paths[i]);
				}
				ListViewItem LVI = new ListViewItem(info.Name);
				LVI.SubItems.Add(info.LastAccessTime.ToString());
				LVI.SubItems.Add("Папка");
				LVI.SubItems.Add("");
				LVI.SubItems[LVI.SubItems.Count - 1].Tag = 0;
				LVI.ImageIndex = 0;
				explorerList.Items.Add(LVI);
			}
		}

		private void showFiles(String[] files)
		{
			for (int i = 0; i < files.Length; i++)
			{
				FileInfo info;
				if (isSortedByNames)
				{
					if (new FileInfo(files[files.Length - i - 1]).Attributes.HasFlag(FileAttributes.Hidden))
						continue;
					info = new FileInfo(files[files.Length - i - 1]);
				}
				else
				{
					if (new FileInfo(files[i]).Attributes.HasFlag(FileAttributes.Hidden))
						continue;
					info = new FileInfo(files[i]);
				}
				ListViewItem LVI = new ListViewItem(info.Name);
				String ext = Path.GetExtension(info.Name);

				if (icons.ContainsKey(ext))
					LVI.ImageIndex = icons[ext];
				else
				{
					imageList1.Images.Add(Icon.ExtractAssociatedIcon(info.FullName));
					if (ext.ToLower() != ".exe" && ext.ToLower() != ".ico" && ext.ToLower() != ".png" && ext.ToLower() != ".bmp")
						icons.Add(ext, explorerList.SmallImageList.Images.Count - 1);
					LVI.ImageIndex = explorerList.SmallImageList.Images.Count - 1;
				}
				LVI.SubItems.Add(info.LastAccessTime.ToString());
				LVI.SubItems.Add("Файл");
				LVI.SubItems.Add(BytesToString(info.Length));
				LVI.SubItems[LVI.SubItems.Count - 1].Tag = info.Length.ToString();
				explorerList.Items.Add(LVI);
			}
		}
	}
}