using System.Linq;
using ProjectEulerDotNet.Solvers;
using Xunit;

namespace ProjectEulerDotNet.Tests;

public class TestSolver2 : TestSolver
{
    public override string CorrectAnswer { get; set; } = "4613732";

    public TestSolver2() 
        : base(new Solver2()) 
    { }

    [Fact]
    public void FibonacciSequenceUpTo_ShouldReturn11_WhenGiven5()
    {
        var solver = new Solver2();

        var result = solver.FibonacciSequenceUpTo(5)
            .Sum();

        Assert.Equal(11, result);
    }
}