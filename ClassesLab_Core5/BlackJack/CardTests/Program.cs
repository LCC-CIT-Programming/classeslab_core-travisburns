using System;
using CardClasses;

namespace CardTests
{
    class Program
    {
        static void Main(string[] args)
        {
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