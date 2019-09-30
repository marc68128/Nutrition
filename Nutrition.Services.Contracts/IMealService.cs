using System;
using System.Collections.Generic;
using System.Text;
using Nutrition.Dtos;

namespace Nutrition.Services.Contracts
{
    public interface IMealService
    {
        MealDto GetRandomMeal(MealGoalsDto goals, int alimentCount);
    }
}
