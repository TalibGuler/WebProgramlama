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
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Araba> Araba { get; set; }
        public DbSet<BizeUlasin> BizeUlasin { get; set; }
        public DbSet<Hakkimizda> Hakkimizda { get; set; }
        public DbSet<Iletisim> Iletisim { get; set; }
        public DbSet<Sofor> Sofor { get; set; }
    }
}
