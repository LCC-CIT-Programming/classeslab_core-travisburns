using DominoClasses;

public class PlayerTrain : Train
{
    private bool isOpen;
    public Hand hand;

    public Hand Hand { get; private set; }

    public PlayerTrain(Hand hand) : base()
    {
        Hand = hand;
        isOpen = false;
    }

    public PlayerTrain(Hand hand, int engineValue) : base(engineValue)
    {
        Hand = hand;
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