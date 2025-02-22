using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod4Assignment.Interfaces;
using Mod4Assignment.Models;
using Mod4Assignment.Services;

namespace Mod4Assignment
{
    internal class DataContext
    {
        private string _filePath;
        private IFileManager _fileManager;

        public DataContext()
        {
        }

        public DataContext(string filePath)
        {
            if (filePath.EndsWith(".csv"))
            {
                _fileManager = new CsvFileManager(filePath);
            }
            else if (filePath.EndsWith(".json"))
            {
                _fileManager = new JsonFileManager(filePath);
            }
            else
            {
                throw new Exception("Invalid file format");
            }
        }

        public void DisplayCharacters(string _filePath)
        {
            var characters = _fileManager.ReadCharacters(_filePath);
            foreach (var character in characters)
            {
                Console.WriteLine($"\nName: {character.Name}\nClass: {character.Class}\nLevel: " +
                    $"{character.Level}\nHP: {character.HP}\nEquipment: {character.Equipment}\n");
            }
        }

        public void FindCharacter(string _filePath, string name)
        {
            var characters = _fileManager.ReadCharacters(_filePath);
            var character = characters.Find(c => c.Name == name);
            if (character != null)
            {
                Console.WriteLine($"\nName: {character.Name}\nClass: {character.Class}\nLevel: " +
                    $"{character.Level}\nHP: {character.HP}\nEquipment: {character.Equipment}\n");
            }
            else
            {
                Console.WriteLine("Character not found.");
            }



        }

        public void AddCharacter(string _filePath, Character character)
        {
            var characters = _fileManager.ReadCharacters(_filePath);
            characters.Add(character);
            _fileManager.WriteCharacters(_filePath, characters);
        }

        public void LevelUpCharacter(string _filePath, string name)
        {
            var characters = _fileManager.ReadCharacters(_filePath);
            var character = characters.Find(c => c.Name == name);
            if (character != null)
            {
                character.Level++;
                _fileManager.WriteCharacters(_filePath, characters);
            }
            else
            {
                Console.WriteLine("Character not found.");
            }
        }




    }
}
