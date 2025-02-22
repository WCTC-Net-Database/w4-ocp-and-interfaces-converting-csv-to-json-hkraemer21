using Newtonsoft.Json;
using Mod4Assignment.Interfaces;
using Mod4Assignment.Models;

namespace Mod4Assignment.Services;

public class JsonFileManager : IFileManager
{
    private string _json;
    public JsonFileManager(string filePath)
    {
        _json = File.ReadAllText(filePath);
    }

    public List<Character> ReadCharacters(string filePath)
    {
        List<Character> characters = new List<Character>();
        characters = JsonConvert.DeserializeObject<List<Character>>(_json);
        return characters;
    }

    public void WriteCharacters(string filePath, List<Character> characters)
    {
        _json = JsonConvert.SerializeObject(characters);
        File.WriteAllText(filePath, _json);
    }
}