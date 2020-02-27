using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CIT365_W9_MegaDeskV2.Models;

namespace CIT365_W9_MegaDeskV2.Data
{
    public class CIT365_W9_MegaDeskV2Context : DbContext
    {
        public CIT365_W9_MegaDeskV2Context (DbContextOptions<CIT365_W9_MegaDeskV2Context> options)
            : base(options)
        {
        }

        public DbSet<CIT365_W9_MegaDeskV2.Models.SurfaceMaterial> SurfaceMaterial { get; set; }

        public DbSet<CIT365_W9_MegaDeskV2.Models.RushType> RushType { get; set; }
        public DbSet<RushType> RushTypeList { get; set; }

        public DbSet<CIT365_W9_MegaDeskV2.Models.Desk> Desk { get; set; }

        public DbSet<CIT365_W9_MegaDeskV2.Models.DeskQuote> DeskQuote { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RushType>().ToTable("RushType");
        }

    }

}
