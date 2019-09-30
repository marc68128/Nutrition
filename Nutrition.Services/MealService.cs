using System;
using System.Collections.Generic;
using System.Text;
using Nutrition.Dtos;
using Nutrition.Repositories.Contracts;
using Nutrition.Services.Contracts;

namespace Nutrition.Services
{
    public class MealService : IMealService
    {
        private readonly IAlimentService _alimentService;
        private readonly Random _random; 

        public MealService(IAlimentService alimentService)
        {
            _alimentService = alimentService;
            _random = new Random();
        }

        public MealDto GetRandomMeal(MealGoalsDto goals, int alimentCount)
        {
            MealDto meal;

            var aliments = _alimentService.GetAll();

            do
            {
                meal = new MealDto();

                for (int i = 0; i < alimentCount; i++)
                {
                    meal.MealParts.Add(new MealPartDto
                    {
                        Aliment = aliments[_random.Next(0, aliments.Count -1)]
                    });
                }

                meal = ComputeBestQuantities(meal, goals);
            } while (!MatchGoals(meal));
            

            return meal;
        }

        private MealDto ComputeBestQuantities(MealDto meal, MealGoalsDto goals)
        {
            throw new NotImplementedException();
        }

        private bool MatchGoals(MealDto meal)
        {
            return true;
        }
    }
}
