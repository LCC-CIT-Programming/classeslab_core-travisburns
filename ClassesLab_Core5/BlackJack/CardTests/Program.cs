using System;
using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestDeckConstructor();
            //TestDeckShuffle();
            //TestDeckDeal();
            //TestHand();
            TestBJHand();
            Console.ReadLine();
        }

        static void TestDeckConstructor()
        {
            Deck d = new Deck();
            Console.WriteLine("Testing deck of cards default constructor");
            Console.WriteLine("NumCards. Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty. Expecting false. " + d.IsEmpty);
            Console.WriteLine("ToString. Expect a ton of cards in order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckShuffle()
        {
            Deck d = new Deck();
            d.Shuffle();
            Console.WriteLine("Testing deck of cards shuffle");
            Console.WriteLine("NumCards. Expecting 52. " + d.NumCards);
            Console.WriteLine("IsEmpty. Expecting false. " + d.IsEmpty);
            Console.WriteLine("First Card will rarely be the Ace of Clubs. " + d[0]);
            Console.WriteLine("ToString. Expect a ton of cards in shuffled order.\n" + d.ToString());
            Console.WriteLine();
        }

        static void TestDeckDeal()
        {
            Deck d = new Deck();
            Card c = d.Deal();
            Console.WriteLine("Testing deck of cards deal");
            Console.WriteLine("NumCards. Expecting 51. " + d.NumCards);
            Console.WriteLine("IsEmpty. Expecting false. " + d.IsEmpty);
            Console.WriteLine("Dealt Card should be Ace of Clubs. " + c);
            // now let's deal them all and see what happens at the end
            for (int i = 1; i <= 51; i++)
                c = d.Deal();
            Console.WriteLine("Dealt all 52 cards");
            Console.WriteLine("NumCards. Expecting 0. " + d.NumCards);
            Console.WriteLine("IsEmpty. Expecting true. " + d.IsEmpty);
            Console.WriteLine("Last Card should be King of Spades. " + c);
            Console.WriteLine("Dealing again should return null. Expecting true. " + (d.Deal() == null));
            Console.WriteLine();
        }

        static void TestHand()
        {
            Deck deck = new Deck();
            deck.Shuffle();

            Hand hand = new Hand(deck, 5);
            Console.WriteLine("Testing Hand class");
            Console.WriteLine("NumCards. Expecting 5. " + hand.NumCards);
            Console.WriteLine("ToString:\n" + hand.ToString());

            Card card = hand.GetCard(0);
            Console.WriteLine("First card: " + card);
            Console.WriteLine("Discarding first card: " + hand.DiscardCard(card));
            Console.WriteLine("NumCards. Expecting 4. " + hand.NumCards);

            Card newCard = deck.Deal();
            hand.AddCard(newCard);
            Console.WriteLine("Adding new card: " + newCard);
            Console.WriteLine("NumCards. Expecting 5. " + hand.NumCards);

            Console.WriteLine("Index of first card. Expecting 0. " + hand.IndexOf(hand.GetCard(0)));
            Console.WriteLine("Has card with value 10? Expecting true or false. " + hand.HasCard(10));

            Console.WriteLine();
        }


        static void TestBJHand()
        {
            Deck deck = new Deck();
            deck.Shuffle();

            BJHand hand = new BJHand(deck, 2); 
            Console.WriteLine("Testing BJHand class");
            Console.WriteLine($"Hand: {hand}");
            Console.WriteLine($"Score: {hand.Score}");
            Console.WriteLine($"Has Ace: {hand.HasAce}");
            Console.WriteLine($"Is Busted: {hand.IsBusted}");

            
            hand.AddCard(deck.Deal());
            hand.AddCard(deck.Deal());
            Console.WriteLine("\nAfter adding 2 more cards:");
            Console.WriteLine($"Hand: {hand}");
            Console.WriteLine($"Score: {hand.Score}");
            Console.WriteLine($"Has Ace: {hand.HasAce}");
            Console.WriteLine($"Is Busted: {hand.IsBusted}");

            Console.WriteLine();
        }

    }
}