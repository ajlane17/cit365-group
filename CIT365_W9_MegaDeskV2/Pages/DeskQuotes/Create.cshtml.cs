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

namespace CIT365_W9_MegaDeskV2.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context _context;

        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "MX", Text = "Mexico" }
        };

        //public IEnumerable<SelectListItem> RushTypeList { get; set; }
        public List<SelectListItem> RushTypeList { get; set; }
        public List<SelectListItem> SurfaceMaterialList { get; set; }

        public CreateModel(CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context context)
        {
            _context = context;

            RushTypeList = context.RushType.Select(a =>
                                            new SelectListItem
                                            {
                                                Value = a.id.ToString(),
                                                Text = a.description
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


        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        [BindProperty]
        public RushType RushType { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                System.Diagnostics.Debug.WriteLine("Returning page from DeskQuote OnPostAsync");
                return Page();
            }

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
