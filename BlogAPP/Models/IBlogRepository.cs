using BlogAPP.ViewModels;

namespace BlogAPP.Models
{
    public interface IBlogRepository
    {
        public string createblog(BlogViewModel blogViewModel);
        public string Deleteblog(int id);
        public BlogPost Editblog(int id);
        public Task<List<BlogPost>> Getallblogs();
        public string updateblog(BlogViewModel blogViewModel);
    }
}
