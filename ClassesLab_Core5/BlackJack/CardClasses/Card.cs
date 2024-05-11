/* Using the Visual Studio Solution provided in the starting files as a starting point and the Domino class as a model, implement and test a class that represents a (Playing) Card. 

A card has the following attributes:  a integer value in the range of 1 - 13 (ace through king) and an integer suit in the range of 1 - 4 (clubs, diamonds, hearts, spades).  A card must be able to report and update each of these attributes.  Any attempt to update an attribute to a value that is out of range should NOT change the value of the attribute and should generate an appropriate error.  The other attributes illustrated on the class diagram are class variables that are used as a "utility" in the class. 

A programmer must be able to create a card without providing any of the attribute information and must be able to create a card while providing all of the attribute information.  Any attempt to create an invalid card should result in an appropriate error. 

A card must be able to convert its attributes to a string for displaying on the screen.  The string created should a phrase like Ace of Hearts rather than the raw values 1 and 3.

A card must be able to report each of the following boolean values related to its attributes:  is it red, is it black, is it club, is it a diamond, is it a heart, is it a spade, is it an ace and is it a face card (Jack, Queen or King).

A card must also be able to compare itself to another card and report each of the following boolean values:  does its suit match the other card, does its value match the other card.  */




using System;

namespace CardClasses
{
    public class Card
    {
        private static string[] values = { "", "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "Ten", "Jack", "Queen", "King" };
        private static string[] suits = { "", "Clubs", "Diamonds", "Hearts", "Spades" };
        private static Random generator = new Random(); 

        private int value;
        private int suit;

        public Card()
        {
           
        }

        public Card(int value, int suit)
        {

            if (value < 1 || value > 13 || suit < 1 || suit > 4)
                throw new ArgumentException("Invalid card value or suit.");

            this.value = value;
            this.suit = suit;
        }

        public int Value
        {
            get { return value; }
            set { this.value = value; } 
        }

        public bool HasMatchingSuit(Card other)
        {
            if (this.suit == other.suit)
                return true;
            else
                return false;
        }

        public override string ToString()
        {
            return values[value] + " of " + suits[suit]; 
        }

       
        public int Suit
        {
            get { return suit; }
            set
            {
           
                if (suit < 1 || suit > 4)
                    throw new ArgumentException("Invalid card suit.");

                this.suit = suit;
            }
        }

        public bool HasMatchingValue(Card other)
        {
            return this.value == other.value;
        }

        public bool IsRed
        {
            get { return suit == 2 || suit == 3; } 
        }

        public bool IsBlack
        {
            get { return suit == 1 || suit == 4; } 
        }

        public bool IsClub
        {
            get { return suit == 1; }
        }

        public bool IsDiamond
        {
            get { return suit == 2; }
        }

        public bool IsHeart
        {
            get { return suit == 3; }
        }

        public bool IsSpade
        {
            get { return suit == 4; }
        }

        public bool IsAce
        {
            get { return value == 1; }
        }

        public bool IsFaceCard
        {
            get { return value >= 11 && value <= 13; }
        }
    }
}

