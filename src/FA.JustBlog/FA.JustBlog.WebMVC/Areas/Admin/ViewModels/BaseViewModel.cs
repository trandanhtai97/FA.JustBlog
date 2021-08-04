using FA.JustBlog.WebMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.WebMVC.Areas.Admin.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
    }
    public class PostViewModel : BaseViewModel
    {
        public string Title { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}