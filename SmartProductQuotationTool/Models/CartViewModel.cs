using SmartProductQuotationTool.Entities;

namespace SmartProductQuotationTool.Models
{
    public class CartViewModel
    {
        public List<Inventory> Carts { get; set; }
        public User currentUser { get; set; }
        public List<Cart> Items { get; set; }
        public List<Inventory> RecommendedProducts { get; set; }
    }
}
