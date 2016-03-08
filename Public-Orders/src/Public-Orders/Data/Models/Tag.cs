namespace PublicOrders.Data.Models
{
    using System.Collections.Generic;

    public class Tag
    {
        public int TagId { get; set; }

        public string Title { get; set; }

        public ICollection<PostTag> PostTags { get; set; }
    }
}