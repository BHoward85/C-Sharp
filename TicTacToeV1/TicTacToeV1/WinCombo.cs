using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeV1
{
    class WinCombo
    {
        private int[][] combo;

        public WinCombo(params int[] args)
        {
            combo = new int[3][];

            for(int index = 0; index < 3; index++)
            {
                combo[index] = new int[2];
            }

            combo[0][0] = args[0];
            combo[0][1] = args[1];
            combo[1][0] = args[2];
            combo[1][1] = args[3];
            combo[2][0] = args[4];
            combo[2][1] = args[5];
        }

        public int[] this[int index]
        {
            get
            {

                if (index >= 0 && index < 3)
                    return combo[index];
                else
                    throw new IndexOutOfRangeException("Error on Index placement");
            }
            set
            {
                if (index >= 0 && index < 3)
                    combo[index] = value;
                else
                    throw new IndexOutOfRangeException("Error on Index placement");
            }
        }
    }
}
