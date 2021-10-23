using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;

namespace QLCT5.Pages.TrangTra
{
    public class CreateModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public CreateModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public int MaTra { get; set; }
        public IActionResult OnGet(int id)
        {
            MaTra = id;
            //ViewData["TraId"] = new SelectList(_context.Muons, "MuonId", "MuonId");
            ViewData["TenNhanVienTra"] = new SelectList(_context.NhanViens, "IdNhanVien", "HoTen");
            ViewData["TenNhanVienNhan"] = new SelectList(_context.NhanViens.Where(nv=>nv.IdPhongBanNavigation.TenPhongBan=="Kế toán"), "IdNhanVien", "HoTen");
            return Page();
        }

        [BindProperty]
        public Tra Tra { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Tra.TraId = id;
            Tra.NgayTra = DateTime.Now;

            var check = _context.Muons.Where(s => s.MuonId == id).FirstOrDefault();
            if (check == null)
            {
                return null;
            }
            check.TrangThai = "Đã trả";

            _context.Tras.Add(Tra);
            await _context.SaveChangesAsync();

            return Redirect($"~/trangmuon/details/{id}");
        }
    }
}
