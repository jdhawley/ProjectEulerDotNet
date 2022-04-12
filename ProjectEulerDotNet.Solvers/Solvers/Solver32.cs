namespace ProjectEulerDotNet.Solvers;
public class Solver32 : ISolver
{
    public bool IsPandigital(string number, int n = 9)
    {
        if (number.Length != n)
            return false;

        var isPandigital = true;
        for (int i = 1; i <= n; i++)
        {
            var numberChar = char.Parse(i.ToString());
            if (number.Count(c => c == numberChar) != 1)
                isPandigital = false;
        }
        return isPandigital;
    }

    public bool IsFactorPandigital(int number, int n = 9)
    {
        int ceiling = (int)Math.Sqrt(number);
        for (int i = 1; i <= ceiling; i++)
        {
            if (number % i == 0)
            {
                string combinedNumbers = $"{number}{i}{number/i}";
                if (IsPandigital(combinedNumbers, n))
                    return true;
            }
        }
        return false;
    }

    public string Solve()
    {
        var sum = 0;
        for (int i = 1; i < 10000; i++)
        {
            if (IsFactorPandigital(i, 9))
                sum += i;
        }
        return sum.ToString();
    }
}