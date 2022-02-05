using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Yonetici
    {
        public int ID { get; set; }
        public int YoneticiTurID { get; set; }
        public string Isim { get; set; }
        public string SoyIsim { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public bool Durum { get; set; }
    }
}
