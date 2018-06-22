namespace CinemasExam
{
	partial class AddingSessionsForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddingSessionsForm));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonAdd = new System.Windows.Forms.Button();
			this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
			this.daysTextBox = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.filmComboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.label1 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
			this.cinemaComboBox = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
			this.timeTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel6.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel4.SuspendLayout();
			this.tableLayoutPanel5.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tableLayoutPanel1.Controls.Add(this.buttonAdd, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 142);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// buttonAdd
			// 
			this.buttonAdd.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.buttonAdd.Location = new System.Drawing.Point(314, 89);
			this.buttonAdd.Name = "buttonAdd";
			this.buttonAdd.Size = new System.Drawing.Size(111, 34);
			this.buttonAdd.TabIndex = 5;
			this.buttonAdd.Text = "Добавить";
			this.buttonAdd.UseVisualStyleBackColor = true;
			this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
			// 
			// tableLayoutPanel6
			// 
			this.tableLayoutPanel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel6.ColumnCount = 1;
			this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel6.Controls.Add(this.daysTextBox, 0, 1);
			this.tableLayoutPanel6.Controls.Add(this.label5, 0, 0);
			this.tableLayoutPanel6.Location = new System.Drawing.Point(304, 8);
			this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(8);
			this.tableLayoutPanel6.Name = "tableLayoutPanel6";
			this.tableLayoutPanel6.RowCount = 2;
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel6.Size = new System.Drawing.Size(132, 55);
			this.tableLayoutPanel6.TabIndex = 4;
			// 
			// daysTextBox
			// 
			this.daysTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.daysTextBox.Location = new System.Drawing.Point(16, 30);
			this.daysTextBox.Name = "daysTextBox";
			this.daysTextBox.Size = new System.Drawing.Size(100, 20);
			this.daysTextBox.TabIndex = 2;
			this.daysTextBox.TabStop = false;
			this.daysTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.daysTextBox_KeyPress);
			this.daysTextBox.Leave += new System.EventHandler(this.daysTextBox_Leave);
			// 
			// label5
			// 
			this.label5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(10, 9);
			this.label5.Name = "label5";
			this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label5.Size = new System.Drawing.Size(112, 18);
			this.label5.TabIndex = 1;
			this.label5.Text = "Кол-во дней проката";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel3.ColumnCount = 1;
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Controls.Add(this.filmComboBox, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel3.Location = new System.Drawing.Point(156, 8);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(8);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 2;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(132, 55);
			this.tableLayoutPanel3.TabIndex = 1;
			// 
			// filmComboBox
			// 
			this.filmComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.filmComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.filmComboBox.FormattingEnabled = true;
			this.filmComboBox.Location = new System.Drawing.Point(5, 30);
			this.filmComboBox.Name = "filmComboBox";
			this.filmComboBox.Size = new System.Drawing.Size(121, 21);
			this.filmComboBox.TabIndex = 1;
			this.filmComboBox.TabStop = false;
			// 
			// label4
			// 
			this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(44, 9);
			this.label4.Name = "label4";
			this.label4.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label4.Size = new System.Drawing.Size(44, 18);
			this.label4.TabIndex = 1;
			this.label4.Text = "Фильм";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.dateTimePicker1, 0, 1);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(8, 8);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(8);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(132, 55);
			this.tableLayoutPanel2.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(49, 9);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label1.Size = new System.Drawing.Size(33, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Дата";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dateTimePicker1.Location = new System.Drawing.Point(3, 30);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(126, 20);
			this.dateTimePicker1.TabIndex = 0;
			this.dateTimePicker1.TabStop = false;
			// 
			// tableLayoutPanel4
			// 
			this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel4.ColumnCount = 1;
			this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Controls.Add(this.cinemaComboBox, 0, 1);
			this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
			this.tableLayoutPanel4.Location = new System.Drawing.Point(156, 79);
			this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(8);
			this.tableLayoutPanel4.Name = "tableLayoutPanel4";
			this.tableLayoutPanel4.RowCount = 2;
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel4.Size = new System.Drawing.Size(132, 55);
			this.tableLayoutPanel4.TabIndex = 2;
			// 
			// cinemaComboBox
			// 
			this.cinemaComboBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cinemaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cinemaComboBox.FormattingEnabled = true;
			this.cinemaComboBox.Location = new System.Drawing.Point(5, 30);
			this.cinemaComboBox.Name = "cinemaComboBox";
			this.cinemaComboBox.Size = new System.Drawing.Size(121, 21);
			this.cinemaComboBox.TabIndex = 4;
			this.cinemaComboBox.TabStop = false;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(36, 9);
			this.label3.Name = "label3";
			this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label3.Size = new System.Drawing.Size(60, 18);
			this.label3.TabIndex = 1;
			this.label3.Text = "Кинотеатр";
			// 
			// tableLayoutPanel5
			// 
			this.tableLayoutPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel5.ColumnCount = 1;
			this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.Controls.Add(this.timeTextBox, 0, 1);
			this.tableLayoutPanel5.Controls.Add(this.label2, 0, 0);
			this.tableLayoutPanel5.Location = new System.Drawing.Point(8, 79);
			this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(8);
			this.tableLayoutPanel5.Name = "tableLayoutPanel5";
			this.tableLayoutPanel5.RowCount = 2;
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.tableLayoutPanel5.Size = new System.Drawing.Size(132, 55);
			this.tableLayoutPanel5.TabIndex = 3;
			// 
			// timeTextBox
			// 
			this.timeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.timeTextBox.Location = new System.Drawing.Point(16, 30);
			this.timeTextBox.Name = "timeTextBox";
			this.timeTextBox.Size = new System.Drawing.Size(100, 20);
			this.timeTextBox.TabIndex = 3;
			this.timeTextBox.TabStop = false;
			this.timeTextBox.Leave += new System.EventHandler(this.timeTextBox_Leave);
			// 
			// label2
			// 
			this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 9);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.label2.Size = new System.Drawing.Size(75, 18);
			this.label2.TabIndex = 1;
			this.label2.Text = "Время(чч:мм)";
			// 
			// AddingSessionsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(444, 142);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AddingSessionsForm";
			this.Text = "Добавление сеансов";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel6.ResumeLayout(false);
			this.tableLayoutPanel6.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel4.ResumeLayout(false);
			this.tableLayoutPanel4.PerformLayout();
			this.tableLayoutPanel5.ResumeLayout(false);
			this.tableLayoutPanel5.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
		private System.Windows.Forms.TextBox daysTextBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.ComboBox filmComboBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
		private System.Windows.Forms.ComboBox cinemaComboBox;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
		private System.Windows.Forms.TextBox timeTextBox;
		private System.Windows.Forms.Button buttonAdd;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
	}
}