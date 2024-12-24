using CS322_PZ.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS322_PZ.Forms
{
    public partial class KategorijeForms : Form
    {
        public KategorijeForms()
        {
            InitializeComponent();
            LoadKategorije();
        }

        private void LoadKategorije()
        {
            var kategorije = DatabaseHelper.GetKategorije();
            dgvKategorije.DataSource = null;
            dgvKategorije.Rows.Clear();
            dgvKategorije.Columns.Clear();

            dgvKategorije.AutoGenerateColumns = false;

            dgvKategorije.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "ID",
                Visible = false
            });

            dgvKategorije.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Naziv",
                HeaderText = "Naziv Kategorije",
                Name = "Naziv",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            var btnIzmeniColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Izmeni",
                Name = "Izmeni",
                Text = "Izmeni",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvKategorije.Columns.Add(btnIzmeniColumn);

            var btnObrisiColumn = new DataGridViewButtonColumn
            {
                HeaderText = "Obriši",
                Name = "Obrisi",
                Text = "Obriši",
                UseColumnTextForButtonValue = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dgvKategorije.Columns.Add(btnObrisiColumn);

            dgvKategorije.DataSource = new BindingList<Kategorija>(kategorije);
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                MessageBox.Show("Molimo unesite naziv kategorije!");
                return;
            }

            try
            {
 
                DatabaseHelper.AddKategorija(txtNaziv.Text);
                MessageBox.Show("Kategorija uspešno dodata!");
                txtNaziv.Clear();
                LoadKategorije();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvKategorije_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignorišemo klik na zaglavlje kolone

            var selectedRow = dgvKategorije.Rows[e.RowIndex];
            var kategorijaId = (int)selectedRow.Cells["ID"].Value;

            // Provera da li je kliknuto na dugme "Izmeni"
            if (dgvKategorije.Columns[e.ColumnIndex].Name == "Izmeni")
            {
                var trenutniNaziv = selectedRow.Cells["Naziv"].Value.ToString();
                var noviNaziv = Microsoft.VisualBasic.Interaction.InputBox(
                    "Unesite novi naziv kategorije:",
                    "Izmena kategorije",
                    trenutniNaziv);

                if (string.IsNullOrWhiteSpace(noviNaziv))
                {
                    MessageBox.Show("Naziv ne može biti prazan!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    DatabaseHelper.UpdateKategorija(kategorijaId, noviNaziv);
                    MessageBox.Show("Kategorija uspešno izmenjena!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadKategorije();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom izmene kategorije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (dgvKategorije.Columns[e.ColumnIndex].Name == "Obrisi")
            {
                var naziv = selectedRow.Cells["Naziv"].Value.ToString();

                var result = MessageBox.Show(
                    $"Da li ste sigurni da želite da obrišete kategoriju '{naziv}'?",
                    "Potvrda brisanja",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        DatabaseHelper.DeleteKategorija(kategorijaId);
                        MessageBox.Show("Kategorija uspešno obrisana!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadKategorije();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Došlo je do greške prilikom brisanja kategorije: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
