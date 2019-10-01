using Ninject.Modules;
using Nutrition.Core.Services.Contracts;

namespace Nutrition.Core.Services.Configuration
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAlimentService>().To<AlimentService>().InSingletonScope();
            Bind<IMealService>().To<MealService>().InSingletonScope();
        }
    }
}
