using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangNhanVien
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public EditModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public NhanVien NhanVien { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NhanVien = await _context.NhanViens
                .Include(n => n.IdChucDanhNavigation)
                .Include(n => n.IdDonViNavigation)
                .Include(n => n.IdPhongBanNavigation).FirstOrDefaultAsync(m => m.IdNhanVien == id);

            if (NhanVien == null)
            {
                return NotFound();
            }
           ViewData["TenChucDanh"] = new SelectList(_context.ChucDanhs, "IdChucDanh", "TenChucDanh");
           ViewData["TenDonVi"] = new SelectList(_context.DonVis, "IdDonVi", "TenDonVi");
           ViewData["TenPhongBan"] = new SelectList(_context.PhongBans, "IdPhongBan", "TenPhongBan");
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

            _context.Attach(NhanVien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(NhanVien.IdNhanVien))
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

        private bool NhanVienExists(int id)
        {
            return _context.NhanViens.Any(e => e.IdNhanVien == id);
        }
    }
}
