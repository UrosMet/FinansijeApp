using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS322_PZ.Models
{
    public class Transakcija
    {
        public int ID { get; set; }
        public DateTime Datum { get; set; }
        public decimal Iznos { get; set; }
        public Kategorija Kategorija { get; set; }
        public string Opis { get; set; }

        public string KategorijaNaziv
        {
            get => Kategorija?.Naziv;
            set
            {
                if (Kategorija != null)
                    Kategorija.Naziv = value;
            }
        }
    }
}
