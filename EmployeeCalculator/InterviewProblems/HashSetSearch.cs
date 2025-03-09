namespace EmployeeCalculator.InterviewProblems;

public class HashSetSearch : ISearchable
{
    private readonly HashSet<int> hashset = new();

    public bool Search(int value)
    {
        return hashset.Contains(value);
    }

    public void Seed(int count, int maxValue)
    {
        hashset.Clear();
        var rnd = new Random();
        for (int i = 0; i < count; i++)
        {
            hashset.Add(rnd.Next(maxValue));
        }
    }
}
