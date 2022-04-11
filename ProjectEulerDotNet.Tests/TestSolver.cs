using ProjectEulerDotNet.Solvers;
using Xunit;

namespace ProjectEulerDotNet.Tests;
public class TestSolver
{
    public virtual string CorrectAnswer { get; set; } = "";
    public ISolver Solver { get; set; }

    public TestSolver(ISolver? solver = null)
    {
        Solver = solver ?? new NullSolver();
    }

    [Fact]
    public void Solver_ShouldReturnCorrectAnswer()
    {
        var result = Solver.Solve();

        Assert.Equal(CorrectAnswer, result);
    }
}