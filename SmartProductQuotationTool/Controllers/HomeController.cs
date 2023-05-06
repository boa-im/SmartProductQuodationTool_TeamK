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



        public IActionResult Index(int level = 1)
        {
            Nav.setActive(level);
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            double discountRate = 0.00;
            if (users.Find(u => u.UserName == username) != null)
            {
                discountRate = (double)users.Find(u => u.UserName == username).DiscountRate;
            }

            //For badge
            List<Inventory> findInventory = new List<Inventory>();
            var Qty = new Dictionary<string, int>();
            User currentUser = users.Find(u => u.UserName == username);
            List<Cart> cartList = new List<Cart>();

            if (currentUser != null)
            {
                cartList = _context.Carts.Where(m => m.User.Id == currentUser.Id).ToList();
                foreach (var list in cartList)
                {
                    Inventory item = _context.Inventories.Where(m => m.InventoryId == list.InventoryId).FirstOrDefault();
                    findInventory.Add(item);
                }

                findInventory = findInventory.OrderBy(m => m.Name).ToList();
            }

            

            ListViewModel listViewModel = new ListViewModel()
            {
                Inventories = _context.Inventories.Where(i => i.Level == level).ToList(),
                DiscountRate = discountRate,
                Carts = findInventory,
                Items = cartList
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