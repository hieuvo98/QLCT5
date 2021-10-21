using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangChungTu
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChungTu = await _context.ChungTus.FindAsync(id);

            if (ChungTu != null)
            {
                _context.ChungTus.Remove(ChungTu);
                await _context.SaveChangesAsync();
            }

            var idkepchungtu = ChungTu.IdKepChungTu;
            return Redirect($"~/trangkepchungtu/details/{idkepchungtu}");
        }
    }
}
