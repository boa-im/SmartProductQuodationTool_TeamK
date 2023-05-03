using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartProductQuotationTool.DataAccess;
using SmartProductQuotationTool.Entities;
using SmartProductQuotationTool.Models;
using System.Diagnostics;

namespace SmartProductQuotationTool.Controllers
{
    public class HomeController : Controller
    {
        private SPQTDbContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public HomeController(SPQTDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            double discountRate = 0.00;
            if(users.Find(u => u.UserName == username) != null)
            {
                discountRate = (double) users.Find(u => u.UserName == username).DiscountRate;
            }


            ListViewModel listViewModel = new ListViewModel()
            {
                Inventories = _context.Inventories.ToList(),
                DiscountRate = discountRate
            };
            return View(listViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}