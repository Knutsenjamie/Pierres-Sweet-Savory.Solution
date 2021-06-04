using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetSavory.Controllers
{
    [Authorize]
    public class FlavorsController : Controller
    {
        private readonly SweetSavoryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public FlavorsController(UserManager<ApplicationUser> userManager, SweetSavoryContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var allFlavors = _db.Flavors;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null) {
            var currentUser = await _userManager.FindByIdAsync(userId);
            var userFlavors = _db.Flavors.Where(entry => entry.User.Id == currentUser.Id).ToList();
            return View(userFlavors);
            }
            else { return View(allFlavors); }
        }
        public async Task<ActionResult> Create()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
            ViewBag.TreatId = new SelectList(userTreats, "TreatId", "Title");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Flavor flavor, int TreatId)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            flavor.User = currentUser;
            _db.Flavors.Add(flavor);
            _db.SaveChanges();
            if (TreatId != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { TreatId = TreatId, FlavorId = flavor.FlavorId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}