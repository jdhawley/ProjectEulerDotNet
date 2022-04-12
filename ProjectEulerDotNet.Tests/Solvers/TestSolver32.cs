using System;
using System.Linq;
using ProjectEulerDotNet.Solvers;
using Xunit;

namespace ProjectEulerDotNet.Tests;
public class TestSolver32 : TestSolver
{
    public override string CorrectAnswer { get; set; } = "45228";

    public TestSolver32()
        : base(new Solver32())
    { }

    [Theory]
    [InlineData("15234", 5, true)]
    [InlineData("1234567", 7, true)]
    [InlineData("1234567000", 7, false)]
    [InlineData("1123", 3, false)]
    public void IsPandigital_ShouldCorrectlyEvaluatePandigitals_ForAllN(string number, int n, bool expectedPandigital)
    {
        var solver = new Solver32();

        var result = solver.IsPandigital(number, n);

        Assert.Equal(expectedPandigital, result);
    }

    [Theory]
    [InlineData(12, 4, true)]
    [InlineData(12, 5, false)]
    [InlineData(7254, 9, true)]
    [InlineData(7253, 9, false)]
    public void IsFactorPandigital_ShouldReturnCorrectFactorPandigitalStatus_GivenAnyNumber(int number, int n, bool expectedFactorPandigital)
    {
        var solver = new Solver32();

        var result = solver.IsFactorPandigital(number, n);

        Assert.Equal(expectedFactorPandigital, result);
    }
}