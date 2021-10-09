using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
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
        public int totalChungTu { set; get; }

        public IList<ChungTu> ChungTu { get;set; }

        public async Task OnGetAsync()
        {
            totalChungTu = await _context.ChungTus.CountAsync();
            countPages = (int)Math.Ceiling((double)totalChungTu / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPages)
                countPages = countPages;

            var qr = _context.ChungTus.OrderByDescending(ct => ct.NgayChungTu)
                            .Include(c => c.IdDonViNavigation)
                            .Include(c => c.IdKepChungTuNavigation);
            var qr1 = qr.Skip((currentPage - 1) * ITEM_PER_PAGE)
                        .Take(ITEM_PER_PAGE);

            ChungTu = await qr1.ToListAsync();
            //ChungTu = await _context.ChungTus
            //    .Include(c => c.IdDonViNavigation)
            //    .Include(c => c.IdKepChungTuNavigation).ToListAsync();
        }
    }
}
