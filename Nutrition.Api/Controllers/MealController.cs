using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nutrition.Dtos;
using Nutrition.Services.Contracts;
using System.Threading.Tasks;

namespace Nutrition.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        private readonly ILogger<MealController> _logger;
        private readonly IMealService _mealService;

        public MealController(ILogger<MealController> logger, IMealService mealService)
        {
            _logger = logger;
            _mealService = mealService;
        }

        [HttpGet] //meal?goalCalories=480&goalProtides=38&goalLipides=17&goalGlucides=45&alimentCount=4
        public async Task<MealDto> Get(double goalCalories, double goalProtides, double goalLipides, double goalGlucides, int alimentCount)
        {
            var meal = await _mealService.GetRandomMealAsync(
                new MealGoalsDto { Calories = goalCalories, Glucides = goalGlucides, Lipides = goalLipides, Protides = goalProtides },
                alimentCount);

            return meal;
        }
    }
}
