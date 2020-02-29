using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Models;

namespace MegaDesk.Data
{
    public class MegaDeskContext : DbContext
    {
        public MegaDeskContext (DbContextOptions<MegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<DeskQuote> DeskQuote { get; set; }
        public DbSet<Desk> Desk { get; set; }
        public DbSet<RushType> RushType { get; set; }
        public DbSet<SurfaceMaterial> SurfaceMaterial { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DeskQuote>().ToTable("DeskQuote");
            modelBuilder.Entity<Desk>().ToTable("Desk");
            modelBuilder.Entity<RushType>().ToTable("RushType");
            modelBuilder.Entity<SurfaceMaterial>().ToTable("SurfaceMaterial");
            System.Diagnostics.Debug.WriteLine("Initialized Models");
        }
    }
}
