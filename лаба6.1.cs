using System;
using System.Collections.Generic;
using System.Linq;

class Participant
{
    public string LastName { get; }
    public string Club { get; }
    public double FirstAttempt { get; }
    public double SecondAttempt { get; }

    public Participant(string lastName, string club, double firstAttempt, double secondAttempt)
    {
        LastName = lastName;
        Club = club;
        FirstAttempt = firstAttempt;
        SecondAttempt = secondAttempt;
    }

    public double GetTotalResult()
    {
        return FirstAttempt + SecondAttempt;
    }

    public override string ToString()
    {
        return $"{LastName,-10}\t{Club,-10}\t{GetTotalResult()}";
    }
}

class JumpCompetitionProtocol
{
    private List<Participant> competitionResults;

    public JumpCompetitionProtocol(List<Participant> results)
    {
        competitionResults = results;
    }

    public void GenerateProtocol()
    {
        var sortedResults = competitionResults
            .OrderByDescending(r => r.GetTotalResult())
            .ToList();

        Console.WriteLine("Место\tФамилия\t\tОбщество\tРезультат");

        for (int i = 0; i < sortedResults.Count; i++)
        {
            var result = sortedResults[i];
            Console.WriteLine($"{i + 1}\t{result}");
        }
    }
}

// Пример использования

class Program
{
    static void Main()
    {
        var participants = new List<Participant>
        {
            new Participant("Иванов", "Клуб1", 10.5, 11.2),
            new Participant("Петров", "Клуб2", 10.2, 11.5),
            new Participant("Сидоров", "Клуб1", 9.8, 10.0)
        };

        var protocol = new JumpCompetitionProtocol(participants);
        protocol.GenerateProtocol();
    }
}
