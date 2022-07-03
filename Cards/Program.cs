using System;
using System.Collections.Generic;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dealer dealer = new Dealer();
            dealer.Deck.Shuffle();

            Console.WriteLine("Hello! What game would you like to play?");
            Console.WriteLine($"0: Exit{Environment.NewLine}1: Blackjack");

            int choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 0:
                    Console.WriteLine("Goodbye...");
                    Environment.Exit(0);
                    break;
                case 1:
                    BlackJackGame.PlayBlackJack();
                    break;
                default:
                    Console.WriteLine("Invalid choice! Try again!");
                    break;
            }
        }
    }
}
