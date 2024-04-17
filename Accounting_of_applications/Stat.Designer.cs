namespace Accounting_of_applications
{
    partial class Stat
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
            this.label_call = new System.Windows.Forms.Label();
            this.label_time = new System.Windows.Forms.Label();
            this.label_type = new System.Windows.Forms.Label();
            this.comboBox_level_education = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Количество выполненных заявок";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Среднее время выполнения заявок";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(221, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Статистика по типом уровня образования";
            // 
            // label_call
            // 
            this.label_call.AutoSize = true;
            this.label_call.Location = new System.Drawing.Point(248, 36);
            this.label_call.Name = "label_call";
            this.label_call.Size = new System.Drawing.Size(13, 13);
            this.label_call.TabIndex = 3;
            this.label_call.Text = "0";
            // 
            // label_time
            // 
            this.label_time.AutoSize = true;
            this.label_time.Location = new System.Drawing.Point(248, 75);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(13, 13);
            this.label_time.TabIndex = 4;
            this.label_time.Text = "0";
            // 
            // label_type
            // 
            this.label_type.AutoSize = true;
            this.label_type.Location = new System.Drawing.Point(114, 166);
            this.label_type.Name = "label_type";
            this.label_type.Size = new System.Drawing.Size(13, 13);
            this.label_type.TabIndex = 5;
            this.label_type.Text = "0";
            // 
            // comboBox_level_education
            // 
            this.comboBox_level_education.FormattingEnabled = true;
            this.comboBox_level_education.Location = new System.Drawing.Point(52, 131);
            this.comboBox_level_education.Name = "comboBox_level_education";
            this.comboBox_level_education.Size = new System.Drawing.Size(121, 21);
            this.comboBox_level_education.TabIndex = 6;
            this.comboBox_level_education.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Результат";
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(12, 197);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(78, 28);
            this.button_back.TabIndex = 8;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // Stat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 237);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_level_education);
            this.Controls.Add(this.label_type);
            this.Controls.Add(this.label_time);
            this.Controls.Add(this.label_call);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Stat";
            this.Text = "Stat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_call;
        private System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_type;
        private System.Windows.Forms.ComboBox comboBox_level_education;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_back;
    }
}