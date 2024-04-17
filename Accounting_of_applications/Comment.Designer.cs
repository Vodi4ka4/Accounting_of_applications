namespace Accounting_of_applications
{
    partial class Comment
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
            this.textBox_comment = new System.Windows.Forms.TextBox();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.button_document = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(136, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Комментарий";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Статус";
            // 
            // textBox_comment
            // 
            this.textBox_comment.Location = new System.Drawing.Point(139, 25);
            this.textBox_comment.Multiline = true;
            this.textBox_comment.Name = "textBox_comment";
            this.textBox_comment.Size = new System.Drawing.Size(204, 82);
            this.textBox_comment.TabIndex = 2;
            // 
            // comboBox_status
            // 
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Location = new System.Drawing.Point(12, 25);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(121, 21);
            this.comboBox_status.TabIndex = 3;
            // 
            // button_document
            // 
            this.button_document.Location = new System.Drawing.Point(12, 52);
            this.button_document.Name = "button_document";
            this.button_document.Size = new System.Drawing.Size(121, 55);
            this.button_document.TabIndex = 4;
            this.button_document.Text = "Посмотреть документ об образовании";
            this.button_document.UseVisualStyleBackColor = true;
            this.button_document.Click += new System.EventHandler(this.button_document_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(15, 113);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(328, 37);
            this.button_save.TabIndex = 5;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_back
            // 
            this.button_back.Location = new System.Drawing.Point(12, 156);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(75, 23);
            this.button_back.TabIndex = 6;
            this.button_back.Text = "Назад";
            this.button_back.UseVisualStyleBackColor = true;
            this.button_back.Click += new System.EventHandler(this.button_back_Click);
            // 
            // Comment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 183);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_document);
            this.Controls.Add(this.comboBox_status);
            this.Controls.Add(this.textBox_comment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Comment";
            this.Text = "Обработка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_comment;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Button button_document;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_back;
    }
}