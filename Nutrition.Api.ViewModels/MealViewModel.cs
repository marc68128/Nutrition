using System;
using System.Collections.Generic;
using System.Linq;

namespace Nutrition.Api.ViewModels
{
    public class MealViewModel 
    {
        private List<MealPartViewModel> _mealParts;

        public List<MealPartViewModel> MealParts
        {
            get => _mealParts;
            set
            {
                _mealParts = value;
                TotalCalories = value.Select(v => v.Aliment.Calories * v.Quantity).Sum();
                TotalProtides = value.Select(v => v.Aliment.Protides * v.Quantity).Sum();
                TotalLipides = value.Select(v => v.Aliment.Lipides * v.Quantity).Sum();
                TotalGlucides = value.Select(v => v.Aliment.Glucides * v.Quantity).Sum();
            }
        }
        public double Accuracy { get; set; }

        public double TotalCalories { get; private set; }
        public double TotalProtides { get; private set; }
        public double TotalLipides { get; private set; }
        public double TotalGlucides { get; private set; }
    }
}
