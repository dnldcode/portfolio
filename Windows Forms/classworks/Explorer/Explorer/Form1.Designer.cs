namespace Explorer
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.TreeViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.createTW = new System.Windows.Forms.ToolStripMenuItem();
			this.createTWCatalog = new System.Windows.Forms.ToolStripMenuItem();
			this.renameTW = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteTW = new System.Windows.Forms.ToolStripMenuItem();
			this.explorerList = new System.Windows.Forms.ListView();
			this.ListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.create = new System.Windows.Forms.ToolStripMenuItem();
			this.createCatalog = new System.Windows.Forms.ToolStripMenuItem();
			this.goBackButton = new System.Windows.Forms.ToolStripMenuItem();
			this.refresh = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.copy = new System.Windows.Forms.ToolStripMenuItem();
			this.paste = new System.Windows.Forms.ToolStripMenuItem();
			this.rename = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.delete = new System.Windows.Forms.ToolStripMenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.prevButton = new System.Windows.Forms.ToolStripButton();
			this.filePath = new System.Windows.Forms.ToolStripTextBox();
			this.comboBox1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.detailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.largeIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.smallIconToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.imageList2 = new System.Windows.Forms.ImageList(this.components);
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.TreeViewContextMenu.SuspendLayout();
			this.ListViewContextMenu.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.076142F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.92386F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(939, 591);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.Location = new System.Drawing.Point(3, 32);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.treeView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.explorerList);
			this.splitContainer1.Size = new System.Drawing.Size(933, 556);
			this.splitContainer1.SplitterDistance = 185;
			this.splitContainer1.TabIndex = 1;
			// 
			// treeView1
			// 
			this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.treeView1.ContextMenuStrip = this.TreeViewContextMenu;
			this.treeView1.Location = new System.Drawing.Point(0, 0);
			this.treeView1.Name = "treeView1";
			this.treeView1.Size = new System.Drawing.Size(182, 561);
			this.treeView1.TabIndex = 0;
			// 
			// TreeViewContextMenu
			// 
			this.TreeViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTW,
            this.renameTW,
            this.toolStripMenuItem3,
            this.deleteTW});
			this.TreeViewContextMenu.Name = "TreeViewContextMenu";
			this.TreeViewContextMenu.Size = new System.Drawing.Size(181, 76);
			// 
			// createTW
			// 
			this.createTW.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createTWCatalog});
			this.createTW.Name = "createTW";
			this.createTW.Size = new System.Drawing.Size(180, 22);
			this.createTW.Text = "Создать";
			// 
			// createTWCatalog
			// 
			this.createTWCatalog.Name = "createTWCatalog";
			this.createTWCatalog.Size = new System.Drawing.Size(117, 22);
			this.createTWCatalog.Text = "Каталог";
			this.createTWCatalog.Click += new System.EventHandler(this.ContextMenuTWCreateCatalog_Click);
			// 
			// renameTW
			// 
			this.renameTW.Name = "renameTW";
			this.renameTW.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.renameTW.Size = new System.Drawing.Size(180, 22);
			this.renameTW.Text = "Переименовать";
			this.renameTW.Click += new System.EventHandler(this.ContextMenuTWRename_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(177, 6);
			// 
			// deleteTW
			// 
			this.deleteTW.Name = "deleteTW";
			this.deleteTW.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.deleteTW.Size = new System.Drawing.Size(180, 22);
			this.deleteTW.Text = "Удалить";
			this.deleteTW.Click += new System.EventHandler(this.ContextMenuTWDelete_Click);
			// 
			// explorerList
			// 
			this.explorerList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.explorerList.ContextMenuStrip = this.ListViewContextMenu;
			this.explorerList.LargeImageList = this.imageList1;
			this.explorerList.Location = new System.Drawing.Point(3, -3);
			this.explorerList.Name = "explorerList";
			this.explorerList.Size = new System.Drawing.Size(738, 564);
			this.explorerList.SmallImageList = this.imageList1;
			this.explorerList.StateImageList = this.imageList1;
			this.explorerList.TabIndex = 2;
			this.explorerList.UseCompatibleStateImageBehavior = false;
			// 
			// ListViewContextMenu
			// 
			this.ListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.create,
            this.goBackButton,
            this.refresh,
            this.toolStripMenuItem1,
            this.copy,
            this.paste,
            this.rename,
            this.toolStripMenuItem2,
            this.delete});
			this.ListViewContextMenu.Name = "contextMenuStrip1";
			this.ListViewContextMenu.Size = new System.Drawing.Size(182, 170);
			this.ListViewContextMenu.Opened += new System.EventHandler(this.ListViewContextMenu_Opened);
			// 
			// create
			// 
			this.create.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCatalog});
			this.create.Name = "create";
			this.create.Size = new System.Drawing.Size(181, 22);
			this.create.Text = "Создать";
			// 
			// createCatalog
			// 
			this.createCatalog.Name = "createCatalog";
			this.createCatalog.Size = new System.Drawing.Size(117, 22);
			this.createCatalog.Text = "Каталог";
			this.createCatalog.Click += new System.EventHandler(this.ContextMenuLWCreate_Click);
			// 
			// goBackButton
			// 
			this.goBackButton.Name = "goBackButton";
			this.goBackButton.Size = new System.Drawing.Size(181, 22);
			this.goBackButton.Text = "Назад";
			this.goBackButton.Click += new System.EventHandler(this.goBackButton_Click);
			// 
			// refresh
			// 
			this.refresh.Name = "refresh";
			this.refresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
			this.refresh.Size = new System.Drawing.Size(181, 22);
			this.refresh.Text = "Обновить";
			this.refresh.Click += new System.EventHandler(this.ContextMenuLWRefresh_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(178, 6);
			// 
			// copy
			// 
			this.copy.Name = "copy";
			this.copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copy.Size = new System.Drawing.Size(181, 22);
			this.copy.Text = "Копировать";
			this.copy.Click += new System.EventHandler(this.ContextMenuLWCopy_Click);
			// 
			// paste
			// 
			this.paste.Name = "paste";
			this.paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.paste.Size = new System.Drawing.Size(181, 22);
			this.paste.Text = "Вставить";
			this.paste.Click += new System.EventHandler(this.ContextMenuLWPaste_Click);
			// 
			// rename
			// 
			this.rename.Name = "rename";
			this.rename.ShortcutKeys = System.Windows.Forms.Keys.F2;
			this.rename.Size = new System.Drawing.Size(181, 22);
			this.rename.Text = "Переименовать";
			this.rename.Click += new System.EventHandler(this.ContextMenuLWRename_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(178, 6);
			// 
			// delete
			// 
			this.delete.Name = "delete";
			this.delete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
			this.delete.Size = new System.Drawing.Size(181, 22);
			this.delete.Text = "Удалить";
			this.delete.Click += new System.EventHandler(this.ContextMenuLWRemove_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "imageres_5.ico");
			this.imageList1.Images.SetKeyName(1, "imageres_3.ico");
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.90032F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.09968F));
			this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.MinimumSize = new System.Drawing.Size(0, 25);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(933, 25);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.toolStrip1.AutoSize = false;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prevButton,
            this.filePath,
            this.comboBox1});
			this.toolStrip1.Location = new System.Drawing.Point(194, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(739, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// prevButton
			// 
			this.prevButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.prevButton.Image = global::Explorer.Properties.Resources.imageres_5315;
			this.prevButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.prevButton.Name = "prevButton";
			this.prevButton.Size = new System.Drawing.Size(23, 22);
			this.prevButton.Text = "Назад";
			this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
			// 
			// filePath
			// 
			this.filePath.Name = "filePath";
			this.filePath.Size = new System.Drawing.Size(450, 25);
			this.filePath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxKeyDown);
			// 
			// comboBox1
			// 
			this.comboBox1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.comboBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailsToolStripMenuItem,
            this.largeIconToolStripMenuItem,
            this.listToolStripMenuItem,
            this.smallIconToolStripMenuItem,
            this.tileToolStripMenuItem});
			this.comboBox1.Image = global::Explorer.Properties.Resources.imageres_5308;
			this.comboBox1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(29, 22);
			this.comboBox1.Text = "Вид";
			// 
			// detailsToolStripMenuItem
			// 
			this.detailsToolStripMenuItem.Name = "detailsToolStripMenuItem";
			this.detailsToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.detailsToolStripMenuItem.Text = "Details";
			this.detailsToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
			// 
			// largeIconToolStripMenuItem
			// 
			this.largeIconToolStripMenuItem.Name = "largeIconToolStripMenuItem";
			this.largeIconToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.largeIconToolStripMenuItem.Text = "LargeIcon";
			this.largeIconToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
			// 
			// listToolStripMenuItem
			// 
			this.listToolStripMenuItem.Name = "listToolStripMenuItem";
			this.listToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.listToolStripMenuItem.Text = "List";
			this.listToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
			// 
			// smallIconToolStripMenuItem
			// 
			this.smallIconToolStripMenuItem.Name = "smallIconToolStripMenuItem";
			this.smallIconToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.smallIconToolStripMenuItem.Text = "SmallIcon";
			this.smallIconToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
			// 
			// tileToolStripMenuItem
			// 
			this.tileToolStripMenuItem.Name = "tileToolStripMenuItem";
			this.tileToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
			this.tileToolStripMenuItem.Text = "Tile";
			this.tileToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem_Click);
			// 
			// errorProvider
			// 
			this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
			this.errorProvider.ContainerControl = this;
			// 
			// imageList2
			// 
			this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
			this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList2.Images.SetKeyName(0, "imageres_5.ico");
			this.imageList2.Images.SetKeyName(1, "imageres_3.ico");
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(939, 594);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(680, 425);
			this.Name = "Form1";
			this.Text = "Проводник";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.TreeViewContextMenu.ResumeLayout(false);
			this.ListViewContextMenu.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ErrorProvider errorProvider;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView explorerList;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.ContextMenuStrip ListViewContextMenu;
		private System.Windows.Forms.ToolStripMenuItem refresh;
		private System.Windows.Forms.ToolStripMenuItem create;
		private System.Windows.Forms.ToolStripMenuItem createCatalog;
		private System.Windows.Forms.ToolStripMenuItem copy;
		private System.Windows.Forms.ToolStripMenuItem paste;
		private System.Windows.Forms.ToolStripMenuItem rename;
		private System.Windows.Forms.ToolStripMenuItem delete;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ContextMenuStrip TreeViewContextMenu;
		private System.Windows.Forms.ToolStripMenuItem createTW;
		private System.Windows.Forms.ToolStripMenuItem createTWCatalog;
		private System.Windows.Forms.ToolStripMenuItem renameTW;
		private System.Windows.Forms.ToolStripMenuItem deleteTW;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton prevButton;
		private System.Windows.Forms.ToolStripTextBox filePath;
		private System.Windows.Forms.ToolStripDropDownButton comboBox1;
		private System.Windows.Forms.ToolStripMenuItem detailsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem largeIconToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem smallIconToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tileToolStripMenuItem;
		private System.Windows.Forms.ImageList imageList2;
		private System.Windows.Forms.ToolStripMenuItem goBackButton;
	}
}

