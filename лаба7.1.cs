using System;
using System.Collections.Generic;
using System.Linq;

class CompetitionProtocol
{
    private List<(string, string, double, double, bool)> competitionResults;

    public CompetitionProtocol(List<(string, string, double, double, bool)> results)
    {
        competitionResults = results;
    }

    public void GenerateProtocol()
    {
        var disqualifiedResults = competitionResults.Where(r => !r.Item5).ToList();

        var sortedResults = disqualifiedResults
            .Select(r => (r.Item1, r.Item2, r.Item3 + r.Item4))
            .OrderByDescending(r => r.Item3)
            .ToList();

        Console.WriteLine("Место\tФамилия\t\tОбщество\tРезультат");

        for (int i = 0; i < sortedResults.Count; i++)
        {
            var result = sortedResults[i];
            Console.WriteLine($"{i + 1}\t{result.Item1,-10}\t{result.Item2,-10}\t{result.Item3}");
        }
    }

    public void DisqualifyParticipant(string lastName)
    {
        var participant = competitionResults.FirstOrDefault(r => r.Item1.Equals(lastName, StringComparison.OrdinalIgnoreCase));
        if (participant != default)
        {
            var index = competitionResults.IndexOf(participant);
            competitionResults[index] = (participant.Item1, participant.Item2, participant.Item3, participant.Item4, true);
            Console.WriteLine($"Участник {lastName} дисквалифицирован.");
        }
        else
        {
            Console.WriteLine($"Участник {lastName} не найден.");
        }
    }
}

class JumpCompetition
{
    static void Main()
    {
        var competitionResults = new List<(string, string, double, double, bool)>
        {
            ("Иванов", "Клуб 1", 5.6, 5.8, false),
            ("Петров", "Клуб 2", 5.9, 5.7, false),
            ("Сидоров", "Клуб 1", 5.5, 5.6, false),
            ("Алексеев", "Клуб 2", 6.1, 6.2, false),
            ("Смирнов", "Клуб 1", 5.7, 5.9, false)
        };

        var protocol = new CompetitionProtocol(competitionResults);
        protocol.GenerateProtocol();

        protocol.DisqualifyParticipant("Петров");
        
        protocol.GenerateProtocol();
    }
}
