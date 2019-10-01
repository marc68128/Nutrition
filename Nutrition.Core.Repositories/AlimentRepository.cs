using CsvHelper;
using CsvHelper.TypeConversion;
using Nutrition.Core.Domain;
using Nutrition.Core.Enums;
using Nutrition.Core.Repositories.Contracts;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Nutrition.Core.Repositories
{
    internal class AlimentRepository : IAlimentRepository
    {
        private const string AlimentDbPath = @"Data\Aliments.csv";

        public List<Aliment> GetAll()
        {
            using (var reader = new StreamReader(AlimentDbPath))
            using (var csv = new CsvReader(reader))
            {
                var doubleOptions = new TypeConverterOptions
                {
                    CultureInfo = new CultureInfo("fr-FR"),
                    NumberStyle = NumberStyles.Number
                };
                csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(double), doubleOptions);
                return csv.GetRecords<Aliment>().ToList();
            }
        }

        public List<Aliment> GetByCategory(EnumAlimentCategory category)
        {
            return GetAll().Where(a => a.Category == category).ToList();
        }
    }
}
