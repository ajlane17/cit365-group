using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT365_W9_MegaDeskV2.Data;
using CIT365_W9_MegaDeskV2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIT365_W9_MegaDeskV2.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context _context;

        public IndexModel(CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context context)
        {
            _context = context;

        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public async Task OnGetAsync()
        {
            //DeskQuote = await _context.DeskQuote.ToListAsync();
            DeskQuote = await _context.DeskQuote
                .Include(s => s.desk)
                //.Include(t => t.desk.surfaceMaterial)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
