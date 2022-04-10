using ProjectEulerDotNet.Solvers;
using Xunit;

namespace ProjectEulerDotNet.Tests;

public class TestSolver1
{
    [Fact]
    public void GetSumLessThan_ShouldReturn23_WhenGiven10()
    {
        var solver = new Solver1();

        var result = solver.GetSumLessThan(10);

        Assert.Equal(23, result);
    }

    [Fact]
    public void Solver_ShouldReturnCorrectAnswer()
    {
        var solver = new Solver1();

        var result = solver.Solve();

        Assert.Equal("233168", result);
    }
}