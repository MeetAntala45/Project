using System;

class Program
{
    static void Main()
    {
        int age;
        string name;

        Console.Write("Enter your name: ");
        name = Console.ReadLine();

        Console.Write("Enter your age: ");
        age = Convert.ToInt32(Console.ReadLine());

        if (age <= 0)
        {
            Console.WriteLine("Invalid age entered.");
        }
        else
        {
            Console.WriteLine("Valid age.");
        }

        PrintDetails(name, age);

        Console.WriteLine("\nNumbers from 1 to 5:");
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine(i);
        }
    }

    static void PrintDetails(string userName, int userAge)
    {
        Console.WriteLine("\nUser Details:");
        Console.WriteLine("Name: " + userName);
        Console.WriteLine("Age: " + userAge);
    }
}
