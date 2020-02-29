using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDesk.Data;
using MegaDesk.Models;
using Microsoft.Extensions.Configuration;

namespace MegaDesk.Pages.DeskQuotes
{
    public class EditModel : DeskQuotePageModel
    {
        private readonly MegaDeskContext _context;
        private readonly IConfiguration _configuration;

        public EditModel(MegaDeskContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            RushTypeList = context.RushType.Select(a =>
                                            new SelectListItem
                                            {
                                                Value = a.Id.ToString(),
                                                Text = a.Description
                                            }).ToList();

            SurfaceMaterialList = context.SurfaceMaterial.Select(a =>
                                            new SelectListItem
                                            {
                                                Value = a.Id.ToString(),
                                                Text = a.Description
                                            }).ToList();


        }

        public List<SelectListItem> RushTypeList { get; set; }
        public List<SelectListItem> SurfaceMaterialList { get; set; }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //DeskQuote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.Id == Id);

            //Pull in related tables
            DeskQuote = await _context.DeskQuote
                .Include(s => s.Desk)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

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

            UpdateMaterialCost(_context, DeskQuote.Desk.SurfaceMaterialId);
            UpdateShippingCost(_context, _configuration, DeskQuote.RushId, DeskQuote.Desk.SurfaceArea);

            DeskQuote.MaterialCost = MaterialCost;
            DeskQuote.ShippingCost = ShippingCost;

            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.Id))
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
            return _context.DeskQuote.Any(e => e.Id == id);
        }
    }
}
