using System;
using System.Text;

namespace GuessNumber
{
    class Program
    {
        private static readonly Random Rand = new Random();
        private static int _chance = 1;
        private static int _myNumber;
        private const ConsoleColor DefForeground = ConsoleColor.Green;
        private const ConsoleColor DefBackground = ConsoleColor.Black;

        static void Main(string[] args)
        {
            Init();
            while (GuessNumber())
            {
                Init();
            }
        }

        private static void Init()
        {
            Console.ForegroundColor = DefForeground;
            Console.BackgroundColor = DefBackground;
        }

        private static bool GuessNumber()
        {
            
            Console.WriteLine($"I'm thinking of a decimal 0 through 9. What is it? (chance {_chance} of 3) ");
            if (_chance == 1)
            {
                _myNumber = Rand.Next(0, 9);
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            var key = Console.ReadKey(false).KeyChar;
            Console.WriteLine();

            var yourGuessAscii = (int)key;
            if (yourGuessAscii < 48 || yourGuessAscii > 57) return false;

            var yourGuess = int.Parse(key.ToString());
            if (yourGuess == _myNumber)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("YAY!!!! You got it! You're good at this!!!!");
                _chance = 0;
            }
            else
            {
                if (_chance == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Sorry! You didn't get it within 3 guesses :) I was thinking of {_myNumber}");
                    _chance = 0;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    var hintStr = new StringBuilder("Wrong! Try ");
                    hintStr.Append(yourGuess > _myNumber ? "going lower." : "guessing higher.");
                    Console.WriteLine(hintStr);
                }
            }

            _chance++;

            return true;
        }
    }
}
