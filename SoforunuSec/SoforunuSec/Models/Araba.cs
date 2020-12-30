using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoforunuSec.Models
{
    public class Araba
    {
        public int Id { get; set; }

        public string arabaMarka { get; set; }

        public float kmYakma { get; set; }

        public int  yil { get; set; }

        public int koltukSayisi { get; set; }

        public float motorHacmi { get; set; }

    }
}
