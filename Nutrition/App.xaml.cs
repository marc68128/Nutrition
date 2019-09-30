﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AutoMapper;
using Ninject;
using Nutrition.Repositories.Configuration;
using Nutrition.Services.Configuration;
using Nutrition.ViewModels.Configuration;

namespace Nutrition
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _iocKernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _iocKernel = new StandardKernel();
            _iocKernel.Load(new RepositoryModule());
            _iocKernel.Load(new ServiceModule());
            _iocKernel.Load(new ViewModelModule());

            _iocKernel.Bind<IMapper>().ToConstant(new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServicesMappingProfile>();
                cfg.AddProfile<ViewModelsMappingProfile>();
            })));

            Current.MainWindow = _iocKernel.Get<MainWindow>();
            Current.MainWindow.Show();
        }
    }
}
