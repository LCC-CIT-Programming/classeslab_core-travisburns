using System;
using CardClasses;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerWins = 0;
            int dealerWins = 0;

            Console.WriteLine("Starting Blackjack!");

            while (true)
            {
                Console.WriteLine("Starting a new hand");

                Deck deck = new Deck();
                deck.Shuffle();

                BJHand playerHand = new BJHand(deck, 2);
                BJHand dealerHand = new BJHand(deck, 2);

                Console.WriteLine("Player's hand:");
                Console.WriteLine(playerHand);

                Console.WriteLine("Dealer's hand:");
                Console.WriteLine($"{dealerHand.GetCard(0)}\nHidden card");

                while (true)
                {
                    Console.WriteLine("Do you want to (H)it or (S)tand? ");
                    string input = Console.ReadLine().ToUpper();

                    if (input == "H")
                    {
                        playerHand.AddCard(deck.Deal());
                        Console.WriteLine("Player's hand:");
                        Console.WriteLine(playerHand);

                        if (playerHand.IsBusted)
                        {
                            Console.WriteLine("Player busts! Dealer wins.");
                            dealerWins++;
                            break;
                        }
                    }
                    else if (input == "S")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter 'H' or 'S'.");
                    }
                }

                if (!playerHand.IsBusted)
                {
                    Console.WriteLine("Dealer's turn");
                    Console.WriteLine("Dealer's hand:");
                    Console.WriteLine(dealerHand);

                    while (dealerHand.Score < 17)
                    {
                        dealerHand.AddCard(deck.Deal());
                        Console.WriteLine("Dealer hits");
                        Console.WriteLine(dealerHand);
                    }

                    if (dealerHand.IsBusted)
                    {
                        Console.WriteLine("Dealer busts! Player wins.");
                        playerWins++;
                    }
                    else
                    {
                        if (playerHand.Score > dealerHand.Score)
                        {
                            Console.WriteLine("Player wins!");
                            playerWins++;
                        }
                        else if (playerHand.Score < dealerHand.Score)
                        {
                            Console.WriteLine("Dealer wins!");
                            dealerWins++;
                        }
                        else
                        {
                            Console.WriteLine("It is a tie!");
                        }
                    }
                }

                Console.WriteLine($"Player wins: {playerWins}, Dealer wins: {dealerWins}");

                Console.WriteLine("Play another hand? (Y/N)");
                string playAgain = Console.ReadLine().ToUpper();

                if (playAgain != "Y")
                {
                    break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}