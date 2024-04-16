using System;
using System.Collections.Generic;
using System.Linq;

// Определяем класс Participant для хранения информации об участниках
class Participant
{
    public string Surname { get; set; }
    public string Society { get; set; }
    public double Attempt1Result { get; set; }
    public double Attempt2Result { get; set; }

    // Метод для получения суммы результатов двух попыток
    public double GetTotalResult()
    {
        return Attempt1Result + Attempt2Result;
    }
}

class Program
{
    static void Main()
    {
        // Список участников
        List<Participant> participants = new List<Participant>
        {
            new Participant { Surname = "Иванов", Society = "Общество 1", Attempt1Result = 6.0, Attempt2Result = 6.5 },
            new Participant { Surname = "Петров", Society = "Общество 2", Attempt1Result = 6.5, Attempt2Result = 7.0 },
            new Participant { Surname = "Сидоров", Society = "Общество 3", Attempt1Result = 7.0, Attempt2Result = 7.5 },
            new Participant { Surname = "Николаев", Society = "Общество 4", Attempt1Result = 7.5, Attempt2Result = 8.0 },
            new Participant { Surname = "Смирнов", Society = "Общество 5", Attempt1Result = 8.0, Attempt2Result = 8.5 }
        };

        // Сортировка участников по сумме результатов двух попыток
        participants.Sort((x, y) => x.GetTotalResult().CompareTo(y.GetTotalResult()));

        // Вывод заголовка таблицы
        Console.WriteLine("| Фамилия | Общество | Попытка 1 | Попытка 2 | Сумма |");
        Console.WriteLine("|---------|----------|-----------|-----------|-------|");

        // Вывод результатов участников в виде таблицы
        foreach (var participant in participants)
        {
            Console.WriteLine($"| {participant.Surname} | {participant.Society} | {participant.Attempt1Result} | {participant.Attempt2Result} | {participant.GetTotalResult()} |");
        }
    }
}
