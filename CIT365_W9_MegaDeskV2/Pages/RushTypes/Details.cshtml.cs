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
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskContext _context;

        public DetailsModel(MegaDeskContext context)
        {
            _context = context;
        }

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
    }
}
