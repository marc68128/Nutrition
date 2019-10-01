using Nutrition.Enums;

namespace Nutrition.Api.ViewModels
{
    public class AlimentViewModel
    {
        public int Quantity { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Protides { get; set; }
        public double Lipides { get; set; }
        public double Glucides { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string Unit { get; set; }
    }
}
