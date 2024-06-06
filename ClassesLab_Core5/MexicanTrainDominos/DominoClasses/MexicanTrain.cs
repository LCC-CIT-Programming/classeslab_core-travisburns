using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}