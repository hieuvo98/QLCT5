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

namespace QLCT5.Areas.Admin.Pages.User
{
    [Authorize(Roles = "Admin")]
    public class SetPasswordModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public SetPasswordModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Phải nhập mật khẩu")]
            [StringLength(100, ErrorMessage = "{0} phải nằm trong khoảng từ {2} đến {1} ký tự.", MinimumLength = 3)]
            [DataType(DataType.Password)]
            [Display(Name = "Mật khẩu mới")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Xác nhận mật khẩu")]
            [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận lại không trùng.")]
            public string ConfirmPassword { get; set; }
        }

        public AppUser user { set; get; }
        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Không tìm thấy user");
            }

            user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound($"Không tìm thấy user, id = {id}");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound($"Không tìm thấy user");
            }

            user = await _userManager.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound($"Không tìm thấy user, id = {id}");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _userManager.RemovePasswordAsync(user);
            var addPasswordResult = await _userManager.AddPasswordAsync(user, Input.NewPassword);
            if (!addPasswordResult.Succeeded)
            {
                foreach (var error in addPasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return Page();
            }
            StatusMessage = $"Mật khẩu đã được thiết lập cho {user.UserName}";

            return RedirectToPage("./Index1");
        }
    }
}
