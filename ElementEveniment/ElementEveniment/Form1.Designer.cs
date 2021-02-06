namespace ElementEveniment
{
    partial class Form1
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
            this.textBoxIstoric = new System.Windows.Forms.TextBox();
            this.labelIstoric = new System.Windows.Forms.Label();
            this.btnModifica = new System.Windows.Forms.Button();
            this.textBoxNumar = new System.Windows.Forms.TextBox();
            this.btnDeschide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxIstoric
            // 
            this.textBoxIstoric.Location = new System.Drawing.Point(281, 54);
            this.textBoxIstoric.Multiline = true;
            this.textBoxIstoric.Name = "textBoxIstoric";
            this.textBoxIstoric.Size = new System.Drawing.Size(303, 168);
            this.textBoxIstoric.TabIndex = 0;
            // 
            // labelIstoric
            // 
            this.labelIstoric.AutoSize = true;
            this.labelIstoric.Location = new System.Drawing.Point(281, 35);
            this.labelIstoric.Name = "labelIstoric";
            this.labelIstoric.Size = new System.Drawing.Size(35, 13);
            this.labelIstoric.TabIndex = 1;
            this.labelIstoric.Text = "label1";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(40, 120);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(132, 23);
            this.btnModifica.TabIndex = 2;
            this.btnModifica.Text = "button1";
            this.btnModifica.UseVisualStyleBackColor = true;
            this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
            // 
            // textBoxNumar
            // 
            this.textBoxNumar.Location = new System.Drawing.Point(56, 79);
            this.textBoxNumar.Name = "textBoxNumar";
            this.textBoxNumar.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumar.TabIndex = 3;
            // 
            // btnDeschide
            // 
            this.btnDeschide.Location = new System.Drawing.Point(12, 334);
            this.btnDeschide.Name = "btnDeschide";
            this.btnDeschide.Size = new System.Drawing.Size(223, 23);
            this.btnDeschide.TabIndex = 4;
            this.btnDeschide.Text = "button1";
            this.btnDeschide.UseVisualStyleBackColor = true;
            this.btnDeschide.Click += new System.EventHandler(this.btnDeschide_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 423);
            this.Controls.Add(this.btnDeschide);
            this.Controls.Add(this.textBoxNumar);
            this.Controls.Add(this.btnModifica);
            this.Controls.Add(this.labelIstoric);
            this.Controls.Add(this.textBoxIstoric);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxIstoric;
        private System.Windows.Forms.Label labelIstoric;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.TextBox textBoxNumar;
        private System.Windows.Forms.Button btnDeschide;
    }
}

