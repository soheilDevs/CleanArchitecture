using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domains.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        #region Register
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            CheckUser checkUser = _userService.CheckUser(register.UserName, register.Email);
            if (checkUser != CheckUser.Ok)
            {
                ViewBag.Check = checkUser;
                return View(register);
            }

            Users users = new Users()
            {
                Email = register.Email.Trim().ToLower(),
                UserName = register.UserName,
                Password = PasswordHelper.EncodePasswordMd5(register.Password)
            };
            _userService.RegisterUser(users);
            return View("SuccessRegister", register);
        }

        #endregion


        #region     Login

        [Route("Login")]
        public IActionResult Login(string returnUrl="/")
        {
            ViewBag.Return = returnUrl;
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel login,string returnUrl)
        {
            if (!ModelState.IsValid)
                return View(login);


            if (!_userService.IsUserExist(login.Email, login.Password))
            {
                ModelState.AddModelError("Email", "User Not Found ...");
                return View(login);
            }

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,login.Email),
                new Claim(ClaimTypes.NameIdentifier,login.Email),
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var properties = new AuthenticationProperties()
            {
                IsPersistent = login.RememberMe
            };
            HttpContext.SignInAsync(principal, properties);

            return Redirect(returnUrl);
        }

        #endregion

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
