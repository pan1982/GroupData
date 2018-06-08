namespace GroupData
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
            this.MainTable = new System.Windows.Forms.DataGridView();
            this.bGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTable
            // 
            this.MainTable.AllowUserToAddRows = false;
            this.MainTable.AllowUserToDeleteRows = false;
            this.MainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainTable.Location = new System.Drawing.Point(0, 35);
            this.MainTable.Name = "MainTable";
            this.MainTable.ReadOnly = true;
            this.MainTable.Size = new System.Drawing.Size(754, 140);
            this.MainTable.TabIndex = 0;
            // 
            // bGroup
            // 
            this.bGroup.Location = new System.Drawing.Point(656, 8);
            this.bGroup.Name = "bGroup";
            this.bGroup.Size = new System.Drawing.Size(95, 23);
            this.bGroup.TabIndex = 6;
            this.bGroup.Text = "Группировать";
            this.bGroup.UseVisualStyleBackColor = true;
            this.bGroup.Click += new System.EventHandler(this.BGroup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 182);
            this.Controls.Add(this.bGroup);
            this.Controls.Add(this.MainTable);
            this.Name = "Form1";
            this.Text = "Группировка данных в таблице";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MainTable;
        private System.Windows.Forms.Button bGroup;
    }
}

