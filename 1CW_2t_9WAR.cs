using System;
using System.Linq;

public abstract class Disciple
{
    public string Name { get; }
    public int Age { get; }
    public int[,] Grades { get; }
    public double AverageGrade { get; private set; }
    public bool IsRedDiploma { get; private set; }

    protected Disciple(string name, int age, int[,] grades)
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

    public abstract void PrintInfo();

    public static void PrintAllDisciples(Disciple[] disciples)
    {
        foreach (var disciple in disciples)
        {
            disciple.PrintInfo();
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
}

public class Pupil : Disciple
{
    public string Class { get; }
    public string Specialization { get; }

    public Pupil(string name, int age, int[,] grades, string classGrade, string specialization)
        : base(name, age, grades)
    {
        Class = classGrade;
        Specialization = specialization;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Class: {Class}, Specialization: {Specialization}, Average Grade: {AverageGrade:F2}, Red Diploma: {IsRedDiploma}");
    }
}

public class Student : Disciple
{
    public string Group { get; }
    public bool IsDebtor { get; private set; }
    public string StudentID { get; }

    public Student(string name, int age, int[,] grades, string group, string studentID)
        : base(name, age, grades)
    {
        Group = group;
        StudentID = studentID;
        IsDebtor = CheckIfDebtor(grades);
    }

    private static bool CheckIfDebtor(int[,] grades)
    {
        foreach (var grade in grades)
        {
            if (grade == 2)
                return true;
        }
        return false;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}, Group: {Group}, Student ID: {StudentID}, Average Grade: {AverageGrade:F2}, Red Diploma: {IsRedDiploma}, Debtor: {IsDebtor}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Pupil[] pupils = new Pupil[]
        {
            new Pupil("Ivanov", 16, new int[,] { { 5, 4, 5, 5, 4 }, { 4, 5, 5, 4, 4 }, { 4, 5, 5, 5, 5 } }, "10A", "Math"),
            new Pupil("Petrov", 17, new int[,] { { 4, 5, 5, 4, 4 }, { 3, 4, 5, 4, 4 }, { 5, 5, 5, 5, 5 } }, "11B", "Science"),
            new Pupil("Sidorov", 16, new int[,] { { 3, 4, 4, 3, 3 }, { 4, 4, 3, 4, 4 }, { 3, 4, 4, 4, 3 } }, "10C", "Literature"),
            new Pupil("Smirnov", 17, new int[,] { { 5, 5, 5, 5, 5 }, { 5, 5, 5, 5, 5 }, { 5, 5, 5, 5, 5 } }, "11A", "History"),
            new Pupil("Kuznetsov", 16, new int[,] { { 4, 4, 4, 4, 4 }, { 4, 4, 4, 4, 4 }, { 4, 4, 4, 4, 4 } }, "10B", "Geography")
        };

        Student[] students = new Student[]
        {
            new Student("Ivanova", 20, new int[,] { { 5, 4, 5, 5, 4 }, { 5, 5, 5, 4, 4 } }, "CS101", "12345"),
            new Student("Petrova", 21, new int[,] { { 4, 5, 5, 4, 4 }, { 4, 5, 4, 4, 4 } }, "CS102", "12346"),
            new Student("Sidorova", 22, new int[,] { { 3, 4, 4, 3, 2 }, { 4, 4, 3, 4, 4 } }, "CS103", "12347"),
            new Student("Smirnova", 20, new int[,] { { 5, 5, 5, 5, 5 }, { 5, 5, 5, 5, 5 } }, "CS104", "12348"),
            new Student("Kuznetsova", 21, new int[,] { { 4, 4, 4, 4, 4 }, { 4, 4, 4, 4, 4 } }, "CS105", "12349")
        };
        Array.Sort(pupils, (p1, p2) => p2.AverageGrade.CompareTo(p1.AverageGrade));
        Array.Sort(students, (s1, s2) => s2.AverageGrade.CompareTo(s1.AverageGrade));

        Console.WriteLine("All Pupils (sorted by average grade descending):");
        Disciple.PrintAllDisciples(pupils);

        Console.WriteLine("\nAll Students (sorted by average grade descending):");
        Disciple.PrintAllDisciples(students);

        Disciple[] allDisciples = pupils.Cast<Disciple>().Concat(students.Cast<Disciple>()).ToArray();
        var redDiplomaDisciples = allDisciples.Where(d => d.IsRedDiploma).ToArray();

        Console.WriteLine("\nAll Red Diploma Holders:");
        Disciple.PrintAllDisciples(redDiplomaDisciples);
    }
}
