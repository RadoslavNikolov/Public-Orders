namespace PublicOrders.Data.AppData.Repositories
{
    using System;

    public interface IPublicOrderDbContext : IDisposable
    {
        int SaveChanges();
    }
}