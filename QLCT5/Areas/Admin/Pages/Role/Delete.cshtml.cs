using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    //Authorize(Roles = "Admin")]
    public class DeleteModel : RolePageModel
    {
        public DeleteModel(RoleManager<IdentityRole> roleManager, QLCTtest3Context context) : base(roleManager, context)
        {
        }

        public IdentityRole role { set; get; }
        public async Task<IActionResult> OnGet(string roleid)
        {
            if (roleid == null)
            {
                return Content("Không tìm thấy bài viết");
            }

            role = await _roleManager.FindByIdAsync(roleid);

            if (role == null)
            {
                return Content("Không tìm thấy bài viết");
            }
            else
            {
                return Page();
            }
        }

        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid == null) return Content("Không tìm thấy bài viết");

            role = await _roleManager.FindByIdAsync(roleid);

            if (role == null) return Content("Không tìm thấy bài viết");


            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                StatusMessage = $"Bạn vừa xóa Role thành công!";
                return RedirectToPage("./Index1");
            }
            else
            {
                result.Errors.ToList().ForEach(er =>
                {
                    ModelState.AddModelError(string.Empty, er.Description);

                });
            }
            return Page();
        }
    }
}
