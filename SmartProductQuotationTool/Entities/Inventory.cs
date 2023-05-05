namespace SmartProductQuotationTool.Entities
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int Level { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public string? PVCode { get; set; }
        public int? Qty { get; set;}
        public string? Image { get; set; } = "";
    }
}
