using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CIT365_W9_MegaDeskV2.Data;
using CIT365_W9_MegaDeskV2.Models;

namespace CIT365_W9_MegaDeskV2.Pages.DeskQuotes
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
            var lRushTypes = _context.RushTypeList;
            foreach (var rt in lRushTypes)
            {


            }

            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
