using CsvHelper;
using System.Globalization;
using Mod4Assignment.Interfaces;
using Mod4Assignment.Models;

namespace Mod4Assignment.Services;

public class CsvFileManager : IFileManager
{
    public string _filePath;

    public CsvFileManager(string filePath)
    {
        _filePath = filePath;
    }

    public List<Character> ReadCharacters(string filePath)
    {
        List<Character> characters = new List<Character>();
        using (var reader = new StreamReader(filePath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            characters = csv.GetRecords<Character>().ToList();
        }
        return characters;
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        using (var writer = new StreamWriter(filePath))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        {
            csv.WriteRecords(characters);
        }
    }
}