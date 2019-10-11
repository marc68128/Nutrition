using Nutrition.Core.Dtos;
using System.Threading.Tasks;

namespace Nutrition.Core.Services.Contracts
{
    public interface IMealService
    {
        MealDto GetRandomMeal(MealGoalsDto goals, int alimentCount);
        Task<MealDto> GetRandomMealAsync(MealGoalsDto goals, int alimentCount);
    }
}
