using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;

namespace QLCT5.Pages.TrangMuon
{
    public class CreateModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public CreateModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TenNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "HoTen");
            ViewData["TenNhanVienCho"] = new SelectList(_context.NhanViens.Where(nv => nv.IdPhongBanNavigation.TenPhongBan=="Kế toán"), "IdNhanVien", "HoTen");
            var trangthai = new List<SelectListItem>();
            trangthai.Add(new SelectListItem() { Text = "Đang mượn", Value = "0" });
            trangthai.Add(new SelectListItem() { Text = "Đã trả", Value = "1" });
            ViewData["TrangThai"] = trangthai;
            return Page();
        }

        [BindProperty]
        public Muon Muon { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Muon.NgayMuon = DateTime.Now;
            Muon.TrangThai = "Đang mượn";

            _context.Muons.Add(Muon);
            await _context.SaveChangesAsync();

            var id = Muon.MuonId;
            return Redirect($"~/trangmuon/details/{id}");
        }
    }
}
