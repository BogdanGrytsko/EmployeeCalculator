using EmployeeCalculator.InterviewProblems;
using System.Collections.Generic;
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
        var listCounts = new List<int> { 100000, 200000, 400000, 1000000, 4000000, 8000000 };

        //var problem = new ComplexityInvestigation(maxVal);
        var problem = new BinarySearchList();
        int queryCount = 10000;
        foreach (var listCount in listCounts)
        {
            problem.Seed(listCount, maxVal);

            var rnd = new Random();
            var foundElements = 0;
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < queryCount; i++)
            {
                var found = problem.Search(rnd.Next(maxVal));
                if (found)
                    foundElements++;
            }
            testOutputHelper.WriteLine($"Found count: {foundElements}, List Count: {listCount}, Time : {sw.Elapsed}");
        }

        //linear complexity : O(listCount)

        //max val = 100 000
        //100 000 : 2.88
        //200 000 : 4
        //400 000 : 4.93

        //max val = 1000 000
        //Found count: 952, List Count: 100000, Time: 00:00:04.2915932
        //Found count: 1823, List Count: 200000, Time: 00:00:08.0808696
        //Found count: 3330, List Count: 400000, Time: 00:00:14.7376948

        //Binary search: O(Log(listCount))
        //Found count: 980, List Count: 100000, Time: 00:00:00.0071574
        //Found count: 1836, List Count: 200000, Time: 00:00:00.0138103
        //Found count: 3338, List Count: 400000, Time: 00:00:00.0306990
        //Found count: 6322, List Count: 1000000, Time : 00:00:00.0653641
        //Found count: 9831, List Count: 4000000, Time : 00:00:00.2851045
        //Found count: 9996, List Count: 8000000, Time : 00:00:00.5979863
    }
}
