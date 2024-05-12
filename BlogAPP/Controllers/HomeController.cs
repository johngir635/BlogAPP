using BlogAPP.Models;
using BlogAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        public HomeController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }
        public async Task<IActionResult> Index()
        {
           List<BlogPost> blogPosts=await _blogRepository.Getallblogs();
            return View(blogPosts);
        }

        public IActionResult CreateBlog(BlogViewModel blogViewModel)
        {
            if(blogViewModel.Id == null || blogViewModel.Id ==0) {
          _blogRepository.createblog(blogViewModel);
            return RedirectToAction("Index", "Home");
            
            }
            else
            {
                _blogRepository.updateblog(blogViewModel);
                return RedirectToAction("Index", "Home");

            }
           
            
        
        }
        public IActionResult Edit(int id)
        {
          BlogPost blog=  _blogRepository.Editblog(id);

            BlogViewModel blogViewModel = new BlogViewModel()
            {
                Id = id,
                Title = blog.Title,
                Author = blog.Author,
                Content = blog.Content,
                CreatedAt=blog.CreatedAt,
                UpdatedAt = DateTime.Now,
            };
            return View(blogViewModel);


        }
        public IActionResult Delete(int id)
        {
            _blogRepository.Deleteblog(id);

            return RedirectToAction("Index", "Home");


        }


    }
}
