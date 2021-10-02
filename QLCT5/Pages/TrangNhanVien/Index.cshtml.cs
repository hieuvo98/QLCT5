using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

 namespace QLCT5.Pages.TrangNhanVien
{
    public class IndexModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public IndexModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public IList<NhanVien> NhanVien { get;set; }

        public async Task OnGetAsync()
        {
            NhanVien = await _context.NhanViens
                .Include(c => c.IdDonViNavigation)
                .Include(c => c.IdChucDanhNavigation)
                .Include(c=>c.IdPhongBanNavigation)
                .ToListAsync();
        }
    }
}
