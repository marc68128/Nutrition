﻿using Nutrition.Enums;
using Nutrition.ViewModels.Contracts;

namespace Nutrition.ViewModels
{
    class AlimentViewModel : BaseViewModel, IAlimentViewModel
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protides { get; set; }
        public double Lipides { get; set; }
        public double Glucides { get; set; }
        public EnumAlimentCategory Category { get; set; }
        public string SubCategory { get; set; }
    }
}
