using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Copilot.Sw.Converters;

public class InvertBoolToVisibilityConverter : IValueConverter
{
    public object Convert(
        object value,
        Type targetType,
        object parameter,
        CultureInfo culture)
    {
        return value is false