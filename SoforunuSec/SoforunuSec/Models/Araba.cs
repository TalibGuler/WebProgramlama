using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoforunuSec.Models
{
    public class Araba
    {
        public int Id { get; set; }

        public string Marka { get; set; }

        public string Model { get; set; }

        public int? modelYılı { get; set; }

        public int? koltukSayisi { get; set; }

        public double? kmYakit { get; set; }

        public double? motorHacmi { get; set; }

        public string Fotograf { get; set; }
    }
}