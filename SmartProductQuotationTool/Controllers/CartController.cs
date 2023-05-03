using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartProductQuotationTool.DataAccess;
using SmartProductQuotationTool.Entities;
using SmartProductQuotationTool.Models;

namespace SmartProductQuotationTool.Controllers
{
    public class CartController : Controller
    {
        private SPQTDbContext _context;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;

        public CartController(SPQTDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet("/cart/add")]
        [Authorize()]
        public IActionResult AddtoCart(int id)
        {
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            User currentUser = users.Find(u => u.UserName == username);
            Inventory currentInventory = _context.Inventories.Where(m => m.InventoryId == id).FirstOrDefault();

            _context.Carts.Add(new Cart { User = currentUser, Inventory = currentInventory });
            _context.SaveChanges();
            currentInventory.Qty--;
            _context.Inventories.Update(currentInventory);
            _context.SaveChanges();

            var cartList = _context.Carts.Where(m => m.User.Id == currentUser.Id).ToList();
            List<Inventory> findInventory = new List<Inventory>();
            var Qty = new Dictionary<string, int>();

            foreach (var list in cartList)
            {
                Inventory item = _context.Inventories.Where(m => m.InventoryId == list.InventoryId).FirstOrDefault();
                findInventory.Add(item);
            }

            findInventory = findInventory.OrderBy(m => m.Name).ToList();

            foreach (var item in findInventory)
            {
                if (!Qty.ContainsKey(item.Name))
                {
                    Qty.Add(item.Name, 1);
                }
                else
                {
                    Qty[item.Name]++;
                }
            }

            findInventory = findInventory.Distinct().ToList();

            CartViewModel cartViewModel = new CartViewModel
            {
                Carts = findInventory,
                currentUser = currentUser,
                Qty = Qty
            };

            return View("Cart", cartViewModel);
        }

        [HttpGet("/cart/delete")]
        [Authorize()]
        public IActionResult Delete(int id)
        {
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            User currentUser = users.Find(u => u.UserName == username);

            //이부분이랑
            /*List<Inventory> currentInventory = _context.Inventories.Where(m => m.InventoryId == id).ToList();

            foreach (var item in currentInventory)
            {
                //이부분 어케해야될지 모르겠다ㅠ
                //_context.Carts.Remove(item);
                _context.SaveChanges();
                item.Qty++;
                _context.Inventories.Update(item);
                _context.SaveChanges();
            }*/

            List<Cart> cartItems = _context.Carts.Where(c => c.User.Id == currentUser.Id && c.InventoryId == id).ToList();
            Inventory currentInventory = _context.Inventories.Where(c => c.InventoryId == id).FirstOrDefault();

            currentInventory.Qty += cartItems.Count();
            _context.Inventories.Update(currentInventory);
            foreach (var item in cartItems)
            {
                _context.Carts.Remove(item);
            }
            _context.SaveChanges();

            /*List<Cart> cartList = _context.Carts.Where(m => m.User.Id == currentUser.Id).ToList();
            List<Inventory> findInventory = new List<Inventory>();
            var Qty = new Dictionary<string, int>();

            foreach (var list in cartList)
            {
                Inventory item = _context.Inventories.Where(m => m.InventoryId == list.InventoryId).FirstOrDefault();
                findInventory.Add(item);
            }

            findInventory = findInventory.OrderBy(m => m.Name).ToList();

            foreach (var item in findInventory)
            {
                if (!Qty.ContainsKey(item.Name))
                {
                    Qty.Add(item.Name, 1);
                }
                else
                {
                    Qty[item.Name]++;
                }
            }

            findInventory = findInventory.Distinct().ToList();

            CartViewModel cartViewModel = new CartViewModel
            {
                Carts = findInventory,
                currentUser = currentUser,
                Qty = Qty
            };*/

            return RedirectToAction("GetAllCart", "Cart"); 
        }

        [HttpGet("/cart")]
        public IActionResult GetAllCart()
        {
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            User currentUser = users.Find(u => u.UserName == username);

            var cartList = _context.Carts.Where(m => m.User.Id == currentUser.Id).ToList();
            List<Inventory> findInventory = new List<Inventory>();
            var Qty = new Dictionary<string, int>();

            foreach (var list in cartList)
            {
                Inventory item = _context.Inventories.Where(m => m.InventoryId == list.InventoryId).FirstOrDefault();
                findInventory.Add(item);
            }

            findInventory = findInventory.OrderBy(m => m.Name).ToList();

            foreach (var item in findInventory)
            {
                if (!Qty.ContainsKey(item.Name))
                {
                    Qty.Add(item.Name, 1);
                }
                else
                {
                    Qty[item.Name]++;
                }
            }

            findInventory = findInventory.Distinct().ToList();

            CartViewModel cartViewModel = new CartViewModel
            {
                Carts = findInventory,
                currentUser = currentUser,
                Qty = Qty
            };

            return View("Cart", cartViewModel);
        }
    }
}
