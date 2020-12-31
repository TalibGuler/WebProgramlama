using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SoforunuSec.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoforunuSec.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Sofor> Sofor { get; set; }

        public DbSet<Araba> Araba { get; set; }

        public DbSet<Dil> Dil { get; set; }

        public DbSet<Ulke> Ulke { get; set; }

        public DbSet<Sehir> Sehir { get; set; }

        public DbSet<Hakkimizda> Hakkimizda { get; set; }

        public DbSet<Iletisim> Iletisim { get; set; }

        public DbSet<BizeUlasin> BizeUlasin { get; set; }
    }
}
