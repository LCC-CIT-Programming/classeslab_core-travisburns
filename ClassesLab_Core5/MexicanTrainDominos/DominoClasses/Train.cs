using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoClasses
{
    public abstract class Train
    {
        protected List<Domino> dominos;
        protected int engineValue;

        public Train()
        {
            dominos = new List<Domino>();
            engineValue = 0;
        }

        public Train(int engineValue)
        {
            dominos = new List<Domino>();
            this.engineValue = engineValue;
        }

        public int Count => dominos.Count;
        public int EngineValue => engineValue;
        public bool IsEmpty => dominos.Count == 0;
        public Domino LastDomino => IsEmpty ? null : dominos[dominos.Count - 1];
        public int PlayableValue => IsEmpty ? engineValue : LastDomino.Side2;

        public Domino this[int index] => dominos[index];

        public bool IsPlayable(Domino d)
        {
            return d.Side1 == PlayableValue || d.Side2 == PlayableValue;
        }

        public void Play(Hand h, Domino d)
        {
            bool mustFlip;
            if (IsPlayable(h, d, out mustFlip))
            {
                if (mustFlip)
                    d.Flip();
                dominos.Add(d);
                h.RemoveDomino(d);
            }
            else
            {
                throw new Exception($"Domino {d} does not match the last domino in the train and cannot be played.");
            }
        }

        public override string ToString()
        {
            return string.Join(", ", dominos);
        }

        public abstract bool IsPlayable(Hand h, Domino d, out bool mustFlip);
    }
}