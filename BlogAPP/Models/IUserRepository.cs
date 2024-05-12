using BlogAPP.ViewModels;

namespace BlogAPP.Models
{
    public interface IUserRepository
    {
        public Task<string> AddUser(UserViewModel userViewModel);
        public string Authenticateuser(UserViewModel user);
    }
}
