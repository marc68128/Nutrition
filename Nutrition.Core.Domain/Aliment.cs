using Nutrition.Core.Enums;

namespace Nutrition.Core.Domain
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
        public EnumUnit Unit { get; set; }
    }
}
