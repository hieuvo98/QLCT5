using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;

namespace QLCT5.Pages.TrangChungTu
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public CreateModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["TenDonVi"] = new SelectList(_context.DonVis, "IdDonVi", "TenDonVi");
            ViewData["TenKepChungTu"] = new SelectList(_context.KepChungTus, "IdKepChungTu", "TenKepChungTu");
            return Page();
        }

        [BindProperty]
        public ChungTu ChungTu { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ChungTus.Add(ChungTu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
