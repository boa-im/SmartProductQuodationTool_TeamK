namespace SmartProductQuotationTool.Entities
{
    public class Cart
    {
        public int CartId { get; set; }
        public int InventoryId { get; set; }
        public int Qty { get; set; } = 0;

        // FK
        public User? User { get; set; }
        public Inventory? Inventory { get; set; }
    }
}
