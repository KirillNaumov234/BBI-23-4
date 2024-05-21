using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



public struct Disciple
{
    public string Name { get; }
    public int Age { get; }
    public int[,] Grades { get; }
    public double AverageGrade { get; private set; }
    public bool IsRedDiploma { get; private set; }

    public Disciple(string name, int age, int[,] grades)
    {
        Name = name;
        Age = age;
        Grades = grades;
        AverageGrade = CalculateAverageGrade(grades);
        IsRedDiploma = AverageGrade > 4.5;
    }

    private static double CalculateAverageGrade(int[,] grades)
    {
        int totalGrades = grades.GetLength(0) * grades.GetLength(1);
        int sum = 0;
        foreach (var grade in grades)
        {
            sum += grade;
        }
        return (double)sum / totalGrades;
    }

    public static void PrintAllDisciples(Disciple[] disciples)
    {
        foreach (var disciple in disciples)
        {
            Console.WriteLine($"Name: {disciple.Name}, Age: {disciple.Age}, Average Grade: {disciple.AverageGrade:F2}, Red Diploma: {disciple.IsRedDiploma}");
            Console.Write("Grades: ");
            for (int i = 0; i < disciple.Grades.GetLength(0); i++)
            {
                for (int j = 0; j < disciple.Grades.GetLength(1); j++)
                {
                    Console.Write($"{disciple.Grades[i, j]} ");
                }
                Console.WriteLine();
            }
        }
    }

    public static void PrintDiscipleInfo(Disciple disciple)
    {
        Console.WriteLine($"Name: {disciple.Name}");
        Console.WriteLine($"Age: {disciple.Age}");
        Console.WriteLine($"Average Grade: {disciple.AverageGrade:F2}");
        if (disciple.IsRedDiploma)
        {
            Console.WriteLine("Status: Red Diploma");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Disciple[] disciples = new Disciple[5]
        {
            new Disciple("Ivanov", 20, new int[,] { { 5, 4, 5, 5, 4 } }),
            new Disciple("Petrov", 21, new int[,] { { 4, 5, 5, 4, 4 } }),
            new Disciple("Sidorov", 22, new int[,] { { 3, 4, 4, 3, 3 } }),
            new Disciple("Smirnov", 20, new int[,] { { 5, 5, 5, 5, 5 } }),
            new Disciple("Kuznetsov", 21, new int[,] { { 4, 4, 4, 4, 4 } })
        };

        Array.Sort(disciples, (d1, d2) => d1.Name.CompareTo(d2.Name));

        Console.WriteLine("All Disciples:");
        Disciple.PrintAllDisciples(disciples);

        Console.WriteLine("\nDetails of Each Disciple:");
        foreach (var disciple in disciples)
        {
            Disciple.PrintDiscipleInfo(disciple);
            Console.WriteLine();
        }
    }
}

