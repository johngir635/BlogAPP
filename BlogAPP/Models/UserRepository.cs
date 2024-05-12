using BlogAPP.Data;
using BlogAPP.ViewModels;

namespace BlogAPP.Models
{
    public class UserRepository:IUserRepository
    {       
        private readonly BlogDBContext _blogDBContext;
        public UserRepository(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }

        public async Task<string> AddUser(UserViewModel userViewModel)
        {
            try
            {
                UserBlog user = new UserBlog()
                {
                    FirstName = userViewModel.FirstName,
                    LastName = userViewModel.LastName,
                    Email=userViewModel.Email,
                    Password = userViewModel.Password,
                    ConfirmPassword = userViewModel.ConfirmPassword
                };
                _blogDBContext.Users.Add(user);
                _blogDBContext.SaveChanges();
                return "User Added";
            }
            catch (Exception ex) {
                return "Error Occured";
            }

        }

        public string Authenticateuser(UserViewModel user)
        {

            var userExist = _blogDBContext.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (userExist != null)
            {
                return "Ok";
            }
            else
            {
                return "Error";
            }

        }
    }
}
