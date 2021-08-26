namespace Wicresoft.WFH.Api
{
    using System.Reflection;
    using System.Collections.Generic;

    using Unity;
    using Unity.Lifetime;
    using Unity.Injection;
    using Unity.RegistrationByConvention;

    using Wicresoft.WFH.Data;
    using Wicresoft.WFH.Repository;

    public static class UnityConfig
    {
        public static IUnityContainer RootContainer { get; } = new UnityContainer();

        public static void RegisterComponents()
        {
            var assemblies = new List<Assembly>() {typeof(IUserService).Assembly};
            RootContainer.RegisterTypes(AllClasses.FromAssemblies(assemblies), WithMappings.FromMatchingInterface,
                WithName.Default);

            RootContainer.RegisterType<WorkFromHomeEntities>(new TransientLifetimeManager(),
                new InjectionConstructor(Configuration.ConnectionString, Configuration.CommandTimeout));
            RootContainer.RegisterType<IWorkFromHomeEntities, WorkFromHomeEntities>(new TransientLifetimeManager());

            RootContainer.RegisterType<IUserRepository, UserRepository>();
            RootContainer.RegisterType<IRoleRepository, RoleRepository>();
            RootContainer.RegisterType<IAccessRepository, AccessRepository>();
            RootContainer.RegisterType<IPermissionRepository, PermissionRepository>();
            RootContainer.RegisterType<IMenuRepository, MenuRepository>();
        }
    }
}