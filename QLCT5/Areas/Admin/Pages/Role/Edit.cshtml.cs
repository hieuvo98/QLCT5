using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using QLCT5.Models;

namespace QLCT5.Areas.Admin.Pages.Role
{
    //[Authorize(Roles = "Admin")]
    public class EditModel : RolePageModel
    {
        public EditModel(RoleManager<IdentityRole> roleManager, QLCTtest3Context myBlogContext) : base(roleManager, myBlogContext)
        {
        }

        public class InputModel
        {
            [Display(Name = "Tên mới")]
            [Required(ErrorMessage = "Phải nhập tên role")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài từ {2} đến {1} kí tự")]
            public string Name { set; get; }
        }

        [BindProperty]
        public InputModel Input { set; get; }

        //public IdentityRole role1 { set; get; }
        //public async Task OnGet()
        //{
        //    role1 = await _roleManager.
        //}

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
                var input = new InputModel()
                {
                    Name = role.Name
                };
                return Page();
            }    
        }
        public async Task<IActionResult> OnPostAsync(string roleid)
        {
            if (roleid == null) return Content("Không tìm thấy bài viết");

            role = await _roleManager.FindByIdAsync(roleid);
            
            if (role == null) return Content("Không tìm thấy bài viết");
            
            if (!ModelState.IsValid)
            {
                return Page();
            }

            role.Name = Input.Name;
            var result = await _roleManager.UpdateAsync(role);

            if (result.Succeeded)
            {
                StatusMessage = $"Bạn vừa đổi tên Role thành công: {Input.Name}";
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
