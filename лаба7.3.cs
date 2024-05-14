using System;
using System.Collections.Generic;
using System.Linq;

class Country
{
    public virtual void ProcessResponses(List<List<string>> responses)
    {
        Console.WriteLine("Результаты для страны: " + this.GetType().Name);
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
        Console.WriteLine("Результаты для России:");
        base.ProcessResponses(responses);
    }
}

class Japan : Country
{
    public override void ProcessResponses(List<List<string>> responses)
    {
        Console.WriteLine("Результаты для Японии:");
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
        var russia = new Russia();
        var japan = new Japan();

        List<Country> countries = new List<Country> { russia, japan };

        var survey = new InternationalSurvey(countries);

        // Пример ответов на опрос
        List<List<string>> responses = new List<List<string>>
        {
            new List<string> { "A", "B", "A" },
            new List<string> { "C", "A", "A", "B" },
            new List<string> { "A", "B" }
        };

        survey.ProcessInternationalResponses(responses);
    }
}

