namespace Crossovki3
{
    partial class FormSymbols
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
            this.BDelSymbols = new System.Windows.Forms.Button();
            this.BQuotes = new System.Windows.Forms.Button();
            this.BBackSlash = new System.Windows.Forms.Button();
            this.BSlash = new System.Windows.Forms.Button();
            this.BUnderLine = new System.Windows.Forms.Button();
            this.BDash = new System.Windows.Forms.Button();
            this.BSpace = new System.Windows.Forms.Button();
            this.BSemicolon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BPoint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BDelSymbols
            // 
            this.BDelSymbols.BackColor = System.Drawing.Color.Gainsboro;
            this.BDelSymbols.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BDelSymbols.Location = new System.Drawing.Point(24, 221);
            this.BDelSymbols.Name = "BDelSymbols";
            this.BDelSymbols.Size = new System.Drawing.Size(315, 37);
            this.BDelSymbols.TabIndex = 19;
            this.BDelSymbols.Text = "Удалить зеленые символы";
            this.BDelSymbols.UseVisualStyleBackColor = false;
            this.BDelSymbols.Click += new System.EventHandler(this.BDelSymbols_Click);
            // 
            // BQuotes
            // 
            this.BQuotes.BackColor = System.Drawing.Color.LawnGreen;
            this.BQuotes.Location = new System.Drawing.Point(201, 160);
            this.BQuotes.Name = "BQuotes";
            this.BQuotes.Size = new System.Drawing.Size(138, 37);
            this.BQuotes.TabIndex = 18;
            this.BQuotes.Text = "Кавычки \"\"\"";
            this.BQuotes.UseVisualStyleBackColor = false;
            this.BQuotes.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // BBackSlash
            // 
            this.BBackSlash.BackColor = System.Drawing.Color.LawnGreen;
            this.BBackSlash.Location = new System.Drawing.Point(201, 117);
            this.BBackSlash.Name = "BBackSlash";
            this.BBackSlash.Size = new System.Drawing.Size(138, 37);
            this.BBackSlash.TabIndex = 17;
            this.BBackSlash.Text = "БэкСлэш \"\\\"";
            this.BBackSlash.UseVisualStyleBackColor = false;
            this.BBackSlash.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // BSlash
            // 
            this.BSlash.BackColor = System.Drawing.Color.LawnGreen;
            this.BSlash.Location = new System.Drawing.Point(201, 74);
            this.BSlash.Name = "BSlash";
            this.BSlash.Size = new System.Drawing.Size(138, 37);
            this.BSlash.TabIndex = 16;
            this.BSlash.Text = "Слэш \"/\"";
            this.BSlash.UseVisualStyleBackColor = false;
            this.BSlash.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // BUnderLine
            // 
            this.BUnderLine.BackColor = System.Drawing.Color.LawnGreen;
            this.BUnderLine.Location = new System.Drawing.Point(201, 31);
            this.BUnderLine.Name = "BUnderLine";
            this.BUnderLine.Size = new System.Drawing.Size(138, 37);
            this.BUnderLine.TabIndex = 15;
            this.BUnderLine.Text = "Подчеркивание \"_\"";
            this.BUnderLine.UseVisualStyleBackColor = false;
            this.BUnderLine.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // BDash
            // 
            this.BDash.BackColor = System.Drawing.Color.LawnGreen;
            this.BDash.Location = new System.Drawing.Point(24, 160);
            this.BDash.Name = "BDash";
            this.BDash.Size = new System.Drawing.Size(138, 37);
            this.BDash.TabIndex = 14;
            this.BDash.Text = "Дефис \"-\"";
            this.BDash.UseVisualStyleBackColor = false;
            this.BDash.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // BSpace
            // 
            this.BSpace.BackColor = System.Drawing.Color.LawnGreen;
            this.BSpace.Location = new System.Drawing.Point(24, 117);
            this.BSpace.Name = "BSpace";
            this.BSpace.Size = new System.Drawing.Size(138, 37);
            this.BSpace.TabIndex = 13;
            this.BSpace.Text = "Пробел \" \"";
            this.BSpace.UseVisualStyleBackColor = false;
            this.BSpace.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // BSemicolon
            // 
            this.BSemicolon.BackColor = System.Drawing.Color.LawnGreen;
            this.BSemicolon.Location = new System.Drawing.Point(22, 74);
            this.BSemicolon.Name = "BSemicolon";
            this.BSemicolon.Size = new System.Drawing.Size(138, 37);
            this.BSemicolon.TabIndex = 12;
            this.BSemicolon.Text = "Запятая \",\"";
            this.BSemicolon.UseVisualStyleBackColor = false;
            this.BSemicolon.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "В номерах деталей удалить следующие символы:";
            // 
            // BPoint
            // 
            this.BPoint.BackColor = System.Drawing.Color.LawnGreen;
            this.BPoint.Location = new System.Drawing.Point(22, 31);
            this.BPoint.Name = "BPoint";
            this.BPoint.Size = new System.Drawing.Size(138, 37);
            this.BPoint.TabIndex = 10;
            this.BPoint.Text = "Точка \".\"";
            this.BPoint.UseVisualStyleBackColor = false;
            this.BPoint.Click += new System.EventHandler(this.ButtonOfSymbols_Click);
            // 
            // FormSymbols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 286);
            this.Controls.Add(this.BDelSymbols);
            this.Controls.Add(this.BQuotes);
            this.Controls.Add(this.BBackSlash);
            this.Controls.Add(this.BSlash);
            this.Controls.Add(this.BUnderLine);
            this.Controls.Add(this.BDash);
            this.Controls.Add(this.BSpace);
            this.Controls.Add(this.BSemicolon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BPoint);
            this.Name = "FormSymbols";
            this.Text = "FormSymbols";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BDelSymbols;
        private System.Windows.Forms.Button BQuotes;
        private System.Windows.Forms.Button BBackSlash;
        private System.Windows.Forms.Button BSlash;
        private System.Windows.Forms.Button BUnderLine;
        private System.Windows.Forms.Button BDash;
        private System.Windows.Forms.Button BSpace;
        private System.Windows.Forms.Button BSemicolon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BPoint;
    }
}