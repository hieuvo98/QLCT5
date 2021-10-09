﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;

namespace QLCT5.Pages.TrangKepChungTu
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly QLCT5.Models.QLCTtest3Context _context;

        public IndexModel(QLCT5.Models.QLCTtest3Context context)
        {
            _context = context;
        }

        public IList<KepChungTu> KepChungTu { get;set; }

        public async Task OnGetAsync()
        {
            //KepChungTu = await _context.KepChungTus
            //    .Include(k => k.IdTuKeNavigation).ToListAsync();

            KepChungTu = await (from kct in _context.KepChungTus
                                orderby kct.NamCt descending                         
                                select kct)
                                .Include(tk => tk.IdTuKeNavigation)
                                    .ThenInclude(k=>k.IdKhoNavigation)
                                .ToListAsync();
           
        }
    }
}
