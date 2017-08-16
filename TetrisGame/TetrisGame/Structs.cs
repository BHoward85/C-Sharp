using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.Structs
{
    // Struct for Mino Rotations
    struct Orientations
    {
        private byte[,] space;
        private byte[][,] rotations;
        private byte currRotation;

        public byte CurrentRotation
        {
            get
            {
                return currRotation;
            }
            set
            {
                if (value >= 0 && value < 4)
                {
                    currRotation = value;
                }
            }
        }

        public byte[,] Spaces
        {
            get
            {
                return space;
            }
            set
            {
                space = value;
            }
        }

        public byte[][,] Rotations
        {
            get
            {
                return rotations;
            }
            set
            {
                if (value != null)
                {
                    rotations = value;
                }
            }
        }

        public byte[,] RightRotation()
        {
            currRotation++;

            return Rotations[currRotation % 4];
        }

        public byte[,] LeftRotation()
        {
            currRotation--;

            return Rotations[currRotation % 4];
        }
    }

    // Struct for Score Board
    struct ScoreInfo
    {
        private string playerName;
        private int lines;
        private int score;
        private int level;

        public string Name
        {
            get
            {
                return playerName;
            }
            set
            {
                playerName = value;
            }
        }

        public int Lines
        {
            get
            {
                return lines;
            }
            set
            {
                lines = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        public override string ToString()
        {
            string str = "";

            str += "Player Name: " + playerName + "\n";
            str += "Score: " + score + "\n";
            str += "Lines: " + lines + "\n";
            str += "Level: " + level + "\n";

            return str;
        }
    }
}
