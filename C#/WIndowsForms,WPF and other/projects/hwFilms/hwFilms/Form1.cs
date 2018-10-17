using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace hwFilms
{
	public partial class Form1 : Form
	{
		static public bool isSorted = false;
		public Form1()
		{
			InitializeComponent();

			toolStripComboBox1.SelectedIndex = 0;
			ColumnHeader name = new ColumnHeader();
			ColumnHeader genre = new ColumnHeader();
			ColumnHeader year = new ColumnHeader();
			ColumnHeader lasting = new ColumnHeader();
			name.Text = "Название";
			name.Width = 200;
			genre.Text = "Жанр";
			genre.Width = 100;
			year.Text = "Год";
			year.Width = 80;
			lasting.Text = "Длительность, мин";
			lasting.Width = 80;
			listView1.ColumnClick += ListView1_ColumnClick;
			listView1.Columns.Add(name);
			listView1.Columns.Add(genre);
			listView1.Columns.Add(year);
			listView1.Columns.Add(lasting);

			List<Film> films = new List<Film>();
			films.Add(new Film("Побег из Шоушенка", "драма", 1994, 142));
			films.Add(new Film("Зеленая миля", "фэнтези", 1999, 189));
			films.Add(new Film("Форрест Гамп", "драма", 1994, 142));
			films.Add(new Film("Список Шиндлера", "биография", 1993, 195));
			films.Add(new Film("Криминальное чтиво", "триллер", 1994, 154));
			films.Add(new Film("Бойцовский клуб", "драма", 1999, 131));


			foreach (Film f in films)
			{
				ListViewItem LVI = new ListViewItem(f.name);
				LVI.SubItems.Add(f.genre);
				LVI.SubItems.Add(f.year.ToString());
				LVI.SubItems.Add(f.lasting.ToString());
				if (f.genre == "драма")
					LVI.ImageIndex = 0;
				else if (f.genre == "фэнтези")
					LVI.ImageIndex = 1;
				else if (f.genre == "биография")
					LVI.ImageIndex = 2;
				else if (f.genre == "триллер")
					LVI.ImageIndex = 3;
				listView1.Items.Add(LVI);
			}
		}

		private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
		{
			isSorted = !isSorted;
			this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
		}

		private void StyleChanged(object sender, EventArgs e)
		{
			if (toolStripComboBox1.SelectedIndex == 0)
				listView1.View = View.Details;
			else if (toolStripComboBox1.SelectedIndex == 1)
				listView1.View = View.LargeIcon;
			else if (toolStripComboBox1.SelectedIndex == 2)
				listView1.View = View.List;
			else if (toolStripComboBox1.SelectedIndex == 3)
				listView1.View = View.SmallIcon;
			else if (toolStripComboBox1.SelectedIndex == 4)
				listView1.View = View.Tile;
		}
	}
	public class Film
	{
		public String name { get; set; }
		public String genre { get; set; }
		public int year { get; set; }
		public int lasting { get; set; }

		public Film(String name = "Unknown", String genre = "Unknown", int year = 0, int lasting = 0)
		{
			this.name = name;
			this.genre = genre;
			this.year = year;
			this.lasting = lasting;
		}
	}
	class ListViewItemComparer : IComparer
	{
		private int col;
		public ListViewItemComparer()
		{
			col = 0;
		}
		public ListViewItemComparer(int column)
		{
			col = column;
		}
		public int Compare(object x, object y)
		{
			if (Form1.isSorted)
				return String.Compare(((ListViewItem)y).SubItems[col].Text, ((ListViewItem)x).SubItems[col].Text);
			else
				return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
		}
	}
}
