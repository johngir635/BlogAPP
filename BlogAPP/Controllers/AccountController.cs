using BlogAPP.Data;
using BlogAPP.Models;
using BlogAPP.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPP.Controllers
{
    public class AccountController : Controller
    {
      private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public  IActionResult signup(UserViewModel user)
        {
            _userRepository.AddUser(user);
          return  RedirectToAction("login", "Account");
        }

        public IActionResult login()
        {
            return View();
        }
        public IActionResult userlogin(UserViewModel userlogin)
        {
          var message=  _userRepository.Authenticateuser(userlogin);
            if (message =="Ok" )
            {
            return RedirectToAction("index", "Home");

            }
            else 
            {
                return RedirectToAction("login", "Account");
            }

        }
    }
}
