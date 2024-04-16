using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, int> answers = new Dictionary<string, int>();

        AddAnswer("собака", answers);
        AddAnswer("сакура", answers);
        AddAnswer("трудолюбие", answers);
        AddAnswer("технологии", answers);
        AddAnswer("собака", answers);
        AddAnswer("сакура", answers);
        AddAnswer("трудолюбие", answers);
        AddAnswer("технологии", answers);
        AddAnswer("сакура", answers);
        AddAnswer("трудолюбие", answers);
        
        var topFiveAnswers = GetTopFiveAnswers(answers);

        foreach (var answer in topFiveAnswers)
        {
            Console.WriteLine($"Ответ: {answer.Key}, Доля: {answer.Value}");
        }
    }

    static void AddAnswer(string answer, Dictionary<string, int> dictionary)
    {
        if (!dictionary.ContainsKey(answer))
        {
            dictionary[answer] = 1;
        }
        else
        {
            dictionary[answer]++;
        }
    }

    static List<KeyValuePair<string, double>> GetTopFiveAnswers(Dictionary<string, int> answers)
    {
        var sortedAnswers = answers.OrderByDescending(x => x.Value).ToList();
        return sortedAnswers.Take(5).Select(x => new KeyValuePair<string, double>(x.Key, x.Value / answers.Sum(y => y.Value))).ToList();
    }
}

