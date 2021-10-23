using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangTra
{
    public class DeleteModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DeleteModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Tra Tra { get; set; }

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tra = await _context.Tras.FindAsync(id);
            var idmuon = Tra.TraId;

            if (Tra != null)
            {                
                _context.Tras.Remove(Tra);
                var check = _context.Muons.Where(s => s.MuonId == id).FirstOrDefault();
                if (check == null)
                {
                    return null;
                }
                check.TrangThai = "Đang mượn";
                await _context.SaveChangesAsync();                
            }
            return Redirect($"~/trangmuon/details/{idmuon}");
        }
    }
}
