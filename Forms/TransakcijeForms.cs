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

namespace CS322_PZ.Forms
{
    public partial class TransakcijeForms : Form
    {

        private List<Transakcija> originalneTransakcije;


        public TransakcijeForms()
        {
            InitializeComponent();
            LoadKategorije();
            LoadTransakcije();
            dgvTransakcije.ClearSelection();
        }
        private void ClearInputs()
        {
            dtpDatum.Value = DateTime.Now;
            nudIznos.Value = 0;
            cmbKategorije.SelectedIndex = -1;
            txtOpis.Clear();
        }


        private void LoadKategorije()
        {
            cmbKategorije.DataSource = DatabaseHelper.GetKategorije();
            cmbKategorije.DisplayMember = "Naziv";
            cmbKategorije.ValueMember = "ID";
        }

        private void LoadTransakcije()
        {
            originalneTransakcije = DatabaseHelper.GetTransakcije();

            dgvTransakcije.AutoGenerateColumns = false;
            dgvTransakcije.DataSource = null;
            dgvTransakcije.Rows.Clear();
            dgvTransakcije.Columns.Clear();

            dgvTransakcije.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "ID",
                Visible = false,
            });
            dgvTransakcije.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Datum",
                HeaderText = "Datum",
                Name = "Datum",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = true
            });

            dgvTransakcije.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Iznos",
                HeaderText = "Iznos",
                Name = "Iznos",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                ReadOnly = false
            });

            dgvTransakcije.Columns.Add(new DataGridViewComboBoxColumn
            {
                DataPropertyName = "KategorijaNaziv",
                HeaderText = "Kategorija",
                Name = "Kategorija",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                DataSource = DatabaseHelper.GetKategorije(),
                DisplayMember = "Naziv",
                ValueMember = "Naziv",
                ReadOnly = false
            });

            dgvTransakcije.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Opis",
                HeaderText = "Opis",
                Name = "Opis",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                ReadOnly = false
            });

            dgvTransakcije.DataSource = new BindingList<Transakcija>(originalneTransakcije);
            


        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (cmbKategorije.SelectedValue == null)
            {
                MessageBox.Show("Molimo odaberite kategoriju!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtOpis.Text))
            {
                MessageBox.Show("Molimo unesite opis transakcije!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOpis.Focus();
                return;
            }
            try
            {

                var novaTransakcija = new Transakcija
                {
                    Datum = dtpDatum.Value,
                    Iznos = nudIznos.Value,
                    Kategorija = new Kategorija
                    {
                        ID = (int)cmbKategorije.SelectedValue
                    },
                    Opis = txtOpis.Text
                };

                DatabaseHelper.AddTransakcija(novaTransakcija);

                MessageBox.Show("Transakcija uspešno dodata!");
                ClearInputs();
                LoadTransakcije();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška: " + ex.Message, "Validacija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvTransakcije_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTransakcije.Rows[e.RowIndex];

                if (row.Cells["ID"].Value == null)
                {
                    MessageBox.Show("Nije moguće pronaći ID za ovu transakciju!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = int.Parse(row.Cells["ID"].Value.ToString());
                var transakcija = originalneTransakcije.FirstOrDefault(t => t.ID == id);
                if (transakcija == null)
                {
                    MessageBox.Show("Transakcija sa datim ID-om nije pronađena!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    transakcija.Datum = DateTime.Parse(row.Cells["Datum"].Value.ToString());
                    transakcija.Iznos = decimal.Parse(row.Cells["Iznos"].Value.ToString());
                    transakcija.Kategorija.Naziv = row.Cells["Kategorija"].Value.ToString();
                    transakcija.Opis = row.Cells["Opis"].Value.ToString();

                    DatabaseHelper.UpdateTransakcija(
                        transakcija.ID,
                        transakcija.Datum,
                        transakcija.Iznos,
                        transakcija.Kategorija.Naziv,
                        transakcija.Opis
                    );

                    MessageBox.Show("Transakcija uspešno ažurirana!", "Obaveštenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom ažuriranja: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvTransakcije.SelectedRows.Count == 0)
            {
                MessageBox.Show("Molimo odaberite transakciju za brisanje!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRowIndex = dgvTransakcije.SelectedRows[0].Index;
            var transakcijaZaBrisanje = originalneTransakcije[selectedRowIndex];

            var result = MessageBox.Show(
                $"Da li ste sigurni da želite da obrišete transakciju sa opsiom '{transakcijaZaBrisanje.Opis}' i iznosom '{transakcijaZaBrisanje.Iznos}'?",
                "Potvrda brisanja",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    DatabaseHelper.DeleteTransakcija(transakcijaZaBrisanje.Datum, transakcijaZaBrisanje.Iznos);
                    MessageBox.Show("Transakcija uspešno obrisana!", "Uspešno obrisano", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadTransakcije();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Došlo je do greške prilikom brisanja: " + ex.Message, "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

    }
}
