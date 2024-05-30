using System;
using System.Collections.Generic;
using System.Linq;

class Country
{
    public string Name { get; set; }
    public Dictionary<string, int> Answers { get; private set; }
    private static int TotalAnswerCount = 0;

    public Country(string name)
    {
        Name = name;
        Answers = new Dictionary<string, int>();
    }

    public void AddAnswer(string answer)
    {
        if (Answers.ContainsKey(answer))
        {
            Answers[answer]++;
        }
        else
        {
            Answers[answer] = 1;
        }
        TotalAnswerCount++;
    }

    public double GetPercentage(string answer)
    {
        if (TotalAnswerCount == 0 || !Answers.ContainsKey(answer)) return 0;
        return (double)Answers[answer] / TotalAnswerCount * 100;
    }

    public static int GetTotalAnswerCount()
    {
        return TotalAnswerCount;
    }

    public void PrintTop5Answers()
    {
        var sortedAnswers = Answers.OrderByDescending(a => a.Value).Take(5);
        Console.WriteLine($"Топ-5 ответов для {Name}:");
        foreach (var answer in sortedAnswers)
        {
            double percentage = (double)answer.Value / Answers.Values.Sum() * 100;
            Console.WriteLine($"{answer.Key}: {percentage:F2}%");
        }
        Console.WriteLine();
    }
}

class Russia : Country
{
    public Russia() : base("Russia") { }
}

class Japan : Country
{
    public Japan() : base("Japan") { }
}

class Program
{
    static void Main()
    {
        Russia russia = new Russia();
        Japan japan = new Japan();

        List<string> russianAnswers = new List<string> { "Кошка", "Собака", "Кошка", "Рыба" };
        List<string> japaneseAnswers = new List<string> { "Сакура", "Самурай", "Суши", "Саке", "Сумо" };
        
        foreach (var answer in russianAnswers)
        {
            russia.AddAnswer(answer);
        }

        foreach (var answer in japaneseAnswers)
        {
            japan.AddAnswer(answer);
        }

        russia.PrintTop5Answers();
        japan.PrintTop5Answers();

        Dictionary<string, int> combinedAnswers = new Dictionary<string, int>();
        foreach (var answer in russia.Answers)
        {
            if (combinedAnswers.ContainsKey(answer.Key))
            {
                combinedAnswers[answer.Key] += answer.Value;
            }
            else
            {
                combinedAnswers[answer.Key] = answer.Value;
            }
        }
        foreach (var answer in japan.Answers)
        {
            if (combinedAnswers.ContainsKey(answer.Key))
            {
                combinedAnswers[answer.Key] += answer.Value;
            }
            else
            {
                combinedAnswers[answer.Key] = answer.Value;
            }
        }
        var sortedCombinedAnswers = combinedAnswers.OrderByDescending(a => a.Value).Take(5);
        Console.WriteLine("Топ-5 ответов для обеих стран вместе:");
        foreach (var answer in sortedCombinedAnswers)
        {
            double percentage = (double)answer.Value / Country.GetTotalAnswerCount() * 100;
            Console.WriteLine($"{answer.Key}: {percentage:F2}%");
        }
    }
}
