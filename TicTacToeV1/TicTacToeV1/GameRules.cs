using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeV1
{
    partial class TicTacToe : Form
    {
        private void DrawMark(int X, int Y)
        {
            if (startedGame == true)
            {
                if (playerTurn != '\0' && CheckOpenField() && field[X, Y].State == '_')
                {
                    field[X, Y].State = playerTurn;
                    Invalidate(new Rectangle(1, 25, this.DisplayRectangle.Width - 3, this.DisplayRectangle.Height - 49));

                    if (playerTurn != '\0' && playerTurn == 'O')
                    {
                        playerTurn = 'X';

                        if (vsCPU == true && startedGame == true && advCPU == false)
                        {
                            CheckWin();
                            CPUMove();
                        }
                        else if (vsCPU == true && startedGame == true && advCPU == true)
                        {
                            CheckWin();
                            AdvanceCPUMove();
                        }
                    }
                    else if (playerTurn != '\0' && playerTurn == 'X')
                        playerTurn = 'O';

                    PlayersTurnStatus.Text = "Player " + playerTurn.ToString() + " turn";
                }

                Invalidate(new Rectangle(1, 25, this.DisplayRectangle.Width - 3, this.DisplayRectangle.Height - 49));

                CheckWin();
            }
        }

        private void AdvanceCPUMove()
        {
            debugStatus.Text = "Checking for a move";
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (HasBlockingMove(row, col) == true && field[row, col].State == '_')
                    {
                        debugStatus.Text = "AdvCPU Playing Row:" + row.ToString() + ", Col:" + col.ToString();
                        DrawMark(row, col);
                        CheckWin();
                        return;
                    }
                    else if (HasWinningMove(row, col) == true && field[row, col].State == '_')
                    {
                        debugStatus.Text = "AdvCPU Playing Row:" + row.ToString() + ", Col:" + col.ToString();
                        DrawMark(row, col);
                        CheckWin();
                        return;
                    }
                }
            }
            if (superCPU == false)
                CPUMove();
            else
                SuperCPUMove();
            
            CheckWin();
            return;
        }

        private void SuperCPUMove()
        {
            if (field[1, 1].State == '_')
            {
                DrawMark(1, 1);
                CheckWin();
                return;
            }
            else
            {
                if (OpenCorners() == true)
                {
                    PlayOpenCorners();
                }
                else
                {
                    PlayOpenSides();
                }
            }
        }

        private void PlayOpenCorners()
        {
            Random ran = new Random();
            int[] corners = new int[] { 0, 2 };
            int row;
            int col;

            while(OpenCorners() == true)
            {
                row = corners[ran.Next(2)];
                col = corners[ran.Next(2)];

                if(field[row, col].State == '_')
                {
                    DrawMark(row, col);
                    CheckWin();
                    return;
                }
            }
        }

        private void PlayOpenSides()
        {
            Random rnd = new Random();
            int n;

            while(OpenSides())
            {
                n = rnd.Next(4);

                switch(n)
                {
                    case 0:
                        if(field[1, 0].State == '_')
                        {
                            DrawMark(1, 0);
                            CheckWin();
                            return;
                        }
                        break;
                    case 1: 
                        if (field[0, 1].State == '_')
                        {
                            DrawMark(0, 1);
                            CheckWin();
                            return;
                        }
                        break;
                    case 2:
                        if(field[1, 2].State == '_')
                        {
                            DrawMark(1, 2);
                            CheckWin();
                            return;
                        }
                        break;
                    default:
                        if(field[2, 1].State == '_')
                        {
                            DrawMark(2, 1);
                            CheckWin();
                            return;
                        }
                        break;
                }
            }
        }

        private bool OpenSides()
        {
            if (field[1, 0].State == '_')
                return true;
            else if (field[0, 1].State == '_')
                return true;
            else if (field[1, 2].State == '_')
                return true;
            else if (field[2, 1].State == '_')
                return true;

            return false;
        }

        private bool OpenCorners()
        {
            for (int index = 0; index < 3; index += 2)
            {
                for (int jdex = 0; jdex < 3; jdex += 2)
                {
                    if (field[index, jdex].State == '_')
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        private void CPUMove()
        {
            Random rnd = new Random();
            int X;
            int Y;

            while (CheckOpenField() == true && startedGame == true)
            {
                X = rnd.Next(3);
                Y = rnd.Next(3);
                if (field[X, Y].State == '_')
                {
                    debugStatus.Text = "CPU Playing Row:" + X.ToString() + ", Col:" + Y.ToString();
                    DrawMark(X, Y);
                    CheckWin();
                    return;
                }
            }
        }

        private bool HasBlockingMove(int X, int Y)
        {
            if (X == 1 && Y == 1)
                return CheckCenterBlock();
            else if ((X == 0 && Y == 0) || (X == 2 && Y == 2) || (X == 0 && Y == 2) || (X == 2 && Y == 0))
                return CheckCornersBlock(X, Y);
            else if ((X == 1 && Y == 0) || (X == 0 && Y == 1) || (X == 2 && Y == 1) || (X == 1 && Y == 2))
                return CheckSidesBlock(X, Y);

            debugStatus.Text = "Failed to find block space";
            return false;
        }
       
        private bool HasWinningMove(int X, int Y)
        {
            if (X == 1 && Y == 1)
                return CheckCenterWin();
            else if ((X == 0 && Y == 0) || (X == 2 && Y == 2) || (X == 0 && Y == 2) || (X == 2 && Y == 0))
                return CheckCornersWin(X, Y);
            else if ((X == 1 && Y == 0) || (X == 0 && Y == 1) || (X == 2 && Y == 1) || (X == 1 && Y == 2))
                return CheckSidesWin(X, Y);

            debugStatus.Text = "Failed to find win space";
            return false;
        }

        private bool CheckSidesWin(int X, int Y)
        {
            if (X == 0 && Y == 1)
            {
                if (field[0, 0].State == 'X' && field[0, 2].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[2, 1].State == 'X')
                    return true;
            }
            else if (X == 1 && Y == 0)
            {
                if (field[0, 0].State == 'X' && field[2, 0].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[1, 2].State == 'X')
                    return true;
            }
            else if (X == 2 && Y == 1)
            {
                if (field[2, 0].State == 'X' && field[2, 2].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[0, 1].State == 'X')
                    return true;
            }
            else if (X == 1 && Y == 2)
            {
                if (field[0, 2].State == 'X' && field[2, 2].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[1, 0].State == 'X')
                    return true;
            }

            debugStatus.Text = "Failed to find win Side";
            return false;
        }

        private bool CheckCenterWin()
        {
            if (field[0, 0].State == 'X' && field[2, 2].State == 'X')
                return true;
            else if (field[0, 1].State == 'X' && field[2, 1].State == 'X')
                return true;
            else if (field[0, 2].State == 'X' && field[2, 0].State == 'X')
                return true;
            else if (field[1, 0].State == 'X' && field[1, 2].State == 'X')
                return true;

            debugStatus.Text = "Failed to find win Center";
            return false;
        }

        private bool CheckCornersWin(int X, int Y)
        {
            if (X == 0 && Y == 0)
            {
                if (field[1, 0].State == 'X' && field[2, 0].State == 'X')
                    return true;
                else if (field[0, 1].State == 'X' && field[0, 2].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[2, 2].State == 'X')
                    return true;
            }
            else if (X == 2 && Y == 0)
            {
                if (field[2, 1].State == 'X' && field[2, 2].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[0, 2].State == 'X')
                    return true;
                else if (field[0, 0].State == 'X' && field[1, 0].State == 'X')
                    return true;
            }
            else if (X == 0 && Y == 2)
            {
                if (field[0, 0].State == 'X' && field[0, 1].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[2, 0].State == 'X')
                    return true;
                else if (field[1, 2].State == 'X' && field[2, 2].State == 'X')
                    return true;
            }
            else if (X == 2 && Y == 2)
            {
                if (field[2, 0].State == 'X' && field[2, 1].State == 'X')
                    return true;
                else if (field[1, 1].State == 'X' && field[0, 0].State == 'X')
                    return true;
                else if (field[0, 2].State == 'X' && field[2, 1].State == 'X')
                    return true;
            }

            debugStatus.Text = "Failed to find win Corner";
            return false;
        }

        private bool CheckCornersBlock(int X, int Y)
        {
            if (X == 0 && Y == 0)
            {
                if (field[1, 0].State == 'O' && field[2, 0].State == 'O')
                    return true;
                else if (field[0, 1].State == 'O' && field[0, 2].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[2, 2].State == 'O')
                    return true;
            }
            else if (X == 2 && Y == 0)
            {
                if (field[2, 1].State == 'O' && field[2, 2].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[0, 2].State == 'O')
                    return true;
                else if (field[0, 0].State == 'O' && field[1, 0].State == 'O')
                    return true;
            }
            else if (X == 0 && Y == 2)
            {
                if (field[0, 0].State == 'O' && field[0, 1].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[2, 0].State == 'O')
                    return true;
                else if (field[1, 2].State == 'O' && field[2, 2].State == 'O')
                    return true;
            }
            else if (X == 2 && Y == 2)
            {
                if (field[2, 0].State == 'O' && field[2, 1].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[0, 0].State == 'O')
                    return true;
                else if (field[0, 2].State == 'O' && field[2, 1].State == 'O')
                    return true;
            }

            debugStatus.Text = "Failed to find block Corner";
            return false;
        }

        private bool CheckSidesBlock(int X, int Y)
        {
            if (X == 0 && Y == 1)
            {
                if (field[0, 0].State == 'O' && field[0, 2].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[2, 1].State == 'O')
                    return true;
            }
            else if (X == 1 && Y == 0)
            {
                if (field[0, 0].State == 'O' && field[2, 0].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[1, 2].State == 'O')
                    return true;
            }
            else if (X == 2 && Y == 1)
            {
                if (field[2, 0].State == 'O' && field[2, 2].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[0, 1].State == 'O')
                    return true;
            }
            else if (X == 1 && Y == 2)
            {
                if (field[0, 2].State == 'O' && field[2, 2].State == 'O')
                    return true;
                else if (field[1, 1].State == 'O' && field[1, 0].State == 'O')
                    return true;
            }

            debugStatus.Text = "Failed to find block Side";
            return false;
        }

        private bool CheckCenterBlock()
        {
            if (field[0, 0].State == 'O' && field[2, 2].State == 'O')
                return true;
            else if (field[0, 1].State == 'O' && field[2, 1].State == 'O')
                return true;
            else if (field[0, 2].State == 'O' && field[2, 0].State == 'O')
                return true;
            else if (field[1, 0].State == 'O' && field[1, 2].State == 'O')
                return true;

            debugStatus.Text = "Failed to find block Center";
            return false;
        }

    }
}
