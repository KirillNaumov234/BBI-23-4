using System;
using System.Collections.Generic;
using System.Linq;

class Country
{
    public virtual void ProcessResponses(List<List<string>> responses)
    {
        Console.WriteLine("Results for class: " + this.GetType().Name);
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
            Console.WriteLine($"Answer: {answer.Key}, Percentage: {percentage:F2}%");
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
            new List<string> { "Cat", "Dog", "Cat", "Fish" }, 
            new List<string> { "Friendliness", "Persistence", "Hard Work", "Modesty" }, 
            new List<string> { "Sakura", "Samurai", "Sushi", "Sake", "Sumo" } 
        };

        Russia russia = new Russia();
        russia.ProcessResponses(responses);

        Japan japan = new Japan();
        japan.ProcessResponses(responses);
    }
}
