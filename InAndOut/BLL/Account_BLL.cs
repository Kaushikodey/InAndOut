using InAndOut.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.BLL
{
    public class Account_BLL : IAccount_BLL
    {
        public readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signinmanager;

        public Account_BLL(UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser> signinmanager)
        {
            this.usermanager = usermanager;
            this.signinmanager = signinmanager;
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpModel)
        {
            var user = new ApplicationUser()
            {
                Email = signUpModel.Email,
                UserName = signUpModel.Email,
                FirstName=signUpModel.FirstName,
                LastName=signUpModel.LastName,            
            };

            var Result=await usermanager.CreateAsync(user, signUpModel.Password);
            return Result;
        }

        public async Task<SignInResult> PasswordsignInAsync(SignInModel signinmodel)
        {
            var result = await signinmanager.PasswordSignInAsync(signinmodel.Email, signinmodel.Password, signinmodel.RememberMe, false);
            return result;
        }

        public async Task SignOutAsync()
        {
            await signinmanager.SignOutAsync();
        }
    }
}
