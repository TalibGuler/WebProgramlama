using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoforunuSec.Models
{
    public class Sofor
    {
        public int Id { get; set; }

        public string adSoyad { get; set; }

        public int yas { get; set; }

        public int kazaSayisi { get; set; }

        public Cinsiyet Cinsiyet { get; set; }

        public string Fotograf { get; set; }

        public Araba araba { get; set; }

    }

    public enum Cinsiyet { 
        Erkek = 1,
        Kadin = 2
    }

}
