using Microsoft.EntityFrameworkCore;
using Proje.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proje.Dal
{
    public class ProjeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("Server=localhost; Database=adaDb; uid=root; pwd=wbnmyx22");
        }

        public DbSet<Tren> Trenler { get; set; }
        public DbSet<Vagonlar> Vagonlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vagonlar>()
                .HasOne(s => s.Tren)
                .WithMany(g => g.Vagonlars)
                .IsRequired();

        }
    }
}
