using System;
using System.Collections.Generic;
using System.Linq;

class RadioSurvey
{
    static void Main()
    {
        List<List<string>> responses = new List<List<string>>
        {
            new List<string> { "Кошка", "Собака", "Кошка", "Рыба" }, 
            new List<string> { "Дружелюбие", "Упорство", "Трудолюбие", "Скромность" }, 
            new List<string> { "Сакура", "Самурай", "Суши", "Саке", "Сумо" } 
        };

        var topAnswers = new List<List<string>>();
        foreach (var questionResponses in responses)
        {
            if (questionResponses.Count == 0)
            {
                topAnswers.Add(new List<string> { "" });
                continue;
            }

            var groupedAnswers = questionResponses.GroupBy(answer => answer)
                                                  .OrderByDescending(group => group.Count())
                                                  .Select(group => group.Key)
                                                  .Take(5)
                                                  .ToList();
            topAnswers.Add(groupedAnswers);
        }

        Console.WriteLine("Ответы на вопрос а):");
        PrintTopAnswers(topAnswers[0]);
        Console.WriteLine("\nОтветы на вопрос б):");
        PrintTopAnswers(topAnswers[1]);
        Console.WriteLine("\nОтветы на вопрос в):");
        PrintTopAnswers(topAnswers[2]);
    }

    static void PrintTopAnswers(List<string> answers)
    {
        if (answers.Count == 0)
        {
            Console.WriteLine("Нет ответов.");
            return;
        }

        var totalCount = answers.Count;
        var answerCounts = answers.GroupBy(answer => answer)
                                  .ToDictionary(group => group.Key, group => group.Count());

        foreach (var answer in answers)
        {
            var percentage = (double)answerCounts[answer] / totalCount * 100;
            Console.WriteLine($"Ответ: {answer}, Доля: {percentage:F2}%");
        }
    }
}
