using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ComboBoxLes7
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			for (int i = 0; i < 10; i++)
				this.listView.Items.Add(new Product("Snickers " + i, 12.5 + i, 50 + i));
		}

		private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (((ComboBoxItem)this.comboBox.SelectedItem).Name)
			{
				case "bigImg":
					this.bigImgList();
					break;
				case "smallImg":
					this.smallImgList();
					break;
				case "list":
					this.list_View();
					break;
				case "tile":
					this.tileView();
					break;
				case "table":
					this.tableView();
					break;
			}
		}

		private void bigImgList()
		{
			DataTemplate DT = new DataTemplate();
			FrameworkElementFactory FEFMain = new FrameworkElementFactory(typeof(UniformGrid));
			FEFMain.SetValue(UniformGrid.WidthProperty, 100.00);
			FEFMain.SetValue(UniformGrid.HeightProperty, 100.00);
			FEFMain.SetValue(UniformGrid.RowsProperty, 2);
			FEFMain.SetValue(UniformGrid.ColumnsProperty, 1);

			FrameworkElementFactory FEFSecondRow = new FrameworkElementFactory(typeof(UniformGrid));
			FEFSecondRow.SetValue(UniformGrid.RowsProperty, 1);
			FEFSecondRow.SetValue(UniformGrid.ColumnsProperty, 2);

			FrameworkElementFactory FEFLabelName = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelName = new Binding("Name");
			FEFLabelName.SetValue(ContentProperty, bindLabelName);

			FEFMain.AppendChild(FEFLabelName);
			FEFMain.AppendChild(FEFSecondRow);

			FrameworkElementFactory FEFLabelPrice = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelPrice = new Binding("Price");
			FEFLabelPrice.SetValue(ContentProperty, bindLabelPrice);
			FEFSecondRow.AppendChild(FEFLabelPrice);

			DT.VisualTree = FEFMain;
			this.listView.ItemTemplate = DT;
			this.listView.View = null;
			ItemsPanelTemplate IPT = new ItemsPanelTemplate();
			FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

			Binding bindWidth = new System.Windows.Data.Binding("ActualWidth");
			bindWidth.Source = this.listView;
			fefItemsPanel.SetValue(WrapPanel.WidthProperty, bindWidth);
			fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
			IPT.VisualTree = fefItemsPanel;
			this.listView.ItemsPanel = IPT;
		}
		private void smallImgList()
		{
			DataTemplate DT = new DataTemplate();
			FrameworkElementFactory FEFMain = new FrameworkElementFactory(typeof(UniformGrid));
			FEFMain.SetValue(UniformGrid.WidthProperty, 400.00);
			FEFMain.SetValue(UniformGrid.HeightProperty, 45.00);
			FEFMain.SetValue(UniformGrid.RowsProperty, 2);
			FEFMain.SetValue(UniformGrid.ColumnsProperty, 1);

			FrameworkElementFactory FEFSecondRow = new FrameworkElementFactory(typeof(UniformGrid));
			FEFSecondRow.SetValue(UniformGrid.RowsProperty, 1);
			FEFSecondRow.SetValue(UniformGrid.ColumnsProperty, 2);

			FrameworkElementFactory FEFLabelName = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelName = new Binding("Name");
			FEFLabelName.SetValue(ContentProperty, bindLabelName);

			FEFMain.AppendChild(FEFLabelName);
			FEFMain.AppendChild(FEFSecondRow);

			FrameworkElementFactory FEFLabelPrice = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelPrice = new Binding("Price");
			FEFLabelPrice.SetValue(ContentProperty, bindLabelPrice);
			FEFSecondRow.AppendChild(FEFLabelPrice);

			DT.VisualTree = FEFMain;
			this.listView.ItemTemplate = DT;
			this.listView.View = null;
			ItemsPanelTemplate IPT = new ItemsPanelTemplate();
			FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

			Binding bindWidth = new System.Windows.Data.Binding("ActualWidth");
			bindWidth.Source = this.listView;
			fefItemsPanel.SetValue(WrapPanel.WidthProperty, bindWidth);
			fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
			IPT.VisualTree = fefItemsPanel;
			this.listView.ItemsPanel = IPT;
		}
		public void tableView()
		{
			GridViewColumn col1 = new GridViewColumn();
			col1.Header = "Название";
			col1.DisplayMemberBinding = new System.Windows.Data.Binding("Name");

			GridViewColumn col2 = new GridViewColumn();
			col2.Header = "Стоимость";
			col2.DisplayMemberBinding = new System.Windows.Data.Binding("Price");

			GridViewColumn col3 = new GridViewColumn();
			col3.Header = "Вес";
			col3.DisplayMemberBinding = new System.Windows.Data.Binding("Weight");

			GridView GV = new GridView();
			GV.Columns.Add(col1);
			GV.Columns.Add(col2);
			GV.Columns.Add(col3);

			this.listView.View = GV;

			ItemsPanelTemplate IPT = new ItemsPanelTemplate();
			FrameworkElementFactory FEFUG = new FrameworkElementFactory(typeof(StackPanel));
			FEFUG.SetValue(StackPanel.OrientationProperty, System.Windows.Controls.Orientation.Vertical);
			IPT.VisualTree = FEFUG;
			this.listView.ItemsPanel = IPT;
		}
		public void list_View()
		{
			DataTemplate DT = new DataTemplate();
			FrameworkElementFactory FEFMain = new FrameworkElementFactory(typeof(UniformGrid));
			FEFMain.SetValue(UniformGrid.WidthProperty, 200.00);
			FEFMain.SetValue(UniformGrid.HeightProperty, 35.00);
			FEFMain.SetValue(UniformGrid.RowsProperty, 1);
			FEFMain.SetValue(UniformGrid.ColumnsProperty, 2);

			FrameworkElementFactory FEFSecondRow = new FrameworkElementFactory(typeof(UniformGrid));
			FEFSecondRow.SetValue(UniformGrid.RowsProperty, 1);
			FEFSecondRow.SetValue(UniformGrid.ColumnsProperty, 2);

			FrameworkElementFactory FEFLabelName = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelName = new Binding("Name");
			FEFLabelName.SetValue(ContentProperty, bindLabelName);

			FEFMain.AppendChild(FEFLabelName);
			FEFMain.AppendChild(FEFSecondRow);

			FrameworkElementFactory FEFLabelPrice = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelPrice = new Binding("Price");
			FEFLabelPrice.SetValue(ContentProperty, bindLabelPrice);
			FEFSecondRow.AppendChild(FEFLabelPrice);

			DT.VisualTree = FEFMain;
			this.listView.ItemTemplate = DT;


			this.listView.View = null;
			ItemsPanelTemplate IPT = new ItemsPanelTemplate();
			FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

			Binding bindWidth = new System.Windows.Data.Binding("ActualWidth");
			bindWidth.Source = this.listView;
			fefItemsPanel.SetValue(WrapPanel.WidthProperty, bindWidth);
			fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Vertical);
			IPT.VisualTree = fefItemsPanel;
			this.listView.ItemsPanel = IPT;
		}
		public void tileView()
		{
			DataTemplate DT = new DataTemplate();
			FrameworkElementFactory FEFMain = new FrameworkElementFactory(typeof(UniformGrid));
			FEFMain.SetValue(UniformGrid.WidthProperty, 300.00);
			FEFMain.SetValue(UniformGrid.HeightProperty, 70.00);
			FEFMain.SetValue(UniformGrid.RowsProperty, 2);
			FEFMain.SetValue(UniformGrid.ColumnsProperty, 1);

			FrameworkElementFactory FEFSecondRow = new FrameworkElementFactory(typeof(UniformGrid));
			FEFSecondRow.SetValue(UniformGrid.RowsProperty, 1);
			FEFSecondRow.SetValue(UniformGrid.ColumnsProperty, 2);

			FrameworkElementFactory FEFLabelName = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelName = new Binding("Name");
			FEFLabelName.SetValue(ContentProperty, bindLabelName);

			FEFMain.AppendChild(FEFLabelName);
			FEFMain.AppendChild(FEFSecondRow);

			FrameworkElementFactory FEFLabelPrice = new FrameworkElementFactory(typeof(Label));
			Binding bindLabelPrice = new Binding("Price");
			FEFLabelPrice.SetValue(ContentProperty, bindLabelPrice);
			FEFSecondRow.AppendChild(FEFLabelPrice);

			DT.VisualTree = FEFMain;
			this.listView.ItemTemplate = DT;
			this.listView.View = null;
			ItemsPanelTemplate IPT = new ItemsPanelTemplate();
			FrameworkElementFactory fefItemsPanel = new FrameworkElementFactory(typeof(WrapPanel));

			Binding bindWidth = new System.Windows.Data.Binding("ActualWidth");
			bindWidth.Source = this.listView;
			fefItemsPanel.SetValue(WrapPanel.WidthProperty, bindWidth);
			fefItemsPanel.SetValue(WrapPanel.OrientationProperty, Orientation.Horizontal);
			IPT.VisualTree = fefItemsPanel;
			this.listView.ItemsPanel = IPT;
		}
	}

	class Product
	{
		private double price;
		private String name;
		private int weight;
		public String Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;

			}
		}
		public double Price
		{
			get
			{
				return this.price;
			}
			set
			{
				this.price = value;

			}
		}
		public int Weight
		{
			get
			{
				return this.weight;
			}
			set
			{
				this.weight = value;

			}
		}

		public Product(String Name, double Price, int Weight)
		{
			this.Name = Name;
			this.Price = Price;
			this.Weight = Weight;
		}


	}
}

