#pragma warning disable IDE0022 // Use expression body for method.

using AccessModifiersInCsharp;

namespace AnotherAssembly;

public class ExternalManager : Employee
{
    public override string GetEmployeeDetails()
    {
        // EmployeeId = 3;
        // Name = "David";
        // Salary = 80000;

        return $"ExternalManager Details: {base.GetEmployeeDetails()}";
    }
}
