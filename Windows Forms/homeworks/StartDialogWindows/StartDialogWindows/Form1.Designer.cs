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
			this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.шрифтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.цветФонаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.цветТекстаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.writingField = new System.Windows.Forms.TextBox();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.цветФонаОкнаToolStripMenuItem,
            this.настройкиToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(994, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// цветФонаОкнаToolStripMenuItem
			// 
			this.цветФонаОкнаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.выходToolStripMenuItem});
			this.цветФонаОкнаToolStripMenuItem.Name = "цветФонаОкнаToolStripMenuItem";
			this.цветФонаОкнаToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
			this.цветФонаОкнаToolStripMenuItem.Text = "Файл";
			// 
			// открытьToolStripMenuItem
			// 
			this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
			this.открытьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.открытьToolStripMenuItem.Text = "Открыть";
			this.открытьToolStripMenuItem.Click += new System.EventHandler(this.MenuItemOpen_Click);
			// 
			// сохранитьToolStripMenuItem
			// 
			this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
			this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.сохранитьToolStripMenuItem.Text = "Сохранить";
			this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.MenuItemSave_Click);
			// 
			// выходToolStripMenuItem
			// 
			this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
			this.выходToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
			this.выходToolStripMenuItem.Text = "Выход";
			this.выходToolStripMenuItem.Click += new System.EventHandler(this.MenuItemExit_Click);
			// 
			// настройкиToolStripMenuItem
			// 
			this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.шрифтToolStripMenuItem,
            this.цветФонаToolStripMenuItem,
            this.цветТекстаToolStripMenuItem});
			this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
			this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
			this.настройкиToolStripMenuItem.Text = "Настройки";
			// 
			// шрифтToolStripMenuItem
			// 
			this.шрифтToolStripMenuItem.Name = "шрифтToolStripMenuItem";
			this.шрифтToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.шрифтToolStripMenuItem.Text = "Шрифт";
			this.шрифтToolStripMenuItem.Click += new System.EventHandler(this.MenuItemFont_Click);
			// 
			// цветФонаToolStripMenuItem
			// 
			this.цветФонаToolStripMenuItem.Name = "цветФонаToolStripMenuItem";
			this.цветФонаToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.цветФонаToolStripMenuItem.Text = "Цвет фона";
			this.цветФонаToolStripMenuItem.Click += new System.EventHandler(this.MenuItemBackGroundColor_Click);
			// 
			// цветТекстаToolStripMenuItem
			// 
			this.цветТекстаToolStripMenuItem.Name = "цветТекстаToolStripMenuItem";
			this.цветТекстаToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.цветТекстаToolStripMenuItem.Text = "Цвет текста";
			this.цветТекстаToolStripMenuItem.Click += new System.EventHandler(this.MenuItemForeColor_Click);
			// 
			// writingField
			// 
			this.writingField.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.writingField.Location = new System.Drawing.Point(0, 27);
			this.writingField.Multiline = true;
			this.writingField.Name = "writingField";
			this.writingField.Size = new System.Drawing.Size(994, 492);
			this.writingField.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(994, 518);
			this.Controls.Add(this.writingField);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Form1";
			this.Text = "Блокнот";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem цветФонаОкнаToolStripMenuItem;
		private System.Windows.Forms.TextBox writingField;
		private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem шрифтToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem цветФонаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem цветТекстаToolStripMenuItem;
	}
}

