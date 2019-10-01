using System.Collections.Generic;
using System.Windows.Input;

namespace Nutrition.Wpf.ViewModels.Contracts
{
    public interface IHomeViewModel : IBaseViewModel
    {
        List<IAlimentViewModel> Aliments { get; set; }

        IMealViewModel Meal { get; set; }

        double GoalCalories { get; set; }
        double GoalProtides { get; set; }
        double GoalLipides { get; set; }
        double GoalGlucides { get; set; }
        int AlimentCount { get; set; }

        bool IsLoading { get; set; }

        ICommand GenerateMealCommand { get; }
    }
}
