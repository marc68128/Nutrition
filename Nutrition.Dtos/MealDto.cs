using System;
using System.Collections.Generic;
using System.Text;

namespace Nutrition.Dtos
{
    public class MealDto
    {
        public MealDto()
        {
            MealParts = new List<MealPartDto>();
        }
        public List<MealPartDto> MealParts { get; set; }
        public double Accuracy { get; set; }
    }

    public class MealPartDto
    {
        public AlimentDto Aliment { get; set; }
        public double Quantity { get; set; }
    }

    public class MealGoalsDto
    {
        public double Calories { get; set; }
        public double Protides { get; set; }
        public double Lipides { get; set; }
        public double Glucides { get; set; }
    }
}
