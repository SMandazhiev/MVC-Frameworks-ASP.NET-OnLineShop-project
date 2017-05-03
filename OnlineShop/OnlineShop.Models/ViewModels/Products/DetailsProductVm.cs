using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.ViewModels.Products
{
    public class DetailsProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Product Price")]
        public decimal Price { get; set; }

        [Display(Name = "Product Availability")]
        public int Amount { get; set; }
        public string Picture { get; set; }
    }
}