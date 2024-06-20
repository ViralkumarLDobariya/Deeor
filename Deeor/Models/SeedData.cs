using Deeor.Data;
using Deeor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Deeor.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DeeorContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DeeorContext>>()))
            {
                // Look for any bracelets.
                if (context.Bracelette.Any())
                {
                    return;   // DB has been seeded
                }

                context.Bracelette.AddRange(
                    new Bracelette
                    {
                        Material = "Gold",
                        Length = 18.5,
                        Beads = 10,
                        Color = "Yellow",
                        ClassType = "Lobster",
                        Price = 250.99m,
                        Brand = "LuxuryBrand"
                    },
                    new Bracelette
                    {
                        Material = "Silver",
                        Length = 19.0,
                        Beads = 15,
                        Color = "Silver",
                        ClassType = "Toggle",
                        Price = 150.50m,
                        Brand = "ElegantBrand"
                    },
                    new Bracelette
                    {
                        Material = "Leather",
                        Length = 20.0,
                        Beads = 0,
                        Color = "Brown",
                        ClassType = "Magnetic",
                        Price = 75.25m,
                        Brand = "RusticBrand"
                    },
                    new Bracelette
                    {
                        Material = "Platinum",
                        Length = 17.5,
                        Beads = 12,
                        Color = "White",
                        ClassType = "Foldover",
                        Price = 300.75m,
                        Brand = "EliteBrand"
                    },
                    new Bracelette
                    {
                        Material = "Stainless Steel",
                        Length = 18.0,
                        Beads = 8,
                        Color = "Black",
                        ClassType = "Box",
                        Price = 60.00m,
                        Brand = "ModernBrand"
                    },
                    new Bracelette
                    {
                        Material = "Titanium",
                        Length = 19.5,
                        Beads = 5,
                        Color = "Grey",
                        ClassType = "Spring Ring",
                        Price = 110.00m,
                        Brand = "TechBrand"
                    },
                    new Bracelette
                    {
                        Material = "Pearl",
                        Length = 16.0,
                        Beads = 20,
                        Color = "White",
                        ClassType = "Fish Hook",
                        Price = 200.00m,
                        Brand = "ClassicBrand"
                    },
                    new Bracelette
                    {
                        Material = "Wood",
                        Length = 22.0,
                        Beads = 25,
                        Color = "Natural",
                        ClassType = "Slip Knot",
                        Price = 45.00m,
                        Brand = "EcoBrand"
                    },
                    new Bracelette
                    {
                        Material = "Plastic",
                        Length = 21.0,
                        Beads = 30,
                        Color = "Red",
                        ClassType = "Elastic",
                        Price = 20.00m,
                        Brand = "CasualBrand"
                    },
                    new Bracelette
                    {
                        Material = "Fabric",
                        Length = 23.0,
                        Beads = 18,
                        Color = "Blue",
                        ClassType = "Adjustable",
                        Price = 35.00m,
                        Brand = "ComfortBrand"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
