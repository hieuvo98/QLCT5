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

namespace QLCT5.Areas.Admin.Pages.User
{
    //[Authorize(Roles = "Admin")]
    public class Index1Model : PageModel
    {

        private readonly UserManager<AppUser> _userManager;
        public Index1Model(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [TempData]
        public string StatusMessage { set; get; }
        public class UserandRole : AppUser
        {
            public string RolesNames { set; get; }
        }

        public List<UserandRole> users { set; get; }

        public const int ITEM_PER_PAGE = 10;

        [BindProperty(SupportsGet = true, Name = "p")] //tự động binding từ querry vào currentPage
        public int currentPage { set; get; }
        public int countPages { set; get; }
        public int totalUser { set; get; }

        public async Task OnGet()
        {
            //users = await _userManager.Users.OrderBy(r => r.UserName).ToListAsync();
            totalUser = await _userManager.Users.CountAsync();
            countPages = (int)Math.Ceiling((double)totalUser / ITEM_PER_PAGE);
            if (currentPage < 1)
                currentPage = 1;
            if (currentPage > countPages)
                countPages = countPages;

            var qr = _userManager.Users.OrderBy(u => u.UserName);
            var qr1 = qr.Skip((currentPage - 1) * ITEM_PER_PAGE)
                        .Take(ITEM_PER_PAGE)
                        .Select(u=>new UserandRole()
                        {
                            Id = u.Id,
                            UserName =  u.UserName
                        });

            users = await qr1.ToListAsync();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                user.RolesNames = string.Join(", ", roles);
            }    
        }
        public void OnPost()
        {
            RedirectToPage();
        }
    }
}
