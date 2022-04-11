namespace ProjectEulerDotNet.Solvers;
public interface ISolver
{
    string Solve();
}

public class NullSolver : ISolver
{
    public string Solve()
    {
        return string.Empty;
    }
}