﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIT365_W9_MegaDeskV2.Models;
using CIT365_W9_MegaDeskV2.Data;

namespace CIT365_W9_MegaDeskV2.Pages.SurfaceMaterials
{
    public class IndexModel : PageModel
    {
        private readonly CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context _context;

        public IndexModel(CIT365_W9_MegaDeskV2.Data.CIT365_W9_MegaDeskV2Context context)
        {
            _context = context;
        }

        public IList<SurfaceMaterial> SurfaceMaterial { get;set; }

        public async Task OnGetAsync()
        {
            SurfaceMaterial = await _context.SurfaceMaterial.ToListAsync();
        }
    }
}
