namespace TaskManager
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.listView1 = new TaskManager.MyListView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.задатьПриоритетToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.реальногоВремениToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.высокийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.вышеСреднегоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.обычныйToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.нижеСреднегоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.низкийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокМодулейToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.списокПотоковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.listView1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.45316F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.54684F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(798, 459);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 409);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(792, 47);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.button1.Location = new System.Drawing.Point(249, 7);
			this.button1.Margin = new System.Windows.Forms.Padding(3, 3, 25, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(122, 32);
			this.button1.TabIndex = 0;
			this.button1.Text = "Обновить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.button2.Location = new System.Drawing.Point(421, 7);
			this.button2.Margin = new System.Windows.Forms.Padding(25, 3, 3, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(160, 32);
			this.button2.TabIndex = 1;
			this.button2.Text = "Завершить процесс";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// listView1
			// 
			this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listView1.Location = new System.Drawing.Point(3, 3);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(792, 400);
			this.listView1.TabIndex = 1;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.задатьПриоритетToolStripMenuItem,
            this.списокМодулейToolStripMenuItem,
            this.списокПотоковToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(172, 92);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(171, 22);
			this.toolStripMenuItem2.Text = "Убить процесс";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
			// 
			// задатьПриоритетToolStripMenuItem
			// 
			this.задатьПриоритетToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.реальногоВремениToolStripMenuItem,
            this.высокийToolStripMenuItem,
            this.вышеСреднегоToolStripMenuItem,
            this.обычныйToolStripMenuItem,
            this.нижеСреднегоToolStripMenuItem,
            this.низкийToolStripMenuItem});
			this.задатьПриоритетToolStripMenuItem.Name = "задатьПриоритетToolStripMenuItem";
			this.задатьПриоритетToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.задатьПриоритетToolStripMenuItem.Text = "Задать приоритет";
			// 
			// реальногоВремениToolStripMenuItem
			// 
			this.реальногоВремениToolStripMenuItem.Name = "реальногоВремениToolStripMenuItem";
			this.реальногоВремениToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.реальногоВремениToolStripMenuItem.Text = "Реального времени";
			this.реальногоВремениToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// высокийToolStripMenuItem
			// 
			this.высокийToolStripMenuItem.Name = "высокийToolStripMenuItem";
			this.высокийToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.высокийToolStripMenuItem.Text = "Высокий";
			this.высокийToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// вышеСреднегоToolStripMenuItem
			// 
			this.вышеСреднегоToolStripMenuItem.Name = "вышеСреднегоToolStripMenuItem";
			this.вышеСреднегоToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.вышеСреднегоToolStripMenuItem.Text = "Выше среднего";
			this.вышеСреднегоToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// обычныйToolStripMenuItem
			// 
			this.обычныйToolStripMenuItem.Name = "обычныйToolStripMenuItem";
			this.обычныйToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.обычныйToolStripMenuItem.Text = "Обычный";
			this.обычныйToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// нижеСреднегоToolStripMenuItem
			// 
			this.нижеСреднегоToolStripMenuItem.Name = "нижеСреднегоToolStripMenuItem";
			this.нижеСреднегоToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.нижеСреднегоToolStripMenuItem.Text = "Ниже среднего";
			this.нижеСреднегоToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// низкийToolStripMenuItem
			// 
			this.низкийToolStripMenuItem.Name = "низкийToolStripMenuItem";
			this.низкийToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
			this.низкийToolStripMenuItem.Text = "Низкий";
			this.низкийToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
			// 
			// списокМодулейToolStripMenuItem
			// 
			this.списокМодулейToolStripMenuItem.Name = "списокМодулейToolStripMenuItem";
			this.списокМодулейToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.списокМодулейToolStripMenuItem.Text = "Список модулей";
			this.списокМодулейToolStripMenuItem.Click += new System.EventHandler(this.списокМодулейToolStripMenuItem_Click);
			// 
			// списокПотоковToolStripMenuItem
			// 
			this.списокПотоковToolStripMenuItem.Name = "списокПотоковToolStripMenuItem";
			this.списокПотоковToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
			this.списокПотоковToolStripMenuItem.Text = "Список потоков";
			this.списокПотоковToolStripMenuItem.Click += new System.EventHandler(this.списокПотоковToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(798, 459);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Task Manager v0.02";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private MyListView listView1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem задатьПриоритетToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem реальногоВремениToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem высокийToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem вышеСреднегоToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem обычныйToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem нижеСреднегоToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem низкийToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокМодулейToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem списокПотоковToolStripMenuItem;
	}
}

