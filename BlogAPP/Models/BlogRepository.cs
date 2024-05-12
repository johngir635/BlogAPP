
using BlogAPP.Data;
using BlogAPP.ViewModels;

namespace BlogAPP.Models
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDBContext _blogDBContext;
        public BlogRepository(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }

        public string createblog(BlogViewModel blogViewModel)
        {
            
            try
            {
                BlogPost blogPost = new BlogPost()
                {
                    Title = blogViewModel.Title,
                    Content = blogViewModel.Content,
                    Author = blogViewModel.Author,
                    CreatedAt = DateTime.Now,
                    UpdatedAt= DateTime.Now,

                };
                _blogDBContext.BlogPosts.Add(blogPost);
                _blogDBContext.SaveChanges();
                return "Ok";
            }
            catch
            {
                return "Error";
            }

        }

        public string Deleteblog(int id)
        {
            try
            {


                BlogPost blogPost = _blogDBContext.BlogPosts.Find(id);
                _blogDBContext.BlogPosts.Remove(blogPost);
                _blogDBContext.SaveChanges();
                return "Ok";
            }
            catch
            {
                return "Error";
            }
        }

        public BlogPost Editblog(int id)
        {
            try
            {

           BlogPost blogPost= _blogDBContext.BlogPosts.Find(id);
                return blogPost;
            }
            catch
            {
                return new BlogPost();
            }
            
        }

        public async Task<List<BlogPost>> Getallblogs()
        {
            List<BlogPost> blogPosts = _blogDBContext.BlogPosts
    .OrderByDescending(post => post.CreatedAt)
    .ToList();
            if (blogPosts.Any())
            {
            return blogPosts;

            }
            else
            {
                return new List<BlogPost>();
            }


        }

        public string updateblog(BlogViewModel blogViewModel)
        {
            try
            {
                BlogPost blogPostedit = _blogDBContext.BlogPosts.Find(blogViewModel.Id);


                blogPostedit.Id = blogViewModel.Id ?? 0; // Default to 0 if Id is null
                blogPostedit.Title = blogViewModel.Title ?? ""; // Default to empty string if Title is null
                blogPostedit.Content = blogViewModel.Content ?? ""; // Default to empty string if Content is null
                blogPostedit.Author = blogViewModel.Author ?? ""; // Default to empty string if Author is null
                blogPostedit.CreatedAt = (DateTime)blogViewModel.CreatedAt;  // Default to minimum DateTime if CreatedAt is null
                blogPostedit.UpdatedAt = DateTime.Now;  // Default to minimum DateTime if UpdatedAt is null


                _blogDBContext.BlogPosts.Update(blogPostedit);
                _blogDBContext.SaveChanges();
                return "Ok";
            }
            catch
            {
                return "Error";
            }
        }
    }
}
