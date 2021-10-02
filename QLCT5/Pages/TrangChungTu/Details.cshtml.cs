using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangChungTu
{
    public class DetailsModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DetailsModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public ChungTu ChungTu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChungTu = await _context.ChungTus
                .Include(c => c.IdDonViNavigation)
                .Include(c => c.IdKepChungTuNavigation)
                    .ThenInclude(c=>c.IdTuKeNavigation)
                .FirstOrDefaultAsync(m => m.IdChungTu == id);

            if (ChungTu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
