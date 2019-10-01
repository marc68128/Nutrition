using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nutrition.Wpf.Views.Converters
{
    public class MultiplicateConverter : MarkupExtension, IMultiValueConverter, IDisposable
    {
        private static MultiplicateConverter converter = null;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var res = values.Select(System.Convert.ToDouble).Aggregate((x1, x2) => x1 * x2);
            return res;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ??= new MultiplicateConverter();
        }

        public void Dispose()
        {
            converter = null;
        }

    }
}
