using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using HotelReservationManager.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelReservationManager.Data;

namespace HotelReservationManager.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<HotelUser> _signInManager;
        private readonly UserManager<HotelUser> _userManager;
        private readonly HotelReservationManagerDbContext _dbContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel(
            UserManager<HotelUser> userManager,
            SignInManager<HotelUser> signInManager,
           HotelReservationManagerDbContext dbContext,
           RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
            _roleManager = roleManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [Display(Name = "Usename")]
            public string Username { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Second Name")]
            public string SecondName { get; set; }

            [Required]
            [Display(Name = "Third Name")]
            public string ThirdName { get; set; }

            [Required]
            [Display(Name = "UCN")]
            [StringLength(10, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 10)]
            public string UCN { get; set; }

            [Required]
            [DataType(DataType.PhoneNumber)]
            public string PhoneNumber { get; set; }
        }

        public async Task OnGetAync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            var role = new IdentityRole("Admin");

            await CheckHasAnyRoles(role);

            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new HotelUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = Input.Username,
                    FirstName = Input.FirstName,
                    SecondName = Input.SecondName,
                    ThirdName = Input.ThirdName,
                    UCN = Input.UCN,
                    PhoneNumber = Input.PhoneNumber,
                    Email = Input.Email,
                    StartDate = DateTime.UtcNow,
                    IsActive = true,
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    if (_dbContext.Users.Count() == 1)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "User");
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private async Task CheckHasAnyRoles(IdentityRole role)
        {
            if (!_roleManager.Roles.Contains(role))
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("User"));
            }
        }
    }
}
