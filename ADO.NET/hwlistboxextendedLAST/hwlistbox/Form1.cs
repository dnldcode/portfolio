using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hwlistbox
{
	public partial class Form1 : Form
	{
		Form3 f3 = new Form3();
		Form4 f4 = new Form4();
		public Form1()
		{
			InitializeComponent();
		
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.MultiSelect = false;
			listView1.View = View.Details;
			listView1.Columns.Add("id", -2, HorizontalAlignment.Left);
			listView1.Columns.Add("name", -2, HorizontalAlignment.Left);

			listView2.FullRowSelect = true;
			listView2.GridLines = true;
			listView2.MultiSelect = false;
			listView2.View = View.Details;
			listView2.Columns.Add("id", -2, HorizontalAlignment.Left);
			listView2.Columns.Add("name", -2, HorizontalAlignment.Left);
			listView2.Columns.Add("genre", -2, HorizontalAlignment.Left);

			ReloadItems();
		}

		private void ReloadItems()
		{
			listView1.Items.Clear();
			using (var ctx = new CinemasEntities())
			{
				var genres = from T in ctx.Genre select T;
				foreach (Genre g in genres)
				{
					ListViewItem item = new ListViewItem(g.id.ToString());
					item.SubItems.Add(g.name);
					listView1.Items.Add(item);
				}
				ctx.SaveChanges();
			}

			listView2.Items.Clear();
			using (var ctx = new CinemasEntities())
			{
				var films = from T in ctx.Film select T;
				foreach (Film f in films)
				{
					ListViewItem item = new ListViewItem(f.id.ToString());
					item.SubItems.Add(f.name);
					foreach (ListViewItem lvi in listView1.Items)
					{
						if (lvi.SubItems[0].Text == f.id_genre.ToString())
							item.SubItems.Add(lvi.SubItems[1]);
					}
					listView2.Items.Add(item);
				}
				ctx.SaveChanges();
			}
		}
		private void button_add(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tabPage1)
			{
				f3.Text = "Adding";
				f3.textBox1.Text = "";
				f3.ShowDialog();
				if (f3.genre == null)
					return;
				using (var ctx = new CinemasEntities())
				{
					Genre c1 = new Genre()
					{
						name = f3.genre
					};
					ctx.Genre.Add(c1);
					ctx.SaveChanges();
					if (checkBox1.Checked)
						MessageBox.Show("Жанр был успешно добавлен!", "Успех");
					ReloadItems();
				}
			}
			else if (tabControl1.SelectedTab == tabPage2)
			{
				f4.Text = "Adding";
				f4.textBox1.Text = "";
				f4.comboBox1.Items.Clear();
				foreach (ListViewItem lvi in listView1.Items)
					f4.comboBox1.Items.Add(lvi.SubItems[1].Text);
				f4.comboBox1.SelectedIndex = 0;
				f4.ShowDialog();
				if (f4.name == null)
					return;
				using (var ctx = new CinemasEntities())
				{
					int ind = 0;
					foreach (ListViewItem lvi in listView1.Items)
						if (lvi.SubItems[1].Text == f4.selectedGenre)
						{
							ind = Convert.ToInt32(lvi.SubItems[0].Text);
							break;
						}
					Film c1 = new Film()
					{
						name = f4.name,
						id_genre = ind
					};
					ctx.Film.Add(c1);
					ctx.SaveChanges();
					if (checkBox1.Checked)
						MessageBox.Show("Фильм был успешно добавлен!", "Успех");
					ReloadItems();
				}
			}
		}

		private void button_edit(object sender, EventArgs e)
		{
			if(tabControl1.SelectedTab == tabPage1)
			{
				if (listView1.SelectedItems.Count == 0)
				{
					MessageBox.Show("Жанр не выбран.", "Ошибка");
					return;
				}
				f3.Text = "Editing";
				f3.textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
				f3.ShowDialog();
				if (f3.genre == null)
					return;
				using (var ctx = new CinemasEntities())
				{
					int gId = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
					var gObj = from T in ctx.Genre where (T.id == gId) select T;
					gObj.FirstOrDefault().name = f3.genre;
					ctx.SaveChanges();
					if (checkBox1.Checked)
						MessageBox.Show("Жанр был успешно изменен!", "Успех");
					ReloadItems();
				}
			}
			else if (tabControl1.SelectedTab == tabPage2)
			{
				if (listView2.SelectedItems.Count == 0)
				{
					MessageBox.Show("Фильм не выбран.", "Ошибка");
					return;
				}
				f4.Text = "Editing";
				f4.textBox1.Text = listView2.SelectedItems[0].SubItems[1].Text;
				f4.comboBox1.Items.Clear();
				foreach (ListViewItem lvi in listView1.Items)
					f4.comboBox1.Items.Add(lvi.SubItems[1].Text);
				f4.comboBox1.SelectedItem = listView2.SelectedItems[0].SubItems[2].Text;
				f4.ShowDialog();
				if (f4.name == null)
					return;

				using (var ctx = new CinemasEntities())
				{
					int gId = Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text);
					var gObj = from T in ctx.Film where (T.id == gId) select T;
					int ind = 0;
					foreach (ListViewItem lvi in listView1.Items)
						if (lvi.SubItems[1].Text == f4.selectedGenre)
						{
							ind = Convert.ToInt32(lvi.SubItems[0].Text);
							break;
						}
					gObj.FirstOrDefault().name = f4.name;
					gObj.FirstOrDefault().id_genre = ind;
					ctx.SaveChanges();
					if(checkBox1.Checked)
						MessageBox.Show("Жанр был успешно изменен!", "Успех");
					ReloadItems();
				}
			}
		}

		private void button_delete(object sender, EventArgs e)
		{
			if(tabControl1.SelectedTab == tabPage1)
			{
				if(listView1.SelectedItems.Count == 0)
				{
					MessageBox.Show("Жанр не выбран.", "Ошибка");
					return;
				}
				using (var ctx = new CinemasEntities())
				{
					int gId = Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text);
					var gObj = from T in ctx.Genre where (T.id == gId) select T;
					ctx.Genre.Remove(gObj.FirstOrDefault());
					if (MessageBox.Show(String.Format("Вы действительно хотите удалить жанр '{0}'?", gObj.First().name), "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
						return;
					try
					{
						ctx.SaveChanges();
					}
					catch
					{
						MessageBox.Show("Нарушение связей", "Ошибка");
						return;
					}
					if (checkBox1.Checked)
						MessageBox.Show("Жанр был успешно удален!", "Успех");
					ReloadItems();
				}
			}
			else if (tabControl1.SelectedTab == tabPage2)
			{
				if(listView2.SelectedItems.Count == 0)
				{
					MessageBox.Show("Фильм не выбран.", "Ошибка");
					return;
				}
				using (var ctx = new CinemasEntities())
				{
					int fId = Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text);
					var fObj = from T in ctx.Film where (T.id == fId) select T;
					ctx.Film.Remove(fObj.FirstOrDefault());
					if (MessageBox.Show(String.Format("Вы действительно хотите удалить фильм '{0}'?", fObj.First().name), "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.No)
						return;
					ctx.SaveChanges();
					if (checkBox1.Checked)
						MessageBox.Show("Фильм был успешно удален!", "Успех");
					ReloadItems();
				}
			}
		}

		private void listView_DoubleClick(object sender, EventArgs e)
		{
			if (tabControl1.SelectedTab == tabPage1)
			{
				if (listView1.Items.Count != 0)
				{
					this.button_edit(null, null);
				}
			}
			else if (tabControl1.SelectedTab == tabPage2)
			{
				if (listView2.Items.Count != 0)
				{
					this.button_edit(null, null);
				}
			}
		}

		private void listView_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Delete)
			{
				if (tabControl1.SelectedTab == tabPage1)
				{
					if (listView1.Items.Count != 0)
					{
						this.button_delete(null, null);
					}
				}
				else if (tabControl1.SelectedTab == tabPage2)
				{
					if (listView2.Items.Count != 0)
					{
						this.button_delete(null, null);
					}
				}
			}
		}
	}
}
