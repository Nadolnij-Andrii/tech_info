namespace tech_info
{
    partial class FormAddNewCashier
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addCardButton = new System.Windows.Forms.Button();
            this.asddCashierButton = new System.Windows.Forms.Button();
            this.cashierFIORichTextBox = new System.Windows.Forms.RichTextBox();
            this.cashierIdTextBox = new System.Windows.Forms.TextBox();
            this.cashierCardTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 81);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "ФИО";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 254);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "№ Карты";
            // 
            // addCardButton
            // 
            this.addCardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCardButton.Location = new System.Drawing.Point(18, 305);
            this.addCardButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.addCardButton.Name = "addCardButton";
            this.addCardButton.Size = new System.Drawing.Size(221, 50);
            this.addCardButton.TabIndex = 3;
            this.addCardButton.Text = "Добавить карту";
            this.addCardButton.UseVisualStyleBackColor = true;
            this.addCardButton.Click += new System.EventHandler(this.addCardButton_Click);
            // 
            // asddCashierButton
            // 
            this.asddCashierButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.asddCashierButton.Location = new System.Drawing.Point(393, 305);
            this.asddCashierButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.asddCashierButton.Name = "asddCashierButton";
            this.asddCashierButton.Size = new System.Drawing.Size(221, 48);
            this.asddCashierButton.TabIndex = 4;
            this.asddCashierButton.Text = "Добавить кассира";
            this.asddCashierButton.UseVisualStyleBackColor = true;
            this.asddCashierButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // cashierFIORichTextBox
            // 
            this.cashierFIORichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierFIORichTextBox.Location = new System.Drawing.Point(128, 75);
            this.cashierFIORichTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cashierFIORichTextBox.Name = "cashierFIORichTextBox";
            this.cashierFIORichTextBox.Size = new System.Drawing.Size(483, 121);
            this.cashierFIORichTextBox.TabIndex = 5;
            this.cashierFIORichTextBox.Text = "";
            // 
            // cashierIdTextBox
            // 
            this.cashierIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierIdTextBox.Location = new System.Drawing.Point(128, 18);
            this.cashierIdTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cashierIdTextBox.Name = "cashierIdTextBox";
            this.cashierIdTextBox.Size = new System.Drawing.Size(483, 29);
            this.cashierIdTextBox.TabIndex = 6;
            // 
            // cashierCardTextBox
            // 
            this.cashierCardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierCardTextBox.Location = new System.Drawing.Point(128, 249);
            this.cashierCardTextBox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.cashierCardTextBox.Name = "cashierCardTextBox";
            this.cashierCardTextBox.ReadOnly = true;
            this.cashierCardTextBox.Size = new System.Drawing.Size(483, 29);
            this.cashierCardTextBox.TabIndex = 7;
            // 
            // FormAddNewCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 373);
            this.Controls.Add(this.cashierCardTextBox);
            this.Controls.Add(this.cashierIdTextBox);
            this.Controls.Add(this.cashierFIORichTextBox);
            this.Controls.Add(this.asddCashierButton);
            this.Controls.Add(this.addCardButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormAddNewCashier";
            this.Text = "Добавить нового кассира";
            this.Load += new System.EventHandler(this.FormAddNewCashier_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addCardButton;
        private System.Windows.Forms.Button asddCashierButton;
        private System.Windows.Forms.RichTextBox cashierFIORichTextBox;
        private System.Windows.Forms.TextBox cashierIdTextBox;
        private System.Windows.Forms.TextBox cashierCardTextBox;
    }
}