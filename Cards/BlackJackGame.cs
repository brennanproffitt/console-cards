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
                        
                    }
                }
            }
        }

        public void DisplayHandInfo()
        {
            Console.WriteLine("Dealer cards:");
            Console.WriteLine("?Hidden Card?");
            foreach(var card in DealerCards.Cards.Skip(1))
            {
                Console.WriteLine(card);
            }

            Console.WriteLine("---------------");

            Console.WriteLine("Your cards:");
            Player1Cards.Cards.ForEach(Console.WriteLine);
            Console.WriteLine(Player1Cards.TotalValue);
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
