using System.Collections.Generic;
using OnlineShop.Models.BindingModels.Editor;
using OnlineShop.Models.ViewModels.Comments;

namespace OnlineShopServices.Interfaces
{
    public interface ICommentService
    {
        IEnumerable<CommentVm> GetAllArticles();
        void AddNewArticle(AddCommentBm bind, string username);
    }
}