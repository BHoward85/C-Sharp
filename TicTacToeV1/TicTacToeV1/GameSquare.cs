using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TicTacToeV1
{
    class GameSquare
    {
        private Rectangle rect;
        private char state;

        public GameSquare()
        {
            rect = new Rectangle();
            state = '_';
        }

        public GameSquare(int x, int y, int h, int w)
            : this()
        {
            rect.X = x;
            rect.Y = y;
            rect.Height = h;
            rect.Width = w;
        }

        public char State
        {
            get
            {
                return state;
            }
            set
            {
                if (value != '\0')
                {
                    state = value;
                }
            }
        }

        public int X
        {
            get
            {
                return rect.X;
            }
            set
            {
                rect.X = value;
            }
        }

        public int Y
        {
            get
            {
                return rect.Y;
            }
            set
            {
                rect.Y = value;
            }
        }

        public int Height
        {
            get
            {
                return rect.Height;
            }
            set
            {
                rect.Height = value;
            }
        }

        public int Width
        {
            get
            {
                return rect.Width;
            }
            set
            {
                rect.Width = value;
            }
        }
    }
}