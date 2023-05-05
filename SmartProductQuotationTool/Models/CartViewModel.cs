using SmartProductQuotationTool.Entities;

namespace SmartProductQuotationTool.Models
{
    public class CartViewModel
    {
        public List<Inventory>? Carts { get; set; }
        public User currentUser { get; set; }
        public Dictionary<string, int> Qty { get; set; }
        public List<Inventory> RecommendedProducts { get; set; }
    }
}
