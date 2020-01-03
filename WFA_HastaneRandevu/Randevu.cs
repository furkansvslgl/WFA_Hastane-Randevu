using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA_HastaneRandevu
{
    public class Randevu
    {
        public string TCKN { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public Brans Brans { get; set; }
        public Doktor DoktorAdi { get; set; }
        public string Saat { get; set; }

        public DateTime RandevuTarih { get; set; }


    }
}
