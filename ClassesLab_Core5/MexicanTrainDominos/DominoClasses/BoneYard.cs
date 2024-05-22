using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace DominoClasses
{
    public class BoneYard
    {
        
        private List<Domino> dominos;
        private int maxDots;

        public BoneYard(int maxDots)
        {
            this.maxDots = maxDots;
            dominos = new List<Domino>();

            for (int side1 = 0; side1 <= maxDots; side1++)
            {
                for (int side2 = side1; side2 <= maxDots; side2++)
                {
                    dominos.Add(new Domino(side1, side2));
                }
            }
        }

        public int DominosRemaining
        {
            get { return dominos.Count; }
        }

        public bool IsEmpty
        {
            get { return dominos.Count == 0; }
        }

        public Domino this[int index]
        {
            get { return dominos[index]; }
            set { dominos[index] = value; }
        }

        public Domino Draw()
        {
            if (!IsEmpty)
            {
                Domino d = dominos[0];
                dominos.RemoveAt(0);
                return d;
            }
            return null;
        }

        public void Shuffle()
        {
            Random rng = new Random();
            int n = dominos.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Domino d = dominos[k];
                dominos[k] = dominos[n];
                dominos[n] = d;
            }
        }

        public override string ToString()
        {
            string output = "";
            foreach (Domino d in dominos)
            {
                output += d.ToString() + "\n";
            }
            return output;
        }
    }
}

