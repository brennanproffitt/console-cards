using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public class BlackJackGame
    {
        private List<Card> _player1Cards;

        private List<Card> _dealerCards;

        private Deck _deck;

        private int _player1Score;
        private int _dealerScore;

        public BlackJackGame()
        {
            _deck = new Deck();
            _player1Cards = new List<Card>();
            _dealerCards = new List<Card>();
            _player1Score = 0;
            _dealerScore = 0;
        }

        public void StartGame()
        {
            // shuffle the deck
            ShuffleDeck();

            // deal two cards to the player
            DealCardToPlayer();
            DealCardToPlayer();

            // deal two cards to the dealer
            DealCardToDealer();
            DealCardToDealer();

            // check initial scores
            CheckScores();

            // show details of game start to player
            DisplayStartingHandInfo();

            // player turn
            PlayerTurn();

            // dealer turn
            DealerTurn();

            // check winner
            CheckWinner();

            //BlackJackGame game = new BlackJackGame();

            //Dealer.Deck.Shuffle();

            //bool playing = true;

            //while(playing)
            //{
            //    game.Line();

            //    for (int i = 1; i < 3; i++)
            //    {
            //        Dealer.DealOneCard(Player1Cards);
            //        Dealer.DealOneCard(DealerCards);
            //    }

            //    game.DisplayStartingHandInfo();
            //    game.Line();

            //    bool roundInProgress = true;

            //    while(roundInProgress)
            //    {
            //        Console.WriteLine("Would you like to hit or stay?");
            //        Console.WriteLine("0: Stay");
            //        Console.WriteLine("1: Hit!");

            //        var choice = Console.ReadLine();

            //        switch(choice)
            //        {
            //            case "1":
            //                Hit();
            //                break;
            //            case "2":
            //                Stand();
            //                break;
            //            default:
            //                Console.WriteLine("Invalid choice, please try again.");
            //                break;
            //        }
            //    }
            //}
        }

        private void ShuffleDeck()
        {
            _deck.Shuffle();
        }
        private void DealCardToPlayer()
        {
            Card cardToDeal = _deck.Cards.First();
            _deck.Cards.Remove(cardToDeal);
            _player1Cards.Add(cardToDeal);
        }
        private void DealCardToDealer()
        {
            Card cardToDeal = _deck.Cards.First();
            _deck.Cards.Remove(cardToDeal);
            _dealerCards.Add(cardToDeal);
        }
        private void CheckScores()
        {
            foreach (var card in _player1Cards)
            {
                if (_player1Cards.Any(p => p.FaceValue == FaceValue.Ace))
                {
                    OptimizeAceValues(_player1Cards);
                }
                _player1Score += card.PointValue;
            }

            foreach (var card in _dealerCards)
            {
                if (_dealerCards.Any(p => p.FaceValue == FaceValue.Ace))
                {
                    OptimizeAceValues(_player1Cards);
                }
                _dealerScore += card.PointValue;
            }
        }
        private void PlayerTurn()
        {
            if(_player1Score == 21)
            {
                Console.WriteLine("You have 21! Dealer's turn:");
                return;
            }

            Console.WriteLine("Hit or Stand?");
            Console.WriteLine("1: Stand");
            Console.WriteLine("2: Hit!");

            var choice = Console.ReadLine();

            do
            {
                switch (choice)
                {
                    case "1":
                        Stand();
                        break;
                    case "2":
                        Hit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != "1");
        }
        private void DealerTurn()
        {
            throw new NotImplementedException();
        }
        private void CheckWinner()
        {
            throw new NotImplementedException();
        }

        private static void Stand()
        {
            throw new NotImplementedException();
        }

        private static void Hit()
        {
            Console.WriteLine("Player chose to hit! (logic not implemented yet lol)");
        }

        public void DisplayStartingHandInfo()
        {
            Console.WriteLine("Dealer cards:");
            Buffer();
            Console.WriteLine(_dealerCards.FirstOrDefault());
            Buffer();
            Console.WriteLine("?Hidden Card?");
            
            Line();

            Console.WriteLine("Your cards:");
            Buffer();

            _player1Cards.ForEach(Console.WriteLine);
            //display player's score for them here:
            Console.WriteLine($"Player 1's score: {_player1Cards.Sum(c => c.PointValue)}");
        }

        public void Buffer()
        {
            System.Threading.Thread.Sleep(500);
        }

        public void Line()
        {
            Console.WriteLine("---------------");
        }

        private void OptimizeAceValues(List<Card> collection)
        {
            IEnumerable<Card> aces = collection.Where(c => c.FaceValue == FaceValue.Ace);

            int totalValueWithoutAces = collection.Where(c => c.FaceValue != FaceValue.Ace).Sum(c => c.PointValue);

            if (totalValueWithoutAces >= 12 && totalValueWithoutAces < 21)
            {
                foreach (Card ace in aces)
                {
                    ace.PointValue = 1;
                }
            }
            else if (aces.Count() == 1 && totalValueWithoutAces <= 11)
            {
                aces.FirstOrDefault().PointValue = 11;
            }
            else
            {
                foreach (Card ace in aces)
                {
                    ace.PointValue = 11;
                }
            }
        }
    }
}
