using CS322_PZ.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS322_PZ
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnKategorije_Click(object sender, EventArgs e)
        {
            KategorijeForms kategorijeForm = new KategorijeForms();
            kategorijeForm.Show();
        }

        private void btnTransakcije_Click(object sender, EventArgs e)
        {
            TransakcijeForms transakcijeForm = new TransakcijeForms();
            transakcijeForm.Show();
        }

        private void btnIzvestaji_Click(object sender, EventArgs e)
        {
            IzvestajiForms izvestajiForm = new IzvestajiForms();
            izvestajiForm.ShowDialog();
        }
    }
}
