using System;
using System.Collections.Generic;
using System.Linq;

public class Diver
{
    public string Name { get; set; }
    public double TotalScore { get; set; }

    public Diver(string name)
    {
        Name = name;
        TotalScore = 0;
    }
}

public class Competition
{
    private const int JudgesCount = 7;
    private const int JumpsCount = 4;
    private const int ScoreRange = 6;
    private const double MinDifficulty = 2.5;
    private const double MaxDifficulty = 3.5;

    private List<Diver> divers = new List<Diver>();

    public Competition()
    {
        divers.Add(new Diver("Витя"));
        divers.Add(new Diver("Марина"));
        divers.Add(new Diver("Андрейка"));
        divers.Add(new Diver("Марфа"));
    }

    public void EvaluateJump(int diverIndex, int difficulty, int score)
    {
        if (diverIndex < 0 || diverIndex >= divers.Count ||
            difficulty < MinDifficulty || difficulty > MaxDifficulty ||
            score < 1 || score > ScoreRange)
        {
            throw new ArgumentException("Некорректные данные.");
        }

        double jumpScore = (score - 1)  *  difficulty;

        divers[diverIndex].TotalScore += jumpScore;
    }

    public void PrintResults()
    {
        var orderedDivers = divers.OrderByDescending(d => d.TotalScore);

        for (int i = 0; i < orderedDivers.Count(); i++)
        {
            Console.WriteLine($"{i + 1}. Место: {orderedDivers.ElementAt(i).Name} - {orderedDivers.ElementAt(i).TotalScore}");
        }
    }
}

class Program
{
    static void Main()
    {
        Competition competition = new Competition();

        competition.EvaluateJump(0, 3, 6); 
        competition.EvaluateJump(1, 3, 6); 
        competition.EvaluateJump(2, 3, 6); 
        competition.EvaluateJump(3, 3, 6); 

        competition.PrintResults();
    }
}
