using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Nutrition.Dtos;

namespace Nutrition.Services.Contracts
{
    public interface IMealService
    {
        Task<MealDto> GetRandomMealAsync(MealGoalsDto goals, int alimentCount);
    }
}
