namespace EmployeeCalculator.InterviewProblems;

public interface ISearchable
{
    void Seed(int count, int maxValue);

    bool Search(int value);
}
