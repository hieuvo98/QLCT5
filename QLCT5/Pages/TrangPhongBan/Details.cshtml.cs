using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangPhongBan
{
    public class DetailsModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DetailsModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public PhongBan PhongBan { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhongBan = await _context.PhongBans.FirstOrDefaultAsync(m => m.IdPhongBan == id);

            if (PhongBan == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
