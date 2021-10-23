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
    public class EditModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public EditModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Muon Muon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Muon = await _context.Muons
                .Include(m => m.NhanVienMuon)
                .Include(m => m.NhanVienCho)
                .FirstOrDefaultAsync(m => m.MuonId == id);

            if (Muon == null)
            {
                return NotFound();
            }

            ViewData["TenNhanVien"] = new SelectList(_context.NhanViens, "IdNhanVien", "HoTen");
            ViewData["TenNhanVienCho"] = new SelectList(_context.NhanViens.Where(nv => nv.IdPhongBanNavigation.TenPhongBan == "Kế toán"), "IdNhanVien", "HoTen");
            var trangthai = new List<SelectListItem>();
            trangthai.Add(new SelectListItem() { Text = "Đang mượn", Value = "0" });
            trangthai.Add(new SelectListItem() { Text = "Đã trả", Value = "1" });
            ViewData["TrangThai"] = trangthai;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Muon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MuonExists(Muon.MuonId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MuonExists(int id)
        {
            return _context.Muons.Any(e => e.MuonId == id);
        }
    }
}
