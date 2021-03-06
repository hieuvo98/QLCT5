using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangTuKe
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DetailsModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public TuKe TuKe { get; set; }
        //public Kho Kho { set; get; }
        public int? TuKeID { get; set; }
        public IEnumerable<TuKe> dstuke { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            dstuke = await _context.TuKes.ToListAsync();
            if (id == null)
            {
                return NotFound();
            }

            TuKe = await _context.TuKes
                .Include(t => t.IdKhoNavigation).FirstOrDefaultAsync(m => m.IdTuKe == id);

            if (TuKe == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
