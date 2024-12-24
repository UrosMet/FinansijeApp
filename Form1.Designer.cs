namespace CS322_PZ
{
    partial class MainForm
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
            this.btnKategorije = new System.Windows.Forms.Button();
            this.btnTransakcije = new System.Windows.Forms.Button();
            this.btnIzvestaji = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnKategorije
            // 
            this.btnKategorije.Location = new System.Drawing.Point(12, 33);
            this.btnKategorije.Name = "btnKategorije";
            this.btnKategorije.Size = new System.Drawing.Size(117, 58);
            this.btnKategorije.TabIndex = 0;
            this.btnKategorije.Text = "Kategorije";
            this.btnKategorije.UseVisualStyleBackColor = true;
            this.btnKategorije.Click += new System.EventHandler(this.btnKategorije_Click);
            // 
            // btnTransakcije
            // 
            this.btnTransakcije.Location = new System.Drawing.Point(145, 33);
            this.btnTransakcije.Name = "btnTransakcije";
            this.btnTransakcije.Size = new System.Drawing.Size(117, 58);
            this.btnTransakcije.TabIndex = 1;
            this.btnTransakcije.Text = "Transakcije";
            this.btnTransakcije.UseVisualStyleBackColor = true;
            this.btnTransakcije.Click += new System.EventHandler(this.btnTransakcije_Click);
            // 
            // btnIzvestaji
            // 
            this.btnIzvestaji.Location = new System.Drawing.Point(282, 33);
            this.btnIzvestaji.Name = "btnIzvestaji";
            this.btnIzvestaji.Size = new System.Drawing.Size(117, 58);
            this.btnIzvestaji.TabIndex = 2;
            this.btnIzvestaji.Text = "Izvestaji";
            this.btnIzvestaji.UseVisualStyleBackColor = true;
            this.btnIzvestaji.Click += new System.EventHandler(this.btnIzvestaji_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 108);
            this.Controls.Add(this.btnIzvestaji);
            this.Controls.Add(this.btnTransakcije);
            this.Controls.Add(this.btnKategorije);
            this.Name = "MainForm";
            this.Text = "Licni Troskovi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnKategorije;
        private System.Windows.Forms.Button btnTransakcije;
        private System.Windows.Forms.Button btnIzvestaji;
    }
}

