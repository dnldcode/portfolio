using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TaskManager
{
	public partial class Form1 : Form
	{
		Form2 f2 = new Form2();
		public Form1()
		{
			InitializeComponent();

			listView1.View = View.Details;
			listView1.Columns.Add("Имя", 150, HorizontalAlignment.Left);
			listView1.Columns.Add("Пользователь", 100, HorizontalAlignment.Left);
			listView1.Columns.Add("Время работы", 100, HorizontalAlignment.Left);
			listView1.Columns.Add("Время запуска", 100, HorizontalAlignment.Left);
			listView1.Columns.Add("Память", 100, HorizontalAlignment.Left);
			listView1.FullRowSelect = true;
			listView1.GridLines = true;
			listView1.MultiSelect = false;
			LoadItems();
		}

		private void LoadItems()
		{
			listView1.Items.Clear();
			Process[] processes = Process.GetProcesses();
			foreach(Process p in processes)
			{
				ListViewItem lvi = new ListViewItem(p.ProcessName);

				try
				{
					lvi.SubItems.Add(p.MachineName);
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}

				try
				{
					lvi.SubItems.Add(p.TotalProcessorTime.ToString());
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}


				try
				{
					lvi.SubItems.Add(p.StartTime.ToString());
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}


				try
				{
					lvi.SubItems.Add(Form1.BytesToString(p.PagedMemorySize64));
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}
					listView1.Items.Add(lvi);
			}
			listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
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

		private void button2_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count == 0)
			{
				MessageBox.Show("Не выбран процесс!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			try
			{
				Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[0].Text)[0].Kill();
			}
			catch
			{
				MessageBox.Show("Невозможно завершить процесс", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			listView1.Items.Remove(listView1.SelectedItems[0]);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			LoadItems();
		}


		private void listView1_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				if (listView1.FocusedItem.Bounds.Contains(e.Location) == true)
				{
					contextMenuStrip1.Items[1].Visible = true;
					contextMenuStrip1.Items[2].Visible = true;
					contextMenuStrip1.Items[3].Visible = true;
					try
					{
						ProcessModuleCollection pmc = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[0].Text)[0].Modules;
					}
					catch
					{
						contextMenuStrip1.Items[2].Visible = false;
					}
					try
					{
						ProcessThreadCollection ptc = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[0].Text)[0].Threads;
					}
					catch
					{
						contextMenuStrip1.Items[3].Visible = false;
					}
					try
					{
						ProcessPriorityClass priority = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[0].Text)[0].PriorityClass;
						if (priority == ProcessPriorityClass.RealTime)
							this.задатьПриоритетToolStripMenuItem.DropDownItems[0].Select();
						else if (priority == ProcessPriorityClass.High)
							this.задатьПриоритетToolStripMenuItem.DropDownItems[1].Select();
						else if (priority == ProcessPriorityClass.AboveNormal)
							this.задатьПриоритетToolStripMenuItem.DropDownItems[2].Select();
						else if (priority == ProcessPriorityClass.Normal)
							this.задатьПриоритетToolStripMenuItem.DropDownItems[3].Select();
						else if (priority == ProcessPriorityClass.BelowNormal)
							this.задатьПриоритетToolStripMenuItem.DropDownItems[4].Select();
						else if (priority == ProcessPriorityClass.Idle)
							this.задатьПриоритетToolStripMenuItem.DropDownItems[5].Select();
					}
					catch
					{
						contextMenuStrip1.Items[1].Visible = false;
					}
					finally
					{
						contextMenuStrip1.Show(Cursor.Position);
					}
				}
			}
		}

		private void toolStripMenuItem2_Click(object sender, EventArgs e)
		{
			this.button2_Click(null, null);
		}

		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Process process;
			try
			{
				process = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[0].Text)[0];
				if (sender == this.реальногоВремениToolStripMenuItem)
					process.PriorityClass = ProcessPriorityClass.RealTime;
				if (sender == this.высокийToolStripMenuItem)
					process.PriorityClass = ProcessPriorityClass.High;
				if (sender == this.вышеСреднегоToolStripMenuItem)
					process.PriorityClass = ProcessPriorityClass.AboveNormal;
				if (sender == this.обычныйToolStripMenuItem)
					process.PriorityClass = ProcessPriorityClass.Normal;
				if (sender == this.нижеСреднегоToolStripMenuItem)
					process.PriorityClass = ProcessPriorityClass.BelowNormal;
				if (sender == this.низкийToolStripMenuItem)
					process.PriorityClass = ProcessPriorityClass.Idle;
			}
			catch
			{
				MessageBox.Show("Невозможно получить доступ к потоку", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void списокМодулейToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessModuleCollection pmc =  Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[0].Text)[0].Modules;
			f2.Text = "Список Модулей";
			f2.listView1.Columns.Add("Имя", 100, HorizontalAlignment.Left);
			f2.listView1.Columns.Add("Адрес", 100, HorizontalAlignment.Left);
			f2.listView1.Columns.Add("Память", 100, HorizontalAlignment.Left);
			f2.listView1.Columns.Add("Путь", 100, HorizontalAlignment.Left);

			foreach (ProcessModule m in pmc)
			{
				ListViewItem lvi = new ListViewItem(m.ModuleName);
				try
				{
					lvi.SubItems.Add(m.BaseAddress.ToString());
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}
				try
				{
					lvi.SubItems.Add(Form1.BytesToString(m.ModuleMemorySize));
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}
				try
				{
					lvi.SubItems.Add(m.FileName);
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}


				f2.listView1.Items.Add(lvi);
			}

			f2.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			f2.ShowDialog();
			f2.listView1.Columns.Clear();
			f2.listView1.Items.Clear();
		}

		private void списокПотоковToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ProcessThreadCollection ptc = Process.GetProcessesByName(listView1.SelectedItems[0].SubItems[0].Text)[0].Threads;
			f2.Text = "Список потоков";
			f2.listView1.Columns.Add("Ид", 100, HorizontalAlignment.Left);
			f2.listView1.Columns.Add("Приоритет", 100, HorizontalAlignment.Left);
			f2.listView1.Columns.Add("Состояние", 100, HorizontalAlignment.Left);
			f2.listView1.Columns.Add("Время запуска", 100, HorizontalAlignment.Left);
			f2.listView1.Columns.Add("Причина ожидания", 100, HorizontalAlignment.Left);
			foreach (ProcessThread t in ptc)
			{
				ListViewItem lvi = new ListViewItem(t.Id.ToString());
				try
				{
					lvi.SubItems.Add(t.PriorityLevel.ToString());
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}
				try
				{
					lvi.SubItems.Add(t.ThreadState.ToString());
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}
				try
				{
					lvi.SubItems.Add(t.StartTime.ToString());
				}
				catch
				{
					lvi.SubItems.Add("Unknown");
				}
				if (t.ThreadState == System.Diagnostics.ThreadState.Wait)
					lvi.SubItems.Add(t.WaitReason.ToString());
				else
					lvi.SubItems.Add("None");

				f2.listView1.Items.Add(lvi);
			}
			f2.listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			f2.ShowDialog();
			f2.listView1.Columns.Clear();
			f2.listView1.Items.Clear();
		}
	}
}