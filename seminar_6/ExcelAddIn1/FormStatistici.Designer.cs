namespace ExcelAddIn1
{
    partial class FormStatistici
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtStatistici = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblTitle.Location = new System.Drawing.Point(101, 34);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(10, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "-";
            // 
            // txtStatistici
            // 
            this.txtStatistici.Location = new System.Drawing.Point(12, 50);
            this.txtStatistici.Multiline = true;
            this.txtStatistici.Name = "txtStatistici";
            this.txtStatistici.Size = new System.Drawing.Size(198, 291);
            this.txtStatistici.TabIndex = 1;
            // 
            // FormStatistici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 369);
            this.Controls.Add(this.txtStatistici);
            this.Controls.Add(this.lblTitle);
            this.Name = "FormStatistici";
            this.Text = "FormStatistici";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtStatistici;
    }
}