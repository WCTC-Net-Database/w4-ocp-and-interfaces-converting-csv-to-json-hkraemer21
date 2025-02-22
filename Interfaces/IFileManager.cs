using Mod4Assignment.Models;

namespace Mod4Assignment.Interfaces;

public interface IFileManager
{
    List<Character> ReadCharacters(string filePath);
    void WriteCharacters(string filePath, List<Character> characters);
}