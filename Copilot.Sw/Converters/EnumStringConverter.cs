using System;
using System.Globalization;
using System.Windows.Data;

namespace Copilot.Sw.Converters;

public sealed class EnumStringConverter : IValueConverter
{
    public object? Convert(object value, Type targetType, objec