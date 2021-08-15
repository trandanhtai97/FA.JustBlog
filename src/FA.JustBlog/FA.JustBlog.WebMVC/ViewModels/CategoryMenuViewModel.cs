using FA.JustBlog.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FA.JustBlog.WebMVC.ViewModels
{
    public class CategoryMenuViewModel
    {
        public IEnumerable<Category> PopularCategory { get; set; }
        public IEnumerable<Category> leftCategories { get; set; }
    }
}