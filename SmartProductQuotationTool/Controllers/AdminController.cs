using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartProductQuotationTool.DataAccess;
using SmartProductQuotationTool.Entities;
using SmartProductQuotationTool.Models;
using System.Data;



namespace SmartProductQuotationTool.Controllers
{
    public class AdminController : Controller
    {
        private SPQTDbContext _context;



        public AdminController(SPQTDbContext context) => _context = context;



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Manage()
        {
            List<Inventory> inventories = _context.Inventories.ToList();
            return View(inventories);
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            Inventory inventory = new Inventory();
            return View(inventory);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return View(inventory);
            }



            _context.Inventories.Add(inventory);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Inventory inventory = _context.Inventories.Find(id);
            return View(inventory);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return View(inventory);
            }



            _context.Inventories.Update(inventory);
            _context.SaveChanges();
            return RedirectToAction("Manage");
        }



        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Inventory inventory = _context.Inventories.Find(id);
            return View(inventory);
        }



        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Delete(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
            _context.SaveChanges();
            return RedirectToAction("Manage", "Admin");
        }
    }
}