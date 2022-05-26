using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WeatherApp.Model
{
    class TempColorTextBlock : TextBlock
    {     
        public string Temp
        {
            get { return (string)GetValue(TempProperty); }
            set { SetValue(TempProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TempProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TempProperty =
            DependencyProperty.Register("Temp", typeof(string), typeof(TempColorTextBlock), new PropertyMetadata(" ", OnIsTextBlockForegroundChanged));

        private static void OnIsTextBlockForegroundChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            TempColorTextBlock mytb = (TempColorTextBlock)source;

            //string s = Regex.Replace(mytb.Temp, @"\D", "");
            //int num_temp = Int32.Parse(s);

            //if (num_temp > 20)
            //{
            //    mytb.Foreground = System.Windows.Media.Brushes.Red;
            //}
            //else mytb.Foreground = System.Windows.Media.Brushes.Blue;

            string s = mytb.Temp.Substring(0, mytb.Temp.IndexOf(' '));
            double num_temp = double.Parse(s);

            if (num_temp > 20)
            {
                mytb.Foreground = System.Windows.Media.Brushes.Red;
            }
            else mytb.Foreground = System.Windows.Media.Brushes.Blue;

        }

    }
}
