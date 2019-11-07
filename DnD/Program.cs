using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DnD
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceRoll.chooser();
            CharacterSheet.start();
            Console.ReadKey();
        }
    }

    class DiceRoll
    {
        public static void chooser()
        {
            Console.WriteLine("What dice would you like to roll?");
            Console.WriteLine("d2, d4, d6, d8, d10, d12, d20, d100, or other kind of dice");
            string choice = Console.ReadLine();
            if (choice == "")
            {
                Console.WriteLine("Please input an actual value");
                chooser();
            }
            string die = new String(choice.Where(Char.IsDigit).ToArray());
            roller(Int32.Parse(die));
        }

        public static void roller(int die)
        {
            Random rnd = new Random();
            int roll = 0;
            int total = 0;
            int counter = 1;
            Console.WriteLine("How many would you like to roll?");
            string choice = Console.ReadLine();
            string number = new String(choice.Where(char.IsDigit).ToArray());
            int num = Int32.Parse(number);
            while (counter <= num)
            {
                roll = rnd.Next(1, die + 1);
                Console.WriteLine("Roll " + counter + " is: " + roll);
                counter++;
                total += roll;
            }

            Console.WriteLine("Total is: " + total);
            Continue();
        }

        public static void Continue()
        {
            Console.WriteLine("Would you like to continue?");
            string choice = Console.ReadLine();
            choice.ToLower();
            if (choice == "y" || choice == "yes" || choice == "")
            {
                Console.Clear();
                chooser();
            }
            if (choice == "n" || choice == "no")
            {
                Environment.Exit(0);
            }
        }
    }

    class CharacterSheet
    {
        public static void start()
        {
            Console.WriteLine("Would you like to access a character sheet or make a new one?");
            string choice = Console.ReadLine();
            string Choice = new String(choice.Where(char.IsDigit).ToArray());
            Choice.ToLower();
            if (Choice == "new")
            {
                newCharacter();
            }
            else if (Choice == "access")
            {
                accessCharacter();
            }
            else
            {
                Console.WriteLine("Please input either 'new' or 'access'");
                Console.ReadKey();
                Console.Clear();
                start();
            }
        }

        public static void newCharacter()
        {
            Console.WriteLine("Welcome to character creation!");
            Console.WriteLine("First, input your race:");
            string choice = Console.ReadLine();
            string race = new String(choice.Where(Char.IsDigit).ToArray());
            StreamReader sr = new StreamReader("c:\\home\\loganpixley\\races\\" + race + ".txt");

        }

        public static void accessCharacter()
        {
            Console.WriteLine("What is the name of your character?");
            string name = Console.ReadLine();
        }
    }
}