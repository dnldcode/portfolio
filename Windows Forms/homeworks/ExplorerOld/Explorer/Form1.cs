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

namespace Explorer
{
	public partial class Form1 : Form
	{
		static public Dictionary<String, int> icons = new Dictionary<String, int>();
		private void fillNode(TreeNode node, String path)
		{
			try
			{
				String[] dirs = Directory.GetDirectories(path);
				foreach (String dir in dirs)
				{
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
			comboBox1.SelectedIndex = 0;
			explorerList.DoubleClick += ExplorerList_DoubleClick;
		}

		private void ExplorerList_DoubleClick(object sender, EventArgs e)
		{
			filePath.Text = Path.Combine(filePath.Text, explorerList.SelectedItems[0].Text);
		}

		private void TreeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			 filePath.Text = e.Node.FullPath;
		}

		private void filePath_TextChanged(object sender, EventArgs e)
		{
			DirectoryInfo fi = new DirectoryInfo(filePath.Text);
				prevButton.Enabled = !(filePath.Text == fi.Root.Name);

			try
			{
				explorerList.Clear();
				String[] paths = Directory.GetDirectories(filePath.Text);
				String[] files = Directory.GetFiles(filePath.Text);
				ColumnHeader name = new ColumnHeader();
				ColumnHeader date = new ColumnHeader();
				ColumnHeader type = new ColumnHeader();
				name.Text = "Имя";
				name.Width = 200;
				date.Text = "Дата изменения";
				date.Width = 120;
				type.Text = "Тип";
				type.Width = 120;
				explorerList.Columns.Add(name);
				explorerList.Columns.Add(date);
				explorerList.Columns.Add(type);

				foreach (String path in paths)
				{
					FileInfo info = new FileInfo(path);
					ListViewItem LVI = new ListViewItem(info.Name);
					LVI.SubItems.Add(info.LastAccessTime.ToString());
					LVI.SubItems.Add("Папка");
					LVI.ImageIndex = 0;
					explorerList.Items.Add(LVI);
				}
				foreach (String file in files)
				{
					FileInfo info = new FileInfo(file);
					ListViewItem LVI = new ListViewItem(info.Name);
					String ext = Path.GetExtension(info.Name);

					if (icons.ContainsKey(ext))
					{
						if (ext != ".exe")
						{
							int value;
							icons.TryGetValue(ext, out value);
							LVI.ImageIndex = value;
						}
						else
						{
							imageList1.Images.Add(Icon.ExtractAssociatedIcon(info.FullName));
							LVI.ImageIndex = explorerList.SmallImageList.Images.Count - 1;
						}
					}
					else
					{
						imageList1.Images.Add(Icon.ExtractAssociatedIcon(info.FullName));
						icons.Add(ext, explorerList.SmallImageList.Images.Count - 1);
						LVI.ImageIndex = explorerList.SmallImageList.Images.Count - 1;
					}


					LVI.SubItems.Add(info.LastAccessTime.ToString());
					LVI.SubItems.Add("Файл");
					explorerList.Items.Add(LVI);
				}


				this.explorerList.SmallImageList = imageList1;
				this.explorerList.LargeImageList = imageList1;
			}
			catch
			{
				explorerList.Items.Clear();
				return;
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (comboBox1.SelectedIndex == 0)
				explorerList.View = View.Details;
			if (comboBox1.SelectedIndex == 1)
				explorerList.View = View.LargeIcon;
			if (comboBox1.SelectedIndex == 2)
				explorerList.View = View.List;
			if (comboBox1.SelectedIndex == 3)
				explorerList.View = View.SmallIcon;
			if (comboBox1.SelectedIndex == 4)
				explorerList.View = View.Tile;
		}

		private void prevButton_Click(object sender, EventArgs e)
		{
			DirectoryInfo fi = new DirectoryInfo(filePath.Text);
			filePath.Text = fi.Parent.FullName;
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
		{
			String temp = filePath.Text;
			filePath.Text = "";
			filePath.Text = temp;
		}
	}
}
