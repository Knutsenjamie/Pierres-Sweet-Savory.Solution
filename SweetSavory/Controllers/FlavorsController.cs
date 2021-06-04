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
    }
}