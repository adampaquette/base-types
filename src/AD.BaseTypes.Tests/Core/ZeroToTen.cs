﻿namespace AD.BaseTypes.Tests.Core
{
    //type for multiple tests

    [IntRange(Min, Max)]
    public partial record ZeroToTen
    {
        public const int Min = 0, Max = 10;
    }
}