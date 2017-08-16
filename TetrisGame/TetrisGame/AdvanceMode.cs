﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisGame.Interfaces;
using TetrisGame.Classes;

namespace TetrisGame
{
    class AdvanceMode : IGameMode
    {
        private const int ADV_HEIGHT = 29;
        private const int ADV_WIDTH = 16;
        private const int ADV_PLAY_HEIGHT = 27;
        private const int ADV_PLAY_WIDTH = 14;
        private IPolyomino[] minoSet;
        private IPolyominoFactory tf;
        private Random rng;

        public AdvanceMode(string[] minoList)
        {
            tf = new TetrominoFactory();
            minoSet = new IPolyomino[minoList.Length];
            rng = new Random();

            BuildTetrominoSet(minoList);
        }

        private void BuildTetrominoSet(string[] list)
        {
            for (int index = 0; index < list.Length; index++)
            {
                if (list[index][0] == '5')
                    minoSet[index] = tf.BuildPentominos(list[index]);
                else if (list[index][0] == '4')
                    minoSet[index] = tf.BuildTetrominos(list[index]);
                else
                    minoSet[index] = tf.BuildSmallMinos(list[index]);
            }
        }

        public void NextLevel(ref double time, ref int level, ref int minoTier, ref int toNextLevel, ref Label NextLevelValue)
        {
            if (toNextLevel == 0)
            {
                toNextLevel = CheckNextLevel(level);
                NextLevelValue.Text = toNextLevel.ToString();
                level++;

                if (level <= 10)
                {
                    minoTier++;
                    
                    if(level % 3 == 0)
                        time = time * (1 / (1 + (0.0625 * (level - 2))));
                }
                else
                    time = time * (1 / (1 + (0.25 * (level - 10))));
            }
            else
                NextLevelValue.Text = toNextLevel.ToString();
        }

        public int CheckNextLevel(int level)
        {
            int next = 0;

            next = level * 5;

            return next;
        }

        public bool GameOverCheck(ref char[,] field, ref bool gameOver)
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 2; col < 14; col++)
                {
                    if (field[row, col] != '_')
                    {
                        gameOver = true;
                        return true;
                    }
                }
            }

            return false;
        }

        public void SetField(ref char[,] field)
        {
            for (int row = 0; row < ADV_HEIGHT; row++)
            {
                for (int col = 0; col < ADV_WIDTH; col++)
                {
                    if (col > 1 && col < ADV_PLAY_WIDTH && row < ADV_PLAY_HEIGHT)
                        field[row, col] = '_';
                    else if (col <= 1 || col >= ADV_PLAY_WIDTH || row >= ADV_PLAY_HEIGHT)
                        field[row, col] = '*';
                }
            }
        }

        public IPolyomino GetNextMino()
        {
            return minoSet[rng.Next(minoSet.Length)];
        }

        public void CheckForClearLines(ref char[,] field, ref int lines, ref int score, ref int level, ref int toNextLevel)
        {
            bool test = false;
            int n = 0;

            for (int row = ADV_PLAY_HEIGHT - 1; row >= 0; )
            {
                for (int col = 2; col <= ADV_PLAY_WIDTH; col++)
                {
                    if (field[row, col] == '_')
                    {
                        test = false;
                        break;
                    }
                    else if (field[row, col] != '_')
                        test = true;
                }
                if (test)
                {
                    ClearLines(ref field, row);
                    lines++;
                    n++;
                    if (toNextLevel > 0)
                        toNextLevel--;
                }
                else
                    row--;
            }
            
            if (n > 0)
            {
                score += 100 * level;
                n--;

                while (n > 0)
                {
                    score += 150 * level;
                    n--;
                }
            }
        }

        public void ClearLines(ref char[,] field, int row)
        {
            for (int col = 2; col <= ADV_PLAY_WIDTH; col++)
            {
                field[row, col] = '_';
            }

            for (int nrow = row - 1, orow = row; nrow >= 0 && orow >= 0; nrow--, orow--)
            {
                for (int col = 2; col <= ADV_PLAY_WIDTH; col++)
                {
                    field[orow, col] = field[nrow, col];
                }
            }
        }
    }
}
