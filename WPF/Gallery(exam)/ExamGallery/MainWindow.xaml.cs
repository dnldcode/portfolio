using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
//using System.Windows.Shapes;

namespace ExamGallery
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			String[] drives = Directory.GetLogicalDrives();
			foreach (String drive in drives)
			{
				DirItem DI = new DirItem(drive, drive);
				DI.Nodes.Add(new DirItem("1"));
				this.treeView.Items.Add(DI);
			}
		}

		private void fillTree(String fullPath, DirItem parent)
		{
			try
			{
				String[] dirs = Directory.GetDirectories(fullPath);
				foreach (String dir in dirs)
				{
					if (new DirectoryInfo(dir).Attributes.HasFlag(FileAttributes.Hidden) != true)
					{
						DirItem DI = new DirItem(System.IO.Path.GetFileName(dir), dir);
						try
						{
							if (Directory.GetDirectories(dir).Length > 0)
								DI.Nodes.Add(new DirItem("1"));
						}
						catch
						{
							DI.Nodes.Add(new DirItem("1"));
						}
						parent.Nodes.Add(DI);
					}
					else
						continue;
				}
			}
			catch { }
		}

		private void treeView_Expanded(object sender, RoutedEventArgs e)
		{
			TreeViewItem tmp = (TreeViewItem)e.OriginalSource;
			DirItem DI = (DirItem)tmp.Header;
			DI.Nodes.Clear();
			this.fillTree(DI.fullPath, DI);
		}

		private void treeView_Selected(object sender, RoutedEventArgs e)
		{
			mainImage.Source = null;
			try
			{
				TreeViewItem tmp = (TreeViewItem)e.OriginalSource;
				DirItem DI = (DirItem)tmp.Header;
				listView1.Items.Clear();
				String[] files = Directory.GetFiles(DI.fullPath);
				foreach (String file in files)
				{
					String extension = Path.GetExtension(file).ToLower();
					if (extension == ".png" || extension == ".bmp" || extension == ".jpg")
						listView1.Items.Add(new DirItem(System.IO.Path.GetFileName(file), file));
				}
			}
			catch { }
		}

		private void listView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			ListView temp = sender as ListView;
			if (temp.SelectedIndex == -1)
				return;
			DirItem di = (DirItem)temp.Items[temp.SelectedIndex];
			mainImage.Source = BitmapFrame.Create(new Uri(@di.fullPath));
		}

		private void buttonForward_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				DirItem DI = (DirItem)treeView.SelectedItem;
				String[] files = Directory.GetFiles(DI.fullPath);
				List<DirItem> temp = new List<DirItem>();
				foreach (String file in files)
				{
					String extension = Path.GetExtension(file).ToLower();
					if (extension == ".png" || extension == ".bmp" || extension == ".jpg")
					{
						DirItem adding = new DirItem(Path.GetFileName(file), file);
						listView2.Items.Add(adding);
						temp.Add(adding);
					}
				}
			}
			catch { }
		}

		private void listView_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				if (sender == listView1)
				{
					DirItem di = (DirItem)listView1.SelectedItem;
					listView2.Items.Add(di);
				}
				if (sender == listView2)
				{
					DirItem di = (DirItem)listView2.SelectedItem;
					listView2.Items.Remove(di);
				}
			}
		}
		private void treeView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (e.LeftButton == MouseButtonState.Pressed)
			{
				DirItem DI = (DirItem)treeView.SelectedItem;
				if (DI == null)
					return;
				foreach(DirItem di in listView1.Items)
				{
					listView2.Items.Add(di);
				}
			}
		}
	}

	class DirItem : INotifyPropertyChanged
	{
		public String fileName { get; set; }
		public String fullPath { get; set; }
		private ObservableCollection<DirItem> nodes = new ObservableCollection<DirItem>();

		public event PropertyChangedEventHandler PropertyChanged;

		public ObservableCollection<DirItem> Nodes
		{
			get
			{
				if (this.PropertyChanged != null)
					this.PropertyChanged(this, new PropertyChangedEventArgs("node"));
				return this.nodes;
			}
			set { this.nodes = value; }
		}

		public String ImageName
		{
			get
			{
				if (fileName == fullPath)
					return @"Resources/disk.ico";
				else
					return @"Resources/folder.ico";
			}
		}

		public DirItem(String fileName, String fullPath = null)
		{
			this.fileName = fileName;
			this.fullPath = fullPath;
		}
	}
	class LoadedFile
	{
		public String Name { get; set; }
		public List<DirItem> Files;
		public LoadedFile(String name, List<DirItem> files)
		{
			this.Name = name;
			this.Files = files;
		}
	}
}
