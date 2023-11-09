using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyWebSiteBackend.api.ViewModels;
using MyWebSiteBackend.Security;
using MyWebSiteBackend.Security.Models;

namespace MyWebSiteBackend.api.Controllers.IdentityControllers
{
    public class AccountManagement : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly MyWebSiteSecurityDbContext db;
        private readonly IConfiguration configuration;

        public AccountManagement(IConfiguration configuration, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, MyWebSiteSecurityDbContext db)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
            this.db = db;
            this.configuration = configuration;
        }
        [Route("account/register")]
        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] UserRegisterAddEditModel uservm)
        {
            if (uservm.Password == uservm.RePassword)
            {
                ApplicationUser user = new ApplicationUser
                {
                    Id = uservm.Id
            ,
                    Email = uservm.Email.Trim()
            ,
                    FirstName = uservm.FirstName.Trim()
            ,
                    LastName = uservm.LastName.Trim()
            ,
                    UserName = uservm.UserName.Trim()
                    ,
                    PasswordHash = uservm.Password.Trim()
            ,
                    MobileNumber = uservm.Mobile.Trim()
                    ,
                    EmailConfirmed = true
                    ,
                    PhoneNumberConfirmed = true
                    ,
                    LockoutEnabled = false
                    ,
                    TwoFactorEnabled = false


                };

                IdentityResult userRegistrationResult = await userManager.CreateAsync(user);
                IdentityResult makeUserMemberOfRoleResult = null;
                if (userRegistrationResult.Succeeded)
                {
                    var applicationUser = await userManager.FindByEmailAsync(uservm.Email);
                    var roleName = roleManager.Roles.FirstOrDefault(x => x.Id == uservm.RoleID);
                    makeUserMemberOfRoleResult = await userManager.AddToRoleAsync(applicationUser, roleName.Name);
                }
                if (userRegistrationResult.Succeeded && makeUserMemberOfRoleResult.Succeeded && userRegistrationResult != null)
                {
                    var loginModel = await userManager.FindByNameAsync(uservm.UserName);
                    return Ok(Json(new
                    {
                        username = loginModel.UserName
                        ,
                        password = loginModel.PasswordHash
                    }));
                }
                else
                {
                    foreach (var err in userRegistrationResult.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                    if (makeUserMemberOfRoleResult != null && !makeUserMemberOfRoleResult.Succeeded)
                    {
                        foreach (var err in makeUserMemberOfRoleResult.Errors)
                        {
                            ModelState.AddModelError("", err.Description);
                        }
                    }
                }
                return Ok(Json(makeUserMemberOfRoleResult.Errors));
            }
            return Ok();
        }
    



    [Route("account/login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginViewModel lvm)
    {
        var user = await userManager.FindByNameAsync(lvm.username);
        if (user == null)
        {
            var error = new
            {
                error = "کاربر با این نام کاربری موجود نیست"
            };
            return BadRequest(Json(error));
        }
        if (user.PasswordHash == lvm.password)
        {
            LoginViewModel info = new LoginViewModel
            {
                username = lvm.username
                ,
                password = lvm.password
                ,
                RememberMe = lvm.RememberMe
                ,
                ReturnUrl = ""
                ,
                Token = GenerateNewToken(lvm.username)
            };
            return Ok(Json(info));

        }
        else
        {
            var error = new
            {
                error = "پسورد صحیح نمیباشد"
            };
            return BadRequest(Json(error));
        }
    }
    public string GenerateNewToken(string username)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(configuration.GetValue<string>("TokenKey"));
        var tokenTimeOut = configuration.GetValue<int>("TokenTimeOut");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim("username", username),
            }),
            Expires = DateTime.UtcNow.AddMinutes(tokenTimeOut),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), "HS256")
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    [Route("account/logout")]
    [HttpGet]
    public async Task<IActionResult> Logout(string returnUrl = "")
    {
        await signInManager.SignOutAsync();
        if (!string.IsNullOrEmpty(returnUrl))
        {
            return LocalRedirect(returnUrl);
        }
        else
        {

            return Ok(Json("خروج با موفقیت انجام شد"));
        }
    }
}
}
