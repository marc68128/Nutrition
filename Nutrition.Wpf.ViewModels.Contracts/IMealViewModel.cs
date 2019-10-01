using System.Collections.Generic;

namespace Nutrition.Wpf.ViewModels.Contracts
{
    public interface IMealViewModel : IBaseViewModel
    {
        List<IMealPartViewModel> MealParts { get; set; }
        double TotalCalories { get; }
        double TotalProtides { get; }
        double TotalLipides { get; }
        double TotalGlucides { get; }
        double Accuracy { get; }
    }
}
