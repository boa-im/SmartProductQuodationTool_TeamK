using SmartProductQuotationTool.Entities;

namespace SmartProductQuotationTool.Models
{
    public class ListViewModel
    {
        public List<Inventory>? Inventories { get; set; }
        public double DiscountRate { get; set; }
        public List<Inventory>? Carts { get; set; }
        public List<Cart> Items { get; set; }
    }
}
