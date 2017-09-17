﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace TestDrive.Converters
{
    public class NegativoConverter : IValueConverter
    {
        
        public NegativoConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(Boolean)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return !(Boolean)value;
        }
    }
}
