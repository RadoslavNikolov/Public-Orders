namespace PublicOrders.Data.Repositories
{
    using System;
    public interface IPublicOrderDbContext : IDisposable
    {
        int SaveChanges();
    }
}