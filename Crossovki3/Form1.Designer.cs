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
            this.BGoExcel = new System.Windows.Forms.Button();
            this.OpenFileUnrec = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelCurrentUnrec = new System.Windows.Forms.Label();
            this.BOpenFileTecDoc = new System.Windows.Forms.Button();
            this.OpenFileTecDoc = new System.Windows.Forms.OpenFileDialog();
            this.LabelCurrentTecDoc = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BMergeThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGTable)).BeginInit();
            this.SuspendLayout();
            // 
            // BSymbolsForm
            // 
            this.BSymbolsForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BSymbolsForm.Location = new System.Drawing.Point(964, 166);
            this.BSymbolsForm.Name = "BSymbolsForm";
            this.BSymbolsForm.Size = new System.Drawing.Size(297, 41);
            this.BSymbolsForm.TabIndex = 13;
            this.BSymbolsForm.Text = "Удалить символы";
            this.BSymbolsForm.UseVisualStyleBackColor = true;
            this.BSymbolsForm.Click += new System.EventHandler(this.BSymbolsForm_Click);
            // 
            // BChooseBrand
            // 
            this.BChooseBrand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BChooseBrand.Location = new System.Drawing.Point(964, 119);
            this.BChooseBrand.Name = "BChooseBrand";
            this.BChooseBrand.Size = new System.Drawing.Size(297, 41);
            this.BChooseBrand.TabIndex = 12;
            this.BChooseBrand.Text = "Выбрать брэнд";
            this.BChooseBrand.UseVisualStyleBackColor = true;
            this.BChooseBrand.Click += new System.EventHandler(this.BChooseBrand_Click);
            // 
            // ComboBrands
            // 
            this.ComboBrands.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboBrands.FormattingEnabled = true;
            this.ComboBrands.IntegralHeight = false;
            this.ComboBrands.Location = new System.Drawing.Point(964, 92);
            this.ComboBrands.MaxDropDownItems = 30;
            this.ComboBrands.Name = "ComboBrands";
            this.ComboBrands.Size = new System.Drawing.Size(297, 21);
            this.ComboBrands.TabIndex = 11;
            // 
            // LAbelCount
            // 
            this.LAbelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LAbelCount.AutoSize = true;
            this.LAbelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LAbelCount.Location = new System.Drawing.Point(960, 566);
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
            this.BRefresh.Location = new System.Drawing.Point(964, 45);
            this.BRefresh.Name = "BRefresh";
            this.BRefresh.Size = new System.Drawing.Size(297, 41);
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
            this.DGTable.Location = new System.Drawing.Point(12, 45);
            this.DGTable.Name = "DGTable";
            this.DGTable.Size = new System.Drawing.Size(935, 541);
            this.DGTable.TabIndex = 7;
            // 
            // BGoExcel
            // 
            this.BGoExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BGoExcel.Location = new System.Drawing.Point(964, 213);
            this.BGoExcel.Name = "BGoExcel";
            this.BGoExcel.Size = new System.Drawing.Size(297, 41);
            this.BGoExcel.TabIndex = 14;
            this.BGoExcel.Text = "Запустить Excel";
            this.BGoExcel.UseVisualStyleBackColor = true;
            this.BGoExcel.Click += new System.EventHandler(this.BGoExcel_Click);
            // 
            // OpenFileUnrec
            // 
            this.OpenFileUnrec.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(497, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Файл Unrec:";
            // 
            // LabelCurrentUnrec
            // 
            this.LabelCurrentUnrec.AutoSize = true;
            this.LabelCurrentUnrec.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelCurrentUnrec.Location = new System.Drawing.Point(599, 10);
            this.LabelCurrentUnrec.Name = "LabelCurrentUnrec";
            this.LabelCurrentUnrec.Size = new System.Drawing.Size(78, 16);
            this.LabelCurrentUnrec.TabIndex = 17;
            this.LabelCurrentUnrec.Text = "Не выбран";
            // 
            // BOpenFileTecDoc
            // 
            this.BOpenFileTecDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BOpenFileTecDoc.Location = new System.Drawing.Point(964, 260);
            this.BOpenFileTecDoc.Name = "BOpenFileTecDoc";
            this.BOpenFileTecDoc.Size = new System.Drawing.Size(297, 41);
            this.BOpenFileTecDoc.TabIndex = 18;
            this.BOpenFileTecDoc.Text = "Выбрать файл TecDoc (старый)";
            this.BOpenFileTecDoc.UseVisualStyleBackColor = true;
            this.BOpenFileTecDoc.Click += new System.EventHandler(this.BOpenFileTecDoc_Click);
            // 
            // OpenFileTecDoc
            // 
            this.OpenFileTecDoc.FileName = "openFileDialog1";
            this.OpenFileTecDoc.Multiselect = true;
            // 
            // LabelCurrentTecDoc
            // 
            this.LabelCurrentTecDoc.AutoSize = true;
            this.LabelCurrentTecDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelCurrentTecDoc.Location = new System.Drawing.Point(599, 26);
            this.LabelCurrentTecDoc.Name = "LabelCurrentTecDoc";
            this.LabelCurrentTecDoc.Size = new System.Drawing.Size(78, 16);
            this.LabelCurrentTecDoc.TabIndex = 20;
            this.LabelCurrentTecDoc.Text = "Не выбран";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(483, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Файл TecDoc:";
            // 
            // BMergeThem
            // 
            this.BMergeThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BMergeThem.BackColor = System.Drawing.Color.GreenYellow;
            this.BMergeThem.Location = new System.Drawing.Point(964, 307);
            this.BMergeThem.Name = "BMergeThem";
            this.BMergeThem.Size = new System.Drawing.Size(297, 41);
            this.BMergeThem.TabIndex = 21;
            this.BMergeThem.Text = "Объединить Unrec и Tecdoc";
            this.BMergeThem.UseVisualStyleBackColor = false;
            this.BMergeThem.Click += new System.EventHandler(this.BMergeThem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 600);
            this.Controls.Add(this.BMergeThem);
            this.Controls.Add(this.LabelCurrentTecDoc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BOpenFileTecDoc);
            this.Controls.Add(this.LabelCurrentUnrec);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BGoExcel);
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
        private System.Windows.Forms.Button BGoExcel;
        private System.Windows.Forms.OpenFileDialog OpenFileUnrec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelCurrentUnrec;
        private System.Windows.Forms.Button BOpenFileTecDoc;
        private System.Windows.Forms.OpenFileDialog OpenFileTecDoc;
        private System.Windows.Forms.Label LabelCurrentTecDoc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BMergeThem;
    }
}

