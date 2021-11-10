﻿namespace AD.BaseTypes.Tests;

[Double] public partial record MyDouble;

[TestClass]
public class DoubleTest : BaseTypeTest<MyDouble, double>
{
    protected override DoubleArbitrary<MyDouble> Arbitrary => new();

    protected override bool JsonFilter(double value) => double.IsFinite(value);
}
