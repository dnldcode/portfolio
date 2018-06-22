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

namespace TreeViewles1._1
{
	public partial class Form1 : Form
	{
		/// <summary>
		/// Заполняет узел node дочерними узлами, которые содержат
		/// названия подкаталогов каталога path
		/// </summary>
		/// <param name="node">Узел к которому будет добавлены новые узлы</param>
		/// <param name="path">Путь к каталогу содержимого которого должно быть добавлено к node</param>
		//private void fillTree(TreeNode node, String path)
		//{
		//	try
		//	{
		//		String[] dirs = Directory.GetDirectories(path);

		//		foreach (String dir in dirs)
		//		{
		//			TreeNode TN = new TreeNode(Path.GetFileName(dir), 0, 1);
		//			node.Nodes.Add(TN);
		//			this.fillTree(TN, dir);
		//		}
		//	}
		//	catch { }
		//}
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
		public Form1()
		{
			InitializeComponent();

			treeView1.BeforeExpand += TreeView1_BeforeExpand;
			treeView1.ImageList = imageList1;
			String[] drivers = Directory.GetLogicalDrives();
			foreach (String drive in drivers)
			{
				TreeNode TN = new TreeNode(drive, 0, 1);
				treeView1.Nodes.Add(TN);
				this.fillNode(TN, drive);
			}
		}

		private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
		{
			TreeNode node = e.Node;
			node.Nodes.Clear();
			this.fillNode(node, node.FullPath);
		}
	}
}
