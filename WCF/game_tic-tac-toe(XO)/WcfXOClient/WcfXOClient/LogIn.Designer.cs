namespace WcfXOClient
{
	partial class LogIn
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.49296F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.50704F));
			this.tableLayoutPanel1.Controls.Add(this.textBoxInput, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonOK, 1, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(234, 31);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// textBoxInput
			// 
			this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInput.Location = new System.Drawing.Point(3, 5);
			this.textBoxInput.MaxLength = 25;
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(170, 20);
			this.textBoxInput.TabIndex = 0;
			this.textBoxInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInput_KeyDown);
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.buttonOK.Location = new System.Drawing.Point(179, 3);
			this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(52, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "Войти";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			// 
			// LogIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(234, 31);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "LogIn";
			this.Text = "Авторизация";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		public System.Windows.Forms.TextBox textBoxInput;
		private System.Windows.Forms.Button buttonOK;
	}
}