using System.Net.Security;
using System.Reflection.Emit;

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to Character Management");
        while (true)
        {
            Console.WriteLine("\n1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Quit");
            Console.Write("Selection: ");
            var input = Console.ReadLine();
            string[] lines = File.ReadAllLines("input.csv");

            if (input == "1")
            {
                Console.WriteLine("\nAll Characters");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine(lines[i]);
                }
            }
            else if (input == "2")
            {
                Console.Write("\nEnter your character's name: ");
                string name = Console.ReadLine();

                Console.Write("\nEnter your character's class: ");
                string characterClass = Console.ReadLine();

                int level;
                while (true)
                {
                    try
                    {
                        Console.Write("\nEnter your character's level: ");
                        level = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Please enter an integer.");
                    }
                }

                Console.Write("\nEnter your character's equipment (separate items with a '|'): ");
                string[] equipment = Console.ReadLine().Split('|');

                Console.WriteLine($"\nWelcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");

                string character = string.Format("\n{0},{1},{2},{3}", name, characterClass, level, String.Join("|", equipment));

                File.AppendAllText("input.csv", character);

            }
            else if (input == "3")
            {
                Console.WriteLine("\nSelect a character to level up");
                for (int i = 0; i < lines.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + lines[i]);
                }
                int numberSelection;
                while (true) {
                    while (true)
                    {
                        try
                        {
                            Console.Write("Selection: ");
                            numberSelection = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter an integer.");
                        }
                    }
                    if (numberSelection > lines.Length || numberSelection < 1)
                    {
                        Console.WriteLine("Select an integer on the character list.");
                    }
                    else
                    {
                        break;
                    }
                }
                for (int i = 0; i < lines.Length; i++)
                {
                    if (i == numberSelection - 1)
                    {
                        string[] UpdatedCharacter = [lines[i].Split(",")[0], lines[i].Split(",")[1], (int.Parse(lines[i].Split(",")[2]) + 1).ToString(), lines[i].Split(",")[3]];
                        lines[i] = String.Join(",", UpdatedCharacter);
                        String characterName = lines[i].Split(",")[0];
                        String characterLevel = lines[i].Split(",")[2];
                        File.WriteAllLines("input.csv", lines);
                        Console.WriteLine("\n" + characterName + " is now level " + characterLevel);
                    }
                }
            }
            else if (input == "4")
            {
                break;
            }
            else
            {
                Console.WriteLine("\nPlease use vaid input\n");
            }
        }
    }
}