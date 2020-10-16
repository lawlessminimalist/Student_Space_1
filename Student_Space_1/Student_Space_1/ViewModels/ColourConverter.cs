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

        /*Converts String e.g. #34534 to value for correct data binding 
         * Helper Code to Convert Hex Strings to a format for Data Binding Colours
         */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && value is string && (string)value != "")
                return Color.FromHex(value.ToString());
            else
                return Color.Cyan; //Set Default Colour if no #value is specified 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
