using System;
using System.Collections.Generic;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;

            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            Console.WriteLine("Hello! What game would you like to play?");
            Console.WriteLine($"1: Exit");
            Console.WriteLine($"2: Blackjack");

            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Come back when you're ready to play! Goodbye...");
                    return false;
                case 2:
                    bool playingBlackJack = true;
                    while (playingBlackJack)
                        playingBlackJack = PlayBlackJack();
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    return true;
            }
        }

        private static bool PlayBlackJack()
        {
            BlackJackGame bjg = new BlackJackGame();
            bjg.StartGame();
            Console.WriteLine($"Would you like to play again?\n1: Yes\n2: No, thanks.");
            int.TryParse(Console.ReadLine(), out int userChoiceForPlayAgain);
            switch (userChoiceForPlayAgain)
            {
                case 1:
                    return true;
                case 2:
                    Console.WriteLine("Understood. Thanks for playing!");
                    return false;
                default:
                    Console.WriteLine("Invalid choice. Returning to main menu.");
                    return false;
            }
        }
    }
}
