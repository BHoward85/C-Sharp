using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Structs;
using TetrisGame.Supports;
using TetrisGame.Interfaces;

namespace TetrisGame.Classes
{
    class Polyomino : IPolyomino
    {
        private Orientations orientation;
        private char type;
        private int tier;
        private int x;
        private int y;

        public Polyomino()
        {
            orientation = new Orientations();
            type = '!';
            tier = 0;
            x = 0;
            y = 0;

            orientation.Spaces = new byte[1, 1] { { 0 } };
            SetOrientation();
        }
        
        public Polyomino(char shape, int t)
        {
            orientation = new Orientations();
            orientation.Spaces = new byte[1, 1] { { 0 } };
            type = shape;
            tier = t;
            x = 0;
            y = 0;
            SetOrientation();
        }

        private void SetOrientation()
        {
            orientation.Rotations = new byte[4][,];

            for (int index = 0; index < 4; index++)
                orientation.Rotations[index] = new byte[1, 1] { { 0 } };
        }

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                if (value >= 0)
                    x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value >= 0)
                    y = value;
            }
        }

        public int Tier
        {
            get
            {
                return tier;
            }
            set
            {
                if (value > 0)
                    tier = value;
            }
        }

        public char Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        public byte[,] Shape
        {
            get
            {
                return orientation.Spaces;
            }
            set
            {
                orientation.Spaces = value;
            }
        }

        public byte[][,] Rotations
        {
            get
            {
                return orientation.Rotations;
            }
            set
            {
                orientation.Rotations = value;
            }
        }

        public byte[,] RightRotation()
        {
            return orientation.RightRotation();
        }

        public byte[,] LeftRotation()
        {
            return orientation.LeftRotation();
        }
    }
}
