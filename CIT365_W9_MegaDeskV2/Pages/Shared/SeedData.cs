using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CIT365_W9_MegaDeskV2.Data;

namespace CIT365_W9_MegaDeskV2.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CIT365_W9_MegaDeskV2Context(
                serviceProvider.GetRequiredService<DbContextOptions<CIT365_W9_MegaDeskV2Context>>()))
            {
                //Look for any surface materials and add if missing.
                if (!context.SurfaceMaterial.Any())
                {
                    context.SurfaceMaterial.AddRange(
                        new SurfaceMaterial
                        {
                            description = "Pine",
                            cost = 50,
                            imageFile = "pine.jpg"
                        },
                        new SurfaceMaterial
                        {
                            description = "Laminate",
                            cost = 100,
                            imageFile = "laminate.jpg"
                        },
                        new SurfaceMaterial
                        {
                            description = "Veneer",
                            cost = 125,
                            imageFile = "veneer.jpg"
                        },
                        new SurfaceMaterial
                        {
                            description = "Oak",
                            cost = 200,
                            imageFile = "oak.jpg"
                        },
                        new SurfaceMaterial
                        {
                            description = "Rosewood",
                            cost = 300,
                            imageFile = "rosewood.jpg"
                        }

                    );
                    context.SaveChanges();
                }

                //Look for any surface materials and add if missing.
                if (!context.RushType.Any())
                {
                    context.RushType.AddRange(
                        new RushType
                        {
                            Description = "Standard Shipping",
                            Tier1Cost=0,
                            Tier2Cost=0,
                            Tier3Cost=0
                        },
                        new RushType
                        {
                            Description = "7-Day Shipping",
                            Tier1Cost = 30,
                            Tier2Cost = 35,
                            Tier3Cost = 40
                        },
                        new RushType
                        {
                            Description = "5-Day Shipping",
                            Tier1Cost = 40,
                            Tier2Cost = 50,
                            Tier3Cost = 60
                        },
                        new RushType
                        {
                            Description = "3-Day Shipping",
                            Tier1Cost = 60,
                            Tier2Cost = 70,
                            Tier3Cost = 80
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}