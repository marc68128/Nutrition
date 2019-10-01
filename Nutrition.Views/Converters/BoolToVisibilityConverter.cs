using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Nutrition.Wpf.Views.Converters
{
    public class BoolToVisibilityConverter : MarkupExtension, IValueConverter, IDisposable
    {
        private static BoolToVisibilityConverter converter = null;

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolean && !boolean)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ??= new BoolToVisibilityConverter();
        }

        public void Dispose()
        {
            converter = null;
        }
    }
}
