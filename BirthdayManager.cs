using System;
using System.Collections.Generic;
using System.Linq;

public class BirthdayManager
{
    public List<BirthdayEntry> Entries { get; set; } = new();

    public void AddEntry(BirthdayEntry entry) => Entries.Add(entry);

    public void RemoveEntry(string name) =>
        Entries.RemoveAll(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

    public void EditEntry(string name, BirthdayEntry newEntry)
    {
        var index = Entries.FindIndex(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (index >= 0) Entries[index] = newEntry;
    }

    public List<BirthdayEntry> GetTodayBirthdays() =>
        Entries.Where(e => e.IsToday()).ToList();

    public List<BirthdayEntry> GetUpcomingBirthdays(int daysAhead = 7) =>
        Entries.Where(e => !e.IsToday() && e.DaysUntilNextBirthday() <= daysAhead).ToList();

    public List<BirthdayEntry> GetAllSorted() =>
        Entries.OrderBy(e => e.DaysUntilNextBirthday()).ToList();
}
