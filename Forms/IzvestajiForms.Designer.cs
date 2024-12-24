namespace CS322_PZ.Forms
{
    partial class IzvestajiForms
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpOd = new System.Windows.Forms.DateTimePicker();
            this.dtpDo = new System.Windows.Forms.DateTimePicker();
            this.cmbKategorije = new System.Windows.Forms.ComboBox();
            this.lblKategorija = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvIzvestaji = new System.Windows.Forms.DataGridView();
            this.chartIzvestaji = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblUkupno = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvestaji)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIzvestaji)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Od datuma";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Do datuma";
            // 
            // dtpOd
            // 
            this.dtpOd.Location = new System.Drawing.Point(82, 27);
            this.dtpOd.Name = "dtpOd";
            this.dtpOd.Size = new System.Drawing.Size(200, 20);
            this.dtpOd.TabIndex = 2;
            // 
            // dtpDo
            // 
            this.dtpDo.Location = new System.Drawing.Point(82, 54);
            this.dtpDo.Name = "dtpDo";
            this.dtpDo.Size = new System.Drawing.Size(200, 20);
            this.dtpDo.TabIndex = 3;
            // 
            // cmbKategorije
            // 
            this.cmbKategorije.FormattingEnabled = true;
            this.cmbKategorije.Location = new System.Drawing.Point(82, 81);
            this.cmbKategorije.Name = "cmbKategorije";
            this.cmbKategorije.Size = new System.Drawing.Size(200, 21);
            this.cmbKategorije.TabIndex = 4;
            // 
            // lblKategorija
            // 
            this.lblKategorija.AutoSize = true;
            this.lblKategorija.Location = new System.Drawing.Point(12, 89);
            this.lblKategorija.Name = "lblKategorija";
            this.lblKategorija.Size = new System.Drawing.Size(54, 13);
            this.lblKategorija.TabIndex = 5;
            this.lblKategorija.Text = "Kategorija";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(15, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Generisi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvIzvestaji
            // 
            this.dgvIzvestaji.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzvestaji.Location = new System.Drawing.Point(15, 159);
            this.dgvIzvestaji.Name = "dgvIzvestaji";
            this.dgvIzvestaji.Size = new System.Drawing.Size(267, 236);
            this.dgvIzvestaji.TabIndex = 7;
            // 
            // chartIzvestaji
            // 
            chartArea2.Name = "ChartArea1";
            this.chartIzvestaji.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartIzvestaji.Legends.Add(legend2);
            this.chartIzvestaji.Location = new System.Drawing.Point(335, 27);
            this.chartIzvestaji.Name = "chartIzvestaji";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartIzvestaji.Series.Add(series2);
            this.chartIzvestaji.Size = new System.Drawing.Size(420, 368);
            this.chartIzvestaji.TabIndex = 8;
            this.chartIzvestaji.Text = "chart1";
            // 
            // lblUkupno
            // 
            this.lblUkupno.AutoSize = true;
            this.lblUkupno.Location = new System.Drawing.Point(96, 124);
            this.lblUkupno.Name = "lblUkupno";
            this.lblUkupno.Size = new System.Drawing.Size(0, 13);
            this.lblUkupno.TabIndex = 9;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(207, 119);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 10;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // IzvestajiForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 407);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblUkupno);
            this.Controls.Add(this.chartIzvestaji);
            this.Controls.Add(this.dgvIzvestaji);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblKategorija);
            this.Controls.Add(this.cmbKategorije);
            this.Controls.Add(this.dtpDo);
            this.Controls.Add(this.dtpOd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "IzvestajiForms";
            this.Text = "Izvestaji";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzvestaji)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartIzvestaji)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpOd;
        private System.Windows.Forms.DateTimePicker dtpDo;
        private System.Windows.Forms.ComboBox cmbKategorije;
        private System.Windows.Forms.Label lblKategorija;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvIzvestaji;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartIzvestaji;
        private System.Windows.Forms.Label lblUkupno;
        private System.Windows.Forms.Button btnExport;
    }
}