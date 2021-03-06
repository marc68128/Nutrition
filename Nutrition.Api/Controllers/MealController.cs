﻿using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nutrition.Api.ViewModels;
using Nutrition.Core.Dtos;
using Nutrition.Core.Services.Contracts;

namespace Nutrition.Api.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [ApiController]
    [Route("[controller]")]
    public class MealController : ControllerBase
    {
        private readonly ILogger<MealController> _logger;
        private readonly IMapper _mapper;
        private readonly IMealService _mealService;

        public MealController(ILogger<MealController> logger, IMapper mapper, IMealService mealService)
        {
            _logger = logger;
            _mapper = mapper;
            _mealService = mealService;
        }

        [HttpGet] //meal?goalCalories=480&goalProtides=38&goalLipides=17&goalGlucides=45&alimentCount=4
        public MealViewModel Get(double goalCalories, double goalProtides, double goalLipides, double goalGlucides, int alimentCount)
        {
            var meal = _mealService.GetRandomMeal(
                new MealGoalsDto { Calories = goalCalories, Glucides = goalGlucides, Lipides = goalLipides, Protides = goalProtides },
                alimentCount);

            return _mapper.Map<MealViewModel>(meal);
        }
    }
}
