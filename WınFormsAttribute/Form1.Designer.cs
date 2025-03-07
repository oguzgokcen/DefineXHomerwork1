namespace WınFormsAttribute
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			button1 = new Button();
			label1 = new Label();
			comboBox1 = new ComboBox();
			inputAmount = new TextBox();
			txtAmount = new Label();
			SuspendLayout();
			// 
			// button1
			// 
			button1.Location = new Point(312, 250);
			button1.Name = "button1";
			button1.Size = new Size(187, 23);
			button1.TabIndex = 0;
			button1.Text = "button1";
			button1.UseVisualStyleBackColor = true;
			button1.Click += button1_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(312, 315);
			label1.Name = "label1";
			label1.Size = new Size(38, 15);
			label1.TabIndex = 1;
			label1.Text = "label1";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(312, 153);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(199, 23);
			comboBox1.TabIndex = 2;
			comboBox1.Tag = "Ödeme türü";
			comboBox1.Text = "Ödeme türü";
			// 
			// inputAmount
			// 
			inputAmount.Location = new Point(315, 202);
			inputAmount.MaxLength = 20;
			inputAmount.Name = "inputAmount";
			inputAmount.PlaceholderText = "Miktar Giriniz";
			inputAmount.Size = new Size(196, 23);
			inputAmount.TabIndex = 3;
			// 
			// txtAmount
			// 
			txtAmount.AutoSize = true;
			txtAmount.Location = new Point(315, 228);
			txtAmount.Name = "txtAmount";
			txtAmount.Size = new Size(41, 15);
			txtAmount.TabIndex = 4;
			txtAmount.Text = "Miktar";
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(txtAmount);
			Controls.Add(inputAmount);
			Controls.Add(comboBox1);
			Controls.Add(label1);
			Controls.Add(button1);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Label label1;
		private ComboBox comboBox1;
		private TextBox inputAmount;
		private Label txtAmount;
	}
}
