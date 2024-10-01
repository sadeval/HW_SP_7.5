using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Введите путь для первого файла:");
            string? firstFilePath = Console.ReadLine();

            Console.WriteLine("Введите путь для второго файла:");
            string? secondFilePath = Console.ReadLine();

            File.WriteAllText(firstFilePath, "Содержимое первого файла.");
            File.WriteAllText(secondFilePath, "Содержимое второго файла.");

            Console.WriteLine("Файлы успешно созданы.");

            if (File.Exists(firstFilePath) && File.Exists(secondFilePath))
            {
                Console.WriteLine("Оба файла существуют.");

                Console.WriteLine("Введите путь для перемещения первого файла:");
                string? destinationDirectory = Console.ReadLine();

                if (!Directory.Exists(destinationDirectory))
                {
                    Console.WriteLine("Указанная папка не существует, создаем её.");
                    Directory.CreateDirectory(destinationDirectory);
                }

                // Получаем новое местоположение для первого файла
                string? destinationFilePath = Path.Combine(destinationDirectory, Path.GetFileName(firstFilePath));

                // Перемещаем первый файл
                File.Move(firstFilePath, destinationFilePath);
                Console.WriteLine($"Первый файл перемещен в {destinationFilePath}");

                // Удаляем второй файл
                File.Delete(secondFilePath);
                Console.WriteLine("Второй файл успешно удален.");
            }
            else
            {
                Console.WriteLine("Ошибка: один или оба файла не существуют.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
