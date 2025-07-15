using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public static class FileService
{
    private const string FileName = "birthdays.json";

    public static void Save(List<BirthdayEntry> entries)
    {
        var json = JsonSerializer.Serialize(entries);
        File.WriteAllText(FileName, json);
    }

    public static List<BirthdayEntry> Load()
    {
        if (!File.Exists(FileName)) return new List<BirthdayEntry>();
        var json = File.ReadAllText(FileName);
        return JsonSerializer.Deserialize<List<BirthdayEntry>>(json) ?? new List<BirthdayEntry>();
    }
}
