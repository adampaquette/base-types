﻿using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("AD.BaseTypes.Benchmarks")]

namespace AD.BaseTypes;

static class StringValidation
{
    public static void MinLength(int minLength, string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value.Length < minLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must be at least {minLength} character(s) long.");
    }

    public static void MaxLength(int maxLength, string value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value.Length > maxLength) throw new ArgumentOutOfRangeException(nameof(value), value, $"Parameter must not be no longer than {maxLength} character(s).");
    }
}
