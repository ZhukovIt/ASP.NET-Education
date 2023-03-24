using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    [Authorize]
    public sealed class AccountController : Controller
    {
        private UserManager<IdentityUser> m_UserManager;
        private SignInManager<IdentityUser> m_SignInManager;

        public AccountController(UserManager<IdentityUser> UserManager, 
            SignInManager<IdentityUser> SignInManager)
        {
            m_UserManager = UserManager;
            m_SignInManager = SignInManager;
        }

        [AllowAnonymous]
        public ViewResult Login(string _ReturnUrl)
        {
            return View(new LoginModel { ReturnUrl = _ReturnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel _LoginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await m_UserManager.FindByNameAsync(_LoginModel.Name);
                if (user != null)
                {
                    await m_SignInManager.SignOutAsync();
                    if ((await m_SignInManager.PasswordSignInAsync(user,
                        _LoginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(_LoginModel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Неправильное имя или пароль");
            return View(_LoginModel);
        }

        public async Task<RedirectResult> Logout(string _ReturnUrl = "/")
        {
            await m_SignInManager.SignOutAsync();
            return Redirect(_ReturnUrl);
        }
    }
}
