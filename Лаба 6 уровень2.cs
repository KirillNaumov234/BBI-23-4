using System;
using System.Collections.Generic;
using System.Linq;

// Класс для представления дайвера
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

// Класс для управления соревнованиями
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
        // Добавляем дайверов
        divers.Add(new Diver("Alice"));
        divers.Add(new Diver("Bob"));
        divers.Add(new Diver("Charlie"));
        divers.Add(new Diver("David"));
    }

    public void EvaluateJump(int diverIndex, int difficulty, int score)
    {
        // Проверяем корректность входных данных
        if (diverIndex < 0 || diverIndex >= divers.Count ||
            difficulty < MinDifficulty || difficulty > MaxDifficulty ||
            score < 1 || score > ScoreRange)
        {
            throw new ArgumentException("Некорректные данные.");
        }

        // Вычисляем оценку прыжка
        double jumpScore = (score - 1)  *  difficulty;

        // Прибавляем оценку прыжка к общей сумме дайвера
        divers[diverIndex].TotalScore += jumpScore;
    }

    public void PrintResults()
    {
        // Сортируем дайверов по итоговой оценке
        var orderedDivers = divers.OrderByDescending(d => d.TotalScore);

        // Выводим результаты
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

        // Оценка прыжков
        competition.EvaluateJump(0, 3, 6); // Alice
        competition.EvaluateJump(1, 3, 6); // Bob
        competition.EvaluateJump(2, 3, 6); // Charlie
        competition.EvaluateJump(3, 3, 6); // David

        // Вывод результатов
        competition.PrintResults();
    }
}
