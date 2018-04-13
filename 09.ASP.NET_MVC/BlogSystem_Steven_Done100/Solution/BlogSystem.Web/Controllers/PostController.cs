using BlogSystem.Data.Models;
using BlogSystem.DTO;
using BlogSystem.Infrastructure.Mapping;
using BlogSystem.Services.Data.Contracts;
using BlogSystem.Web.Models.PostViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogSystem.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IMappingProvider mapper;
        private readonly IPostsService posts;
        private readonly ICommentsService comments;
        private readonly UserManager<User> userManager;

        public PostController(IMappingProvider mapper, IPostsService posts, ICommentsService comments, UserManager<User> userManager)
        {
            this.mapper = mapper;
            this.posts = posts;
            this.comments = comments;
            this.userManager = userManager;
        }

        public IActionResult Details(int id)
        {
            var model = new DetailsViewModel();

            var post = this.posts.GetById(id);
            model.Post = this.mapper.MapTo<PostViewModel>(post);

            var comments = this.comments.GetByPostId(id);
            model.Comments = this.mapper.ProjectTo<CommentViewModel>(comments);

            return View(model);
        }

        [Authorize]
        public IActionResult Publish()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]

        public IActionResult Publish(PostViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                var dto = this.mapper.MapTo<PostDto>(model);
                dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

                this.posts.Publish(dto);

                TempData["Success-Message"] = "You published a new post!";
                return this.RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Comment(int id, CommentViewModel comment)
        {
            var dto = new CommentDto();
            dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);
            dto.Content = comment.Content;
            dto.PostId = id;

            this.comments.Publish(dto);

            return this.RedirectToAction("Details", "Post", new { id });
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]

        public IActionResult Update(PostViewModel model)
        {
            var dto = this.mapper.MapTo<PostDto>(model);
            dto.AuthorId = this.userManager.GetUserId(this.HttpContext.User);

            this.posts.Update(dto);

            return this.RedirectToAction("Details", "Post", new { id = model.Id });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]

        public IActionResult Delete(int id)
        {
            this.posts.Delete(id);

            TempData["Success-Message"] = "You deleted a post with ID: " + id;
            return this.RedirectToAction("Index", "Home");
        }
    }
}