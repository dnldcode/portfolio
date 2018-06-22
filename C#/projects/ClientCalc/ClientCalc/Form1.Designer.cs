namespace ClientCalc
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.buttonPlus = new System.Windows.Forms.Button();
			this.buttonMinus = new System.Windows.Forms.Button();
			this.buttonDiv = new System.Windows.Forms.Button();
			this.buttonMult = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.buttonResult = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.textBox1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.textBox3, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.buttonResult, 0, 3);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.66197F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.33803F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 164);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(3, 3);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(244, 20);
			this.textBox1.TabIndex = 0;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(3, 74);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(244, 20);
			this.textBox2.TabIndex = 1;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
			this.tableLayoutPanel2.Controls.Add(this.buttonPlus, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.buttonMinus, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.buttonDiv, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.buttonMult, 2, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 34);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(244, 34);
			this.tableLayoutPanel2.TabIndex = 3;
			// 
			// buttonPlus
			// 
			this.buttonPlus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonPlus.Location = new System.Drawing.Point(3, 3);
			this.buttonPlus.Name = "buttonPlus";
			this.buttonPlus.Size = new System.Drawing.Size(55, 28);
			this.buttonPlus.TabIndex = 0;
			this.buttonPlus.Text = "+";
			this.buttonPlus.UseVisualStyleBackColor = true;
			this.buttonPlus.Click += new System.EventHandler(this.buttons_Click);
			// 
			// buttonMinus
			// 
			this.buttonMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMinus.Location = new System.Drawing.Point(64, 3);
			this.buttonMinus.Name = "buttonMinus";
			this.buttonMinus.Size = new System.Drawing.Size(55, 28);
			this.buttonMinus.TabIndex = 1;
			this.buttonMinus.Text = "-";
			this.buttonMinus.UseVisualStyleBackColor = true;
			this.buttonMinus.Click += new System.EventHandler(this.buttons_Click);
			// 
			// buttonDiv
			// 
			this.buttonDiv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonDiv.Location = new System.Drawing.Point(186, 3);
			this.buttonDiv.Name = "buttonDiv";
			this.buttonDiv.Size = new System.Drawing.Size(55, 28);
			this.buttonDiv.TabIndex = 2;
			this.buttonDiv.Text = "/";
			this.buttonDiv.UseVisualStyleBackColor = true;
			this.buttonDiv.Click += new System.EventHandler(this.buttons_Click);
			// 
			// buttonMult
			// 
			this.buttonMult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonMult.Location = new System.Drawing.Point(125, 3);
			this.buttonMult.Name = "buttonMult";
			this.buttonMult.Size = new System.Drawing.Size(55, 28);
			this.buttonMult.TabIndex = 3;
			this.buttonMult.Text = "*";
			this.buttonMult.UseVisualStyleBackColor = true;
			this.buttonMult.Click += new System.EventHandler(this.buttons_Click);
			// 
			// textBox3
			// 
			this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox3.Location = new System.Drawing.Point(3, 135);
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(244, 20);
			this.textBox3.TabIndex = 2;
			// 
			// buttonResult
			// 
			this.buttonResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonResult.Location = new System.Drawing.Point(3, 102);
			this.buttonResult.Name = "buttonResult";
			this.buttonResult.Size = new System.Drawing.Size(244, 23);
			this.buttonResult.TabIndex = 4;
			this.buttonResult.Text = "=";
			this.buttonResult.UseVisualStyleBackColor = true;
			this.buttonResult.Click += new System.EventHandler(this.buttonResult_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(250, 164);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Calc";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button buttonPlus;
		private System.Windows.Forms.Button buttonMinus;
		private System.Windows.Forms.Button buttonDiv;
		private System.Windows.Forms.Button buttonMult;
		private System.Windows.Forms.Button buttonResult;
	}
}

