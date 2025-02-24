﻿using System;
using System.Collections.Generic;

namespace DominoClasses
{
    public class Domino : IComparable<Domino>
    {
        private int side1;
        private int side2;

        public int Side1
        {
            get { return side1; }
            set
            {
                if (value >= 0 && value <= 12)
                    side1 = value;
                else
                    throw new ArgumentException("Value must be between 0 and 12.");
            }
        }

        public int Side2
        {
            get { return side2; }
            set
            {
                if (value >= 0 && value <= 12)
                    side2 = value;
                else
                    throw new ArgumentException("Value must be between 0 and 12.");
            }
        }

        public Domino()
        {
            Side1 = 0;
            Side2 = 0;
        }

        public Domino(int p1, int p2)
        {
            Side1 = p1;
            Side2 = p2;
        }

        public void Flip()
        {
            int temp = side1;
            side1 = side2;
            side2 = temp;
        }

        public int Score
        {
            get { return side1 + side2; }
        }

        public bool IsDouble()
        {
            return side1 == side2;
        }

        public override string ToString()
        {
            return String.Format("Side 1: {0}  Side 2: {1}", side1, side2);
        }

        public int CompareTo(Domino other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}