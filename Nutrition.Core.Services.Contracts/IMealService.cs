using Nutrition.Core.Dtos;
using System.Threading.Tasks;

namespace Nutrition.Core.Services.Contracts
{
    public interface IMealService
    {
        Task<MealDto> GetRandomMealAsync(MealGoalsDto goals, int alimentCount);
    }
}
