using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class BlackJackGame
    {
        private static CardCollection _player1Cards = new CardCollection();

        public static CardCollection Player1Cards
        {
            get { return _player1Cards; }
            set { _player1Cards = value; }
        }

        private static CardCollection _dealerCards = new CardCollection();

        public static CardCollection DealerCards
        {
            get { return _dealerCards; }
            set { _dealerCards = value; }
        }

        //private Dealer _dealer;

        //public Dealer Dealer
        //{
        //    get { return _dealer; }
        //    set { _dealer = value; }
        //}


        public static void PlayBlackJack()
        {
            BlackJackGame game = new BlackJackGame();

            Dealer dealer = new Dealer();
            dealer.Deck.Shuffle();

            bool playing = true;

            while(playing)
            {
                Console.WriteLine("---------------");

                for (int i = 1; i < 3; i++)
                {
                    dealer.DealOneCard(Player1Cards);
                    dealer.DealOneCard(DealerCards);
                }

                game.DisplayHandInfo();
                Console.WriteLine("---------------");
                
                bool roundInProgress = true;

                while(roundInProgress)
                {
                    Console.WriteLine("Would you like to hit or stay?");
                    Console.WriteLine("0: Stay");
                    Console.WriteLine("1: Hit!");

                    var choice = Console.ReadLine();

                    switch(choice)
                    {
                        case "1":
                            Hit();
                            break;
                        case "2":
                            Stay();
                            break;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            break;
                    }
                }
            }
        }

        private static void Stay()
        {
            throw new NotImplementedException();
        }

        private static void Hit()
        {
             
        }

        public void DisplayHandInfo()
        {
            Console.WriteLine("Dealer cards:");
            Buffer();
            Console.WriteLine("?Hidden Card?");
            Buffer();
            foreach (var card in DealerCards.Cards.Skip(1))
            {
                Buffer();
                Console.WriteLine(card);
            }

            Console.WriteLine("---------------");

            Console.WriteLine("Your cards:");
            Buffer();

            Player1Cards.Cards.ForEach(Console.WriteLine);
            Console.WriteLine(Player1Cards.TotalValue);
        }

        public void Buffer()
        {
            System.Threading.Thread.Sleep(500);
        }

        public bool CheckForGameOver()
        {
            bool over = false;

            if(Player1Cards.TotalValue >= 21 || DealerCards.TotalValue >= 21)
            {
                over = true;
            }

            return over;
        }
    }
}
