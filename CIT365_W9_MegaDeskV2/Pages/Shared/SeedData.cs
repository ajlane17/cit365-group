using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MegaDesk.Data;

namespace MegaDesk.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MegaDeskContext(
                serviceProvider.GetRequiredService<DbContextOptions<MegaDeskContext>>()))
            {
                //Look for any surface materials and add if missing.
                if (!context.SurfaceMaterial.Any())
                {
                    context.SurfaceMaterial.AddRange(
                        new SurfaceMaterial
                        {
                            Description = "Pine",
                            Cost = 50,
                            ImageFile = "pine.jpg"
                        },
                        new SurfaceMaterial
                        {
                            Description = "Laminate",
                            Cost = 100,
                            ImageFile = "laminate.jpg"
                        },
                        new SurfaceMaterial
                        {
                            Description = "Veneer",
                            Cost = 125,
                            ImageFile = "veneer.jpg"
                        },
                        new SurfaceMaterial
                        {
                            Description = "Oak",
                            Cost = 200,
                            ImageFile = "oak.jpg"
                        },
                        new SurfaceMaterial
                        {
                            Description = "Rosewood",
                            Cost = 300,
                            ImageFile = "rosewood.jpg"
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