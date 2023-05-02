using Microsoft.AspNetCore.Mvc;
using SmartProductQuotationTool.DataAccess;
using SmartProductQuotationTool.Models;
using System.Diagnostics;



namespace SmartProductQuotationTool.Controllers
{
    public class HomeController : Controller
    {
        private SPQTDbContext _context;



        public HomeController(SPQTDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            ListViewModel listViewModel = new ListViewModel()
            {
                Inventories = _context.Inventories.ToList(),
                DiscountRate = 1.0
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