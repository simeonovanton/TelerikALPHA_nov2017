using BlogSystem.Infrastructure.Mapping;
using BlogSystem.Services.Data.Contracts;
using BlogSystem.Web.Models;
using BlogSystem.Web.Models.HomeViewModels;
using BlogSystem.Web.Models.PostViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMappingProvider mapper;
        private readonly IPostsService posts;

        public HomeController(IMappingProvider mapper, IPostsService posts)
        {
            this.mapper = mapper;
            this.posts = posts;
        }

        public IActionResult Index()
        {
            var latestPosts = this.posts.GetLatestPosts();

            var model = new IndexViewModel();
            model.Posts = this.mapper.ProjectTo<PostViewModel>(latestPosts);

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
