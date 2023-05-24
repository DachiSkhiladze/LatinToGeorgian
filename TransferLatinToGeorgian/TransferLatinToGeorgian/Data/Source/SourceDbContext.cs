using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferLatinToGeorgian.Data.Source.Entities;

namespace TransferLatinToGeorgian.Data.Source
{
    public class SourceDbContext : DbContext
    {
        public DbSet<reestri> reestris { get; set; }
        public DbSet<reestriGeo> reestriGeos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Citizens;Integrated Security=True;Encrypt=True;TrustServerCertificate = True;User Instance = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<reestri>(builder =>
            {
                builder.HasNoKey();
                builder.ToTable("reestri");
            });
        }
    }
}
