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
        foreach (var answerList in responses)
        {
            foreach (var answer in answerList)
            {
                if (answerCounts.ContainsKey(answer))
                {
                    answerCounts[answer]++;
                }
                else
                {
                    answerCounts[answer] = 1;
                }
            }
        }

        var totalResponses = responses.Sum(x => x.Count);

        var topAnswers = answerCounts.OrderByDescending(x => x.Value)
                                      .Take(5)
                                      .ToDictionary(pair => pair.Key, pair => ((double)pair.Value / totalResponses) * 100);

        foreach (var entry in topAnswers)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value:f2}%");
        }
    }
}

class Russia : Country
{
    public override void ProcessResponses(List<List<string>> responses)
    {
        Console.WriteLine("Results for Russia:");
        base.ProcessResponses(responses);
    }
}

class Japan : Country
{
    public override void ProcessResponses(List<List<string>> responses)
    {
        Console.WriteLine("Results for Japan:");
        base.ProcessResponses(responses);
    }
}

class InternationalSurvey
{
    public List<Country> Countries { get; set; }

    public InternationalSurvey(List<Country> countries)
    {
        Countries = countries;
    }

    public void ProcessInternationalResponses(List<List<string>> responses)
    {
        Console.WriteLine("International Results:");

        foreach (var country in Countries)
        {
            country.ProcessResponses(responses);
        }
    }
}

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
        Japan japan = new Japan();

        InternationalSurvey internationalSurvey = new InternationalSurvey(new List<Country> { russia, japan });
        internationalSurvey.ProcessInternationalResponses(responses);
    }
}
