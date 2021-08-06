using FA.JustBlog.Models.Common;
using FA.JustBlog.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace FA.JustBlog.WebMVC.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostServices _postServices;
        private readonly ICategoryServices _categoryServices;

        public PostsController(IPostServices postServices, ICategoryServices categoryServices)
        {
            _postServices = postServices;
            _categoryServices = categoryServices;
        }
        public async Task<ActionResult> Index(int? pageIndex = 1, int? pageSize = 5)
        {
            Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy = x => x.OrderByDescending(p => p.PublishedDate);
            var posts = await _postServices.GetAsync(filter: null, orderBy: orderBy,
                pageIndex: pageIndex ?? 1, pageSize: pageSize ?? 5);
            return View(posts);
        }
        public ActionResult LastestPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetLatestPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Lasted Posts";
            return PartialView("_LastestPost", lastestPosts);
        }

        public ActionResult MostViewPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetMostViewPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Most Posts";
            return PartialView("_LastestPost", lastestPosts);
        }

        public ActionResult HighesPosts()
        {
            var lastestPosts = Task.Run(() => _postServices.GetHighesPostAsync(5)).Result;
            ViewBag.PartialViewTitle = "Highes Posts";
            return PartialView("_LastestPost", lastestPosts);
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var post = await _postServices.GetByIdAsync(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }
    }
}