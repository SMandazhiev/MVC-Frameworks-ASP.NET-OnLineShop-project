using System;
using OnlineShop.Models.EntityModels;

namespace OnlineShop.Models.ViewModels.Comments
{
   public class CommentVm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public CommentAutorVm Author { get; set; }
    }
}
