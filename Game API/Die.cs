using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSystem
{
    class Die
    {
        private int numberOfSides;
        private int[] sides;
        private Random rdm;

        public Die()
        {
            numberOfSides = 0;
            sides = new int[1];
            sides[0] = 0;
        }

        public Die(int numbSides) : this()
        {
            if (numbSides > 0)
            {
                numberOfSides = numbSides;
                sides = new int[numberOfSides];

                for (int index = 0; index < numbSides; index++)
                {
                    sides[index] = index + 1;
                }

                rdm = new Random();
            }
        }
		
		public Die(int numbSides, int[] sides)
		{
			if (numbSides > 0 && int[].Length != 0)
			{
				numberOfSides = numbSides;
				this.sides = sides;
			}
		}

        public int[] Sides
        {
            get
            {
                return sides;
            }
            set
            {
                if(value.Length == numberOfSides)
                {
                    sides = value;
                }
            }
        }

        public int SideNumber
        {
            get
            {
                return numberOfSides;
            }
        }

        public int Roll()
        {
            int num = 0;

            num = sides[rdm.Next(numberOfSides)];

            return num;
        }

        public override string ToString()
        {
            return "D" + numberOfSides;
        }
    }
}
