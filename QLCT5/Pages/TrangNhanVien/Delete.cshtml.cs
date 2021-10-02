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
    public class DeleteModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DeleteModel(QLCT5.Models.QLCTtest3Context context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NhanVien = await _context.NhanViens.FindAsync(id);

            if (NhanVien != null)
            {
                _context.NhanViens.Remove(NhanVien);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
