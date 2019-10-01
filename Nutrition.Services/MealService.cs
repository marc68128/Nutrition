using Nutrition.Dtos;
using Nutrition.Enums;
using Nutrition.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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

        public Task<MealDto> GetRandomMealAsync(MealGoalsDto goals, int alimentCount)
        {
            return Task.Factory.StartNew(() =>
            {
                MealDto meal;

                var aliments = _alimentService.GetAll();

                do
                {
                    meal = GenerateMealWithRandomAliments(alimentCount, aliments);
                    meal = ComputeBestQuantities(meal, goals);
                } while (!MatchGoals(meal));


                return meal;
            });
        }

        private MealDto GenerateMealWithRandomAliments(int alimentCount, List<AlimentDto> alimentList)
        {
            var meal = new MealDto();
            var category = EnumAlimentCategory.Protides;

            for (int i = 0; i < alimentCount; i++)
            {
                var filteredAliments = alimentList.Where(a => a.Category == category).ToList();
                meal.MealParts.Add(new MealPartDto
                {
                    Aliment = filteredAliments[_random.Next(0, filteredAliments.Count() - 1)]
                });

                switch (category)
                {
                    case EnumAlimentCategory.Protides:
                        category = EnumAlimentCategory.Glucides;
                        break;
                    case EnumAlimentCategory.Glucides:
                        category = EnumAlimentCategory.Lipides;
                        break;
                    case EnumAlimentCategory.Lipides:
                        category = EnumAlimentCategory.Vegetables;
                        break;
                    case EnumAlimentCategory.Vegetables:
                        category = EnumAlimentCategory.Protides;
                        break;
                }
            }

            return meal;
        }

        private MealDto ComputeBestQuantities(MealDto meal, MealGoalsDto goals)
        {
            var calories = meal.MealParts.Select(p => p.Aliment.Calories).ToList();
            var protides = meal.MealParts.Select(p => p.Aliment.Protides).ToList();
            var lipides = meal.MealParts.Select(p => p.Aliment.Lipides).ToList();
            var glucides = meal.MealParts.Select(p => p.Aliment.Glucides).ToList();


            var combos = GetAllPossibleCombos(meal.MealParts.Count);

            double minRes = double.MaxValue;
            List<double> bestValue = null;

            foreach (var combo in combos)
            {
                double ct = 0;
                double pt = 0;
                double lt = 0;
                double gt = 0;

                for (int i = 0; i < combo.Count; i++)
                {
                    ct += combo[i] * calories[i];
                    pt += combo[i] * protides[i];
                    lt += combo[i] * lipides[i];
                    gt += combo[i] * glucides[i];
                }

                var result = 100 * Math.Abs(ct - goals.Calories) / goals.Calories +
                             100 * Math.Abs(pt - goals.Protides) / goals.Protides +
                             100 * Math.Abs(lt - goals.Lipides) / goals.Lipides +
                             100 * Math.Abs(gt - goals.Glucides) / goals.Glucides;

                if (result < minRes)
                {
                    minRes = result;
                    bestValue = combo;
                }
            }

            for (int i = 0; i < meal.MealParts.Count; i++)
            {
                meal.MealParts[i].Quantity = bestValue[i];
            }

            meal.Accuracy = Math.Max(0, 100 - minRes);

            return meal;
        }

        private bool MatchGoals(MealDto meal)
        {
            Debug.WriteLine(meal.Accuracy);
            if (meal.MealParts.Any(m => m.Quantity == 0) || meal.Accuracy < 50)
            {
                return false;
            }
            return true;
        }


        public List<List<double>> GetAllPossibleCombos(int itemPerCombo)
        {
            double precision = 100d;
            double maxValue = 10d;

            while (Math.Pow(maxValue * precision, itemPerCombo) > 10000000)
            {
                precision -= 1;
                maxValue -= 0.05;
            }


            return GetAllPossibleCombos(Enumerable.Range(0, itemPerCombo).Select(x => Enumerable.Range(1, Convert.ToInt32(maxValue * precision) + 1).Select(v => v / precision)));
        }

        public List<List<double>> GetAllPossibleCombos(IEnumerable<IEnumerable<double>> lists)
        {
            IEnumerable<IEnumerable<double>> combos = new double[][] { new double[0] };

            foreach (var inner in lists)
                combos = from c in combos
                         from i in inner
                         select c.Append(i).ToList();

            return combos.Select(x => x.ToList()).ToList();
        }



    }

    public static class Ext
    {
        public static IEnumerable<TSource> Append<TSource>(
            this IEnumerable<TSource> source, TSource item)
        {
            foreach (TSource element in source)
                yield return element;

            yield return item;
        }
    }
}
