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
            if (_player1Cards.Any(p => p.FaceValue == FaceValue.Ace))
            {
                OptimizeAceValues(_player1Cards);
            }
            _player1Score = _player1Cards.Sum(c => c.PointValue);

            if (_dealerCards.Any(p => p.FaceValue == FaceValue.Ace))
            {
                OptimizeAceValues(_dealerCards);
            }
            _dealerScore = _dealerCards.Sum(c => c.PointValue);
        }
        private void PlayerTurn()
        {
            if (_player1Score == 21)
            {
                Console.WriteLine("You have 21! Dealer's turn:");
                return;
            }

            PromptPlayerForAction();

            string choice;

            do
            {
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Stand();
                        return;
                    case "2":
                        Hit();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            } while (choice != "1" && _player1Score < 21);

            if (_player1Score == 21)
                Console.WriteLine("Blackjack!");
            if (_player1Score > 21)
                Console.WriteLine("Bust!");
        }

        private static void PromptPlayerForAction()
        {
            Console.WriteLine("Hit or Stand?");
            Console.WriteLine("1: Stand");
            Console.WriteLine("2: Hit!");
        }

        private void DealerTurn()
        {
            Line();
            Console.WriteLine("Dealer Cards:");
            _dealerCards.ForEach(Console.WriteLine);

            Buffer();
            CheckScores();
            Console.WriteLine($"Dealer's score: {_dealerScore}");

            do
            {
                if (_dealerScore < 17)
                {
                    DealCardToDealer();
                    Buffer();
                    Console.WriteLine($"Dealer received {_dealerCards.Last()}");
                    Buffer();
                    CheckScores();
                    Console.WriteLine($"Dealer's new score: {_dealerScore}");
                }
                if (_dealerScore == 17 && _dealerCards.Any(p => p.FaceValue == FaceValue.Ace))
                {
                    Console.WriteLine($"Dealer has a soft 17 (score of {_dealerScore} and an ace in the hand) and must hit.");
                    DealCardToDealer();
                    Buffer();
                    Console.WriteLine($"Dealer received {_dealerCards.Last()}");
                    Buffer();
                    CheckScores();
                    Console.WriteLine($"Dealer's new score: {_dealerScore}");
                }
            } while (_dealerScore <= 17);

            if (_dealerScore > 17)
            {
                Console.WriteLine($"Dealer's score ({_dealerScore}) is greater than 17, and the dealer must stand.");
                return;
            }
        }
        private void CheckWinner()
        {
            CheckScores();

            if (_dealerScore > 21)
            {
                Console.WriteLine($"Dealer busted! Score {_dealerScore}.");
                Buffer();
            }
            if (_player1Score > 21)
            {
                Console.WriteLine($"Player 1 busted! Score {_player1Score}.");
                Buffer();
            }
            if (_player1Score <= 21 && _dealerScore <= 21)
            {
                if (_player1Score == _dealerScore)
                {
                    Console.WriteLine($"Push! Dealer and Player 1 tied with a score of {_dealerScore}.");
                    Buffer();
                }
                if (_player1Score > _dealerScore)
                {
                    Console.WriteLine($"Player 1 won the hand! Player 1 had {_player1Score} while the dealer had {_dealerScore}.");
                }
                if (_dealerScore > _player1Score)
                {
                    Console.WriteLine($"Dealer won the hand. Player 1 had {_player1Score} while the dealer had {_dealerScore}.");
                }
            }
        }

        private void Stand()
        {
            Console.WriteLine("Player chose to stand. Dealer's turn.");
            CheckScores();
        }

        private void Hit()
        {
            Console.WriteLine("Player chose to hit! Dealing card...");
            Buffer();
            DealCardToPlayer();

            Buffer();
            Line();

            DisplayPlayerCards();

            Buffer();
            Line();

            if (_player1Score <= 21)
                PromptPlayerForAction();
        }

        public void DisplayStartingHandInfo()
        {
            Console.WriteLine("Dealer cards:");
            Buffer();
            Console.WriteLine(_dealerCards.FirstOrDefault());
            Buffer();
            Console.WriteLine("?Hidden Card?");

            Line();

            DisplayPlayerCards();
        }

        public void DisplayPlayerCards()
        {
            Console.WriteLine("Player 1 Cards:");
            Buffer();
            _player1Cards.ForEach(Console.WriteLine);
            //display player's score for them here:
            CheckScores();
            Console.WriteLine($"Player 1's score: {_player1Score}");
        }

        public void Buffer()
        {
            System.Threading.Thread.Sleep(500);
        }

        public void Line()
        {
            Console.WriteLine("");
            Console.WriteLine("---------------");
            Console.WriteLine("");
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
