using EmployeeCalculator;

var manager = new EmployeeManager();
manager.ReadFromDisk("SomeData.csv");
var yearlySumBytes = manager.GetYearlySumFile();
File.WriteAllBytes("Output.csv", yearlySumBytes);

var topEarners = manager.TopN(5);
File.WriteAllBytes("TopEarners.csv", topEarners);
var bottomEarners = manager.BottomN(5);
File.WriteAllBytes("BottomEarners.csv", bottomEarners);