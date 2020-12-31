using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoforunuSec.Models
{
    public class Iletisim
    {
        public int Id { get; set; }

        public string AdSoyad { get; set; }

        public string Konu { get; set; }

        public string Mail { get; set; }

        public string telefonNo { get; set; }

        public string Mesaj { get; set; }
    }
}