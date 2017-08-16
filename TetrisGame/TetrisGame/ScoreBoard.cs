using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisGame.Supports;
using TetrisGame.Structs;

namespace TetrisGame.Supports
{
    public class ScoreBoard
    {
        private ScoreInfo[] normalBoard;
        private ScoreInfo[] advanceBoard;
        private int curScore;
        private int curLevel;
        private int curLines;
        private bool curAdvMode;
        private string playerNameTag;

        public ScoreBoard()
        {
            normalBoard = new ScoreInfo[5];
            advanceBoard = new ScoreInfo[5];
            BuildNormalBoard();
            BuildAdvanceBoard();
        }

        public string PlayersNameTag
        {
            set
            {
                playerNameTag = value;
            }
        }

        public bool CurAdvMode
        {
            set
            {
                curAdvMode = value;
            }
        }

        public int CurLines
        {
            set
            {
                curLines = value;
            }
        }

        public int CurLevel
        {
            set
            {
                curLevel = value;
            }
        }

        public int CurScore
        {
            set
            {
                curScore = value;
            }
        }

        public void EnterData()
        {
            if (curAdvMode)
                PlaceAdvanceScore();
            else
                PlaceNormalScore();
        }

        private void BuildNormalBoard()
        {
            normalBoard[0].Name = "Kosuke";
            normalBoard[0].Score = 30000;
            normalBoard[0].Level = 10;
            normalBoard[0].Lines = 100;

            normalBoard[1].Name = "Eric";
            normalBoard[1].Score = 25000;
            normalBoard[1].Level = 9;
            normalBoard[1].Lines = 90;

            normalBoard[2].Name = "Chris";
            normalBoard[2].Score = 20000;
            normalBoard[2].Level = 8;
            normalBoard[2].Lines = 80;

            normalBoard[3].Name = "Dan";
            normalBoard[3].Score = 15000;
            normalBoard[3].Level = 7;
            normalBoard[3].Lines = 70;

            normalBoard[4].Name = "Shamima";
            normalBoard[4].Score = 10000;
            normalBoard[4].Level = 6;
            normalBoard[4].Lines = 60;
        }

        private void BuildAdvanceBoard()
        {
            advanceBoard[0].Name = "Tom";
            advanceBoard[0].Score = 50000;
            advanceBoard[0].Level = 10;
            advanceBoard[0].Lines = 275;

            advanceBoard[1].Name = "Stu";
            advanceBoard[1].Score = 40000;
            advanceBoard[1].Level = 9;
            advanceBoard[1].Lines = 225;

            advanceBoard[2].Name = "Paul";
            advanceBoard[2].Score = 30000;
            advanceBoard[2].Level = 8;
            advanceBoard[2].Lines = 180;

            advanceBoard[3].Name = "Tony";
            advanceBoard[3].Score = 20000;
            advanceBoard[3].Level = 7;
            advanceBoard[3].Lines = 140;

            advanceBoard[4].Name = "Bojian";
            advanceBoard[4].Score = 10000;
            advanceBoard[4].Level = 6;
            advanceBoard[4].Lines = 105;
        }

        private void PlaceNormalScore()
        {
            for (int index = 0; index < 5; index++)
            {
                if (normalBoard[index].Score < curScore)
                {
                    if (index < 4)
                    {
                        for (int jdex = 3; jdex >= index; jdex--)
                        {
                            normalBoard[jdex + 1].Name = normalBoard[jdex].Name;
                            normalBoard[jdex + 1].Score = normalBoard[jdex].Score;
                            normalBoard[jdex + 1].Level = normalBoard[jdex].Level;
                            normalBoard[jdex + 1].Lines = normalBoard[jdex].Lines;
                        }
                    }

                    normalBoard[index].Name = playerNameTag;
                    normalBoard[index].Score = curScore;
                    normalBoard[index].Level = curLevel;
                    normalBoard[index].Lines = curLines;

                    MessageBox.Show("Good game, " + playerNameTag + ", your place is " + (index + 1) + " of the Normal Score Board.");

                    break;
                }
            }
        }

        private void PlaceAdvanceScore()
        {
            for (int index = 0; index < 5; index++)
            {
                if (advanceBoard[index].Score < curScore)
                {
                    if (index < 4)
                    {
                        for (int jdex = 3; jdex >= index; jdex--)
                        {
                            advanceBoard[jdex + 1].Name = advanceBoard[jdex].Name;
                            advanceBoard[jdex + 1].Score = advanceBoard[jdex].Score;
                            advanceBoard[jdex + 1].Level = advanceBoard[jdex].Level;
                            advanceBoard[jdex + 1].Lines = advanceBoard[jdex].Lines;
                        }
                    }

                    advanceBoard[index].Name = playerNameTag;
                    advanceBoard[index].Score = curScore;
                    advanceBoard[index].Level = curLevel;
                    advanceBoard[index].Lines = curLines;

                    MessageBox.Show("Good game, " + playerNameTag + ", your place is " + (index + 1) + " of the Advance Score Board.");

                    break;
                }
            }
        }

        public void ShowNormalScores()
        {
            string str = string.Format("Normal Mode Score Board\n1st Place:\n{0}\n2nd Place:\n{1}\n3rd Place:\n{2}\n4th Place:\n{3}\n5th Place:\n{4}"
                                      , normalBoard[0].ToString(), normalBoard[1].ToString(), normalBoard[2].ToString()
                                      , normalBoard[3].ToString(), normalBoard[4].ToString());

            MessageBox.Show(str);
        }

        public void ShowAdvanceScores()
        {
            string str = string.Format("Advance Mode Score Board\n1st Place:\n{0}\n2nd Place:\n{1}\n3rd Place:\n{2}\n4th Place:\n{3}\n5th Place:\n{4}"
                                      , advanceBoard[0].ToString(), advanceBoard[1].ToString(), advanceBoard[2].ToString()
                                      , advanceBoard[3].ToString(), advanceBoard[4].ToString());

            MessageBox.Show(str);
        }
    }
}
