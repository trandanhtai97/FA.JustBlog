using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FA.JustBlog.Services;

namespace FA.JustBlog.WebMVC.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagServices _tagServices;
        private readonly IPostServices _postServices;

        public TagController(ITagServices tagServices, IPostServices postServices)
        {
            _tagServices = tagServices;
            _postServices = postServices;
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var tag = await _tagServices.GetByIdAsync(id);
            var posts = await _postServices.GetPostsByTagAsync(id);
            ViewBag.TagName = tag.Name;
            return View(posts);
        }

        public ActionResult PopularTags()
        {
            var popularTags = Task.Run(() => _tagServices.GetPopularTags()).Result;
            return PartialView("_PopularTags", popularTags);
        }
    }
}