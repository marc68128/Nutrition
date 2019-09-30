using CsvHelper.Configuration.Attributes;
using Nutrition.Enums;

namespace Nutrition.Domain
{
    public class Aliment
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protides { get; set; }
        public double Lipides { get; set; }
        public double Glucides { get; set; }
        public EnumAlimentCategory Category { get; set; }
        public string SubCategory { get; set; }
    }
}
