namespace ProjectEulerDotNet.Solvers;
public class Solver2 : ISolver
{
    public IEnumerable<int> FibonacciSequenceUpTo(int top)
    {
        int currentFib = 1;
        int previousFib = 1;
        int secondPreviousFib = 0;

        while (currentFib <= top)
        {
            yield return currentFib;
            secondPreviousFib = previousFib;
            previousFib = currentFib;
            currentFib = previousFib + secondPreviousFib;
        }

        yield break;
    }

    public string Solve()
    {
        return FibonacciSequenceUpTo(4000000)
            .Where(num => num % 2 == 0)
            .Sum()
            .ToString();
    }
}
