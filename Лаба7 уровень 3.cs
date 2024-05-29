using System;
using System.Collections.Generic;

class Country
{
    public string Name { get; set; }
    public int AnswerCount { get; private set; }
    private static int TotalAnswerCount = 0;

    public Country(string name)
    {
        Name = name;
        AnswerCount = 0;
    }

    public void AddAnswer()
    {
        AnswerCount++;
        TotalAnswerCount++;
    }

    public double GetPercentage()
    {
        if (TotalAnswerCount == 0) return 0;
        return (double)AnswerCount / TotalAnswerCount * 100;
    }

    public static int GetTotalAnswerCount()
    {
        return TotalAnswerCount;
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
            russia.AddAnswer();
        }

        foreach (var answer in japaneseAnswers)
        {
            japan.AddAnswer();
        }

        Console.WriteLine($"Ответы для России: {russia.GetPercentage()}%");
        Console.WriteLine($"Ответы для Японии: {japan.GetPercentage()}%");
        Console.WriteLine($"Ответы для обеих стран вместе: {Country.GetTotalAnswerCount()}");
    }
}
