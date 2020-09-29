using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DjTaba.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DjTaba.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [Route("AddUser")]
        [HttpPost]
        public async Task<ActionResult> AddUser(InputModel Input)
        {
            try
            {
                var user = new ApplicationUser { UserName = Input.UserName, Email = Input.Email , Birthday = Input.Birthday  };
                var result = await _userManager.CreateAsync(user, Input.Password);
                string ErrorMessage = string.Empty;
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Normal");
                    return Ok();
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ErrorMessage += error.Description;
                    }
                    return BadRequest(ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("ChangePassword")]
        [HttpPost]
        public async Task<ActionResult> ChangePassword(InputPasswordModel Input)
        {
            try
            {
                string ErrorMessage = string.Empty;
                var user = await _userManager.FindByIdAsync(Input.Id);
                if(user is null)
                {
                    return BadRequest($"The User By Id {Input.Id} is Not Found!");
                }
                var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
                if (changePasswordResult.Succeeded)
                {
                    return Ok();

                }
             else
                {
                 
                    foreach (var error in changePasswordResult.Errors)
                    {
                        ErrorMessage += error.Description;
                    }
                    return BadRequest(ErrorMessage);

                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Route("Login")]
        [HttpPost]
        public async Task<ActionResult> Login(LoginModel Input)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {                 
                    return BadRequest("UserName Or Password Is InCorrect !");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
    public class InputModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} ", MinimumLength = 6)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required(ErrorMessage ="User Name Is Empty")]
        public string UserName { get; set; }
        public DateTime Birthday { get; set; }
        public string Id { get; set; }
    }
    public class InputPasswordModel
    {
        public string Id { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} ", MinimumLength = 6)]
        public string NewPassword { get; set; }
    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }


}