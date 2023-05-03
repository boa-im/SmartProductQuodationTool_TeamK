namespace SmartProductQuotationTool.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int InventoryId { get; set; }

        // FK
        public User? User { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
