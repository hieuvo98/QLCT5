using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QLCT5.Models;


namespace QLCT5.Areas.Admin.Pages.Role
{
    //[Authorize(Roles = "Admin")]
    public class CreateModel : RolePageModel
    {
        public CreateModel(RoleManager<IdentityRole> roleManager, QLCTtest3Context context) : base(roleManager, context)
        {
        }

        public class InputModel
        {
            [Display(Name = "Tên của Role")]
            [Required(ErrorMessage = "Phải nhập tên role")]
            [StringLength(256, MinimumLength = 3, ErrorMessage = "{0} phải dài từ {2} đến {1} kí tự")]
            public string Name { set; get; }
        }
        [BindProperty]
        public InputModel Input { set; get; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }    

            var newRole = new IdentityRole(Input.Name);
            var result = await _roleManager.CreateAsync(newRole);

            if(result.Succeeded)
            {
                StatusMessage = $"Bạn vừa tạo Role mới: {Input.Name}";
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
