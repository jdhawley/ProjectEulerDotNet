using System.Collections.Generic;
using System.Diagnostics;

namespace ProjectEulerDotNet.Solvers;
public class Solver31 : ISolver
{
    public int CombinationTotal(CoinCombination c, int maxCoin = 200)
    {
        int total = c.p1;
        if (maxCoin >= 2)
            total += 2*c.p2;
        if (maxCoin >= 5)
            total += 5*c.p5;
        if (maxCoin >= 10)
            total += 10*c.p10;
        if (maxCoin >= 20)
            total += 20*c.p20;
        if (maxCoin >= 50)
            total += 50*c.p50;
        if (maxCoin >= 100)
            total += 100*c.p100;
        if (maxCoin >= 200)
            total += 200*c.p200;
        return total;
    }

    public int BiggestCoin(CoinCombination c)
    { 
        if (c.p200 > 0)
            return 200;
        if (c.p100 > 0)
            return 100;
        if (c.p50 > 0)
            return 50;
        if (c.p20 > 0)
            return 20;
        if (c.p10 > 0)
            return 10;
        if (c.p5 > 0)
            return 5;
        if (c.p2 > 0)
            return 2;
        return 1;
    }

    public CoinCombination CombineSmallest(CoinCombination c)
    {
        var total = CombinationTotal(c);
        if (c.p1 >= 2)
            return new CoinCombination(c.p1 - 2, c.p2 + 1, c.p5, c.p10, c.p20, c.p50, c.p100, c.p200);
        if (CombinationTotal(c, 2) >= 5)
            return new CoinCombination(CombinationTotal(c, 2)-5, 0, c.p5+1, c.p10, c.p20, c.p50, c.p100, c.p200);
        if (CombinationTotal(c, 5) >= 10)
            return new CoinCombination(CombinationTotal(c, 5)-10, 0, 0, c.p10+1, c.p20, c.p50, c.p100, c.p200);
        if (CombinationTotal(c, 10) >= 20)
            return new CoinCombination(CombinationTotal(c, 10)-20, 0, 0, 0, c.p20+1, c.p50, c.p100, c.p200);
        if (CombinationTotal(c, 20) >= 50)
            return new CoinCombination(CombinationTotal(c, 20)-50, 0, 0, 0, 0, c.p50+1, c.p100, c.p200);
        if (CombinationTotal(c, 50) >= 100)
            return new CoinCombination(CombinationTotal(c, 50)-100, 0, 0, 0, 0, 0, c.p100+1, c.p200);
        if (CombinationTotal(c, 100) >= 200)
            return new CoinCombination(CombinationTotal(c, 100)-200, 0, 0, 0, 0, 0, 0, c.p200+1);

        return c;
    }

    public int CoinCombinationsFor(int amount)
    {
        var coinCombinations = new HashSet<CoinCombination>();
        var coinCombination = new CoinCombination(amount, 0, 0, 0, 0, 0, 0, 0);
        while (!coinCombinations.Contains(coinCombination))
        {
            coinCombinations.Add(coinCombination);
            coinCombination = CombineSmallest(coinCombination);
        }
        
        return coinCombinations.Count();
    }

    public string Solve()
    {
        return CoinCombinationsFor(200).ToString();
    }
}

public record CoinCombination(int p1, int p2, int p5, int p10, int p20, int p50, int p100, int p200);