namespace PublicOrders.Data.AppData.Models
{
    using System.Collections.Generic;

    public class Post
    {
        public int PostId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}