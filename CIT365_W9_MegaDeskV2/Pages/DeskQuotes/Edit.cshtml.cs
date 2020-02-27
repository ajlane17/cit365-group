using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CIT365_W9_MegaDeskV2.Data;
using CIT365_W9_MegaDeskV2.Models;

namespace CIT365_W9_MegaDeskV2.Pages.DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context _context;

        public EditModel(CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //DeskQuote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.id == id);

            //Pull in related tables
            DeskQuote = await _context.DeskQuote
                .Include(s => s.desk)
                .Include(t => t.desk.surfaceMaterial)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
            return _context.DeskQuote.Any(e => e.id == id);
        }
    }
}
