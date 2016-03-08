﻿namespace PublicOrders.Data.UnitOfWork
{
    using Models;
    using Repositories;

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