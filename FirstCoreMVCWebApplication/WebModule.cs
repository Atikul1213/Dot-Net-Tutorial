using Autofac;
using FirstCoreMVCWebApplication.Models.Services;

namespace FirstCoreMVCWebApplication
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Item>().As<IItem>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
