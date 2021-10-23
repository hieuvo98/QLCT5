using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangMuon
{
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
        public int totalMuon { set; get; }

        [BindProperty(SupportsGet = true)]
        public string TrangThaiMuonTra { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? IdNhanVienMuon { get; set; }
        [BindProperty(SupportsGet = true)]
        public int? IdNhanVienCho { get; set; }
        public IList<Muon> Muon { get;set; }

        public async Task OnGetAsync()
        {
            totalMuon = await _context.Muons.CountAsync();
            countPages = (int)Math.Ceiling((double)totalMuon / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPages)
                countPages = countPages;

            var tt = new List<string>() { "Đang mượn", "Đã trả" };
            ViewData["TrangThai"] = new SelectList(tt);
            ViewData["TenNhanVienMuon"] = new SelectList(_context.NhanViens.Where(nv => nv.IdPhongBanNavigation.TenPhongBan != "Kế toán"), "IdNhanVien", "HoTen");
            ViewData["TenNhanVienCho"] = new SelectList(_context.NhanViens.Where(nv => nv.IdPhongBanNavigation.TenPhongBan == "Kế toán"), "IdNhanVien", "HoTen");

            var muon = from m in _context.Muons
                          select m;

            if (!string.IsNullOrEmpty(TrangThaiMuonTra))
            {
                muon = muon.Where(ct => ct.TrangThai == TrangThaiMuonTra);
            }
            if (IdNhanVienMuon.HasValue)
            {
                muon = muon.Where(ct => ct.MaNvMuon == IdNhanVienMuon);
            }
            if (IdNhanVienCho.HasValue)
            {
                muon = muon.Where(ct => ct.MaNvCho == IdNhanVienCho);
            }

            Muon = await muon.Include(m => m.NhanVienCho)
                            .Include(m => m.NhanVienMuon)
                            .OrderByDescending(m => m.NgayMuon)
                            .Skip((currentPage - 1) * ITEM_PER_PAGE).Take(ITEM_PER_PAGE)
                            .ToListAsync();                                 
        }
    }
}
