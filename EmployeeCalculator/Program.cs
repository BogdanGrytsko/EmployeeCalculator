using Employee.Data;
using EmployeeCalculator;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<EmployeeContext>()
                        .UseSqlServer("Server=.;Database=EmployeeDB;trusted_connection=true;TrustServerCertificate=True")
                        .Options;
var context = new EmployeeContext(options);
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