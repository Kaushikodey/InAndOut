using InAndOut.BLL;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccount_BLL AccountBLL;
        public AccountController(IAccount_BLL _AccountBLL)
        {
            AccountBLL = _AccountBLL;
        }

        [Route("signup")]
        public IActionResult Signup()
        {
            return View();
        }

        [Route("signup")]
        [HttpPost]
        public async Task<IActionResult> Signup(SignUpUserModel data)
        {
            if(ModelState.IsValid)
            {
                var res=await AccountBLL.CreateUserAsync(data);
                if(!res.Succeeded)
                {
                    foreach(var item in res.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    //return View(ModelState);
                }
                ModelState.Clear();
            }
            return View();
        }

        [Route("login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login(SignInModel signinmodel,string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                var result = await AccountBLL.PasswordsignInAsync(signinmodel);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }

                    return RedirectToAction("Index", "Home");
                }
                
                    
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await AccountBLL.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
