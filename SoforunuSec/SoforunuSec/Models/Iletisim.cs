using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoforunuSec.Models
{
    public class Iletisim
    {
        public int Id { get; set; }

        public string adSoyad { get; set; }

        public string konu { get; set; }

        public string mail { get; set; }

        public string telefonNo { get; set; }

        public string mesaj { get; set; }
    }
}
