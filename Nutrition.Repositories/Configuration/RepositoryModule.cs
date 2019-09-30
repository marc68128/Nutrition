using Ninject.Modules;
using Nutrition.Repositories.Contracts;

namespace Nutrition.Repositories.Configuration
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlimentRepository>().To<AlimentRepository>().InSingletonScope();
        }
    }
}
