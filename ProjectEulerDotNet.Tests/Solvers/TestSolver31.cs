using ProjectEulerDotNet.Solvers;
using Xunit;

namespace ProjectEulerDotNet.Tests;
public class TestSolver31 : TestSolver
{
    public override string CorrectAnswer { get; set; } = "73682";

    public TestSolver31()
        : base(new Solver31())
    { }

    [Fact]
    public void CombinationTotal_ShouldReturnCorrectTotal_ForAnyCoinCombination()
    {
        var solver = new Solver31();
        var coinCombination = new CoinCombination(8, 7, 6, 5, 4, 3, 2, 1);

        var result = solver.CombinationTotal(coinCombination);

        Assert.Equal(732, result);
    }

    [Fact]
    public void CombinationTotal_ShouldReturnCorrectTotal_WhenGivenMaxCoin()
    {
        var solver = new Solver31();
        var coinCombination = new CoinCombination(8, 7, 6, 5, 4, 3, 2, 1);

        var result = solver.CombinationTotal(coinCombination, 50);

        Assert.Equal(332, result);
    }

    [Theory]
    [InlineData(1, 0, 0, 0, 0, 0, 0, 0, 1)]
    [InlineData(1, 0, 0, 1, 0, 0, 0, 0, 10)]
    [InlineData(1, 0, 0, 0, 10, 1, 0, 0, 50)]
    public void BiggestCoin_ShouldReturnBiggestCoin_GivenAnyCoinCombination(int p1, int p2, int p5, int p10, int p20, int p50, int p100, int p200, int expectedCoin)
    {
        var solver = new Solver31();
        var coinCombination = new CoinCombination(p1, p2, p5, p10, p20, p50, p100, p200);

        var result = solver.BiggestCoin(coinCombination);

        Assert.Equal(expectedCoin, result);
    }

    [Theory]
    [InlineData(2, 0, 0, 0, 0, 0, 0, 0,   0, 1, 0, 0, 0, 0, 0, 0)]
    [InlineData(1, 2, 0, 0, 0, 0, 0, 0,   0, 0, 1, 0, 0, 0, 0, 0)]
    [InlineData(0, 0, 2, 0, 0, 0, 0, 0,   0, 0, 0, 1, 0, 0, 0, 0)]
    [InlineData(0, 0, 0, 2, 0, 0, 0, 0,   0, 0, 0, 0, 1, 0, 0, 0)]
    [InlineData(0, 0, 0, 1, 2, 0, 0, 0,   0, 0, 0, 0, 0, 1, 0, 0)]
    [InlineData(0, 0, 0, 0, 0, 2, 0, 0,   0, 0, 0, 0, 0, 0, 1, 0)]
    [InlineData(0, 0, 0, 0, 0, 0, 2, 0,   0, 0, 0, 0, 0, 0, 0, 1)]
    public void CombineSmallest_ShouldProperlyCombine_WhenGivenEvenCombinations(
        int p1, int p2, int p5, int p10, int p20, int p50, int p100, int p200,
        int exp1, int exp2, int exp5, int exp10, int exp20, int exp50, int exp100, int exp200)
    {
        var solver = new Solver31();
        var coinCombination = new CoinCombination(p1, p2, p5, p10, p20, p50, p100, p200);

        var result = solver.CombineSmallest(coinCombination);

        Assert.Equal(exp1, result.p1);
        Assert.Equal(exp2, result.p2);
        Assert.Equal(exp5, result.p5);
        Assert.Equal(exp10, result.p10);
        Assert.Equal(exp20, result.p20);
        Assert.Equal(exp50, result.p50);
        Assert.Equal(exp100, result.p100);
        Assert.Equal(exp200, result.p200);
    }

    [Theory]
    [InlineData(1, 2, 1, 0, 0, 0, 0, 0,   0, 0, 2, 0, 0, 0, 0, 0)]
    [InlineData(0, 0, 2, 1, 0, 0, 0, 0,   0, 0, 0, 2, 0, 0, 0, 0)]
    [InlineData(0, 0, 0, 2, 1, 0, 0, 0,   0, 0, 0, 0, 2, 0, 0, 0)]
    [InlineData(0, 0, 0, 1, 2, 1, 0, 0,   0, 0, 0, 0, 0, 2, 0, 0)]
    [InlineData(0, 0, 0, 0, 0, 2, 1, 0,   0, 0, 0, 0, 0, 0, 2, 0)]
    [InlineData(0, 0, 0, 0, 0, 0, 2, 1,   0, 0, 0, 0, 0, 0, 0, 2)]
    public void CombineSmallest_ShouldProperlyCombine_WhenGivenUnevenCombinations(
        int p1, int p2, int p5, int p10, int p20, int p50, int p100, int p200,
        int exp1, int exp2, int exp5, int exp10, int exp20, int exp50, int exp100, int exp200)
    {
        var solver = new Solver31();
        var coinCombination = new CoinCombination(p1, p2, p5, p10, p20, p50, p100, p200);

        var result = solver.CombineSmallest(coinCombination);

        Assert.Equal(exp1, result.p1);
        Assert.Equal(exp2, result.p2);
        Assert.Equal(exp5, result.p5);
        Assert.Equal(exp10, result.p10);
        Assert.Equal(exp20, result.p20);
        Assert.Equal(exp50, result.p50);
        Assert.Equal(exp100, result.p100);
        Assert.Equal(exp200, result.p200);
    }

    [Theory]
    [InlineData(2, 2)]
    [InlineData(3, 2)]
    [InlineData(10, 11)]
    [InlineData(11, 12)]
    [InlineData(12, 15)]
    [InlineData(13, 16)]
    [InlineData(14, 19)]
    [InlineData(15, 22)]
    [InlineData(20, 41)]
    public void CoinCombinationsFor_ShouldReturnCorrectCombinations_GivenValidCoinAmount(int amount, int expectedCombinations)
    {
        var solver = new Solver31();

        var result = solver.CoinCombinationsFor(amount);

        Assert.Equal(expectedCombinations, result);
    }
}