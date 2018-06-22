namespace StartDialogWindows
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.цветФонаОкнаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.цветФонаОкнаToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.label1 = new System.Windows.Forms.Label();
			this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.открытьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветФонаОкнаToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(603, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// цветФонаОкнаToolStripMenuItem
			// 
			this.цветФонаОкнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветФонаОкнаToolStripMenuItem1,
            this.открытьToolStripMenuItem,
            this.шрифтToolStripMenuItem,
            this.открытьToolStripMenuItem1});
			this.цветФонаОкнаToolStripMenuItem.Name = "цветФонаОкнаToolStripMenuItem";
			this.цветФонаОкнаToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
			this.цветФонаОкнаToolStripMenuItem.Text = "Цвет фона окна";
			// 
			// цветФонаОкнаToolStripMenuItem1
			// 
			this.цветФонаОкнаToolStripMenuItem1.Name = "цветФонаОкнаToolStripMenuItem1";
			this.цветФонаОкнаToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
			this.цветФонаОкнаToolStripMenuItem1.Text = "Цвет фона окна";
			this.цветФонаОкнаToolStripMenuItem1.Click += new System.EventHandler(this.MenuItemBackColor_Click);
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.открытьToolStripMenuItem.Text = "Каталог";
			this.открытьToolStripMenuItem.Click += new System.EventHandler(this.MenuItemChooseFolder_CLick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(476, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Hello World";
			// 
			// шрифтToolStripMenuItem
			// 
			this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
			this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
			this.шрифтToolStripMenuItem.Text = "Шрифт";
			this.шрифтToolStripMenuItem.Click += new System.EventHandler(this.MenuItemFont_Click);
			// 
			// открытьToolStripMenuItem1
			// 
			this.открытьToolStripMenuItem1.Name = "открытьToolStripMenuItem1";
			this.открытьToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
			this.открытьToolStripMenuItem1.Text = "Открыть";
			this.открытьToolStripMenuItem1.Click += new System.EventHandler(this.MenuItemOpen_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(0, 27);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(603, 366);
			this.textBox1.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(603, 392);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Standrts Windows";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem цветФонаОкнаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem цветФонаОкнаToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem1;
		private System.Windows.Forms.TextBox textBox1;
	}
}

