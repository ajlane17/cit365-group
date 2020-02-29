using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.DeskQuotes
{
    public class DetailsModel : DeskQuotePageModel
    {
        private readonly MegaDeskContext _context;

        public DetailsModel(MegaDeskContext context)
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
                .FirstOrDefaultAsync(m => m.Id == id);

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
