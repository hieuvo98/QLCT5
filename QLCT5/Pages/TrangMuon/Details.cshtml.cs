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
    public class DetailsModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public DetailsModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }
        public Muon Muon { get; set; }
        public Tra Tra { get; set; }
        public IList<ChiTietMuon> ChiTietMuon { get; set; }

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

            _context.Entry(Muon)
                    .Collection(m => m.ChiTietMuons)
                    .Query()
                    .Include(ctm => ctm.ChungTu)
                        .ThenInclude(kct=>kct.IdKepChungTuNavigation)
                    .Load();

            if (Muon == null)
            {
                return NotFound();
            }
            Tra = await _context.Tras
                .Include(t => t.Muon)
                .Include(t => t.NhanVienNhan)
                .Include(t => t.NhanVienTra).FirstOrDefaultAsync(m => m.TraId == id);

            //if (Tra == null)
            //{
            //    return NotFound();
            //}
            return Page();
        }
    }
}
