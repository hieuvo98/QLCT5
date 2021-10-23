using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangMuon
{
    public class DeleteModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DeleteModel(QLCT5.Models.QLCTtest3Context context)
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
                .Include(m => m.NhanVienCho)
                .Include(m => m.NhanVienMuon)
                .FirstOrDefaultAsync(m => m.MuonId == id);

            if (Muon == null)
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

            Muon = await _context.Muons.FindAsync(id);

            if (Muon != null)
            {
                _context.Muons.Remove(Muon);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
