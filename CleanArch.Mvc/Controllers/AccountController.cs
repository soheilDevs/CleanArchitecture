using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interfaces;
using CleanArch.Application.Security;
using CleanArch.Application.ViewModels;
using CleanArch.Domains.Models;

namespace CleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


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
            if (checkUser!=CheckUser.Ok)
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
            return View("SuccessRegister",register);
        }
    }
}
