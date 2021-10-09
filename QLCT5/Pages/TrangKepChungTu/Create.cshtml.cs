using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QLCT5.Models;
using QLCT5.ViewModel;

namespace QLCT5.Pages.TrangKepChungTu
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public CreateModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public Kho Kho { set; get; }
        [BindProperty(SupportsGet = true)]
        public int IdKho { set; get; }
        public int IdTuKe { set; get; }
        public SelectList dskho { set; get; }
        public IActionResult OnGet()
        {
            var dsthang = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
            ViewData["ThangCT"] = new SelectList(dsthang);
            
            ViewData["TenKho"] = new SelectList(_context.Khos, "IdKho", "TenKho");

            return Page();
        }
        public JsonResult OnGetKeLookup(int idKho)
        {
            var lookup = (from tk in _context.TuKes
                          where tk.IdKho == idKho
                          select new LookupViewModel
                          {
                              value = tk.IdTuKe,
                              text = tk.TenTuKe
                          }).OrderBy(o => o.text).ToList();
            return new JsonResult(lookup);
        }

        [BindProperty]
        public KepChungTu KepChungTu { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.KepChungTus.Add(KepChungTu);
            //await _context.SaveChangesAsync();

            //return RedirectToPage("./Index");

            var emptyKepCT = new KepChungTu();

            if (await TryUpdateModelAsync<KepChungTu>(
                 emptyKepCT,
                 "KepChungTu",   // Prefix for form value.
                 s => s.SoHopDong, s => s.TenKepChungTu, s => s.NamCt, s => s.ThangCt, s => s.IdTuKe))
            {
                _context.KepChungTus.Add(emptyKepCT);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
