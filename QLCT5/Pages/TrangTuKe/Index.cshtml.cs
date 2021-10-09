using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;
using QLCT5.ViewModel;

namespace QLCT5.Pages.TrangTuKe
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public IndexModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public IList<TuKe> TuKe { get; set; }

        public async Task OnGetAsync()
        {
            TuKe = await _context.TuKes
                .Include(t => t.IdKhoNavigation).ToListAsync();
        }

        
    }
}
