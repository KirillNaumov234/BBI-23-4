using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Задание 1
        string input1 = "Введенная пользователем строка. Здесь есть несколько предложений. Найдем самое длинное.";
        string[] sentences = input1.Split('.');
        string longestSentence = sentences[0];
        foreach (string sentence in sentences)
        {
            if (sentence.Length > longestSentence.Length)
            {
                longestSentence = sentence;
            }
        }
        Console.WriteLine("Самое длинное предложение: " + longestSentence);

        // Задание 2
        string input2 = "Центральные слова всех предложений построчно";
        string[] words = input2.Split(' ');
        int middle = words.Length / 2;
        foreach (string word in words)
        {
            Console.WriteLine(words[middle]);
        }

        // Задание 3
        string directoryPath = @"C:\Users\Username\Downloads\Fourth Task";
        string file1Path = $"{directoryPath}\\string_1.json";
        string file2Path = $"{directoryPath}\\string_2.json";

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }

        if (!File.Exists(file1Path))
        {
            File.WriteAllText(file1Path, (input1));
        }
        else
        {
            string inputFromFile = File.ReadAllText(file1Path);
            Console.WriteLine("Данные из файла string_1.json: " + inputFromFile);
        }

        if (!File.Exists(file2Path))
        {
            File.WriteAllText(file2Path, (input2));
        }
        else
        {
            string inputFromFile = File.ReadAllText(file2Path);
            Console.WriteLine("Данные из файла string_2.json: " + inputFromFile);
        }
    }
}

// Задание 4
class Program
{
    static void Main()
    {
        string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\\Downloads";
        string fourthTaskPath = Path.Combine(downloadsPath, "Fourth Task");

        if (!Directory.Exists(fourthTaskPath))
        {
            Directory.CreateDirectory(fourthTaskPath);
            Console.WriteLine("Папка 'Fourth Task' создана.");
        }

        string file1Path = Path.Combine(fourthTaskPath, "string_1.json");
        string input1 = "";

        if (File.Exists(file1Path))
        {
            input1 = File.ReadAllText(file1Path);
            Console.WriteLine("Входные данные для Задания 1 (из файла 'string_1.json'):");
            Console.WriteLine(input1);
        }
        else
        {
            input1 = "Ваши входные данные для Задания 1";
            File.WriteAllText(file1Path, input1);
            Console.WriteLine("Входные данные для Задания 1 записаны в файл 'string_1.json'.");
        }

        string file2Path = Path.Combine(fourthTaskPath, "string_2.json");
        string output2 = "";

        if (File.Exists(file2Path))
        {
            output2 = File.ReadAllText(file2Path);
            Console.WriteLine("Выходные данные для Задания 2 (из файла 'string_2.json'):");
            Console.WriteLine(output2);
        }
        else
        {
            output2 = "Ваши выходные данные для Задания 2";
            File.WriteAllText(file2Path, output2);
            Console.WriteLine("Выходные данные для Задания 2 записаны в файл 'string_2.json'.");
        }

        Console.ReadKey();
    }
}