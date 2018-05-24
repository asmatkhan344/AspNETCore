using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UefaChampionsLeague.Models;
using UefaChampionsLeague.ViewModels;

namespace UefaChampionsLeague.Controllers
{
    public class LeagueController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UefaDbContext _dbContext;

        public LeagueController(UserManager<ApplicationUser>userManager,UefaDbContext dbContext,SignInManager<ApplicationUser>signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _dbContext = dbContext;
        }
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult AddClubs()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> AddClubs(ClubsViewModel cvm)
        {
            var Claimuser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var ClubInfo = new Clubs
                {
                    ClubName = cvm.ClubName,
                    ClubManager = cvm.ClubManager,
                    UserId = Claimuser.Id.ToString()
                };
                _dbContext.Add(ClubInfo);
                var CName = _dbContext.tblClubs.FirstOrDefault(f => f.ClubName == cvm.ClubName);
                if (CName==null)
                {
                    _dbContext.SaveChanges();
                    ViewBag.Message = "Club is added successfully!";
                }
                else
                {
                    ViewBag.Error = "Club Name already taken!";
                }
            }
            return View(cvm);
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult AddPlayers()
        {
            GetClubInfo();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPlayers(PlayersViewModel pvm)
        {
            var ClaimUser = await _userManager.FindByIdAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                var player = new Players
                {
                    Name=pvm.Name,
                    ClubId=pvm.ClubId
                };
                _dbContext.Add(player);
                var C_Player = _dbContext.tblPlayers.FirstOrDefault(f => f.Name == pvm.Name && f.ClubId == pvm.ClubId);
                if (C_Player==null)
                {
                    _dbContext.SaveChanges();
                    ViewBag.Message = "Player is added successfully!";
                }
                else
                {
                    ViewBag.Error = "Player is already taken by club!";
                }
            }
            GetClubInfo();
            return View(pvm);
        }

        public void GetClubInfo()
        {
            var ClubId = from c in _dbContext.tblClubs orderby c.ClubName select c;
            ViewBag.CId = new SelectList(ClubId.AsNoTracking(), "ClubId", "ClubName");
        }

        //ClubInfoJoins
        [HttpGet]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> ClubInfo()
        {
            var clubInfo = from c in _dbContext.tblClubs
                           join p in _dbContext.tblPlayers on c.ClubId equals p.ClubId into cp
                           from a in cp.DefaultIfEmpty()
                           select new ClubInfoViewModel { ClubId = c.ClubId, PlayerId = a.PlayerId, ClubName = c.ClubName, ClubManager = c.ClubManager, Name = a.Name };
            return View(await clubInfo.ToListAsync());

            //If you want to pass one parameter in where clause - For Example i want to show the record of player no 2

            //var cluInfo = from c in _dbContext.tblClubs
            //              join p in _dbContext.tblPlayers on c.ClubId equals p.ClubId into cp
            //              from a in cp.DefaultIfEmpty()
            //              where a.PlayerId == 2
            //              select new ClubInfoViewModel { ClubId = c.ClubId, PlayerId = a.PlayerId, ClubName = c.ClubName, ClubManager = c.ClubManager, Name = a.Name };
            //return View(await clubInfo.ToListAsync());
        }
    }
}