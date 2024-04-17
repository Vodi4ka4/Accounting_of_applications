namespace Accounting_of_applications
{
    partial class Enrollee
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
            this.dataGridView_applications = new System.Windows.Forms.DataGridView();
            this.button_pdf = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_applications)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_applications
            // 
            this.dataGridView_applications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_applications.Location = new System.Drawing.Point(8, 9);
            this.dataGridView_applications.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView_applications.Name = "dataGridView_applications";
            this.dataGridView_applications.Size = new System.Drawing.Size(721, 217);
            this.dataGridView_applications.TabIndex = 0;
            // 
            // button_pdf
            // 
            this.button_pdf.Location = new System.Drawing.Point(8, 231);
            this.button_pdf.Name = "button_pdf";
            this.button_pdf.Size = new System.Drawing.Size(155, 38);
            this.button_pdf.TabIndex = 1;
            this.button_pdf.Text = "Расспечатать заявление";
            this.button_pdf.UseVisualStyleBackColor = true;
            this.button_pdf.Click += new System.EventHandler(this.button_pdf_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 2;
            // 
            // Enrollee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 281);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_pdf);
            this.Controls.Add(this.dataGridView_applications);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Enrollee";
            this.Text = "Абитуриент";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_applications)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_applications;
        private System.Windows.Forms.Button button_pdf;
        private System.Windows.Forms.Label label1;
    }
}