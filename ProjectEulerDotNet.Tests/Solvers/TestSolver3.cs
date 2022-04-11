using System.Linq;
using ProjectEulerDotNet.Solvers;
using Xunit;

namespace ProjectEulerDotNet.Tests;
public class TestSolver3 : TestSolver
{
    public override string CorrectAnswer { get; set; } = "6857";

    public TestSolver3()
        : base(new Solver3())
    { }

    [Fact]
    public void GetPrimeFactorsOf_ShouldReturnPrimeFactors_WhenGiven13195()
    {
        var solver = new Solver3();

        var result = solver.GetPrimeFactorsOf(13195);

        Assert.Equal(4, result.Count());
        Assert.Contains(5, result);
        Assert.Contains(7, result);
        Assert.Contains(13, result);
        Assert.Contains(29, result);
    }

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(13, true)]
    [InlineData(29, true)]
    [InlineData(36, false)]
    [InlineData(47, true)]
    public void IsPrime_ShouldReturnCorrectPrimeStatus_GivenVariousNumbers(int testNumber, bool expectedPrime)
    {
        var solver = new Solver3();

        var result = solver.IsPrime(testNumber);

        Assert.Equal(expectedPrime, result);
    }
}