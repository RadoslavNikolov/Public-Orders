namespace PublicOrders.Data.AppData.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using AppData.Models;
    using AppData.Repositories;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class PublicOrdersData : IPublicOrdersData
    {
        private readonly PublicOrdersDbContext dbContext;
        private readonly IDictionary<Type, object> repositories;
        private IUserStore<User> userStore;

        //public PublicOrdersData()
        //    : this(new PublicOrdersDbContext())
        //{
        //}

        public PublicOrdersData(PublicOrdersDbContext dbContext)
        {
            //Out of the box DI in Startup.cs do not allow to make DI with parametrizied constructor
            //Because of that "dbContext" is null. And thah is my workaround
            //if (dbContext == null)
            //{
            //    dbContext = new PublicOrdersDbContext();
            //}

            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users => this.GetRepository<User>();

        public IRepository<Blog> Blogs => this.GetRepository<Blog>();

        public IRepository<Post> Posts => this.GetRepository<Post>();

        public IRepository<Tag> Tags => this.GetRepository<Tag>();

        public IRepository<PostTag> PostTags => this.GetRepository<PostTag>();

        public IUserStore<User> UserStore => this.userStore ?? (this.userStore = new UserStore<User>(this.dbContext));

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericEfRepository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.dbContext));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}