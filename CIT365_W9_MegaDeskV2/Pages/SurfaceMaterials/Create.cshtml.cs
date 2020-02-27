using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIT365_W9_MegaDeskV2.Models;
using CIT365_W9_MegaDeskV2.Data;

namespace CIT365_W9_MegaDeskV2.Pages.SurfaceMaterials
{
    public class CreateModel : PageModel
    {
        private readonly CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context _context;

        public CreateModel(CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SurfaceMaterial SurfaceMaterial { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SurfaceMaterial.Add(SurfaceMaterial);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
