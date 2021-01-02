using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoforunuSec.Models
{
    public class Sehir
    {
        public int Id { get; set; }

        public string sehirAd { get; set; }

        public int? ulkeId { get; set; }

        public Ulke Ulke { get; set; }
    }
}