using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardClasses
{
    public class Hand
    {
        protected List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public Hand(Deck deck, int numCards)
        {
            cards = new List<Card>();
            for (int i = 0; i < numCards; i++)
            {
                Card card = deck.Deal();
                if (card != null)
                {
                    cards.Add(card);
                }
            }
        }

        public int NumCards
        {
            get { return cards.Count; }
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public Card DiscardCard(Card card)
        {
            if (cards.Contains(card))
            {
                cards.Remove(card);
                return card;
            }
            return null;
        }

        public Card GetCard(int index)
        {
            if (index >= 0 && index < cards.Count)
            {
                return cards[index];
            }
            return null;
        }

        public bool HasCard(Card card)
        {
            return IndexOf(card) != -1;
        }

        public bool HasCard(int value, int suit)
        {
            return cards.Exists(c => c.Value == value && c.Suit == suit);
        }

        public bool HasCard(int value)
        {
            return cards.Exists(c => c.Value == value);
        }

        public int IndexOf(Card c)
        {
            return cards.IndexOf(c);
        }

        public int IndexOf(int value, int suit)
        {
            return cards.FindIndex(c => c.Value == value && c.Suit == suit);
        }

        public int IndexOf(int value)
        {
            return cards.FindIndex(c => c.Value == value);
        }

        public override string ToString()
        {
            string output = "";
            foreach (Card card in cards)
            {
                output += card.ToString() + "\n";
            }
            return output;
        }
    }
}