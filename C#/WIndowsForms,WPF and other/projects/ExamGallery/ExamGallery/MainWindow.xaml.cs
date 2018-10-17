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
						//if (Directory.GetDirectories(dir).Length > -0)
							DI.Nodes.Add(new DirItem("1"));
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
					String extension = Path.GetExtension(file);
					if (extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".svg")
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
			if (treeView.SelectedItem == null)
			{
				MessageBox.Show("Невозможно выполнить действие. Папка не выбрана", " Ошибка выполнения", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			else
			{
				if (sender == button1Forward)
				{
					try
					{
						DirItem DI = (DirItem)treeView.SelectedItem;
						String[] files = Directory.GetFiles(DI.fullPath);
						List<DirItem> temp = new List<DirItem>();
						foreach (String file in files)
						{
							String extension = Path.GetExtension(file);
							if (extension == ".png" || extension == ".bmp" || extension == ".jpg" || extension == ".svg")
							{
								DirItem adding = new DirItem(Path.GetFileName(file), file);
								listView3.Items.Add(adding);
								temp.Add(adding);
							}
						}
						if (temp.Count != 0)
							listView2.Items.Add(new LoadedFile(DI.fileName, temp));
					}
					catch { }
				}
				if (sender == button2Forward)
				{
					System.Collections.IList dir = (System.Collections.IList)listView1.SelectedItems;
					String tempName = "";
					List<DirItem> temp = new List<DirItem>();
					foreach (object obj in dir)
					{
						DirItem diItem = obj as DirItem;
						tempName += diItem.fileName + " ";
						temp.Add(diItem);
						listView3.Items.Add(diItem);
					}
					if (temp.Count != 0)
						listView2.Items.Add(new LoadedFile(tempName, temp));
				}
			}
		}

		private void buttonBack_Click(object sender, RoutedEventArgs e)
		{
			if (treeView.SelectedItem == null)
			{
				MessageBox.Show("Невозможно выполнить действие. Папка не выбрана", " Ошибка выполнения", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (sender == button3Back)
			{
				System.Collections.IList dir = (System.Collections.IList)listView2.SelectedItems;
				if (dir == null)
					return;
				List<LoadedFile> list = new List<LoadedFile>();
				foreach (object obj in dir)
				{
					LoadedFile ld = obj as LoadedFile;
					list.Add(ld);
					foreach (DirItem di in ld.Files)
					{
						listView3.Items.Remove(di);
					}
				}
				foreach (LoadedFile lds in list)
				{
					listView2.Items.Remove(lds);
				}
				mainImage.Source = null;
				listView2.SelectedIndex = 0;
			}
			else if (sender == button4Back)
			{
				System.Collections.IList dir = (System.Collections.IList)listView3.SelectedItems;
				if (dir == null)
					return;
				List<DirItem> list = new List<DirItem>();
				foreach (object obj in dir)
					list.Add(obj as DirItem);
				foreach (DirItem lds in list)
				{
					listView3.Items.Remove(lds);
				}
				mainImage.Source = null;
				listView3.SelectedIndex = 0;
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
