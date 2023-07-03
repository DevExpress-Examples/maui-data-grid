using System.Globalization;

namespace GridExport {
    public class InverseBoolConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !(bool)value;
    }
    public class EnumToItemsSource : IMarkupExtension {
        public Type EnumType { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider) {
            return Enum.GetValues(EnumType);
        }
    }
}