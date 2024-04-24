using System;
using System.Collections.Generic;
using System.Linq;

class JumpCompetitionProtocol
{
    private List<(string lastName, string club, double firstAttempt, double secondAttempt)> competitionResults;

    public JumpCompetitionProtocol(List<(string, string, double, double)> results)
    {
        competitionResults = results;
    }

    public void GenerateProtocol()
    {
        var sortedResults = competitionResults
            .Select(r => (r.lastName, r.club, r.firstAttempt + r.secondAttempt))
            .OrderByDescending(r => r.Item3)
            .ToList();

        Console.WriteLine("Место\tФамилия\t\tОбщество\tРезультат");

        for (int i = 0; i < sortedResults.Count; i++)
        {
            var result = sortedResults[i];
            Console.WriteLine($"{i + 1}\t{result.lastName,-10}\t{result.club,-10}\t{result.Item3}");
        }
    }
}

class JumpCompetition
{
    static void Main()
    {
        var competitionResults = new List<(string, string, double, double)>
        {
            ("Иванов", "Клуб 1", 5.6, 5.8),
            ("Петров", "Клуб 2", 5.9, 5.7),
            ("Сидоров", "Клуб 1", 5.5, 5.6),
            ("Алексеев", "Клуб 2", 6.1, 6.2),
            ("Смирнов", "Клуб 1", 5.7, 5.9)
        };

        var protocol = new JumpCompetitionProtocol(competitionResults);
        protocol.GenerateProtocol();
    }
}
