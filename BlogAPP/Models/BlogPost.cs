namespace BlogAPP.Models
{
    public class BlogPost
    {
        
            // Unique identifier for the blog post
            public int Id { get; set; }

            // Title of the blog post
            public string Title { get; set; }

            // Content of the blog post
            public string Content { get; set; }

            // Author of the blog post
            public string Author { get; set; }

            // Date and time when the blog post was created
            public DateTime CreatedAt { get; set; }

            // Date and time when the blog post was last updated
            public DateTime UpdatedAt { get; set; }
        
    }
}
