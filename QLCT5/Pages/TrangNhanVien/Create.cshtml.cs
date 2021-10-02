using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;

namespace QLCT5.Pages.TrangNhanVien
{
    public class CreateModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public CreateModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TenChucDanh"] = new SelectList(_context.ChucDanhs, "IdChucDanh", "TenChucDanh");
            ViewData["TenDonVi"] = new SelectList(_context.DonVis, "IdDonVi", "TenDonVi");
            ViewData["TenPhongBan"] = new SelectList(_context.PhongBans, "IdPhongBan", "TenPhongBan");
            return Page();
        }

        [BindProperty]
        public NhanVien NhanVien { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.NhanViens.Add(NhanVien);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
