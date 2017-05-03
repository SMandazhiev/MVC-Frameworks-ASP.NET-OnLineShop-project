namespace OnlineShop.Models.EntityModels
{
    public class Purchase
    {
        public int Id { get; set; }
        public int PurchaseNumber { get; set; }
        public Product Product { get; set; }

        public decimal ProductTypeCosts { get; set; }
        
    }
}