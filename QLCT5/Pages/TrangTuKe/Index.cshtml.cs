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

        public const int ITEM_PER_PAGE = 20;

        [BindProperty(SupportsGet = true, Name = "p")] //tự động binding từ querry vào currentPage
        public int currentPage { set; get; }
        public int countPages { set; get; }
        public int totalTuKe { set; get; }
        public IList<TuKe> TuKe { get; set; }

        public async Task OnGetAsync()
        {
            totalTuKe = await _context.TuKes.CountAsync();
            countPages = (int)Math.Ceiling((double)totalTuKe / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPages)
                countPages = countPages;

            TuKe = await _context.TuKes
                .Include(t => t.IdKhoNavigation)
                .Skip((currentPage - 1) * ITEM_PER_PAGE).Take(ITEM_PER_PAGE)
                .ToListAsync();

        }

        
    }
}
