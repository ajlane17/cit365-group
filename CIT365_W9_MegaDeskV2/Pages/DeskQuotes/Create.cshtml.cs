using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIT365_W9_MegaDeskV2.Data;
using CIT365_W9_MegaDeskV2.Models;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CIT365_W9_MegaDeskV2.Pages.DeskQuotes
{
    public class CreateModel : DeskQuotePageModel
    {
        private readonly CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context _context;
        private readonly IConfiguration _configuration;

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "MX", Text = "Mexico"}
        };

        //public IEnumerable<SelectListItem> RushTypeList { get; set; }
        public List<SelectListItem> RushTypeList { get; set; }
        public List<SelectListItem> SurfaceMaterialList { get; set; }

        public CreateModel(CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            RushTypeList = context.RushType.Select(a =>
                new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Description
                }).ToList();

            SurfaceMaterialList = context.SurfaceMaterial.Select(a =>
                new SelectListItem
                {
                    Value = a.id.ToString(),
                    Text = a.description
                }).ToList();

        }

        public IActionResult OnGet()
        {
            System.Diagnostics.Debug.WriteLine("Initializing OnGet from DeskQuote Create");

            return Page();
        }


        [BindProperty] public DeskQuote DeskQuote { get; set; }

        [BindProperty] public RushType RushType { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyDeskQuote = new DeskQuote
            {
                Desk = new Desk
                {
                    Width = DeskQuote.Desk.Width,
                    Depth = DeskQuote.Desk.Depth,
                    Drawers = DeskQuote.Desk.Drawers,
                    SurfaceMaterialId = DeskQuote.Desk.SurfaceMaterialId
                },
                BasePrice = Decimal.Parse(_configuration["Pricing:BasePrice"]),
                PricePerDrawer = Decimal.Parse(_configuration["Pricing:PricePerDrawer"]),
                PricePerSquareInch = Decimal.Parse(_configuration["Pricing:PricePerSquareInch"]),
                SurfacePriceFloor = int.Parse(_configuration["Pricing:SurfacePricingFloor"])
            };
            
            if (await TryUpdateModelAsync<DeskQuote>(
                emptyDeskQuote,
                "deskquote", // Prefix for form value.
                s => s.CustomerName,
                s => s.RushId))
            {
                UpdateMaterialCost(_context, emptyDeskQuote.Desk.SurfaceMaterialId);
                UpdateShippingCost(_context, _configuration, emptyDeskQuote.RushId, emptyDeskQuote.Desk.SurfaceArea);

                emptyDeskQuote.MaterialCost = MaterialCost;
                emptyDeskQuote.ShippingCost = ShippingCost;

                _context.DeskQuote.Add(emptyDeskQuote);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
