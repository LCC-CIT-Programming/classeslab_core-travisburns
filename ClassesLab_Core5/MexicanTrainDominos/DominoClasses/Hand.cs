using DominoClasses;
using System.Collections.Generic;

public class Hand
{
    private List<Domino> dominos = new List<Domino>();

    public void AddDomino(Domino d)
    {
        dominos.Add(d);
    }

    public void RemoveDomino(Domino d)
    {
        dominos.Remove(d);
    }
}