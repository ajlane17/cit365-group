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

                    if (!context.DeskQuote.Any())
                    {
                        context.DeskQuote.AddRange(
                            new DeskQuote
                            {
                                CustomerName = "John Smith",
                                Desk = new Desk
                                {
                                    Width = 24,
                                    Depth = 13,
                                    Drawers = 0,
                                    SurfaceMaterialId = 1
                                },
                                RushId = 4,
                                PricePerSquareInch = 1,
                                PricePerDrawer = 50,
                                BasePrice = 200,
                                SurfacePriceFloor = 1000,
                                MaterialCost = 50,
                                ShippingCost = 0,
                                CreatedDate = DateTime.Parse("2020-02-27 00:00:00")
                            },
                            new DeskQuote
                            {
                                CustomerName = "Sam Smith",
                                Desk = new Desk
                                {
                                    Width = 33,
                                    Depth = 33,
                                    Drawers = 3,
                                    SurfaceMaterialId = 3
                                },
                                RushId = 2,
                                PricePerSquareInch = 1,
                                PricePerDrawer = 50,
                                BasePrice = 200,
                                SurfacePriceFloor = 1000,
                                MaterialCost = 100,
                                ShippingCost = 50,
                                CreatedDate = DateTime.Parse("2020-02-28 00:00:00")
                            }
,
                            new DeskQuote
                            {
                                CustomerName = "Sally Field",
                                Desk = new Desk
                                {
                                    Width = 44,
                                    Depth = 44,
                                    Drawers = 7,
                                    SurfaceMaterialId = 1
                                },
                                RushId = 1,
                                PricePerSquareInch = 1,
                                PricePerDrawer = 50,
                                BasePrice = 200,
                                SurfacePriceFloor = 1000,
                                MaterialCost = 50,
                                ShippingCost = 70,
                                CreatedDate = DateTime.Parse("2020-02-29 00:00:00")
                            });
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}