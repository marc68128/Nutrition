using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nutrition.Dtos;
using Nutrition.Services.Contracts;

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

        [HttpGet]
        public async Task<MealDto> Get(double goalCalories, double goalProtides, double goalLipides, double goalGlucides, int alimentCount)
        {
            var meal = await _mealService.GetRandomMealAsync(
                new MealGoalsDto
                    {Calories = goalCalories, Glucides = goalGlucides, Lipides = goalLipides, Protides = goalProtides},
                alimentCount);
            return meal;
        }
    }
}
