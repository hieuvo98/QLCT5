using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;

namespace QLCT5.Pages.TrangKho
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
            return Page();
        }

        [BindProperty]
        public Kho Kho { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Khos.Add(Kho);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
