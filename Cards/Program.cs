using Cards.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cards
{
  class Program
  {

    private static List<Game> _games = new()
        {
            new BlackJack(),
        };


    static Dictionary<int, Game> GameOptions
        => new(_games.Select((game, index) => KeyValuePair.Create(++index, game)));


    static void Main(string[] args)
    {
      Console.CancelKeyPress += OnCancelKeyPressed;

      var array = new int[5];
      var selected = array.Select(i => { Console.WriteLine("Selected"); return i; });


      Greet();

      var game = GetPlayerChoice();
      game.Play();

      Goodbye();
    }

    private static void Greet()
    {
      Console.WriteLine("Hello! What game would you like to play?");
      Console.WriteLine();

      DisplayOptions();
    }


    static void DisplayOptions()
    {
      var optionText = GameOptions.Select(p => $"{p.Key}) {p.Value.Name}");
      Console.WriteLine(string.Join(Environment.NewLine, optionText));
    }


    static Game GetPlayerChoice()
    {
      do
      {
        string input = Console.ReadLine();
        if (!int.TryParse(input, out int choice) || !GameOptions.ContainsKey(choice))
        {
          Console.WriteLine();
          Console.WriteLine("Invalid choice. Please try again.");
          Console.WriteLine();
          DisplayOptions();
        }
        else
        {
          return GameOptions[choice];
        }
      } while (true);
    }


    private static void OnCancelKeyPressed(object sender, ConsoleCancelEventArgs e)
    {
      Console.CancelKeyPress -= OnCancelKeyPressed;

      Goodbye();

      Environment.Exit(0);
    }

    private static void Goodbye()
    {
      Console.WriteLine();
      Console.WriteLine("Understood. Thanks for playing!");
      Console.ReadKey();
    }

    //private static bool MainMenu()
    //{
    //    System.Threading.Thread.Sleep(1000);
    //    Console.Clear();

    //    Console.WriteLine($"1: Exit");
    //    Console.WriteLine($"2: Blackjack");

    //    int.TryParse(Console.ReadLine(), out int choice);

    //    switch (choice)
    //    {
    //        case 1:
    //            Console.WriteLine("Come back when you're ready to play! Goodbye...");
    //            return false;
    //        case 2:
    //            bool playingBlackJack = true;
    //            while (playingBlackJack)
    //                playingBlackJack = PlayBlackJack();
    //            return true;
    //        default:
    //            Console.WriteLine("Invalid choice. Please try again.");
    //            return true;
    //    }
    //}

    //private static bool PlayBlackJack()
    //{
    //    BlackJackGame bjg = new BlackJackGame();
    //    bjg.StartGame();
    //    Console.WriteLine($"Would you like to play again?\n1: Yes\n2: No, thanks.");
    //    string userChoiceForPlayAgain;
    //    do
    //    {
    //        userChoiceForPlayAgain = Console.ReadLine().Trim();
    //        switch (userChoiceForPlayAgain)
    //        {
    //            case "1":
    //                return true;
    //            case "2":
    //                Console.WriteLine("Understood. Thanks for playing!");
    //                return false;
    //            default:
    //                Console.WriteLine("Invalid choice. Please try again.");
    //                break;
    //        }
    //    } while (userChoiceForPlayAgain != "1" || userChoiceForPlayAgain != "2");
    //    return false;
    //}
  }
}
