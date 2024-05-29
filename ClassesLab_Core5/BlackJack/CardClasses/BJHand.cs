using CardClasses;

public class BJHand : Hand
{
    public BJHand() : base() { }
    public BJHand(Deck d, int numCards) : base(d, numCards) { }

    public bool HasAce
    {
        get
        {
            return HasCard(1);
        }
    }

    public int Score
    {
        get
        {
            int score = 0;
            foreach (Card c in cards)
            {
                if (c.IsFaceCard())
                    score += 10;
                else
                    score += c.Value;
            }

            if (HasAce && score > 21)
                score -= 10;

            return score;
        }
    }

    public bool IsBusted
    {
        get
        {
            return Score > 21;
        }
    }
}