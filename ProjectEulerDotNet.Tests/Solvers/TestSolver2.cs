using System.Linq;
using ProjectEulerDotNet.Solvers;
using Xunit;

namespace ProjectEulerDotNet.Tests;

public class TestSolver2
{
    [Fact]
    public void Solver_ShouldReturnCorrectAnswer()
    {
        var solver = new Solver2();

        var result = solver.Solve();

        Assert.Equal("4613732", result);
    }

    [Fact]
    public void FibonacciSequenceUpTo_ShouldReturn11_WhenGiven5()
    {
        var solver = new Solver2();

        var result = solver.FibonacciSequenceUpTo(5)
            .Sum();

        Assert.Equal(11, result);
    }
}