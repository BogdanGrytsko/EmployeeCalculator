using EmployeeCalculator.InterviewProblems;
using System.Diagnostics;
using Xunit.Abstractions;

namespace EmployeeCalcucatorTest.InterviewProblems;

public class ComplexityInvestigationTest
{
    private readonly ITestOutputHelper testOutputHelper;

    public ComplexityInvestigationTest(ITestOutputHelper testOutputHelper)
    {
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void RunComplexity()
    {
        var maxVal = 1000000;
        var problem = new ComplexityInvestigation(maxVal);
        int listCount = 100000, queryCount = 10000;
        problem.Seed(listCount);

        var rnd = new Random();
        var foundElements = 0;
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < queryCount; i++)
        {
            var found = problem.SearchLinear(rnd.Next(maxVal));
            if (found)
                foundElements++;
        }
        testOutputHelper.WriteLine($"Found count: {foundElements}, Time : {sw.Elapsed}");
        //linear complexity : O(queryCount * listCount)

        //max val = 100 000
        //100 000 : 2.88
        //200 000 : 4
        //400 000 : 4.93

        //max val = 1000 000
        //100 000 : 04.32
        //200 000 : 08.13
        //400 000 : 15.26
    }
}
