using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegaDesk.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace MegaDesk.Pages.DeskQuotes
{
    public class DeskQuotePageModel : PageModel
    {
        public string MaterialName { get; set; }
        public string ShippingName { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal ShippingCost { get; set; }

        public void UpdateMaterialName(MegaDeskContext context, int materialId)
        {
            var material = context.SurfaceMaterial
                .Single(m => m.Id == materialId);

            MaterialName = material.Description;
        }

        public void UpdateMaterialCost(MegaDeskContext context, int materialId)
        {
            var material = context.SurfaceMaterial
                .Single(m => m.Id == materialId);

            MaterialCost = material.Cost;
        }

        public void UpdateShippingName(MegaDeskContext context, int rushId)
        {
            var shippingMethod = context.RushType
                .Single(r => r.Id == rushId);

            ShippingName = shippingMethod.Description;
        }

        public void UpdateShippingCost(MegaDeskContext context, IConfiguration configuration, int rushId, int surfaceArea)
        {
            var shippingMethod = context.RushType
                .Single(r => r.Id == rushId);

            int tier2Floor = int.Parse(configuration["Pricing:Tier2Floor"]);
            int tier3Floor = int.Parse(configuration["Pricing:Tier3Floor"]);

            if (surfaceArea < tier2Floor)
            {
                ShippingCost = shippingMethod.Tier1Cost;
            }
            else if (surfaceArea < tier3Floor)
            {
                ShippingCost = shippingMethod.Tier2Cost;
            }
            else
            {
                ShippingCost = shippingMethod.Tier3Cost;
            }
        }
    }
}
