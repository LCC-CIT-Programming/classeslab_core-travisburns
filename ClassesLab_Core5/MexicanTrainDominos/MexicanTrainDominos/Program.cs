using DominoClasses;
using System;
using System.Collections.Generic;

namespace DominoClasses
{
    public class MexicanTrain : Train
    {
        public MexicanTrain() : base() { }
        public MexicanTrain(int engineValue) : base(engineValue) { }

        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            mustFlip = false;
            if (IsEmpty || IsPlayable(d))
            {
                if (!IsEmpty && d.Side2 != PlayableValue)
                {
                    mustFlip = true;
                }
                return true;
            }
            return false;
        }
    }

    public class PlayerTrain : Train
    {
        private Hand hand;
        private bool isOpen;

        public PlayerTrain(Hand hand) : base()
        {
            this.hand = hand;
            isOpen = false;
        }

        public PlayerTrain(Hand hand, int engineValue) : base(engineValue)
        {
            this.hand = hand;
            isOpen = false;
        }

        public bool IsOpen => isOpen;

        public void Open()
        {
            isOpen = true;
        }

        public void Close()
        {
            isOpen = false;
        }

        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            mustFlip = false;
            if (IsOpen && (IsEmpty || IsPlayable(d)))
            {
                if (!IsEmpty && d.Side2 != PlayableValue)
                {
                    mustFlip = true;
                }
                return true;
            }
            return false;
        }
    }
}

namespace MexicanTrainDominos
{
    class Program
    {
        static void Main(string[] args)
        {
            TestMexicanTrain();
            TestPlayerTrain();
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
            Assert(train.Hand == hand, "The constructor should set the hand correctly");
            Assert(!train.IsOpen, "The constructor should set the train to closed state");
            Assert(train.EngineValue == 0, "The default constructor should initialize EngineValue to 0");

            train = new PlayerTrain(hand, 5);
            Assert(train.Hand == hand, "The constructor should set the hand correctly");
            Assert(!train.IsOpen, "The constructor should set the train to closed state");
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

        private static void Assert(bool condition, string message)
        {
            if (!condition)
            {
                Console.WriteLine(message);
            }
        }
    }
}