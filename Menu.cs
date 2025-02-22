using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mod4Assignment.Models;

namespace Mod4Assignment
{
    internal class Menu
    {

        private string _fileFormat = "csv";
        private string _filePath = "Files/input.csv";
        private string _name;


        private DataContext _dataContext;


        public void Run()
        {
            Console.WriteLine("Welcome to Character Manager!");

            while (true)
            {
                _dataContext = new DataContext(_filePath);

                Console.WriteLine("Menu:");
                Console.WriteLine("1. Display Characters");
                Console.WriteLine("2. Find Character");
                Console.WriteLine("3. Add Character");
                Console.WriteLine("4. Level Up Character");
                Console.WriteLine($"5. Change File Format (current: {_fileFormat})");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _dataContext.DisplayCharacters(_filePath);
                        break;
                    case "2":
                        Console.Write("Enter character name: ");
                        _name = Console.ReadLine();
                        _dataContext.FindCharacter(_filePath, _name);
                        break;
                    case "3":
                        Character newCharacter = new Character();
                        Console.Write("Enter character name: ");
                        newCharacter.Name = Console.ReadLine();
                        Console.Write("Enter character class: ");
                        newCharacter.Class = Console.ReadLine();
                        Console.Write("Enter character level: ");
                        newCharacter.Level = int.Parse(Console.ReadLine());
                        Console.Write("Enter character HP: ");
                        newCharacter.HP = int.Parse(Console.ReadLine());
                        Console.Write("Enter character's first equipment item: ");
                        var equipment1 = Console.ReadLine();
                        Console.Write("Enter character's second equipment item: ");
                        var equipment2 = Console.ReadLine();
                        Console.Write("Enter character's third equipment item: ");
                        var equipment3 = Console.ReadLine();
                        newCharacter.Equipment = $"{equipment1}|{equipment2}|{equipment3}";
                        _dataContext.AddCharacter(_filePath, newCharacter);
                        break;
                    case "4":
                        Console.Write("Enter character name: ");
                        _name = Console.ReadLine();
                        _dataContext.LevelUpCharacter(_filePath, _name);
                        break;
                    case "5":
                        Console.WriteLine("Choose a file format (csv or json):");
                        var newFileFormat = Console.ReadLine();
                        if (newFileFormat == "csv" || newFileFormat == "json")
                        {
                            _fileFormat = newFileFormat;
                            _filePath = $"Files/input.{_fileFormat}";
                        }
                        else
                        {
                            Console.WriteLine("Invalid file format. Please try again.");
                        }
                        break;
                    case "6":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
