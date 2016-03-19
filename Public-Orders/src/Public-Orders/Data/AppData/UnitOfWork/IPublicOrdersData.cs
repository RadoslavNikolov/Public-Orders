namespace PublicOrders.Data.AppData.UnitOfWork
{
    using AppData.Models;
    using AppData.Repositories;

    public interface IPublicOrdersData
    {
        IRepository<User> Users { get; }

        IRepository<Blog> Blogs { get; }

        IRepository<Post> Posts { get; }

        IRepository<Tag> Tags { get; }
        
        IRepository<PostTag> PostTags { get; }  

        void SaveChanges();
    }
}