namespace PublicOrders.Infrastructure.Autofac
{
    using Data;
    using Data.UnitOfWork;
    using global::Autofac;

    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PublicOrdersData>()
                .As<IPublicOrdersData>()
                .WithParameter("dbContext", new PublicOrdersDbContext());
        }
    }
}