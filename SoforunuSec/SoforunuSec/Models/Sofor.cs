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

        public DateTime dogumTarihi { get; set; }

        public int? kazaSayisi { get; set; }

        public Cinsiyet Cinsiyet { get; set; }

        public string Fotograf { get; set; }

        public int? arabaId { get; set; }

        public int? dilId { get; set; }

        public int? ulkeId { get; set; }

        public int? sehirId { get; set; }

        public Araba Araba { get; set; }

        public Dil Dil { get; set; }

        public Ulke Ulke { get; set; }

        public Sehir Sehir { get; set; }
    }
    public enum Cinsiyet
    {
        Erkek = 1,
        Kadin = 2
    }
}