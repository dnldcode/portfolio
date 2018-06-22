namespace RegeditExam
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.строковыйПараметрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.двоичныйПараметрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.параметрDWORD32БитаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.параметрQWORD64БитаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.мультистроковыйПараметрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.расширяемыйСтроковыйПараметрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.contextMenuStrip2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 619);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(1110, 20);
			this.textBox1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 33);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.listView1);
			this.splitContainer1.Size = new System.Drawing.Size(1110, 583);
			this.splitContainer1.SplitterDistance = 369;
			this.splitContainer1.TabIndex = 1;
			// 
			// treeView1
			// 
			this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.treeView1.ImageIndex = 0;
			this.treeView1.ImageList = this.imageList1;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = 0;
			this.treeView1.Size = new System.Drawing.Size(369, 583);
			this.treeView1.TabIndex = 0;
			this.treeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
			this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(127, 48);
			this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
			// 
			// добавитьToolStripMenuItem
			// 
			this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
			this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.добавитьToolStripMenuItem.Text = "Добавить";
			this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.добавитьToolStripMenuItem_Click);
			// 
			// удалитьToolStripMenuItem
			// 
			this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
			this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.удалитьToolStripMenuItem.Text = "Удалить";
			this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "2.ico");
			this.imageList1.Images.SetKeyName(1, "1.ico");
			// 
			// listView1
			// 
			this.listView1.ContextMenuStrip = this.contextMenuStrip2;
			this.listView1.Cursor = System.Windows.Forms.Cursors.Default;
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(737, 583);
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem1,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem1});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(129, 70);
			this.contextMenuStrip2.Opened += new System.EventHandler(this.contextMenuStrip2_Opened);
			// 
			// добавитьToolStripMenuItem1
			// 
			this.добавитьToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.строковыйПараметрToolStripMenuItem,
            this.двоичныйПараметрToolStripMenuItem,
            this.параметрDWORD32БитаToolStripMenuItem,
            this.параметрQWORD64БитаToolStripMenuItem,
            this.мультистроковыйПараметрToolStripMenuItem,
            this.расширяемыйСтроковыйПараметрToolStripMenuItem});
			this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
			this.добавитьToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.добавитьToolStripMenuItem1.Text = "Создать";
			// 
			// изменитьToolStripMenuItem
			// 
			this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
			this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.изменитьToolStripMenuItem.Text = "Изменить";
			this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
			// 
			// удалитьToolStripMenuItem1
			// 
			this.удалитьToolStripMenuItem1.Name = "удалитьToolStripMenuItem1";
			this.удалитьToolStripMenuItem1.Size = new System.Drawing.Size(128, 22);
			this.удалитьToolStripMenuItem1.Text = "Удалить";
			this.удалитьToolStripMenuItem1.Click += new System.EventHandler(this.удалитьToolStripMenuItem1_Click);
			// 
			// строковыйПараметрToolStripMenuItem
			// 
			this.строковыйПараметрToolStripMenuItem.Name = "строковыйПараметрToolStripMenuItem";
			this.строковыйПараметрToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.строковыйПараметрToolStripMenuItem.Text = "Строковый параметр";
			this.строковыйПараметрToolStripMenuItem.Click += new System.EventHandler(this.строковыйПараметрToolStripMenuItem_Click);
			// 
			// двоичныйПараметрToolStripMenuItem
			// 
			this.двоичныйПараметрToolStripMenuItem.Name = "двоичныйПараметрToolStripMenuItem";
			this.двоичныйПараметрToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.двоичныйПараметрToolStripMenuItem.Text = "Двоичный параметр";
			this.двоичныйПараметрToolStripMenuItem.Click += new System.EventHandler(this.двоичныйПараметрToolStripMenuItem_Click);
			// 
			// параметрDWORD32БитаToolStripMenuItem
			// 
			this.параметрDWORD32БитаToolStripMenuItem.Name = "параметрDWORD32БитаToolStripMenuItem";
			this.параметрDWORD32БитаToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.параметрDWORD32БитаToolStripMenuItem.Text = "Параметр DWORD (32 бита)";
			this.параметрDWORD32БитаToolStripMenuItem.Click += new System.EventHandler(this.параметрDWORD32БитаToolStripMenuItem_Click);
			// 
			// параметрQWORD64БитаToolStripMenuItem
			// 
			this.параметрQWORD64БитаToolStripMenuItem.Name = "параметрQWORD64БитаToolStripMenuItem";
			this.параметрQWORD64БитаToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.параметрQWORD64БитаToolStripMenuItem.Text = "Параметр QWORD (64 бита)";
			this.параметрQWORD64БитаToolStripMenuItem.Click += new System.EventHandler(this.параметрQWORD64БитаToolStripMenuItem_Click);
			// 
			// мультистроковыйПараметрToolStripMenuItem
			// 
			this.мультистроковыйПараметрToolStripMenuItem.Name = "мультистроковыйПараметрToolStripMenuItem";
			this.мультистроковыйПараметрToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.мультистроковыйПараметрToolStripMenuItem.Text = "Мультистроковый параметр";
			this.мультистроковыйПараметрToolStripMenuItem.Click += new System.EventHandler(this.мультистроковыйПараметрToolStripMenuItem_Click);
			// 
			// расширяемыйСтроковыйПараметрToolStripMenuItem
			// 
			this.расширяемыйСтроковыйПараметрToolStripMenuItem.Name = "расширяемыйСтроковыйПараметрToolStripMenuItem";
			this.расширяемыйСтроковыйПараметрToolStripMenuItem.Size = new System.Drawing.Size(274, 22);
			this.расширяемыйСтроковыйПараметрToolStripMenuItem.Text = "Расширяемый строковый параметр";
			this.расширяемыйСтроковыйПараметрToolStripMenuItem.Click += new System.EventHandler(this.расширяемыйСтроковыйПараметрToolStripMenuItem_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1116, 619);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "Редактор реестра";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.contextMenuStrip1.ResumeLayout(false);
			this.contextMenuStrip2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem строковыйПараметрToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem двоичныйПараметрToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem параметрDWORD32БитаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem параметрQWORD64БитаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem мультистроковыйПараметрToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem расширяемыйСтроковыйПараметрToolStripMenuItem;
	}
}

