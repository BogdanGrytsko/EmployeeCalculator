namespace EmployeeCalculator.InterviewProblems;

public class BinaryListSearch : ISearchable
{
    private readonly List<int> list = new();

    public bool Search(int value)
    {
        var idx = list.BinarySearch(value);
        return idx >= 0;
    }

    public void Seed(int count, int maxValue)
    {
        list.Clear();
        var rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            list.Add(rnd.Next(maxValue));
        }
        //O (N * Log(N))
        list.Sort();
    }
}
