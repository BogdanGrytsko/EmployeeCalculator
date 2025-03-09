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
        var maxVal = 10000000;
        var listCounts = new List<int> { 100000, 200000, 400000, 1000000, 4000000, 8000000 };
        //var listCounts = new List<int> { 100000, 200000 };

        //var problem = new ComplexityInvestigation(maxVal);
        var problems = new List<ISearchable>() { /*new LinearListSearch(),*/ new BinaryListSearch(), new HashSetSearch() };
        int queryCount = 10000;
        foreach (var problem in problems)
        {
            testOutputHelper.WriteLine($"Problem: {problem.GetType()}");
            foreach (var listCount in listCounts)
            {
                var sw = Stopwatch.StartNew();
                problem.Seed(listCount, maxVal);

                var rnd = new Random();
                var foundElements = 0;
                
                for (int i = 0; i < queryCount; i++)
                {
                    var found = problem.Search(rnd.Next(maxVal));
                    if (found)
                        foundElements++;
                }
                testOutputHelper.WriteLine($"Found count: {foundElements}, List Count: {listCount}, Time : {sw.Elapsed}");
            }
            //testOutputHelper.WriteLine(Environment.NewLine);
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

    //Problem: EmployeeCalculator.InterviewProblems.BinaryListSearch
    //Found count: 88, List Count: 100000, Time: 00:00:00.0084165
    //Found count: 209, List Count: 200000, Time: 00:00:00.0145713
    //Found count: 380, List Count: 400000, Time: 00:00:00.0290127
    //Found count: 981, List Count: 1000000, Time: 00:00:00.0746679
    //Found count: 3303, List Count: 4000000, Time: 00:00:00.3172178
    //Found count: 5566, List Count: 8000000, Time: 00:00:00.6533506

    //Problem: EmployeeCalculator.InterviewProblems.HashSetSearch
    //Found count: 92, List Count: 100000, Time: 00:00:00.0075271
    //Found count: 184, List Count: 200000, Time: 00:00:00.0079266
    //Found count: 371, List Count: 400000, Time: 00:00:00.0197586
    //Found count: 964, List Count: 1000000, Time: 00:00:00.0624115
    //Found count: 3318, List Count: 4000000, Time: 00:00:00.4736828
    //Found count: 5537, List Count: 8000000, Time: 00:00:00.6652996
    }
}
