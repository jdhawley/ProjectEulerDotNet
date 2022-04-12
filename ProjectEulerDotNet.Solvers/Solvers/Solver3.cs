using System.Collections.Generic;

namespace ProjectEulerDotNet.Solvers;
public class Solver3 : ISolver
{
    public IEnumerable<int> GetPrimeFactorsOf(long targetNumber)
    {
        List<int> primeFactors = new List<int>();

        if (targetNumber % 2 == 0)
            primeFactors.Add(2);

        for (var testNumber = 3; testNumber <= Math.Sqrt(targetNumber); testNumber += 2)
        {
            if (targetNumber % testNumber == 0 && IsPrime(testNumber))
                primeFactors.Add(testNumber);
        }

        return primeFactors;
    }

    public bool IsPrime(long targetNumber)
    {
        if (targetNumber == 1)
            return false;

        if (targetNumber == 2)
            return true;

        if (targetNumber % 2 == 0)
            return false;

        return GetPrimeFactorsOf(targetNumber).Count() == 0;
    }

    public string Solve()
    {
        return GetPrimeFactorsOf(600851475143).Last()
            .ToString();
    }
}