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

namespace QLCT5.Pages.TrangChucDanh
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
        public ChucDanh ChucDanh { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChucDanh = await _context.ChucDanhs.FirstOrDefaultAsync(m => m.IdChucDanh == id);

            if (ChucDanh == null)
            {
                return NotFound();
            }
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

            _context.Attach(ChucDanh).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucDanhExists(ChucDanh.IdChucDanh))
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

        private bool ChucDanhExists(int id)
        {
            return _context.ChucDanhs.Any(e => e.IdChucDanh == id);
        }
    }
}
