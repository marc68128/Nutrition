using System;
using Ninject;
using Nutrition.Wpf.ViewModels.Contracts;
using Nutrition.Wpf.ViewModels.Helpers;

namespace Nutrition.Wpf.ViewModels
{
    internal class MainViewModel : BaseViewModel, IMainViewModel
    {
        private readonly IKernel _kernel;
        private IBaseViewModel _viewModel;

        public MainViewModel(IKernel kernel)
        {
            _kernel = kernel;
            Messenger.Default.Register(this, new Action<IBaseViewModel>(SetupViewModel));
            SetupViewModel(_kernel.Get<IHomeViewModel>());
        }

        public IBaseViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                _viewModel = value;
                OnPropertyChanged();
            }
        }
        private void SetupViewModel(IBaseViewModel viewModel)
        {
            ViewModel = viewModel;
        }
    }
}
