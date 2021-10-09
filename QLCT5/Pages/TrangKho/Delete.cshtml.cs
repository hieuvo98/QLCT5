using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangKho
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DeleteModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Kho Kho { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Kho = await _context.Khos.FirstOrDefaultAsync(m => m.IdKho == id);

            if (Kho == null)
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

            Kho = await _context.Khos.FindAsync(id);

            if (Kho != null)
            {
                _context.Khos.Remove(Kho);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
