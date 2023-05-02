namespace SmartProductQuotationTool.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public ICollection<Inventory>? Inventories { get; set; }

        // FK
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
