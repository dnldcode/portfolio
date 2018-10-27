namespace hw8menu
{
	partial class Form2
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.checkBox1Access = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.fileCB5 = new System.Windows.Forms.CheckBox();
			this.fileCB4 = new System.Windows.Forms.CheckBox();
			this.fileCB3 = new System.Windows.Forms.CheckBox();
			this.fileCB2 = new System.Windows.Forms.CheckBox();
			this.fileCB1 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.editCB6 = new System.Windows.Forms.CheckBox();
			this.editCB5 = new System.Windows.Forms.CheckBox();
			this.editCB4 = new System.Windows.Forms.CheckBox();
			this.editCB3 = new System.Windows.Forms.CheckBox();
			this.editCB2 = new System.Windows.Forms.CheckBox();
			this.editCB1 = new System.Windows.Forms.CheckBox();
			this.checkBox2Access = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.windowsCB5 = new System.Windows.Forms.CheckBox();
			this.windowsCB4 = new System.Windows.Forms.CheckBox();
			this.windowsCB3 = new System.Windows.Forms.CheckBox();
			this.windowsCB2 = new System.Windows.Forms.CheckBox();
			this.windowsCB1 = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.checkBox3Access = new System.Windows.Forms.CheckBox();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// checkBox1Access
			// 
			this.checkBox1Access.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1Access.AutoSize = true;
			this.checkBox1Access.Checked = true;
			this.checkBox1Access.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1Access.Location = new System.Drawing.Point(56, 3);
			this.checkBox1Access.Name = "checkBox1Access";
			this.checkBox1Access.Size = new System.Drawing.Size(47, 17);
			this.checkBox1Access.TabIndex = 0;
			this.checkBox1Access.Text = "File";
			this.checkBox1Access.UseVisualStyleBackColor = true;
			this.checkBox1Access.CheckedChanged += new System.EventHandler(this.checkBoxChecking);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.fileCB5);
			this.groupBox1.Controls.Add(this.fileCB4);
			this.groupBox1.Controls.Add(this.fileCB3);
			this.groupBox1.Controls.Add(this.fileCB2);
			this.groupBox1.Controls.Add(this.fileCB1);
			this.groupBox1.Location = new System.Drawing.Point(34, 59);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(269, 83);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "File Submenu";
			// 
			// fileCB5
			// 
			this.fileCB5.AutoSize = true;
			this.fileCB5.Location = new System.Drawing.Point(100, 51);
			this.fileCB5.Name = "fileCB5";
			this.fileCB5.Size = new System.Drawing.Size(48, 17);
			this.fileCB5.TabIndex = 6;
			this.fileCB5.Text = "New";
			this.fileCB5.UseVisualStyleBackColor = true;
			this.fileCB5.CheckedChanged += new System.EventHandler(this.FileChanged);
			// 
			// fileCB4
			// 
			this.fileCB4.AutoSize = true;
			this.fileCB4.Location = new System.Drawing.Point(14, 51);
			this.fileCB4.Name = "fileCB4";
			this.fileCB4.Size = new System.Drawing.Size(51, 17);
			this.fileCB4.TabIndex = 5;
			this.fileCB4.Text = "Save";
			this.fileCB4.UseVisualStyleBackColor = true;
			this.fileCB4.CheckedChanged += new System.EventHandler(this.FileChanged);
			// 
			// fileCB3
			// 
			this.fileCB3.AutoSize = true;
			this.fileCB3.Location = new System.Drawing.Point(186, 19);
			this.fileCB3.Name = "fileCB3";
			this.fileCB3.Size = new System.Drawing.Size(43, 17);
			this.fileCB3.TabIndex = 4;
			this.fileCB3.Text = "Exit";
			this.fileCB3.UseVisualStyleBackColor = true;
			this.fileCB3.CheckedChanged += new System.EventHandler(this.FileChanged);
			// 
			// fileCB2
			// 
			this.fileCB2.AutoSize = true;
			this.fileCB2.Location = new System.Drawing.Point(100, 19);
			this.fileCB2.Name = "fileCB2";
			this.fileCB2.Size = new System.Drawing.Size(66, 17);
			this.fileCB2.TabIndex = 3;
			this.fileCB2.Text = "Save As";
			this.fileCB2.UseVisualStyleBackColor = true;
			this.fileCB2.CheckedChanged += new System.EventHandler(this.FileChanged);
			// 
			// fileCB1
			// 
			this.fileCB1.AutoSize = true;
			this.fileCB1.Location = new System.Drawing.Point(14, 19);
			this.fileCB1.Name = "fileCB1";
			this.fileCB1.Size = new System.Drawing.Size(52, 17);
			this.fileCB1.TabIndex = 2;
			this.fileCB1.Text = "Open";
			this.fileCB1.UseVisualStyleBackColor = true;
			this.fileCB1.CheckedChanged += new System.EventHandler(this.FileChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox2.Controls.Add(this.editCB6);
			this.groupBox2.Controls.Add(this.editCB5);
			this.groupBox2.Controls.Add(this.editCB4);
			this.groupBox2.Controls.Add(this.editCB3);
			this.groupBox2.Controls.Add(this.editCB2);
			this.groupBox2.Controls.Add(this.editCB1);
			this.groupBox2.Location = new System.Drawing.Point(34, 178);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(269, 81);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Edit Submenu";
			// 
			// editCB6
			// 
			this.editCB6.AutoSize = true;
			this.editCB6.Location = new System.Drawing.Point(186, 51);
			this.editCB6.Name = "editCB6";
			this.editCB6.Size = new System.Drawing.Size(46, 17);
			this.editCB6.TabIndex = 7;
			this.editCB6.Text = "Find";
			this.editCB6.UseVisualStyleBackColor = true;
			this.editCB6.CheckedChanged += new System.EventHandler(this.EditChanged);
			// 
			// editCB5
			// 
			this.editCB5.AutoSize = true;
			this.editCB5.Location = new System.Drawing.Point(100, 51);
			this.editCB5.Name = "editCB5";
			this.editCB5.Size = new System.Drawing.Size(52, 17);
			this.editCB5.TabIndex = 6;
			this.editCB5.Text = "Undo";
			this.editCB5.UseVisualStyleBackColor = true;
			this.editCB5.CheckedChanged += new System.EventHandler(this.EditChanged);
			// 
			// editCB4
			// 
			this.editCB4.AutoSize = true;
			this.editCB4.Location = new System.Drawing.Point(13, 51);
			this.editCB4.Name = "editCB4";
			this.editCB4.Size = new System.Drawing.Size(53, 17);
			this.editCB4.TabIndex = 5;
			this.editCB4.Text = "Paste";
			this.editCB4.UseVisualStyleBackColor = true;
			this.editCB4.CheckedChanged += new System.EventHandler(this.EditChanged);
			// 
			// editCB3
			// 
			this.editCB3.AutoSize = true;
			this.editCB3.Location = new System.Drawing.Point(186, 19);
			this.editCB3.Name = "editCB3";
			this.editCB3.Size = new System.Drawing.Size(52, 17);
			this.editCB3.TabIndex = 4;
			this.editCB3.Text = "Redo";
			this.editCB3.UseVisualStyleBackColor = true;
			this.editCB3.CheckedChanged += new System.EventHandler(this.EditChanged);
			// 
			// editCB2
			// 
			this.editCB2.AutoSize = true;
			this.editCB2.Location = new System.Drawing.Point(100, 19);
			this.editCB2.Name = "editCB2";
			this.editCB2.Size = new System.Drawing.Size(42, 17);
			this.editCB2.TabIndex = 3;
			this.editCB2.Text = "Cut";
			this.editCB2.UseVisualStyleBackColor = true;
			this.editCB2.CheckedChanged += new System.EventHandler(this.EditChanged);
			// 
			// editCB1
			// 
			this.editCB1.AutoSize = true;
			this.editCB1.Location = new System.Drawing.Point(14, 19);
			this.editCB1.Name = "editCB1";
			this.editCB1.Size = new System.Drawing.Size(50, 17);
			this.editCB1.TabIndex = 2;
			this.editCB1.Text = "Copy";
			this.editCB1.UseVisualStyleBackColor = true;
			this.editCB1.CheckedChanged += new System.EventHandler(this.EditChanged);
			// 
			// checkBox2Access
			// 
			this.checkBox2Access.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox2Access.AutoSize = true;
			this.checkBox2Access.Checked = true;
			this.checkBox2Access.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2Access.Location = new System.Drawing.Point(56, 3);
			this.checkBox2Access.Name = "checkBox2Access";
			this.checkBox2Access.Size = new System.Drawing.Size(47, 18);
			this.checkBox2Access.TabIndex = 2;
			this.checkBox2Access.Text = "Edit";
			this.checkBox2Access.UseVisualStyleBackColor = true;
			this.checkBox2Access.CheckedChanged += new System.EventHandler(this.checkBoxChecking);
			// 
			// groupBox3
			// 
			this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox3.Controls.Add(this.windowsCB5);
			this.groupBox3.Controls.Add(this.windowsCB4);
			this.groupBox3.Controls.Add(this.windowsCB3);
			this.groupBox3.Controls.Add(this.windowsCB2);
			this.groupBox3.Controls.Add(this.windowsCB1);
			this.groupBox3.Location = new System.Drawing.Point(34, 295);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(269, 80);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Windows Submenu";
			// 
			// windowsCB5
			// 
			this.windowsCB5.AutoSize = true;
			this.windowsCB5.Location = new System.Drawing.Point(100, 51);
			this.windowsCB5.Name = "windowsCB5";
			this.windowsCB5.Size = new System.Drawing.Size(92, 17);
			this.windowsCB5.TabIndex = 6;
			this.windowsCB5.Text = "Arrange Icons";
			this.windowsCB5.UseVisualStyleBackColor = true;
			this.windowsCB5.CheckedChanged += new System.EventHandler(this.WindowsChanged);
			// 
			// windowsCB4
			// 
			this.windowsCB4.AutoSize = true;
			this.windowsCB4.Location = new System.Drawing.Point(14, 51);
			this.windowsCB4.Name = "windowsCB4";
			this.windowsCB4.Size = new System.Drawing.Size(68, 17);
			this.windowsCB4.TabIndex = 5;
			this.windowsCB4.Text = "Cascade";
			this.windowsCB4.UseVisualStyleBackColor = true;
			this.windowsCB4.CheckedChanged += new System.EventHandler(this.WindowsChanged);
			// 
			// windowsCB3
			// 
			this.windowsCB3.AutoSize = true;
			this.windowsCB3.Location = new System.Drawing.Point(186, 19);
			this.windowsCB3.Name = "windowsCB3";
			this.windowsCB3.Size = new System.Drawing.Size(48, 17);
			this.windowsCB3.TabIndex = 4;
			this.windowsCB3.Text = "Next";
			this.windowsCB3.UseVisualStyleBackColor = true;
			this.windowsCB3.CheckedChanged += new System.EventHandler(this.WindowsChanged);
			// 
			// windowsCB2
			// 
			this.windowsCB2.AutoSize = true;
			this.windowsCB2.Location = new System.Drawing.Point(100, 19);
			this.windowsCB2.Name = "windowsCB2";
			this.windowsCB2.Size = new System.Drawing.Size(80, 17);
			this.windowsCB2.TabIndex = 3;
			this.windowsCB2.Text = "Minimize All";
			this.windowsCB2.UseVisualStyleBackColor = true;
			this.windowsCB2.CheckedChanged += new System.EventHandler(this.WindowsChanged);
			// 
			// windowsCB1
			// 
			this.windowsCB1.AutoSize = true;
			this.windowsCB1.Location = new System.Drawing.Point(14, 19);
			this.windowsCB1.Name = "windowsCB1";
			this.windowsCB1.Size = new System.Drawing.Size(43, 17);
			this.windowsCB1.TabIndex = 2;
			this.windowsCB1.Text = "Tile";
			this.windowsCB1.UseVisualStyleBackColor = true;
			this.windowsCB1.CheckedChanged += new System.EventHandler(this.WindowsChanged);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 5);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 6);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 7;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.47472F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.52039F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.321369F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.07668F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.321369F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.85481F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.430669F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(338, 417);
			this.tableLayoutPanel1.TabIndex = 10;
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 3;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.26506F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.6988F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.03614F));
			this.tableLayoutPanel3.Controls.Add(this.checkBox3Access, 1, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 265);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(332, 24);
			this.tableLayoutPanel3.TabIndex = 13;
			// 
			// checkBox3Access
			// 
			this.checkBox3Access.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox3Access.AutoSize = true;
			this.checkBox3Access.Checked = true;
			this.checkBox3Access.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox3Access.Location = new System.Drawing.Point(57, 3);
			this.checkBox3Access.Name = "checkBox3Access";
			this.checkBox3Access.Size = new System.Drawing.Size(76, 18);
			this.checkBox3Access.TabIndex = 8;
			this.checkBox3Access.Text = "Windows";
			this.checkBox3Access.UseVisualStyleBackColor = true;
			this.checkBox3Access.CheckedChanged += new System.EventHandler(this.checkBoxChecking);
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.ColumnCount = 3;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.26506F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.96386F));
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.77109F));
			this.tableLayoutPanel4.Controls.Add(this.checkBox2Access, 1, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 148);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 1;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(332, 24);
			this.tableLayoutPanel4.TabIndex = 12;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
			this.tableLayoutPanel2.Controls.Add(this.button2, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.button1, 0, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 381);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(332, 33);
			this.tableLayoutPanel2.TabIndex = 10;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(103, 3);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(94, 27);
			this.button2.TabIndex = 1;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.buttonCancel);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(3, 3);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 27);
			this.button1.TabIndex = 0;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.buttonOK);
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.ColumnCount = 1;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel5, 0, 1);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 2;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(332, 50);
			this.tableLayoutPanel6.TabIndex = 14;
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.ColumnCount = 3;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.26506F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.26506F));
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.46988F));
			this.tableLayoutPanel5.Controls.Add(this.checkBox1Access, 1, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 24);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 1;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(326, 23);
			this.tableLayoutPanel5.TabIndex = 13;
			// 
			// Form2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(338, 422);
			this.Controls.Add(this.tableLayoutPanel1);
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(354, 461);
			this.Name = "Form2";
			this.Text = "Menu Configuration";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox1Access;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox fileCB5;
		private System.Windows.Forms.CheckBox fileCB4;
		private System.Windows.Forms.CheckBox fileCB3;
		private System.Windows.Forms.CheckBox fileCB2;
		private System.Windows.Forms.CheckBox fileCB1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.CheckBox editCB6;
		private System.Windows.Forms.CheckBox editCB5;
		private System.Windows.Forms.CheckBox editCB4;
		private System.Windows.Forms.CheckBox editCB3;
		private System.Windows.Forms.CheckBox editCB2;
		private System.Windows.Forms.CheckBox editCB1;
		private System.Windows.Forms.CheckBox checkBox2Access;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox windowsCB5;
		private System.Windows.Forms.CheckBox windowsCB4;
		private System.Windows.Forms.CheckBox windowsCB3;
		private System.Windows.Forms.CheckBox windowsCB2;
		private System.Windows.Forms.CheckBox windowsCB1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.CheckBox checkBox3Access;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
	}
}