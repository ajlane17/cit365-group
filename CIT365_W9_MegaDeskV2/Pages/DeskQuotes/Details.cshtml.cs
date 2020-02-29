using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT365_W9_MegaDeskV2.Data;
using CIT365_W9_MegaDeskV2.Models;

namespace CIT365_W9_MegaDeskV2.Pages.DeskQuotes
{
    public class DetailsModel : DeskQuotePageModel
    {
        private readonly CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context _context;

        public DetailsModel(CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context context)
        {
            _context = context;
        }

        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
                .Include(s => s.Desk)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (DeskQuote == null)
            {
                return NotFound();
            }

            UpdateMaterialName(_context, DeskQuote.Desk.SurfaceMaterialId);
            UpdateShippingName(_context, DeskQuote.RushId);
            return Page();
        }
    }
}
