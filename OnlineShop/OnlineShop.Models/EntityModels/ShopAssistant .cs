namespace OnlineShop.Models.EntityModels
{
    public class ShopAssistant 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}