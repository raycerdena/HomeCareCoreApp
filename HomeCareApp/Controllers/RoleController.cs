using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeCareApp.Core.Interface;
using HomeCareApp.Core.ViewModels;
using HomeCareApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeCareApp.Controllers
{
    public class RoleController : Controller
    {
        private readonly IUnitofWork _unitofWork;

        private readonly RoleManager<ApplicationRole> _roleManager;


        public RoleController(IUnitofWork unitofWork, RoleManager<ApplicationRole> roleManager)
        {
            _unitofWork = unitofWork;
            _roleManager = roleManager;

        }

        public IActionResult Index()
        {
            var roles = _unitofWork.Role.GetRoles();
            if (roles == null)
                return NotFound();

            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> CreateRole(int id)
        {
            RoleFormView roleFormView = new RoleFormView();

            if (id > 0)
            {
                ApplicationRole applicationRole = await _roleManager.FindByIdAsync(id.ToString());
                if (applicationRole != null)
                {
                    roleFormView.RoleName = applicationRole.Name;
                    roleFormView.Description = applicationRole.Description;
                }
            }
            return View(roleFormView);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(int id, RoleFormView roleFormView)
        {


            if (ModelState.IsValid)
            {



                ApplicationRole applicationRole = id == 0 ? new ApplicationRole() : await _roleManager.FindByIdAsync(id.ToString());

                applicationRole.Name = roleFormView.RoleName;
                applicationRole.Description = roleFormView.Description;

                IdentityResult identityResult = id == 0 ? await _roleManager.CreateAsync(applicationRole) : await _roleManager.UpdateAsync(applicationRole);

                if (identityResult.Succeeded)
                    return RedirectToAction("Index");

            }
            return View(roleFormView);
        }
    }
}