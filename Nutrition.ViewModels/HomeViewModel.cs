using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using AutoMapper;
using Ninject;
using Nutrition.Dtos;
using Nutrition.Services.Contracts;
using Nutrition.Wpf.ViewModels.Commands;
using Nutrition.Wpf.ViewModels.Contracts;

namespace Nutrition.Wpf.ViewModels
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
            
            InitCommands();
            LoadAliments();
        }

        public List<IAlimentViewModel> Aliments { get; set; }


        private double _goalCalories;
        private double _goalProtides;
        private double _goalLipides;
        private double _goalGlucides;
        private int _alimentCount;
        private IMealViewModel _meal;
        private bool _isLoading;

        public double GoalCalories
        {
            get => _goalCalories;
            set
            {
                _goalCalories = value;
                OnPropertyChanged();
            }
        }
        public double GoalProtides
        {
            get => _goalProtides;
            set
            {
                _goalProtides = value;
                OnPropertyChanged();
            }
        }
        public double GoalLipides
        {
            get => _goalLipides;
            set
            {
                _goalLipides = value;
                OnPropertyChanged();
            }
        }
        public double GoalGlucides
        {
            get => _goalGlucides;
            set
            {
                _goalGlucides = value;
                OnPropertyChanged();
            }
        }
        public int AlimentCount
        {
            get => _alimentCount;
            set
            {
                _alimentCount = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }

        public IMealViewModel Meal
        {
            get => _meal;
            set
            {
                _meal = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateMealCommand { get; private set; }


        private void LoadAliments()
        {
            Aliments = _alimentService.GetAll().Select(dto => _mapper.Map(dto, _kernel.Get<IAlimentViewModel>())).ToList();
        }

        private void InitCommands()
        {
            GenerateMealCommand = new RelayCommand(ExecuteGenerateMealCommand, CanExecuteGenerateMealCommand);
        }

        private bool CanExecuteGenerateMealCommand(object arg)
        {
            return AlimentCount > 0 && AlimentCount < 10;
        }
        private async void ExecuteGenerateMealCommand(object obj)
        {
            IsLoading = true; 
            Meal = _mapper.Map(
                await _mealService.GetRandomMealAsync(new MealGoalsDto { Calories = GoalCalories, Protides = GoalProtides, Lipides = GoalLipides, Glucides = GoalGlucides }, AlimentCount),
                _kernel.Get<IMealViewModel>());
            IsLoading = false;
        }
    }
}
