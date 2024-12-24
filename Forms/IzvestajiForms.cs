using CS322_PZ.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;

namespace CS322_PZ.Forms
{
    public partial class IzvestajiForms : Form
    {
        public IzvestajiForms()
        {
            InitializeComponent();
            LoadKategorije();
            chartIzvestaji.Series.Clear();
        }

        private void LoadKategorije()
        {
            var kategorije = DatabaseHelper.GetKategorije();

            kategorije.Insert(0, new Kategorija { ID = 0, Naziv = "Sve kategorije" });
            cmbKategorije.DataSource = kategorije;
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "ID";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var odDatum = dtpOd.Value.Date;
            var doDatum = dtpDo.Value.Date;
            var odabranaKategorijaID = (int)cmbKategorije.SelectedValue;

            var transakcije = DatabaseHelper.GetTransakcije()
                .Where(t => t.Datum.Date >= odDatum && t.Datum.Date <= doDatum)
                .ToList();

            if (odabranaKategorijaID != 0)
            {
                transakcije = transakcije.Where(t => t.Kategorija.ID == odabranaKategorijaID).ToList();
            }

            var izvestaj = transakcije
                .GroupBy(t => t.Kategorija.Naziv)
                .Select(g => new
                {
                    Kategorija = g.Key,
                    Ukupno = g.Sum(t => t.Iznos)
                })
                .ToList();

            dgvIzvestaji.DataSource = izvestaj;

            chartIzvestaji.Series.Clear();
            chartIzvestaji.ChartAreas.Clear();
            chartIzvestaji.Titles.Clear();

            var chartArea = new ChartArea
            {
                AxisX =
                        {
                            Interval = 1,
                            LabelStyle = { Angle = -45, Font = new Font("Arial", 10, FontStyle.Bold) },
                            Title = "Kategorije",
                            TitleFont = new Font("Arial", 12, FontStyle.Bold),
                            MajorGrid = { Enabled = false }
                        },
                AxisY =
                        {
                            Title = "Ukupni troškovi",
                            TitleFont = new Font("Arial", 12, FontStyle.Bold),
                            LabelStyle = { Font = new Font("Arial", 10, FontStyle.Regular) },
                            MajorGrid = { Enabled = false }
                        }
            };
            chartIzvestaji.ChartAreas.Add(chartArea);


            var series = new Series("Troškovi")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Font = new Font("Arial", 10, FontStyle.Bold),
                Color = Color.DodgerBlue
            };

            foreach (var item in izvestaj)
            {
                series.Points.AddXY(item.Kategorija, item.Ukupno);
            }

            chartIzvestaji.Series.Add(series);

            chartIzvestaji.Titles.Add("Izveštaj troškova");
            chartIzvestaji.Titles[0].Font = new Font("Arial", 14, FontStyle.Bold);
            chartIzvestaji.Titles[0].Alignment = ContentAlignment.TopCenter;
            chartIzvestaji.Legends.Clear();


            lblUkupno.Text = $"Ukupno: {izvestaj.Sum(i => i.Ukupno)} RSD";
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvIzvestaji.Rows.Count == 0)
            {
                MessageBox.Show("Nema podataka za eksportovanje!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel fajlovi (*.xlsx)|*.xlsx";
                saveFileDialog.Title = "Sačuvaj izveštaj";
                saveFileDialog.FileName = "Izveštaj.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new ClosedXML.Excel.XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Izveštaj");

                            for (int i = 0; i < dgvIzvestaji.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = dgvIzvestaji.Columns[i].HeaderText;
                            }

                            for (int i = 0; i < dgvIzvestaji.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgvIzvestaji.Columns.Count; j++)
                                {
                                    var cellValue = dgvIzvestaji.Rows[i].Cells[j].Value;
                                    worksheet.Cell(i + 2, j + 1).Value = cellValue != null ? cellValue.ToString() : "";

                                }
                            }
                            workbook.SaveAs(saveFileDialog.FileName);
                        }

                        MessageBox.Show("Izveštaj uspešno sačuvan!", "Uspeh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Došlo je do greške prilikom čuvanja fajla: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
