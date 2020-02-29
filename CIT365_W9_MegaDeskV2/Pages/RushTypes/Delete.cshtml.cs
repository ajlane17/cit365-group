using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;

namespace MegaDesk.Pages.RushTypes
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskContext _context;

        public DeleteModel(MegaDeskContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RushType RushType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RushType = await _context.RushType.FirstOrDefaultAsync(m => m.Id == id);

            if (RushType == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RushType = await _context.RushType.FindAsync(id);

            if (RushType != null)
            {
                _context.RushType.Remove(RushType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
