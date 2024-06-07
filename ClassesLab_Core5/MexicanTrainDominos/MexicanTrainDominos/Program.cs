using DominoClasses;
using System.Collections.Generic;
using System;

namespace MexicanTrainDominos
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMexicanTrain();
            TestPlayerTrain();
            TestSortingAndIteration();
        }

        public static void TestMexicanTrain()
        {
            MexicanTrain train = new MexicanTrain();
            Assert(train.EngineValue == 0, "The default constructor should initialize EngineValue to 0");
            Assert(train.Count == 0, "The default constructor should initialize the domino count to 0");

            train = new MexicanTrain(5);
            Assert(train.EngineValue == 5, "The constructor with an engine value should set EngineValue correctly");

            Hand hand = new Hand();
            hand.AddDomino(new Domino(6, 6));
            bool mustFlip;

            // Empty train
            Assert(train.IsPlayable(hand, new Domino(6, 6), out mustFlip), "For an empty train, IsPlayable should return true");
            Assert(!mustFlip, "For an empty train, mustFlip should be false");

            train.Play(hand, new Domino(6, 6));

            // Matching first value
            Assert(train.IsPlayable(hand, new Domino(6, 4), out mustFlip), "If the domino matches the first value, IsPlayable should return true");
            Assert(!mustFlip, "If the domino matches the first value, mustFlip should be false");

            // Matching second value, must flip
            Assert(train.IsPlayable(hand, new Domino(2, 6), out mustFlip), "If the domino matches the second value, IsPlayable should return true");
            Assert(mustFlip, "If the domino matches the second value, mustFlip should be true");

            // Not matching
            Assert(!train.IsPlayable(hand, new Domino(3, 5), out mustFlip), "If the domino doesn't match any value, IsPlayable should return false");
        }

        public static void TestPlayerTrain()
        {
            Hand hand = new Hand();
            PlayerTrain train = new PlayerTrain(hand);
            Assert(train.EngineValue == 0, "The default constructor should initialize EngineValue to 0");

            train = new PlayerTrain(hand, 5);
            Assert(train.EngineValue == 5, "The constructor with an engine value should set EngineValue correctly");

            train.Open();
            Assert(train.IsOpen, "The Open method should mark the train as open");

            train.Close();
            Assert(!train.IsOpen, "The Close method should mark the train as closed");

            hand.AddDomino(new Domino(6, 6));
            train.Open();
            bool mustFlip;

            // Open, empty train
            Assert(train.IsPlayable(hand, new Domino(6, 6), out mustFlip), "For an open, empty train, IsPlayable should return true");
            Assert(!mustFlip, "For an open, empty train, mustFlip should be false");

            train.Play(hand, new Domino(6, 6));

            // Open, matching first value
            Assert(train.IsPlayable(hand, new Domino(6, 4), out mustFlip), "For an open train, if the domino matches the first value, IsPlayable should return true");
            Assert(!mustFlip, "For an open train, if the domino matches the first value, mustFlip should be false");

            // Open, matching second value, must flip
            Assert(train.IsPlayable(hand, new Domino(2, 6), out mustFlip), "For an open train, if the domino matches the second value, IsPlayable should return true");
            Assert(mustFlip, "For an open train, if the domino matches the second value, mustFlip should be true");

            // Open, not matching
            Assert(!train.IsPlayable(hand, new Domino(3, 5), out mustFlip), "For an open train, if the domino doesn't match any value, IsPlayable should return false");

            // Closed
            train.Close();
            Assert(!train.IsPlayable(hand, new Domino(6, 6), out mustFlip), "For a closed train, IsPlayable should return false");
        }

        public static void TestSortingAndIteration()
        {
            // Test sorting
            List<Domino> hand = new List<Domino>();
            hand.Add(new Domino(5, 3));
            hand.Add(new Domino(2, 6));
            hand.Add(new Domino(4, 4));
            hand.Sort();
            Console.WriteLine("Sorted hand:");
            foreach (Domino d in hand)
            {
                Console.WriteLine(d);
            }

            // Test iteration
            MexicanTrain mexicanTrain = new MexicanTrain();
            mexicanTrain.Play(new Hand(), new Domino(6, 6));
            mexicanTrain.Play(new Hand(), new Domino(6, 4));
            Console.WriteLine("\nMexicanTrain:");
            foreach (Domino d in mexicanTrain)
            {
                Console.WriteLine(d);
            }

            PlayerTrain playerTrain = new PlayerTrain(new Hand());
            playerTrain.Open();
            playerTrain.Play(new Hand(), new Domino(3, 3));
            playerTrain.Play(new Hand(), new Domino(3, 5));
            Console.WriteLine("\nPlayerTrain:");
            foreach (Domino d in playerTrain)
            {
                Console.WriteLine(d);
            }
        }

        private static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine(message);
            }
        }
    }
}