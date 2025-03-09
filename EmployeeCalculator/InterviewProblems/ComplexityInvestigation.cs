namespace EmployeeCalculator.InterviewProblems;

public class ComplexityInvestigation
{
    private readonly List<int> list = new();
    private readonly int maxListValue;

    public ComplexityInvestigation(int maxListValue)
    {
        this.maxListValue = maxListValue;
    }

    public bool SearchLinear(int number)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == number)
                return true;
        }
        return false;
    }

    public void Seed(int listCount)
    {
        list.Clear();
        var rnd = new Random();
        for (int i = 0; i < listCount; i++)
        {
            list.Add(rnd.Next(maxListValue));
        }
    }
}
