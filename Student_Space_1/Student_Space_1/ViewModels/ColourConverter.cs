using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Xamarin.Forms;

namespace Student_Space_1.ViewModels
{
    class ColourConverter : IValueConverter
    {
        //Code Reference: https://stackoverflow.com/questions/43469569/binding-color-in-xamarin-listview

        /*Converts String e.g. #34534 to hex value for correct data binding 
         * 
         */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string && (string)value != "")
                return Color.FromHex(value.ToString());
            else
                return Color.Cyan; //Set Default Colour
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
