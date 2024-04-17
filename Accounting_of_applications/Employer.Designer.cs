namespace Accounting_of_applications
{
    partial class Employer
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
            this.dataGridView_application = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button_stat = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_number = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_application)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_application
            // 
            this.dataGridView_application.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_application.Location = new System.Drawing.Point(12, 43);
            this.dataGridView_application.Name = "dataGridView_application";
            this.dataGridView_application.Size = new System.Drawing.Size(776, 353);
            this.dataGridView_application.TabIndex = 0;
            this.dataGridView_application.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_application_CellContentClick);
            this.dataGridView_application.SelectionChanged += new System.EventHandler(this.dataGridView_application_SelectionChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button_stat
            // 
            this.button_stat.Location = new System.Drawing.Point(12, 402);
            this.button_stat.Name = "button_stat";
            this.button_stat.Size = new System.Drawing.Size(96, 36);
            this.button_stat.TabIndex = 2;
            this.button_stat.Text = "Статистика";
            this.button_stat.UseVisualStyleBackColor = true;
            this.button_stat.Click += new System.EventHandler(this.button_stat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Поиск по номеру заявки";
            // 
            // textBox_number
            // 
            this.textBox_number.Location = new System.Drawing.Point(236, 15);
            this.textBox_number.Name = "textBox_number";
            this.textBox_number.Size = new System.Drawing.Size(130, 20);
            this.textBox_number.TabIndex = 4;
            this.textBox_number.TextChanged += new System.EventHandler(this.textBox_number_TextChanged);
            // 
            // Employer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox_number);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_stat);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.dataGridView_application);
            this.Name = "Employer";
            this.Text = "Сотрудник";
            this.Load += new System.EventHandler(this.Employer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_application)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_application;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button_stat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_number;
    }
}