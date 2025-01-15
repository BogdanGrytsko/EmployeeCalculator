using CsvHelper.Configuration;

namespace EmployeeCalcucatorTest.ChatGpt;

public class UserAnswerMap : ClassMap<UserAnswer>
{
    public UserAnswerMap()
    {
        Map(m => m.Timestamp);
        Map(m => m.CompanyName);
        Map(m => m.Q1);
        Map(m => m.Q2);
        Map(m => m.Q3);
        Map(m => m.Q4);
        Map(m => m.Q5);
        Map(m => m.Q6);
        Map(m => m.Q7);
        Map(m => m.Q8);
        Map(m => m.Q9);
        Map(m => m.Q10);
        Map(m => m.Q11);
        Map(m => m.RowId).Optional();
    }
}
