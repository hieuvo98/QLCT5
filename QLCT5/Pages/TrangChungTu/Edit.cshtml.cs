using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangChungTu
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public EditModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ChungTu ChungTu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChungTu = await _context.ChungTus
                .Include(c => c.IdDonViNavigation)
                .Include(c => c.IdKepChungTuNavigation).FirstOrDefaultAsync(m => m.IdChungTu == id);

            if (ChungTu == null)
            {
                return NotFound();
            }
           ViewData["TenDonVi"] = new SelectList(_context.DonVis, "IdDonVi", "TenDonVi");
           ViewData["TenKepChungTu"] = new SelectList(_context.KepChungTus, "IdKepChungTu", "TenKepChungTu");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ChungTu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChungTuExists(ChungTu.IdChungTu))
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

        private bool ChungTuExists(int id)
        {
            return _context.ChungTus.Any(e => e.IdChungTu == id);
        }
    }
}
