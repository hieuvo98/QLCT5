using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QLCT5.Models;


namespace QLCT5.Areas.Admin.Pages.Role
{
    //[Authorize(Roles = "Admin")]
    public class Index1Model : RolePageModel
    {
        public Index1Model(RoleManager<IdentityRole> roleManager, QLCTtest3Context context) : base(roleManager, context)
        {
        }
        
        public List<IdentityRole> roles { set; get; }

        public async Task OnGet()
        {
            roles = await _roleManager.Roles.OrderBy(r=>r.Name).ToListAsync();
        }
        public void OnPost()
        {
            RedirectToPage();
        }
    }
}
