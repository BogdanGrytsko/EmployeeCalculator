using EmployeeCalculator;

var manager = new EmployeeManager();
manager.ReadFromDisk("SomeData.csv");
manager.ProcessFile(5);