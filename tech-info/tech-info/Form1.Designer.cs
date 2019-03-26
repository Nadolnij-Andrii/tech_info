namespace tech_info
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.adminDataGridView = new System.Windows.Forms.DataGridView();
            this.updateAdminInfoButton = new System.Windows.Forms.Button();
            this.addAdminButton = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cashierDataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelNumberOfCashierRegisterOnline = new System.Windows.Forms.Label();
            this.cashierMashineDataGridView = new System.Windows.Forms.DataGridView();
            this.reloadCashierMashineInfo = new System.Windows.Forms.Button();
            this.addCashierMashineButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelNumberOfAttractionsOnline = new System.Windows.Forms.Label();
            this.dataGridViewAttractons = new System.Windows.Forms.DataGridView();
            this.reloadInfoButton = new System.Windows.Forms.Button();
            this.addAttractionButton = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.otherTabPage = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Button = new System.Windows.Forms.Button();
            this.cardPriceButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.adminDataGridView)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierDataGridView)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierMashineDataGridView)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttractons)).BeginInit();
            this.TabControl.SuspendLayout();
            this.otherTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.adminDataGridView);
            this.tabPage4.Controls.Add(this.updateAdminInfoButton);
            this.tabPage4.Controls.Add(this.addAdminButton);
            this.tabPage4.Location = new System.Drawing.Point(4, 33);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1043, 374);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Администраторы";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // adminDataGridView
            // 
            this.adminDataGridView.AllowUserToAddRows = false;
            this.adminDataGridView.AllowUserToDeleteRows = false;
            this.adminDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.adminDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.adminDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.adminDataGridView.Location = new System.Drawing.Point(7, 6);
            this.adminDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.adminDataGridView.Name = "adminDataGridView";
            this.adminDataGridView.Size = new System.Drawing.Size(1015, 251);
            this.adminDataGridView.TabIndex = 7;
            // 
            // updateAdminInfoButton
            // 
            this.updateAdminInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.updateAdminInfoButton.Location = new System.Drawing.Point(707, 269);
            this.updateAdminInfoButton.Margin = new System.Windows.Forms.Padding(6);
            this.updateAdminInfoButton.Name = "updateAdminInfoButton";
            this.updateAdminInfoButton.Size = new System.Drawing.Size(315, 69);
            this.updateAdminInfoButton.TabIndex = 8;
            this.updateAdminInfoButton.Text = "Обновить информацию о администраторах";
            this.updateAdminInfoButton.UseVisualStyleBackColor = true;
            this.updateAdminInfoButton.Click += new System.EventHandler(this.updateAdminInfoButton_Click);
            // 
            // addAdminButton
            // 
            this.addAdminButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAdminButton.Location = new System.Drawing.Point(9, 269);
            this.addAdminButton.Margin = new System.Windows.Forms.Padding(6);
            this.addAdminButton.Name = "addAdminButton";
            this.addAdminButton.Size = new System.Drawing.Size(356, 78);
            this.addAdminButton.TabIndex = 6;
            this.addAdminButton.Text = "Добавить администратора";
            this.addAdminButton.UseVisualStyleBackColor = true;
            this.addAdminButton.Click += new System.EventHandler(this.addAdminButton_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cashierDataGridView);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 33);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage3.Size = new System.Drawing.Size(1043, 374);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Кассиры";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cashierDataGridView
            // 
            this.cashierDataGridView.AllowUserToAddRows = false;
            this.cashierDataGridView.AllowUserToDeleteRows = false;
            this.cashierDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cashierDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.cashierDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashierDataGridView.Location = new System.Drawing.Point(7, 6);
            this.cashierDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.cashierDataGridView.Name = "cashierDataGridView";
            this.cashierDataGridView.Size = new System.Drawing.Size(1030, 251);
            this.cashierDataGridView.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(756, 290);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 73);
            this.button1.TabIndex = 11;
            this.button1.Text = "Обновить информацию о кассирах";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 285);
            this.button2.Margin = new System.Windows.Forms.Padding(6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(356, 78);
            this.button2.TabIndex = 9;
            this.button2.Text = "Добавить кассира";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.checkBox2);
            this.tabPage2.Controls.Add(this.labelNumberOfCashierRegisterOnline);
            this.tabPage2.Controls.Add(this.cashierMashineDataGridView);
            this.tabPage2.Controls.Add(this.reloadCashierMashineInfo);
            this.tabPage2.Controls.Add(this.addCashierMashineButton);
            this.tabPage2.Location = new System.Drawing.Point(4, 33);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage2.Size = new System.Drawing.Size(1043, 374);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Кассы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelNumberOfCashierRegisterOnline
            // 
            this.labelNumberOfCashierRegisterOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumberOfCashierRegisterOnline.AutoSize = true;
            this.labelNumberOfCashierRegisterOnline.Location = new System.Drawing.Point(12, 262);
            this.labelNumberOfCashierRegisterOnline.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelNumberOfCashierRegisterOnline.Name = "labelNumberOfCashierRegisterOnline";
            this.labelNumberOfCashierRegisterOnline.Size = new System.Drawing.Size(0, 24);
            this.labelNumberOfCashierRegisterOnline.TabIndex = 9;
            // 
            // cashierMashineDataGridView
            // 
            this.cashierMashineDataGridView.AllowUserToAddRows = false;
            this.cashierMashineDataGridView.AllowUserToDeleteRows = false;
            this.cashierMashineDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cashierMashineDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.cashierMashineDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.cashierMashineDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cashierMashineDataGridView.Location = new System.Drawing.Point(7, 6);
            this.cashierMashineDataGridView.Margin = new System.Windows.Forms.Padding(6);
            this.cashierMashineDataGridView.Name = "cashierMashineDataGridView";
            this.cashierMashineDataGridView.Size = new System.Drawing.Size(1024, 250);
            this.cashierMashineDataGridView.TabIndex = 7;
            // 
            // reloadCashierMashineInfo
            // 
            this.reloadCashierMashineInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadCashierMashineInfo.Location = new System.Drawing.Point(756, 291);
            this.reloadCashierMashineInfo.Margin = new System.Windows.Forms.Padding(6);
            this.reloadCashierMashineInfo.Name = "reloadCashierMashineInfo";
            this.reloadCashierMashineInfo.Size = new System.Drawing.Size(275, 71);
            this.reloadCashierMashineInfo.TabIndex = 8;
            this.reloadCashierMashineInfo.Text = "Обновить информацию о кассах";
            this.reloadCashierMashineInfo.UseVisualStyleBackColor = true;
            this.reloadCashierMashineInfo.Click += new System.EventHandler(this.reloadCashierMashineInfo_Click);
            // 
            // addCashierMashineButton
            // 
            this.addCashierMashineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addCashierMashineButton.Location = new System.Drawing.Point(7, 292);
            this.addCashierMashineButton.Margin = new System.Windows.Forms.Padding(6);
            this.addCashierMashineButton.Name = "addCashierMashineButton";
            this.addCashierMashineButton.Size = new System.Drawing.Size(356, 71);
            this.addCashierMashineButton.TabIndex = 6;
            this.addCashierMashineButton.Text = "Добавить кассу";
            this.addCashierMashineButton.UseVisualStyleBackColor = true;
            this.addCashierMashineButton.Click += new System.EventHandler(this.addCashierMashineButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.labelNumberOfAttractionsOnline);
            this.tabPage1.Controls.Add(this.dataGridViewAttractons);
            this.tabPage1.Controls.Add(this.reloadInfoButton);
            this.tabPage1.Controls.Add(this.addAttractionButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(6);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage1.Size = new System.Drawing.Size(1043, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Атракционы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // labelNumberOfAttractionsOnline
            // 
            this.labelNumberOfAttractionsOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumberOfAttractionsOnline.AutoSize = true;
            this.labelNumberOfAttractionsOnline.Location = new System.Drawing.Point(12, 274);
            this.labelNumberOfAttractionsOnline.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelNumberOfAttractionsOnline.Name = "labelNumberOfAttractionsOnline";
            this.labelNumberOfAttractionsOnline.Size = new System.Drawing.Size(0, 24);
            this.labelNumberOfAttractionsOnline.TabIndex = 6;
            // 
            // dataGridViewAttractons
            // 
            this.dataGridViewAttractons.AllowUserToAddRows = false;
            this.dataGridViewAttractons.AllowUserToDeleteRows = false;
            this.dataGridViewAttractons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAttractons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAttractons.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewAttractons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAttractons.Location = new System.Drawing.Point(6, 6);
            this.dataGridViewAttractons.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridViewAttractons.Name = "dataGridViewAttractons";
            this.dataGridViewAttractons.Size = new System.Drawing.Size(1016, 262);
            this.dataGridViewAttractons.TabIndex = 4;
            // 
            // reloadInfoButton
            // 
            this.reloadInfoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadInfoButton.Location = new System.Drawing.Point(745, 304);
            this.reloadInfoButton.Margin = new System.Windows.Forms.Padding(6);
            this.reloadInfoButton.Name = "reloadInfoButton";
            this.reloadInfoButton.Size = new System.Drawing.Size(277, 58);
            this.reloadInfoButton.TabIndex = 5;
            this.reloadInfoButton.Text = "Обновить информацию о атракционах";
            this.reloadInfoButton.UseVisualStyleBackColor = true;
            this.reloadInfoButton.Click += new System.EventHandler(this.reloadInfoButton_Click);
            // 
            // addAttractionButton
            // 
            this.addAttractionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addAttractionButton.Location = new System.Drawing.Point(12, 304);
            this.addAttractionButton.Margin = new System.Windows.Forms.Padding(6);
            this.addAttractionButton.Name = "addAttractionButton";
            this.addAttractionButton.Size = new System.Drawing.Size(356, 58);
            this.addAttractionButton.TabIndex = 3;
            this.addAttractionButton.Text = "Добавить аттракцион";
            this.addAttractionButton.UseVisualStyleBackColor = true;
            this.addAttractionButton.Click += new System.EventHandler(this.addAttractionButton_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Controls.Add(this.tabPage4);
            this.TabControl.Controls.Add(this.otherTabPage);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 0);
            this.TabControl.Margin = new System.Windows.Forms.Padding(6);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(1051, 411);
            this.TabControl.TabIndex = 6;
            // 
            // otherTabPage
            // 
            this.otherTabPage.Controls.Add(this.button3);
            this.otherTabPage.Controls.Add(this.label1);
            this.otherTabPage.Controls.Add(this.Button);
            this.otherTabPage.Controls.Add(this.cardPriceButton);
            this.otherTabPage.Location = new System.Drawing.Point(4, 33);
            this.otherTabPage.Margin = new System.Windows.Forms.Padding(6);
            this.otherTabPage.Name = "otherTabPage";
            this.otherTabPage.Padding = new System.Windows.Forms.Padding(6);
            this.otherTabPage.Size = new System.Drawing.Size(1043, 374);
            this.otherTabPage.TabIndex = 4;
            this.otherTabPage.Text = "Другое";
            this.otherTabPage.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(509, 40);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(479, 127);
            this.button3.TabIndex = 3;
            this.button3.Text = "Скидка на все автоматы с 12 до 14 50%";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Button
            // 
            this.Button.Location = new System.Drawing.Point(21, 178);
            this.Button.Margin = new System.Windows.Forms.Padding(6);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(479, 127);
            this.Button.TabIndex = 1;
            this.Button.Text = "Скидка на мягкую зону и все автоматы на среду";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // cardPriceButton
            // 
            this.cardPriceButton.Location = new System.Drawing.Point(18, 40);
            this.cardPriceButton.Margin = new System.Windows.Forms.Padding(6);
            this.cardPriceButton.Name = "cardPriceButton";
            this.cardPriceButton.Size = new System.Drawing.Size(479, 127);
            this.cardPriceButton.TabIndex = 0;
            this.cardPriceButton.Text = "Сменить стоимость карты";
            this.cardPriceButton.UseVisualStyleBackColor = true;
            this.cardPriceButton.Click += new System.EventHandler(this.cardPriceButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(496, 273);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(526, 28);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Активировать автообновление таблицы аттракционов";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(505, 262);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(526, 28);
            this.checkBox2.TabIndex = 10;
            this.checkBox2.Text = "Активировать автообновление таблицы аттракционов";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 411);
            this.Controls.Add(this.TabControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.Text = "Техническая информация";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.adminDataGridView)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cashierDataGridView)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cashierMashineDataGridView)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAttractons)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.otherTabPage.ResumeLayout(false);
            this.otherTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView adminDataGridView;
        private System.Windows.Forms.Button updateAdminInfoButton;
        private System.Windows.Forms.Button addAdminButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView cashierDataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView cashierMashineDataGridView;
        private System.Windows.Forms.Button reloadCashierMashineInfo;
        private System.Windows.Forms.Button addCashierMashineButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dataGridViewAttractons;
        private System.Windows.Forms.Button reloadInfoButton;
        private System.Windows.Forms.Button addAttractionButton;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.Label labelNumberOfAttractionsOnline;
        private System.Windows.Forms.Label labelNumberOfCashierRegisterOnline;
        private System.Windows.Forms.TabPage otherTabPage;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.Button cardPriceButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
    }
}

