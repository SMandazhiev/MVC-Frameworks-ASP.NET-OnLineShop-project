using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models.ViewModels.Users
{
    public class EditUserVm
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
       
    }
}