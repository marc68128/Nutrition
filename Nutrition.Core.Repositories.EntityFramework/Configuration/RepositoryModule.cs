using System.Configuration;
using Ninject.Modules;
using Nutrition.Core.Repositories.Contracts;
using Nutrition.Core.Repositories.EntityFramework.Data;

namespace Nutrition.Core.Repositories.EntityFramework.Configuration
{
    public class RepositoryModule : NinjectModule
    {
        private readonly string _connectionString;

        public RepositoryModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        public override void Load()
        {
            Bind<NutContext>().ToSelf().InTransientScope()
                .WithConstructorArgument("connectionString", _connectionString);

            Bind<IAlimentRepository>().To<AlimentRepository>().InSingletonScope();
        }
    }
}
