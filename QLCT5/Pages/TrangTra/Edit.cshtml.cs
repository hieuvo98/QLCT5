using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangTra
{
    public class EditModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public EditModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Tra Tra { get; set; }
        public int? MaTra { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tra = await _context.Tras
                .Include(t => t.Muon)
                .Include(t => t.NhanVienNhan)
                .Include(t => t.NhanVienTra).FirstOrDefaultAsync(m => m.TraId == id);

            if (Tra == null)
            {
                return NotFound();
            }
            MaTra = id;
            
            //ViewData["TraId"] = new SelectList(_context.Muons, "MuonId", "MuonId");
            ViewData["TenNhanVienNhan"] = new SelectList(_context.NhanViens.Where(nv => nv.IdPhongBanNavigation.TenPhongBan == "Kế toán"), "IdNhanVien", "HoTen");
            ViewData["TenNhanVienTra"] = new SelectList(_context.NhanViens, "IdNhanVien", "HoTen");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TraExists(Tra.TraId))
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

        private bool TraExists(int id)
        {
            return _context.Tras.Any(e => e.TraId == id);
        }
    }
}
