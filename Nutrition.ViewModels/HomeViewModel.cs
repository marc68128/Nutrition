using AutoMapper;
using Nutrition.Services.Contracts;
using Nutrition.ViewModels.Contracts;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace Nutrition.ViewModels
{
    internal class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private readonly IKernel _kernel;
        private readonly IMapper _mapper;
        private readonly IAlimentService _alimentService;

        public HomeViewModel(IKernel kernel, IMapper mapper, IAlimentService alimentService)
        {
            _kernel = kernel;
            _mapper = mapper;
            _alimentService = alimentService;
            LoadAliments();
        }

        public List<IAlimentViewModel> Aliments { get; set; }

        private void LoadAliments()
        {
            Aliments = _alimentService.GetAll().Select(dto => _mapper.Map(dto, _kernel.Get<IAlimentViewModel>())).ToList();
        }
    }
}
