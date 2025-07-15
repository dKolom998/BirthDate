using System;

public class BirthdayEntry
{
    public string Name { get; set; }
    public DateTime Birthday { get; set; }

    public BirthdayEntry(string name, DateTime birthday)
    {
        Name = name;
        Birthday = birthday;
    }

    public override string ToString()
    {
        return $"{Name} — {Birthday:dd.MM.yyyy}";
    }

    public bool IsToday() =>
        Birthday.Day == DateTime.Today.Day && Birthday.Month == DateTime.Today.Month;

    public int DaysUntilNextBirthday()
    {
        var today = DateTime.Today;
        var next = new DateTime(today.Year, Birthday.Month, Birthday.Day);
        if (next < today) next = next.AddYears(1);
        return (next - today).Days;
    }
}
