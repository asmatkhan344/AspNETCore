using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UefaChampionsLeague.Models;
using UefaChampionsLeague.ViewModels;

namespace UefaChampionsLeague.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UefaDbContext _dbContext;
        private readonly SignInManager<ApplicationUser> _SignInManager;

        public UserManagementController(UserManager<ApplicationUser>userManager,RoleManager<IdentityRole> roleManager,SignInManager<ApplicationUser>signInManager,UefaDbContext dbContext)
        {
            _dbContext = dbContext;
            _SignInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult SignUpUsers()
        {
            var RegisteredUsers = new UserManagementRUsersViewModel
            {
                Users = _dbContext.Users.OrderBy(o => o.Name).ToList()
            };
               
            return View(RegisteredUsers);
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddRoles(string UserId)
        {
            var userid = await _userManager.FindByIdAsync(UserId);
            var GetUserData = new UserManagementRoleViewModel
            {
                UserId = userid.Id,
                Email = userid.Email,
                Roles = new SelectList(_roleManager.Roles.OrderBy(o => o.Name))
            };
            return View(GetUserData);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddRoles(UserManagementRoleViewModel urm)
        {
            var user = await _userManager.FindByIdAsync(urm.UserId);
            if (ModelState.IsValid)
            {
                var result = await _userManager.AddToRoleAsync(user, urm.NewRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignUpUsers", "UserManagement");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            urm.Email= user.Email;
            urm.Roles = GetRoles();
            return View(urm);
        }

        public async Task<ApplicationUser> GetUserId(string UserId) =>
            await _userManager.FindByIdAsync(UserId);
        public SelectList GetRoles() => new SelectList(_roleManager.Roles.OrderBy(o => o.Name).ToList());
    }
}