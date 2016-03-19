namespace PublicOrders.Data.AppData.Repositories
{
    using System.Linq;
    using Infrastructure.MyExtensions;
    using Microsoft.Data.Entity;

    public class GenericEfRepository<TEntity> : IRepository<TEntity> where TEntity : class 
    {
        protected DbContext DbContext;
        protected DbSet<TEntity> entitySet;

        public GenericEfRepository(DbContext dbContext)
        {
            this.DbContext = dbContext;
            this.entitySet = dbContext.Set<TEntity>();
        }

        public DbSet<TEntity> EntitySet => this.entitySet;

        public IQueryable<TEntity> All()
        {
            return this.entitySet;
        }

        public TEntity Find(object id)
        {
            return this.entitySet.Find(id);
        }

        public void Add(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public void Update(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public void Remove(TEntity entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public TEntity Remove(object id)
        {
            var entity = this.Find(id);
            this.Remove(entity);

            return entity;
        }

        public void SaveChanges()
        {
            this.DbContext.SaveChanges();
        }


        private void ChangeState(TEntity entity, EntityState state)
        {
            var entry = this.DbContext.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(entity);
            }

            entry.State = state;
        }

    }
}