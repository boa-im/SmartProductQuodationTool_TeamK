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

            if (_context.Carts.Where(m => m.InventoryId == id).FirstOrDefault() == null) 
            {
                _context.Carts.Add(new Cart { User = currentUser, Inventory = currentInventory, Qty = 1 });
            }
            else
            {
                _context.Carts.Where(m => m.InventoryId == id).FirstOrDefault().Qty++;
            }
            
            _context.SaveChanges();
            currentInventory.Qty--;
            _context.Inventories.Update(currentInventory);
            _context.SaveChanges();

            return RedirectToAction("GetAllCart", "Cart");
        }

        [HttpGet("/cart/delete")]
        [Authorize()]
        public IActionResult Delete(int id)
        {
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            User currentUser = users.Find(u => u.UserName == username);

            Cart cartItem = _context.Carts.Where(c => c.User.Id == currentUser.Id && c.InventoryId == id).FirstOrDefault();
            Inventory currentInventory = _context.Inventories.Where(c => c.InventoryId == id).FirstOrDefault();

            currentInventory.Qty += cartItem.Qty;
            _context.Inventories.Update(currentInventory);
            _context.Carts.Remove(cartItem);
            _context.SaveChanges();

            return RedirectToAction("GetAllCart", "Cart"); 
        }

        [HttpGet("/cart")]
        [Authorize()]
        public IActionResult GetAllCart()
        {
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            User currentUser = users.Find(u => u.UserName == username);

            var cartList = _context.Carts.Where(m => m.User.Id == currentUser.Id).ToList();
            List<Inventory> findInventory = new List<Inventory>();

            foreach (var list in cartList)
            {
                Inventory item = _context.Inventories.Where(m => m.InventoryId == list.InventoryId).FirstOrDefault();
                findInventory.Add(item);
            }

            findInventory = findInventory.OrderBy(m => m.Name).ToList();

            CartViewModel cartViewModel = new CartViewModel
            {
                Carts = findInventory,
                currentUser = currentUser,
                Items = cartList,
                RecommendedProducts = _context.Inventories.Where(i => i.Level == 7).ToList()
            };

            for (int level = 7; level >= 1; level--)
            {
                cartViewModel.RecommendedProducts = _context.Carts.Where(c => c.Inventory.Level == level).FirstOrDefault() == null ? _context.Inventories.Where(i => i.Level == level).ToList() : cartViewModel.RecommendedProducts;
            }

            return View("Cart", cartViewModel);
        }

        [HttpPost("/cart/modify")]
        [Authorize()]
        public IActionResult Modify(int id, int Qty)
        {
            string? username = HttpContext.User.Identity.Name;
            var users = _userManager.Users.ToList();
            User currentUser = users.Find(u => u.UserName == username);

            Cart cartItem = _context.Carts.Where(c => c.User.Id == currentUser.Id && c.InventoryId == id).FirstOrDefault();
            Inventory currentInventory = _context.Inventories.Where(c => c.InventoryId == id).FirstOrDefault();

            if(cartItem.Qty == 0)
            {
                currentInventory.Qty += cartItem.Qty;
                _context.Inventories.Update(currentInventory);
                _context.Carts.Remove(cartItem);
                _context.SaveChanges();
            }
            else if(cartItem.Qty > 0)
            {
                // User wants to decrease the qty
                if (cartItem.Qty > Qty)
                {
                    currentInventory.Qty += (cartItem.Qty - Qty);
                    _context.Inventories.Update(currentInventory);
                    cartItem.Qty = Qty;
                    _context.Carts.Update(cartItem);
                    _context.SaveChanges();
                }
                // User wants to increase the qty
                else if (cartItem.Qty <= Qty)
                {
                    if(currentInventory.Qty >= Qty-cartItem.Qty)
                    {
                        currentInventory.Qty -= (Qty - cartItem.Qty);
                        _context.Inventories.Update(currentInventory);
                        cartItem.Qty = Qty;
                        _context.Carts.Update(cartItem);
                        _context.SaveChanges();
                    }
                }
            }

            return RedirectToAction("GetAllCart", "Cart");
        }
    }
}
