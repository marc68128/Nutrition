using Ninject.Modules;
using Nutrition.Services.Contracts;

namespace Nutrition.Services.Configuration
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
