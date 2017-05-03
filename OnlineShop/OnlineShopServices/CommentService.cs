using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using OnlineShop.Models.BindingModels.Editor;
using OnlineShop.Models.EntityModels;
using OnlineShop.Models.ViewModels.Comments;
using OnlineShopServices.Interfaces;

namespace OnlineShopServices
{
    public class CommentService : Service, ICommentService
    {
        public IEnumerable<CommentVm> GetAllArticles()
        {
            IEnumerable<Comment> models = this.Context.Comments;
            IEnumerable<CommentVm> vms = Mapper.Map<IEnumerable<Comment>, IEnumerable<CommentVm>>(models);
            return vms;
        }

        public void AddNewArticle(AddCommentBm bind, string username)
        {
            ApplicationUser currentUser = Context.Users.FirstOrDefault(user => user.UserName == username);
            Comment model = Mapper.Map<AddCommentBm, Comment>(bind);
            model.Author = currentUser;
            model.PublishDate = DateTime.Today;
            this.Context.Comments.Add(model);
            this.Context.SaveChanges();
        }
    }
}