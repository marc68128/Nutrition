using AutoMapper;
using Nutrition.Services.Contracts;
using Nutrition.ViewModels.Contracts;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Nutrition.Dtos;

namespace Nutrition.ViewModels
{
    internal class HomeViewModel : BaseViewModel, IHomeViewModel
    {
        private readonly IKernel _kernel;
        private readonly IMapper _mapper;
        private readonly IAlimentService _alimentService;
        private readonly IMealService _mealService;

        public HomeViewModel(IKernel kernel, IMapper mapper, IAlimentService alimentService, IMealService mealService)
        {
            _kernel = kernel;
            _mapper = mapper;
            _alimentService = alimentService;
            _mealService = mealService;
            LoadAliments();
        }

        public List<IAlimentViewModel> Aliments { get; set; }
        public IMealViewModel Meal { get; set; }

        private void LoadAliments()
        {
            Aliments = _alimentService.GetAll().Select(dto => _mapper.Map(dto, _kernel.Get<IAlimentViewModel>())).ToList();
            Meal = _mapper.Map(
                _mealService.GetRandomMeal(new MealGoalsDto {Calories = 489, Protides = 38, Lipides = 16, Glucides = 45}, 4), 
                _kernel.Get<IMealViewModel>());

        }
    }
}
