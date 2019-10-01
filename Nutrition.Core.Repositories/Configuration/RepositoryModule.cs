using Ninject.Modules;
using Nutrition.Core.Repositories.Contracts;

namespace Nutrition.Core.Repositories.Configuration
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlimentRepository>().To<AlimentRepository>().InSingletonScope();
        }
    }
}
