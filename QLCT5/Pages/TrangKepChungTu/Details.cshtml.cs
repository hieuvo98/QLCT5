using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangKepChungTu
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DetailsModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public KepChungTu KepChungTu { get; set; }

        public IList<ChungTu> ChungTu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //KepChungTu = await _context.KepChungTus
            //            .Include(k => k.IdTuKeNavigation)
            //                .ThenInclude(k=> k.IdKhoNavigation)
            //            .FirstOrDefaultAsync(m => m.IdKepChungTu == id);

            KepChungTu = await _context.KepChungTus
                        .Include((kct => kct.IdTuKeNavigation))
                            .ThenInclude(k=>k.IdKhoNavigation)
                        .SingleAsync(kct => kct.IdKepChungTu == id);   

            _context.Entry(KepChungTu)
                    .Collection(kct => kct.ChungTus)
                    .Query()
                    .Include(ct => ct.IdDonViNavigation)                    
                    .Load();


            //KepChungTu = await _context.KepChungTus
            //        .Include(s => s.ChungTus)
            //    .Include(k=>k.IdTuKeNavigation)
            //    .AsNoTracking()
            //    .FirstOrDefaultAsync(m => m.IdKepChungTu == id);



            if (KepChungTu == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
