using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeCalculator.InterviewProblems;

public class LinearListSearch : ISearchable
{
    private readonly List<int> list = new();

    public bool Search(int value)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] == value)
                return true;
        }
        return false;
    }

    public void Seed(int count, int maxValue)
    {
        list.Clear();
        var rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            list.Add(rnd.Next(maxValue));
        }
    }
}
