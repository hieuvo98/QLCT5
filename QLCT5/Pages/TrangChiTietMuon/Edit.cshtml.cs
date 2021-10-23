using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangChiTietMuon
{
    public class EditModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public EditModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }
        public ChiTietMuon ChiTietMuon { get; set; }
        [TempData]
        public string StatusMessage { set; get; }

        [DisplayName("Mã mượn")]
        public int MaMuon { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Display(Name = "Chứng từ")]
            public int IdChungTu { set; get; }
            //public virtual ChungTu ChungTu { get; set; }
            [Display(Name = "Số lượng mượn")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            public int SoLuong { get; set; }
        }
        public Muon Muon { set; get; }

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

            Muon = await _context.Muons.FindAsync(ChiTietMuon.MuonId);
            MaMuon = Muon.MuonId;
            //ViewData["TenChungTu"] = new SelectList(_context.ChungTus, "IdChungTu", "TenChungTu");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(ChiTietMuon).State = EntityState.Modified;

            ChungTu ct = await _context.ChungTus.FindAsync(Input.IdChungTu);
            if (ct == null)
            {
                StatusMessage = "Id chứng từ này không tồn tại";
                return Page();
            }

            var ctmToUpdate = _context.ChiTietMuons.Where(s => s.ChiTietMuonId == id).FirstOrDefault();
            if (ctmToUpdate == null)
            {
                return null;
            }
            ctmToUpdate.IdChungTu = Input.IdChungTu;
            ctmToUpdate.SoLuong = Input.SoLuong;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietMuonExists(ChiTietMuon.ChiTietMuonId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            int idmuon = ctmToUpdate.MuonId;
            return Redirect($"~/trangmuon/details/{idmuon}");
        }

        private bool ChiTietMuonExists(int id)
        {
            return _context.ChiTietMuons.Any(e => e.ChiTietMuonId == id);
        }
    }
}
