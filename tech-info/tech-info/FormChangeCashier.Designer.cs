namespace tech_info
{
    partial class FormChangeCashier
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
            this.cashierCardTextBox = new System.Windows.Forms.TextBox();
            this.cashierIdTextBox = new System.Windows.Forms.TextBox();
            this.cashierFIORichTextBox = new System.Windows.Forms.RichTextBox();
            this.changeCashierInfoButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.changeCardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cashierCardTextBox
            // 
            this.cashierCardTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierCardTextBox.Location = new System.Drawing.Point(136, 308);
            this.cashierCardTextBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cashierCardTextBox.Name = "cashierCardTextBox";
            this.cashierCardTextBox.ReadOnly = true;
            this.cashierCardTextBox.Size = new System.Drawing.Size(768, 29);
            this.cashierCardTextBox.TabIndex = 15;
            // 
            // cashierIdTextBox
            // 
            this.cashierIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierIdTextBox.Location = new System.Drawing.Point(136, 17);
            this.cashierIdTextBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cashierIdTextBox.Name = "cashierIdTextBox";
            this.cashierIdTextBox.ReadOnly = true;
            this.cashierIdTextBox.Size = new System.Drawing.Size(765, 29);
            this.cashierIdTextBox.TabIndex = 14;
            // 
            // cashierFIORichTextBox
            // 
            this.cashierFIORichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierFIORichTextBox.Location = new System.Drawing.Point(136, 94);
            this.cashierFIORichTextBox.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.cashierFIORichTextBox.Name = "cashierFIORichTextBox";
            this.cashierFIORichTextBox.Size = new System.Drawing.Size(768, 148);
            this.cashierFIORichTextBox.TabIndex = 13;
            this.cashierFIORichTextBox.Text = "";
            // 
            // changeCashierInfoButton
            // 
            this.changeCashierInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.changeCashierInfoButton.Location = new System.Drawing.Point(612, 351);
            this.changeCashierInfoButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.changeCashierInfoButton.Name = "changeCashierInfoButton";
            this.changeCashierInfoButton.Size = new System.Drawing.Size(295, 65);
            this.changeCashierInfoButton.TabIndex = 12;
            this.changeCashierInfoButton.Text = "Изменить данные о кассире";
            this.changeCashierInfoButton.UseVisualStyleBackColor = true;
            this.changeCashierInfoButton.Click += new System.EventHandler(this.asddCashierButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 24);
            this.label3.TabIndex = 10;
            this.label3.Text = "№ Карты";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "ФИО";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "ID";
            // 
            // changeCardButton
            // 
            this.changeCardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeCardButton.Location = new System.Drawing.Point(29, 351);
            this.changeCardButton.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.changeCardButton.Name = "changeCardButton";
            this.changeCardButton.Size = new System.Drawing.Size(295, 57);
            this.changeCardButton.TabIndex = 11;
            this.changeCardButton.Text = "Сменить карту";
            this.changeCardButton.UseVisualStyleBackColor = true;
            this.changeCardButton.Click += new System.EventHandler(this.addCardButton_Click);
            // 
            // FormChangeCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 441);
            this.Controls.Add(this.cashierCardTextBox);
            this.Controls.Add(this.cashierIdTextBox);
            this.Controls.Add(this.cashierFIORichTextBox);
            this.Controls.Add(this.changeCashierInfoButton);
            this.Controls.Add(this.changeCardButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "FormChangeCashier";
            this.Text = "Изменения данных о кассире";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox cashierCardTextBox;
        private System.Windows.Forms.TextBox cashierIdTextBox;
        private System.Windows.Forms.RichTextBox cashierFIORichTextBox;
        private System.Windows.Forms.Button changeCashierInfoButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button changeCardButton;
    }
}