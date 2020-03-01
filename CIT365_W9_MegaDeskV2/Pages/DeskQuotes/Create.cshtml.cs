using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Web;
using MegaDesk.Data;
using MegaDesk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MegaDesk.Pages.DeskQuotes
{
    public class CreateModel : DeskQuotePageModel
    {
        private readonly MegaDeskContext _context;
        private readonly IConfiguration _configuration;

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "MX", Text = "Mexico"}
        };

        //public IEnumerable<SelectListItem> RushTypeList { get; set; }
        public List<SelectListItem> RushTypeList { get; set; }
        public List<SelectListItem> SurfaceMaterialList { get; set; }

        public CreateModel(MegaDeskContext context, IConfiguration configuration)
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
                    Value = a.Id.ToString(),
                    Text = a.Description
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
                SurfacePriceFloor = int.Parse(_configuration["Pricing:SurfacePricingFloor"]),
                CreatedDate = DateTime.UtcNow
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
