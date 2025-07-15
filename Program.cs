using System;

class Program
{
    static BirthdayManager manager = new();
    static void Main()
    {
        manager.Entries = FileService.Load();
        ShowTodayAndUpcoming();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Показать все дни рождения");
            Console.WriteLine("2. Добавить запись");
            Console.WriteLine("3. Удалить запись");
            Console.WriteLine("4. Редактировать запись");
            Console.WriteLine("5. Сохранить и выйти");

            Console.Write("Выбор: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ShowAll(); break;
                case "2": AddEntry(); break;
                case "3": RemoveEntry(); break;
                case "4": EditEntry(); break;
                case "5": FileService.Save(manager.Entries); return;
                default: Console.WriteLine("Неверный выбор."); break;
            }
        }
    }

    static void ShowTodayAndUpcoming()
    {
        Console.WriteLine("Сегодняшние ДР:");
        foreach (var entry in manager.GetTodayBirthdays())
            Console.WriteLine(entry);

        Console.WriteLine("\nБлижайшие ДР:");
        foreach (var entry in manager.GetUpcomingBirthdays())
            Console.WriteLine($"{entry} (через {entry.DaysUntilNextBirthday()} дней)");
    }

    static void ShowAll()
    {
        Console.WriteLine("\nВсе записи:");
        foreach (var entry in manager.GetAllSorted())
            Console.WriteLine($"{entry} (через {entry.DaysUntilNextBirthday()} дней)");
    }

    static void AddEntry()
    {
        Console.Write("Имя: ");
        var name = Console.ReadLine();
        Console.Write("Дата ДР (дд.мм.гггг): ");
        if (DateTime.TryParse(Console.ReadLine(), out var date))
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя не может быть пустым.");
                return;
            }
            manager.AddEntry(new BirthdayEntry(name, date));
            Console.WriteLine("Добавлено.");
        }
        else Console.WriteLine("Неверный формат даты.");
    }

    static void RemoveEntry()
    {
        Console.Write("Имя для удаления: ");
        var name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Имя не может быть пустым.");
            return;
        }
        manager.RemoveEntry(name);
        Console.WriteLine("Удалено.");
    }

    static void EditEntry()
    {
        Console.Write("Имя для редактирования: ");
        var name = Console.ReadLine();
        Console.Write("Новое имя: ");
        var newName = Console.ReadLine();
        Console.Write("Новая дата ДР (дд.мм.гггг): ");
        if (DateTime.TryParse(Console.ReadLine(), out var newDate))
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Имя не может быть пустым.");
                return;
            }
            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Имя не может быть пустым.");
                return;
            }
            manager.EditEntry(name, new BirthdayEntry(newName, newDate));
            Console.WriteLine("Обновлено.");
        }
        else Console.WriteLine("Неверный формат даты.");
    }
}
