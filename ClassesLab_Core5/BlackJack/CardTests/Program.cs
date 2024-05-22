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
                TestDeckDeal();

                Console.ReadLine();
            

            static void TestDeckConstructor()
            {
                Deck d = new Deck();

                Console.WriteLine("Testing deck of cards default constructor");
                Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
                Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
                Console.WriteLine("ToString.  Expect a ton of cards in order.\n" + d.ToString());
                Console.WriteLine();
            }

            static void TestDeckShuffle()
            {
                Deck d = new Deck();
                d.Shuffle();
                Console.WriteLine("Testing deck of cards shuffle");
                Console.WriteLine("NumCards.  Expecting 52. " + d.NumCards);
                Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
                Console.WriteLine("First Card will rarely be the Ace of Clubs. " + d[0]);
                Console.WriteLine("ToString.  Expect a ton of cards in shuffled order.\n" + d.ToString());
                Console.WriteLine();
            }

            static void TestDeckDeal()
            {
                Deck d = new Deck();
                Card c = d.Deal();

                Console.WriteLine("Testing deck of cards deal");
                Console.WriteLine("NumCards.  Expecting 51. " + d.NumCards);
                Console.WriteLine("IsEmpty.   Expecting false. " + d.IsEmpty);
                Console.WriteLine("Dealt Card should be Ace of Clubs. " + c);

                // now let's deal them all and see what happens at the end
                for (int i = 1; i <= 51; i++)
                    c = d.Deal();
                Console.WriteLine("Dealt all 52 cards");
                Console.WriteLine("NumCards.  Expecting 0. " + d.NumCards);
                Console.WriteLine("IsEmpty.   Expecting true. " + d.IsEmpty);
                Console.WriteLine("Last Card should be King of Spades. " + c);
                Console.WriteLine("Dealing again should return null. Expecting true. " + (d.Deal() == null));

                Console.WriteLine();
            }













            Card c1 = new Card(1, 4); 
            Card c2 = new Card(10, 4); 

            // Test ToString()
            Console.WriteLine(c1); 
            Console.WriteLine(c2); 

            // Test HasMatchingSuit
            if (c1.HasMatchingSuit(c2))
            {
                Console.WriteLine("c1 and c2 have matching suits");
            }

            else
            {
                Console.WriteLine("c1 and c2 do not have matching suits");
            }

            // Test HasMatchingValue
            if (c1.HasMatchingValue(c2))
            {
                Console.WriteLine("c1 and c2 have matching values");
            }
            else
            {
                Console.WriteLine("c1 and c2 do not have matching values");
            }

            // Test boolean properties
            Console.WriteLine($"Is c1 red? {c1.IsRed}");
            Console.WriteLine($"Is c2 black? {c2.IsBlack}");
            Console.WriteLine($"Is c1 a club? {c1.IsClub}");
            Console.WriteLine($"Is c2 a spade? {c2.IsSpade}");
            Console.WriteLine($"Is c1 an ace? {c1.IsAce}");
            Console.WriteLine($"Is c2 a face card? {c2.IsFaceCard}");
        }
    }
}