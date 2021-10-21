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
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public string CurrentFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ChungTuOfDonVi { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Thang { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Nam { get; set; }
        [BindProperty(SupportsGet = true)]
        public string MaChungTu { get; set; }

        public async Task OnGetAsync()
        {
            totalChungTu = await _context.ChungTus.CountAsync();
            countPages = (int)Math.Ceiling((double)totalChungTu / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPages)
                countPages = countPages;

            var chungtu = from ct in _context.ChungTus
                          select ct;

            if (!string.IsNullOrEmpty(SearchString))
            {
                chungtu = chungtu.Where(ct => ct.TenChungTu.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(MaChungTu))
            {
                chungtu = chungtu.Where(ct => ct.MaChungTu.Contains(MaChungTu));
            }
            if (!string.IsNullOrEmpty(ChungTuOfDonVi))
            {
                chungtu = chungtu.Where(ct => ct.IdDonVi == Int32.Parse(ChungTuOfDonVi));
            }
            if (!string.IsNullOrEmpty(Thang))
            {
                chungtu = chungtu.Where(ct => ct.IdKepChungTuNavigation.ThangCt == Int32.Parse(Thang));
            }
            if (!string.IsNullOrEmpty(Nam))
            {
                chungtu = chungtu.Where(ct => ct.IdKepChungTuNavigation.NamCt == Int32.Parse(Nam));
            }



            ViewData["TenDonVi"] = new SelectList(_context.DonVis, "IdDonVi", "TenDonVi");
            var dsthang = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            ViewData["ThangCT"] = new SelectList(dsthang);



            ChungTu = await chungtu.OrderByDescending(ct=>ct.NgayChungTu)                
                                .Include(c => c.IdDonViNavigation)
                                .Include(c => c.IdKepChungTuNavigation)
                                .Skip((currentPage - 1) * ITEM_PER_PAGE).Take(ITEM_PER_PAGE)
                                .ToListAsync();
        }
    }
}
