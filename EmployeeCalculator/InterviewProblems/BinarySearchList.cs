namespace EmployeeCalculator.InterviewProblems;

public class BinarySearchList : ISearchable
{
    private readonly List<int> list = new();
    private bool sorted = false;

    public bool Search(int value)
    {
        if (!sorted)
        {
            list.Sort();
            sorted = true;
            //O (N * Log(N))
        }
        var idx = list.BinarySearch(value);
        return idx >= 0;
    }

    public void Seed(int count, int maxValue)
    {
        list.Clear();
        sorted = false;
        var rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            list.Add(rnd.Next(maxValue));
        }
    }
}
