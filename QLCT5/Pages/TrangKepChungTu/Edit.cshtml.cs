using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;
using QLCT5.ViewModel;

namespace QLCT5.Pages.TrangKepChungTu
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public EditModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public KepChungTu KepChungTu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            KepChungTu = await _context.KepChungTus
                .Include(k => k.IdTuKeNavigation).FirstOrDefaultAsync(m => m.IdKepChungTu == id);

            if (KepChungTu == null)
            {
                return NotFound();
            }
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var KepChungTuToUpdate = await _context.KepChungTus.FindAsync(id);

            if (KepChungTuToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<KepChungTu>(
                KepChungTuToUpdate,
                "KepChungTu",   
                s => s.SoHopDong, s => s.TenKepChungTu, s => s.NamCt, s => s.ThangCt, s => s.IdTuKe))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
            //    if (!ModelState.IsValid)
            //    {
            //        return Page();
            //    }

            //    _context.Attach(KepChungTu).State = EntityState.Modified;

            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        if (!KepChungTuExists(KepChungTu.IdKepChungTu))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            //    return RedirectToPage("./Index");
        }

        //private bool KepChungTuExists(int id)
        //{
        //    return _context.KepChungTus.Any(e => e.IdKepChungTu == id);
        //}
    }
}
