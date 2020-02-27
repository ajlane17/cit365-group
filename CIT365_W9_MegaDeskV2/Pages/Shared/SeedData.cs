﻿using System;
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
                            description = "Standard Shipping",
                            tier1Cost=0,
                            tier2Cost=0,
                            tier3Cost=0
                        },
                        new RushType
                        {
                            description = "7-Day Shipping",
                            tier1Cost = 30,
                            tier2Cost = 35,
                            tier3Cost = 40
                        },
                        new RushType
                        {
                            description = "5-Day Shipping",
                            tier1Cost = 40,
                            tier2Cost = 50,
                            tier3Cost = 60
                        },
                        new RushType
                        {
                            description = "3-Day Shipping",
                            tier1Cost = 60,
                            tier2Cost = 70,
                            tier3Cost = 80
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}