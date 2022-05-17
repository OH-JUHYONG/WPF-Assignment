using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WeatherApp.ViewModel.Converters
{
    class HumidityToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int humidityValue = (int)value;
            if(humidityValue < 40)
            {
                return "습도: 낮음(" + humidityValue.ToString() + ")";
            }
            else if (humidityValue > 70)
            {
                return "습도: 높음(" + humidityValue.ToString() + ")";
            }
            else
            {
                return "습도: 보통(" + humidityValue.ToString() + ")";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return 0;
        }
    }
}
