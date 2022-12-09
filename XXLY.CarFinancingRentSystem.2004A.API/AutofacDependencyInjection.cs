using Autofac;

namespace XXLY.CarFinancingRentSystem._2004A.API
{
    public class AutofacDependencyInjection : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region 单个注册
            //单个服务或仓储注册：前面是实现，后面是接口
            //builder.RegisterType<UserService>().As<IUserService>()
            #endregion

            #region 批量注册 使用反射Load加载程序集

            //用反射获取仓储实现的类库（根据命名空间），并注册
            var respository = System.Reflection.Assembly.Load("XXLY.CarFinancingRentSystem.2004A.Repository");
            builder.RegisterAssemblyTypes(respository)
                       .AsImplementedInterfaces()
                       .InstancePerDependency();
            //.InstancePerLifetimeScope();

            //用反射获取服务实现的类库（根据命名空间），并注册
            var services = System.Reflection.Assembly.Load("XXLY.CarFinancingRentSystem.2004A.Services");
            builder.RegisterAssemblyTypes(services)
                       .AsImplementedInterfaces() //是以接口方式进行注入,注入这些类的所有的公共接口作为服务（除了释放资源）
                       .InstancePerDependency(); //每次都创建实例
                                                 //.InstancePerLifetimeScope();//生命周期内相同
            #endregion
        }
    }
}
