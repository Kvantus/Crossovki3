namespace Crossovki3
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
            this.BSymbolsForm = new System.Windows.Forms.Button();
            this.BChooseBrand = new System.Windows.Forms.Button();
            this.ComboBrands = new System.Windows.Forms.ComboBox();
            this.LAbelCount = new System.Windows.Forms.Label();
            this.LabelMain = new System.Windows.Forms.Label();
            this.BRefresh = new System.Windows.Forms.Button();
            this.DGTable = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGTable)).BeginInit();
            this.SuspendLayout();
            // 
            // BSymbolsForm
            // 
            this.BSymbolsForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSymbolsForm.Location = new System.Drawing.Point(1019, 157);
            this.BSymbolsForm.Name = "BSymbolsForm";
            this.BSymbolsForm.Size = new System.Drawing.Size(256, 41);
            this.BSymbolsForm.TabIndex = 13;
            this.BSymbolsForm.Text = "Удалить символы";
            this.BSymbolsForm.UseVisualStyleBackColor = true;
            this.BSymbolsForm.Click += new System.EventHandler(this.BSymbolsForm_Click);
            // 
            // BChooseBrand
            // 
            this.BChooseBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BChooseBrand.Location = new System.Drawing.Point(1019, 110);
            this.BChooseBrand.Name = "BChooseBrand";
            this.BChooseBrand.Size = new System.Drawing.Size(256, 41);
            this.BChooseBrand.TabIndex = 12;
            this.BChooseBrand.Text = "Выбрать брэнд";
            this.BChooseBrand.UseVisualStyleBackColor = true;
            this.BChooseBrand.Click += new System.EventHandler(this.BChooseBrand_Click);
            // 
            // ComboBrands
            // 
            this.ComboBrands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBrands.FormattingEnabled = true;
            this.ComboBrands.Location = new System.Drawing.Point(1019, 83);
            this.ComboBrands.Name = "ComboBrands";
            this.ComboBrands.Size = new System.Drawing.Size(256, 21);
            this.ComboBrands.TabIndex = 11;
            // 
            // LAbelCount
            // 
            this.LAbelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LAbelCount.AutoSize = true;
            this.LAbelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LAbelCount.Location = new System.Drawing.Point(1015, 566);
            this.LAbelCount.Name = "LAbelCount";
            this.LAbelCount.Size = new System.Drawing.Size(58, 20);
            this.LAbelCount.TabIndex = 10;
            this.LAbelCount.Text = "Итого:";
            // 
            // LabelMain
            // 
            this.LabelMain.AutoSize = true;
            this.LabelMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelMain.Location = new System.Drawing.Point(12, 7);
            this.LabelMain.Name = "LabelMain";
            this.LabelMain.Size = new System.Drawing.Size(245, 20);
            this.LabelMain.TabIndex = 9;
            this.LabelMain.Text = "Необходимо получить таблицу";
            // 
            // BRefresh
            // 
            this.BRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BRefresh.Location = new System.Drawing.Point(1019, 36);
            this.BRefresh.Name = "BRefresh";
            this.BRefresh.Size = new System.Drawing.Size(256, 41);
            this.BRefresh.TabIndex = 8;
            this.BRefresh.Text = "Обновить";
            this.BRefresh.UseVisualStyleBackColor = true;
            this.BRefresh.Click += new System.EventHandler(this.BRefresh_Click);
            // 
            // DGTable
            // 
            this.DGTable.AllowUserToOrderColumns = true;
            this.DGTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGTable.Location = new System.Drawing.Point(12, 36);
            this.DGTable.Name = "DGTable";
            this.DGTable.Size = new System.Drawing.Size(990, 550);
            this.DGTable.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 600);
            this.Controls.Add(this.BSymbolsForm);
            this.Controls.Add(this.BChooseBrand);
            this.Controls.Add(this.ComboBrands);
            this.Controls.Add(this.LAbelCount);
            this.Controls.Add(this.LabelMain);
            this.Controls.Add(this.BRefresh);
            this.Controls.Add(this.DGTable);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DGTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BSymbolsForm;
        private System.Windows.Forms.Button BChooseBrand;
        private System.Windows.Forms.ComboBox ComboBrands;
        private System.Windows.Forms.Label LAbelCount;
        private System.Windows.Forms.Label LabelMain;
        private System.Windows.Forms.Button BRefresh;
        public System.Windows.Forms.DataGridView DGTable;
    }
}

