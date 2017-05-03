using System;
using System.ComponentModel.DataAnnotations;
using OnlineShop.Models.EntityModels;

namespace OnlineShop.Models.BindingModels.Editor
{
    public class AddCommentBm
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        
    }
}