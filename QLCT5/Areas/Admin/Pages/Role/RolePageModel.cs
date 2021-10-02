using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCT5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QLCT5.Areas.Admin.Pages.Role
{
    public class RolePageModel : PageModel
    {
        protected readonly RoleManager<IdentityRole> _roleManager;
        protected readonly QLCTtest3Context _QLCT3Context;

        [TempData]
        public string StatusMessage { set; get; }
        public RolePageModel(RoleManager<IdentityRole> roleManager, QLCTtest3Context context)
        {
            _roleManager = roleManager;
            _QLCT3Context = context;
        }
    }
}
