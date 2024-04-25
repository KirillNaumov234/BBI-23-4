using System;
using System.Collections.Generic;
using System.Linq;

class RadioSurvey
{
    class SurveyQuestion
    {
        public string Question { get; set; }
        public List<string> TopAnswers { get; set; }
    }

    static void Main()
    {
        List<List<string>> responses = new List<List<string>>
        {
            new List<string> { "Кошка", "Собака", "Кошка", "Рыба" },
            new List<string> { "Дружелюбие", "Упорство", "Трудолюбие", "Скромность" },
            new List<string> { "Сакура", "Самурай", "Суши", "Саке", "Сумо" }
        };

        var surveyQuestions = new List<SurveyQuestion>();
        for (int i = 0; i < responses.Count; i++)
        {
            var questionResponses = responses[i];

            if (questionResponses.Count == 0)
            {
                surveyQuestions.Add(new SurveyQuestion { Question = "", TopAnswers = new List<string>() });
                continue;
            }

            var groupedAnswers = questionResponses.GroupBy(answer => answer)
                .OrderByDescending(group => group.Count())
                .Select(group => group.Key)
                .Take(5)
                .ToList();

            surveyQuestions.Add(new SurveyQuestion { Question = $"Ответы на вопрос {char.ConvertFromUtf32('а' + i)}:", TopAnswers = groupedAnswers });
        }

        foreach (var question in surveyQuestions)
        {
            Console.WriteLine(question.Question);
            foreach (var answer in question.TopAnswers)
            {
                Console.WriteLine(answer);
            }
            Console.WriteLine();
        }
    }
}
