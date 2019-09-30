using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition.ViewModels.Contracts
{
    public interface IMealViewModel : IBaseViewModel
    {
        List<IMealPartViewModel> MealParts { get; set; }
        double TotalCalories { get; }
        double TotalProtides { get;}
        double TotalLipides { get; }
        double TotalGlucides { get; }
        double Accuracy { get; }
    }
}
