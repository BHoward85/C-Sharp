using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsGame
{
    class Rules
    {
        private int rollNumber;
        private int point;
        private int[] winningNumbers;
        private int[] losingNumbers;
        private int[] pointNumbers;
        private bool gameStarted;
        private bool hasPoint;
        private bool win;
        private bool lose;
        private int finalLosingNumber;

        public Rules()
        {
            winningNumbers = new int[2];
            losingNumbers = new int[3];
            pointNumbers = new int[6];
            finalLosingNumber = 7;
            
            hasPoint = false;
            win = false;
            lose = false;
            gameStarted = false;
            rollNumber = 0;
            point = 0;

            SetNumbers();
        }

        private void SetNumbers()
        {
            winningNumbers[0] = 7;
            winningNumbers[1] = 11;
            losingNumbers[0] = 2;
            losingNumbers[1] = 3;
            losingNumbers[2] = 12;
            pointNumbers[0] = 4;
            pointNumbers[1] = 5;
            pointNumbers[2] = 6;
            pointNumbers[3] = 8;
            pointNumbers[4] = 9;
            pointNumbers[5] = 10;
        }

        public int PlayerPoint
        {
            get
            {
                return point;
            }
        }

        public bool PlayerHasPoint
        {
            get
            {
                return hasPoint;
            }
        }

        public bool PlayerWin
        {
            get
            {
                return win;
            }
        }

        public bool PlayerLose
        {
            get
            {
                return lose;
            }
        }

        public bool GameState
        {
            get
            {
                return gameStarted;
            }
        }

        public int RollNumber
        {
            get
            {
                return rollNumber;
            }
        }

        public void StartGame()
        {
            gameStarted = true;
        }

        public void ResetGame()
        {
            hasPoint = false;
            gameStarted = false;
            win = false;
            lose = false;
            rollNumber = 0;
            point = 0;
        }

        // Returns true if the player has a point, false if the player loses, true if the player wins
        public bool FirstRoll(int diceTotal)
        {
            foreach(int i in pointNumbers)
            {
                if(i == diceTotal)
                {
                    hasPoint = true;
                    rollNumber += 1;
                    point = diceTotal;
                    return true;
                }
            }

            foreach(int i in winningNumbers)
            {
                if(i == diceTotal)
                {
                    win = true;
                    rollNumber += 1;
                    return true;
                }
            }

            // the die total was a 2, 3, or 12
            lose = true;
            rollNumber += 1;
            return false;
        }

        // Returns ture if the players rolls their point, false if they roll a 7
        public bool NextRoll(int diceTotal)
        {
            if (point == diceTotal)
            {
                win = true;
                rollNumber += 1;
                return true;
            }
            else if (finalLosingNumber == diceTotal)
            {
                lose = true;
                rollNumber += 1;
                return false;
            }
            else
            {
                rollNumber += 1;
                return true;
            }
        }

        public void Bid(ref uint bid, ref uint bank)
        {
            uint delta = 0u;

            if (PlayerWin == true)
            {
                bank = bank - bid;
                delta = 2 * bid;
                bank = bank + delta;
            }
            else if (PlayerLose == true)
            {
                bank = bank - bid;
            }
            bid = 0;
        }
    }
}
