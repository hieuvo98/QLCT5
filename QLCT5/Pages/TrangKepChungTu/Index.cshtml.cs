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
    public class IndexModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public IndexModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public const int ITEM_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")] //tự động binding từ querry vào currentPage
        public int currentPage { set; get; }
        public int countPages { set; get; }
        public int totalKepChungTu { set; get; }

        public IList<KepChungTu> KepChungTu { get;set; }

        public async Task OnGetAsync()
        {
            //KepChungTu = await _context.KepChungTus
            //    .Include(k => k.IdTuKeNavigation).ToListAsync();

            totalKepChungTu = await _context.ChungTus.CountAsync();
            countPages = (int)Math.Ceiling((double)totalKepChungTu / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPages)
                countPages = countPages;

            var chungtu = from ct in _context.ChungTus
                          select ct;

            KepChungTu = await (from kct in _context.KepChungTus
                                orderby kct.NamCt descending                         
                                select kct)
                                .Include(tk => tk.IdTuKeNavigation)
                                    .ThenInclude(k=>k.IdKhoNavigation)
                                .Skip((currentPage - 1) * ITEM_PER_PAGE).Take(ITEM_PER_PAGE)
                                .ToListAsync();
           
        }
    }
}
