using System;
using System.Collections.Generic;
using System.Text;
using Nutrition.ViewModels.Contracts;

namespace Nutrition.ViewModels
{
    internal class MealPartViewModel : IMealPartViewModel
    {
        public IAlimentViewModel Aliment { get; set; }
        public double Quantity { get; set; }
    }
}
