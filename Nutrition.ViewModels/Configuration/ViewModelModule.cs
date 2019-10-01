using Ninject.Modules;
using Nutrition.Wpf.ViewModels.Contracts;

namespace Nutrition.Wpf.ViewModels.Configuration
{
    public class ViewModelModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<IAlimentViewModel>().To<AlimentViewModel>().InTransientScope();
            Bind<IHomeViewModel>().To<HomeViewModel>().InTransientScope();
            Bind<IMealViewModel>().To<MealViewModel>().InTransientScope();
            Bind<IMealPartViewModel>().To<MealPartViewModel>().InTransientScope();
        }
    }
}
