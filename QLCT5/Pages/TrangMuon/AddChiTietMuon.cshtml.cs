using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;

namespace testmuontra.Pages.TrangMuon
{
    public class AddChiTietMuonModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public AddChiTietMuonModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [TempData]
        public string StatusMessage { set; get; }

        [DisplayName("Mã mượn")]
        public int MaMuon { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Display(Name = "ID Chứng từ")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            public int ChungTuId { set; get; }
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
            Muon = await _context.Muons.FindAsync(id);
            MaMuon = Muon.MuonId;
            ViewData["TenChungTu"] = new SelectList(_context.ChungTus, "ChungTuId", "TenChungTu");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Muon = await _context.Muons.FindAsync(id);
            MaMuon = Muon.MuonId;

            ChungTu ct = await _context.ChungTus.FindAsync(Input.ChungTuId);
            if (ct == null)
            {
                StatusMessage = "Id chứng từ này không tồn tại";
                return Page();
            }

            ChiTietMuon ctm = new ChiTietMuon
            {
                IdChungTu = Input.ChungTuId,
                SoLuong = Input.SoLuong,
                Muon = Muon
            };

            _context.ChiTietMuons.Add(ctm);
            await _context.SaveChangesAsync();

            return Redirect($"~/trangmuon/details/{id}");
        }
    }
}
