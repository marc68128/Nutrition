using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;
using Nutrition.ViewModels.Contracts;

namespace Nutrition.ViewModels.Configuration
{
    public class ViewModelModule : NinjectModule
    {

        public override void Load()
        {
            Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();
            Bind<IAlimentViewModel>().To<AlimentViewModel>().InTransientScope();
            Bind<IHomeViewModel>().To<HomeViewModel>().InTransientScope();
        }
    }
}
