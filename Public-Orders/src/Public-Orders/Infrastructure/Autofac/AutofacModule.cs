﻿namespace PublicOrders.Infrastructure.Autofac
{
    using global::Autofac;
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder
            //    .Register(c => new SimpleService())
            //    .As<IService>()
            //    .InstancePerLifetimeScope();
        }
    }
}