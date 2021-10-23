using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;

namespace QLCT5.Pages.TrangKepChungTu
{
    [Authorize]
    public class AddChungTuModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public AddChungTuModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [DisplayName("Kẹp chứng từ")]
        public string TenKepChungTu { get; set; }
        public KepChungTu KepChungTu { set; get; }


        public async Task<IActionResult> OnGet(int? id)
        {
            KepChungTu = await _context.KepChungTus.FindAsync(id);
            TenKepChungTu = KepChungTu.TenKepChungTu;
            ViewData["TenDonVi"] = new SelectList(_context.DonVis, "IdDonVi", "TenDonVi");
            return Page();
        }


        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            [Display(Name = "Mã chứng từ")]
            public string MaChungTu { get; set; }
            [Display(Name = "Tên chứng từ")]
            [Required(ErrorMessage = "Phải nhập {0}")]
            public string TenChungTu { get; set; }
            [Display(Name = "Ngày thêm")]
            [DataType(DataType.Date)]
            public DateTime? NgayChungTu { get; set; }
            [Display(Name = "Số tập")]
            public int? SoLuong { get; set; }

            [Display(Name = "Đơn vị")]
            [Required(ErrorMessage = "Phải Chọn {0}")]
            public virtual DonVi IdDonViNavigation { get; set; }
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            KepChungTu = await _context.KepChungTus.FindAsync(id);

            ChungTu ct = new ChungTu();

            ct.MaChungTu = Input.MaChungTu;
            ct.TenChungTu = Input.TenChungTu;
            ct.NgayChungTu = Input.NgayChungTu;
            ct.SoLuong = Input.SoLuong;
            ct.IdDonViNavigation = Input.IdDonViNavigation;
            ct.IdKepChungTuNavigation = KepChungTu;

            _context.ChungTus.Add(ct);
            await _context.SaveChangesAsync();

            //var entry = _context.Add(new ChungTu());
            //entry.CurrentValues.SetValues(Input);
            //await _context.SaveChangesAsync();

            return Redirect($"~/trangkepchungtu/details/{id}");
        }
    }
}
