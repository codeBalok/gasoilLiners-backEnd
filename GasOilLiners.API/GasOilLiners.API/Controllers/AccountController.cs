using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GasOilLiners.API.Helpers;
using GasOilLiners.API.Models;
using GasOilLiners.API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GasOilLiners.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly UserManager<User> _applicationUserManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _loginManager;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;


        public AccountController(UserManager<User> applicationUserManager,
                                    SignInManager<User> loginManager,
                                    Microsoft.Extensions.Configuration.IConfiguration configuration,
                                    Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager)
        {
            _applicationUserManager = applicationUserManager;
            _loginManager = loginManager;
            _configuration = configuration;
            _roleManager = roleManager;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginVM model)
        {

            var result = await _loginManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            if (result.Succeeded)
            {
                var aspNetUser = await _applicationUserManager.FindByNameAsync(model.UserName);
                if (aspNetUser.Status == 1)
                {
                    var role = await _applicationUserManager.GetRolesAsync(aspNetUser);
                    return Ok(new
                    {
                        aspNetUser.Id,
                            aspNetUser.Email,
                            aspNetUser.FirstName,
                            aspNetUser.MiddleName,
                            aspNetUser.LastName,
                            aspNetUser.PhoneNumber,
                            aspNetUser.Status,
                            aspNetUser.UserName,
                            role
                        
                    });
                }
                else
                {
                    return Ok(new Response { Code = (int)HttpStatusCode.Unauthorized, Message = "User is not active." });
                }

            }
            else
            {
                return Ok(new Response { Code = (int)HttpStatusCode.Unauthorized, Message = "The combination of username and password is incorrect." });
            }

        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterVM user)
        {
            User _user = new User
            {
                FirstName = user.FirstName,                
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Status = user.Status,
                UserName = user.UserName,
                CreatedOn = DateTime.Now,
                CreatedIp = Request.HttpContext.Connection.RemoteIpAddress.ToString(),
                Remarks = user.Remark 

            };
            _user.PasswordHash = _applicationUserManager.PasswordHasher.HashPassword(_user, user.Password);

            var result = await _applicationUserManager.CreateAsync(_user);
            if (result.Succeeded)
            {

                await _applicationUserManager.AddToRoleAsync(_user, user.Role);
                return Ok();
            }
            else
            {
                return BadRequest(new { message = result.Errors.Select(a => a.Description) });
            }
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            // check if role exists
            bool roleExist = await _roleManager.RoleExistsAsync(roleName);
            if(!roleExist)
                await _roleManager.CreateAsync(new IdentityRole { Name = roleName });
            return Ok();
        }

        [HttpGet]
        [Route("Profile")]
        public async Task<IActionResult> GetProfile(string id)
        {
            User user = await _applicationUserManager.FindByIdAsync(id);
            return Ok(user);
        }
    }
}