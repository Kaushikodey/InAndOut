using InAndOut.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace InAndOut.BLL
{
    public interface IAccount_BLL
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel signUpModel);
        Task<SignInResult> PasswordsignInAsync(SignInModel signinmodel);
        Task SignOutAsync();
    }
}