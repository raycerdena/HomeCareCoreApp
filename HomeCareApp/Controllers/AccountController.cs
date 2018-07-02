
using HomeCareApp.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeCareApp.Core.Interface;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace HomeCareApp.Controllers
{
    [Authorize]
    //[Route("api/[controller]/[action]")]

    public class AccountController : Controller
    {

        private readonly IUnitofWork _unitOfWork;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(IUnitofWork unitOfWork, UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            //  ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormView loginFormView)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginFormView.Username, loginFormView.Password, loginFormView.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Admin");
                }
            }
            return View(loginFormView);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;



            var viewmodel = new RegisterFormView
            {
                Roles = _unitOfWork.Role.GetRoles()
            };

            return View(viewmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(int id, RegisterFormView registerFormView, string returnUrl = null)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = id == 0 ? new ApplicationUser() : await _userManager.FindByIdAsync(id.ToString());


                user.UserName = registerFormView.UserName;
                user.Email = registerFormView.Email;
                user.Firstname = registerFormView.Firstname;
                user.LastName = registerFormView.Lastname;
                user.PasswordHash = registerFormView.Password;
                user.PhoneNumber = registerFormView.PhoneNumber.ToString();


                IdentityResult result = id == 0 ? await _userManager.CreateAsync(user, registerFormView.Password) : await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {

                    ApplicationRole applicationRole = await _roleManager.FindByIdAsync(registerFormView.RoleId.ToString());

                    if (applicationRole != null)
                    {
                        IdentityResult identityResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);


                        if (identityResult.Succeeded)
                        {
                            return RedirectToAction("Login");
                        }
                    }
                }
            }
            return View(registerFormView);
        }



        public async Task<IActionResult> Logout()
        {


            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}