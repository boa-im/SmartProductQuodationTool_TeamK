namespace SmartProductQuotationTool.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }

        // FK
        public User? User { get; set; }
    }
}
