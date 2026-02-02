using System;

abstract class Person
{
    public string Name { get; set; }
    public abstract void ShowRole();
}

interface IWork
{
    void DoWork();
}

class Employee : Person, IWork
{
    private int salary;
    public void SetSalary(int amount)
    {
        salary = amount;
    }

    public int GetSalary()
    {
        return salary;
    }

    public override void ShowRole()
    {
        Console.WriteLine("Role: Employee");
    }

    public void DoWork()
    {
        Console.WriteLine("Employee is working");
    }
}

class Program
{
    static void Main()
    {
        Employee emp = new Employee();

        emp.Name = "Meet";
        emp.SetSalary(50000);

        Console.WriteLine("Name: " + emp.Name);
        Console.WriteLine("Salary: " + emp.GetSalary());

        emp.ShowRole();
        emp.DoWork();
    }
}
