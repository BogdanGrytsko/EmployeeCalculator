using Employee.Data;
using EmployeeCalculator;

var context = ContextBuilder.GetContext();
var manager = new EmployeeManager();
manager.ReadFromDatabase(context);
//manager.ReadFromDisk("SomeData.csv");
//await manager.SaveToDatabase(context);

var yearlySumBytes = manager.GetYearlySumFile();
File.WriteAllBytes("Output.csv", yearlySumBytes);

var topEarners = manager.TopN(5);
File.WriteAllBytes("TopEarners.csv", topEarners);
var bottomEarners = manager.BottomN(5);
File.WriteAllBytes("BottomEarners.csv", bottomEarners);