using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangChiTietMuon
{
    public class DeleteModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DeleteModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ChiTietMuon ChiTietMuon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ChiTietMuon = await _context.ChiTietMuons
                .Include(c => c.ChungTu)
                .Include(c => c.Muon).FirstOrDefaultAsync(m => m.ChiTietMuonId == id);

            if (ChiTietMuon == null)
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

            ChiTietMuon = await _context.ChiTietMuons.FindAsync(id);
            var idmuon = ChiTietMuon.MuonId;

            if (ChiTietMuon != null)
            {
                _context.ChiTietMuons.Remove(ChiTietMuon);
                await _context.SaveChangesAsync();
            }
          
            return Redirect($"~/trangmuon/details/{idmuon}");
        }
    }
}
