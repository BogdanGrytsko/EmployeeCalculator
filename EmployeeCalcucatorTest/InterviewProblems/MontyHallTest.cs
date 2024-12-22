using EmployeeCalculator.InterviewProblems;
using Xunit.Abstractions;

namespace EmployeeCalcucatorTest.InterviewProblems;

public class MontyHallTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public MontyHallTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void RunTest()
    {
        var numberOfTries = 10000;
        (int wins, int losses) = MontyHallProblem.Simultate(numberOfTries);
        testOutputHelper.WriteLine($"Wins: {wins}, Losses: {losses}, Win ratio: {(double)wins / numberOfTries}");
    }
}
