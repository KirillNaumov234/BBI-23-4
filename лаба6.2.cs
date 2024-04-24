using System;
using System.Collections.Generic;
using System.Linq;

class JumpCompetitionProtocol
{
    private List<JumpResult> competitionResults;

    public JumpCompetitionProtocol(List<JumpResult> results)
    {
        competitionResults = results;
    }

    public void GenerateProtocol()
    {
        var sortedResults = competitionResults
            .OrderByDescending(r => r.TotalScore)
            .ToList();

        Console.WriteLine("Место\tФамилия\t\tОбщество\tРезультат");

        for (int i = 0; i < sortedResults.Count; i++)
        {
            var result = sortedResults[i];
            Console.WriteLine($"{i + 1}\t{result.LastName,-10}\t{result.Club,-10}\t{result.TotalScore}");
        }
    }
}

class JumpResult
{
    public string LastName { get; }
    public string Club { get; }
    public double FirstAttempt { get; }
    public double SecondAttempt { get; }
    public double TotalScore => CalculateTotalScore();

    public JumpResult(string lastName, string club, double firstAttempt, double secondAttempt)
    {
        LastName = lastName;
        Club = club;
        FirstAttempt = firstAttempt;
        SecondAttempt = secondAttempt;
    }

    private double CalculateTotalScore()
    {
        double[] scores = { 5.0, 5.5, 6.0, 6.5 }; 
        double difficultyCoefficient = 3.0; 
        double totalScore = (FirstAttempt + SecondAttempt) * difficultyCoefficient;
        Array.Sort(scores);
        totalScore += scores[1] + scores[2] + scores[3]; 
        return totalScore;
    }
}

class DivingCompetitionProtocol : JumpCompetitionProtocol
{
    public DivingCompetitionProtocol(List<JumpResult> results) : base(results)
    {
    }

    public new void GenerateProtocol()
    {
    }
}

class JumpCompetition
{
    static void Main()
    {
        var competitionResults = new List<JumpResult>
        {
            new JumpResult("Иванов", "Клуб 1", 5.6, 5.8),
            new JumpResult("Петров", "Клуб 2", 5.9, 5.7),
            new JumpResult("Сидоров", "Клуб 1", 5.5, 5.6),
            new JumpResult("Алексеев", "Клуб 2", 6.1, 6.2),
            new JumpResult("Смирнов", "Клуб 1", 5.7, 5.9)
        };

        var protocol = new JumpCompetitionProtocol(competitionResults);
        protocol.GenerateProtocol();
    }
}
