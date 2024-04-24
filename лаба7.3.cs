using System;
using System.Collections.Generic;
using System.Linq;

class Country
{
    public virtual void ProcessResponses(List<List<string>> responses)
    {
        Console.WriteLine("Результаты для класса: " + this.GetType().Name);
        PrintSurveyResults(responses);
    }

    protected void PrintSurveyResults(List<List<string>> responses)
    {
        var answerCounts = new Dictionary<string, int>();

        foreach (var questionResponses in responses)
        {
            foreach (var answer in questionResponses)
            {
                if (!answerCounts.ContainsKey(answer))
                {
                    answerCounts[answer] = 0;
                }
                answerCounts[answer]++;
            }
        }
        var topAnswers = answerCounts.OrderByDescending(kv => kv.Value)
                                     .Take(5);

        foreach (var answer in topAnswers)
        {
            double percentage = (double)answer.Value / responses.Sum(r => r.Count) * 100;
            Console.WriteLine($"Ответ: {answer.Key}, Доля: {percentage:F2}%");
        }
    }
}

class Russia : Country { }

class Japan : Country { }

class Program
{
    static void Main()
    {
        List<List<string>> responses = new List<List<string>>
        {
            new List<string> { "Кошка", "Собака", "Кошка", "Рыба" }, 
            new List<string> { "Дружелюбие", "Упорство", "Трудолюбие", "Скромность" }, 
            new List<string> { "Сакура", "Самурай", "Суши", "Саке", "Сумо" } 
        };

        Country russia = new Russia();
        Country japan = new Japan();

        russia.ProcessResponses(responses);
        japan.ProcessResponses(responses);

        CombineAndProcessResponses(russia, japan, responses);
    }

    static void CombineAndProcessResponses(params Country[] countries)
    {
        var combinedResponses = new List<List<string>>();

        foreach (var country in countries)
        {
            Country c = (Country)country;
            c.ProcessResponses(combinedResponses);
        }
    }
}
