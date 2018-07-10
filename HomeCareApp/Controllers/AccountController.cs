
using HomeCareApp.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeCareApp.Core.Interface;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Linq;

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
        public IActionResult CreateAccount(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;



            var viewmodel = new CreateUserFormView
            {
                ApplicationRoles = _unitOfWork.Role.GetRoles()
            };

            return View(viewmodel);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAccount(int id, CreateUserFormView userFormView, string returnUrl = null)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = id == 0 ? new ApplicationUser() : await _userManager.FindByIdAsync(id.ToString());


                user.UserName = userFormView.UserName;
                user.Email = userFormView.Email;
                user.Firstname = userFormView.Firstname;
                user.LastName = userFormView.Lastname;
                user.PasswordHash = userFormView.Password;
                user.PhoneNumber = userFormView.PhoneNumber.ToString();
                string existingRole = _userManager.GetRolesAsync(user).Result.Single();
                int existingRoleId = _roleManager.Roles.Single(r => r.Name == existingRole).Id;

                IdentityResult result = id == 0 ? await _userManager.CreateAsync(user, userFormView.Password) : await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    if (existingRoleId != userFormView.RoleId)
                    {
                        IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, existingRole);

                        if (roleResult.Succeeded)
                        {
                            ApplicationRole applicationRole = await _roleManager.FindByIdAsync(userFormView.RoleId.ToString());
                            if (applicationRole != null)
                            {
                                IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                                if (newRoleResult.Succeeded)
                                {
                                    return RedirectToAction(returnUrl);
                                }
                            }

                        }
                    }
                }

            }
            return View(userFormView);
        }

        [HttpGet]
        public IActionResult EditUser(EditUserFormView userFormView, string returnUrl = null)
        {
            if (userFormView.Id == 0)
                return BadRequest();

            var user = _unitOfWork.User.GetUser(userFormView.Id);


            var model = new EditUserFormView
            {
                Firstname = user.Firstname,
                Lastname = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                RoleId = _roleManager.Roles.Single(r => r.Name == _userManager.GetRolesAsync(user).Result.Single()).Id,
                ApplicationRoles = _unitOfWork.Role.GetRoles()
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> EditUser(int id, EditUserFormView editUserFormView, string returnUrl = null)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id.ToString());
            if (id == 0)
                return BadRequest();

            user.UserName = editUserFormView.UserName;
            user.Email = editUserFormView.Email;
            user.Firstname = editUserFormView.Firstname;
            user.LastName = editUserFormView.Lastname;
            user.PhoneNumber = editUserFormView.PhoneNumber.ToString();
            string existingRole = _userManager.GetRolesAsync(user).Result.Single();
            int existingRoleId = _roleManager.Roles.Single(r => r.Name == existingRole).Id;

            IdentityResult result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                if (existingRoleId != editUserFormView.RoleId)
                {
                    IdentityResult roleResult = await _userManager.RemoveFromRoleAsync(user, existingRole);

                    if (roleResult.Succeeded)
                    {
                        ApplicationRole applicationRole = await _roleManager.FindByIdAsync(editUserFormView.RoleId.ToString());
                        if (applicationRole != null)
                        {
                            IdentityResult newRoleResult = await _userManager.AddToRoleAsync(user, applicationRole.Name);
                            if (newRoleResult.Succeeded)
                            {

                            }
                        }

                    }
                }
                return RedirectToAction("Index", "Admin");
            }



            return View(editUserFormView);

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var user = _unitOfWork.User.GetUser(id);
            if (user == null)
                return NotFound();

            user.Cancel();
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> Logout()
        {


            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}