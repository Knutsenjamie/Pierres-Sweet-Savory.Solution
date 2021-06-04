using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetSavory.Controllers
{
    [Authorize]
    public class TreatsController : Controller
    {
        private readonly SweetSavoryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController(UserManager<ApplicationUser> userManager, SweetSavoryContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var allTreats = _db.Treats;
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId != null) {
                var currentUser = await _userManager.FindByIdAsync(userId);
                var userTreats = _db.Treats.Where(entry => entry.User.Id == currentUser.Id).ToList();
                return View(userTreats);
            }
            else { return View(allTreats); }
        }
        public ActionResult Create()
        {
            ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "FlavorName");
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Treat treat, int FlavorId1)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            treat.User = currentUser;
            _db.Treats.Add(treat);
            _db.SaveChanges();
            if (FlavorId1 != 0)
            {
                _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId1, TreatId = treat.TreatId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}