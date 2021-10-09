using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

 namespace QLCT5.Pages.TrangNhanVien
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public IndexModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }
        public string CurrentFilter { get; set; }
        public IList<NhanVien> NhanVien { get;set; }

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;
            if (!string.IsNullOrEmpty(searchString))
            {
                var qr = from p in _context.NhanViens
                     where p.HoTen.Contains(searchString)
                     select p;
                NhanVien = await qr.ToListAsync();
            }   
            else
            {
                NhanVien = await _context.NhanViens
                            .Include(c => c.IdDonViNavigation)
                            .Include(c => c.IdChucDanhNavigation)
                            .Include(c => c.IdPhongBanNavigation)
                            .ToListAsync();
            }    

        }
    }
}
