namespace ProjectEulerDotNet.Solvers;
public class Solver1 : ISolver
{
    public int GetSumLessThan(int top)
    {
        return Enumerable.Range(0, top)
            .Where(num => num % 3 == 0 || num % 5 == 0)
            .Sum();
    }

    public string Solve()
    {
        return GetSumLessThan(1000).ToString();
    }
}
