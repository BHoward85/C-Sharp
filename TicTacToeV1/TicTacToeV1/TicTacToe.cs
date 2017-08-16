/*****************************************************
 ** Notes, Extra Credit done                        **
 ** Super CPU is a smart CPU                        **
 ** this CPU will use the best move to prevent      **
 ** the player from winning and Aims to win as well **
 *****************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeV1
{
    public partial class TicTacToe : Form
    {
        private GameSquare[,] field;
        private char playerTurn;
        private bool vsCPU;
        private bool startedGame;
        private bool advCPU;
        private bool superCPU;
        private WinCombo[] winSet;
        public TicTacToe()
        {
            InitializeComponent();
        }

        private void TicTacToe_Load(object sender, EventArgs e)
        {
            field = new GameSquare[3, 3];
            winSet = new WinCombo[8];
            startedGame = false;
            vsCPU = false;
            advCPU = false;
            superCPU = false;
            menuItemAdvanceCPU.Enabled = false;
            menuItemSuperCPU.Enabled = false;
            menuItemEndGame.Enabled = false;
            debugStatus.Visible = false;
            gameState.Visible = false;
            BuildField();
            SetField();
            SetWinLines();

            CPUMode.Text = "CPU Mode Off";
            playerTurn = 'O';
        }

        private void SetWinLines()
        {
            winSet[0] = new WinCombo(0, 0, 0, 1, 0, 2);
            winSet[1] = new WinCombo(1, 0, 1, 1, 1, 2);
            winSet[2] = new WinCombo(2, 0, 2, 1, 2, 2);
            winSet[3] = new WinCombo(0, 0, 1, 0, 2, 0);
            winSet[4] = new WinCombo(0, 1, 1, 1, 2, 1);
            winSet[5] = new WinCombo(0, 2, 1, 2, 2, 2);
            winSet[6] = new WinCombo(0, 0, 1, 1, 2, 2);
            winSet[7] = new WinCombo(0, 2, 1, 1, 2, 0);
        }

        private void BuildField()
        {
            for(int index = 0; index < 3; index++)
            {
                for(int jdex = 0; jdex < 3; jdex++)
                {
                    field[index, jdex] = new GameSquare();
                }
            }
        }

        private void SetField()
        {
            int[] Xs = { 1, this.DisplayRectangle.Width / 3, (2 * this.DisplayRectangle.Width) / 3 };
            int[] Ys = { 25, this.DisplayRectangle.Height / 3, (2 * this.DisplayRectangle.Height) / 3 };

            for (int index = 0; index < Xs.Length; index++)
            {
                for(int jdex = 0; jdex < Ys.Length; jdex++)
                {
                    field[index, jdex].X = Xs[index];
                    field[index, jdex].Y = Ys[jdex];
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Pen pen = new Pen(Color.Black, 3);

            graph.DrawRectangle(pen, 1, 25, this.DisplayRectangle.Width - 3, this.DisplayRectangle.Height - 49);
            graph.DrawLine(pen, this.DisplayRectangle.Width / 3, 40, this.DisplayRectangle.Width / 3, this.DisplayRectangle.Height - 40);
            graph.DrawLine(pen, (2 * this.DisplayRectangle.Width) / 3, 40, (2 * this.DisplayRectangle.Width) / 3, this.DisplayRectangle.Height - 40);
            graph.DrawLine(pen, 20, this.DisplayRectangle.Height / 3, this.DisplayRectangle.Width - 20, this.DisplayRectangle.Height / 3);
            graph.DrawLine(pen, 20, (2 * this.DisplayRectangle.Height) / 3, this.DisplayRectangle.Width - 20, (2 * this.DisplayRectangle.Height) / 3);

            if (startedGame == true)
            {
                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        if(field[row, col].State == 'O')
                            graph.DrawString("O", new Font("Arial", 108, FontStyle.Bold), Brushes.Red, field[row, col].X, field[row, col].Y);
                        else if(field[row, col].State == 'X')
                            graph.DrawString("X", new Font("Arial", 108, FontStyle.Bold), Brushes.Blue, field[row, col].X, field[row, col].Y);
                    }
                }
            }

            base.OnPaint(e);
        }

        private void CheckWin()
        {
            char[] playerSet = new char[3];

            for(int index = 0; index < 8; index++)
            {
                playerSet[0] = field[winSet[index][0][0], winSet[index][0][1]].State;
                playerSet[1] = field[winSet[index][1][0], winSet[index][1][1]].State;
                playerSet[2] = field[winSet[index][2][0], winSet[index][2][1]].State;

                if (playerSet[0] == playerSet[1] && playerSet[1] == playerSet[2] && playerSet[0] == playerSet[2])
                {
                    if(playerSet[0] != '_' && playerSet[1] != '_' && playerSet[2] != '_')
                    {
                        MessageBox.Show("Win for " + playerSet[0]);
                        menuItemEndGame_Click(this, new EventArgs());
                        return;
                    }
                }
            }

            if(CheckOpenField() == false)
            {
                MessageBox.Show("The Game is a Tie");
                menuItemEndGame_Click(this, new EventArgs());
            }
        }

        private bool CheckOpenField()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if(field[row, col].State == '_')
                        return true;
                }
            }

            return false;
        }

        private void TicTacToe_MouseClick(object sender, MouseEventArgs e)
        {
            if(playerTurn == '\0')
            {
                playerTurn = 'O';
            }

            if (e.Y > 24 && e.Y < (this.DisplayRectangle.Height - 25))
            {
                if(e.X < (this.DisplayRectangle.Width / 3) && e.Y < (this.DisplayRectangle.Height / 3))
                {
                    gameState.Text = "Click Zone 0 (0, 0)";
                    DrawMark(0, 0);
                }
                else if (e.X >= (this.DisplayRectangle.Width / 3) && e.X < ((2 * this.DisplayRectangle.Width) / 3) && e.Y < (this.DisplayRectangle.Height / 3))
                {
                    gameState.Text = "Click Zone 1 (1, 0)";
                    DrawMark(1, 0);
                }
                else if (e.X >= ((2 * this.DisplayRectangle.Width) / 3) && e.Y < (this.DisplayRectangle.Height / 3))
                {
                    gameState.Text = "Click Zone 2 (2, 0)";
                    DrawMark(2, 0);
                }          
                else if (e.X < (this.DisplayRectangle.Width / 3) && e.Y >= (this.DisplayRectangle.Height / 3) && e.Y < ((2 * this.DisplayRectangle.Height) / 3))
                {
                    gameState.Text = "Click Zone 3  (0, 1)";
                    DrawMark(0, 1);
                }
                else if (e.X >= (this.DisplayRectangle.Width / 3) && e.X < ((2 * this.DisplayRectangle.Width) / 3) && e.Y >= (this.DisplayRectangle.Height / 3) && e.Y < ((2 * this.DisplayRectangle.Height) / 3))
                {
                    gameState.Text = "Click Zone 4 (1, 1)";
                    DrawMark(1, 1);
                }
                else if (e.X >= ((2 * this.DisplayRectangle.Width) / 3) && e.Y >= (this.DisplayRectangle.Height / 3) && e.Y < ((2 * this.DisplayRectangle.Height) / 3))
                {
                    gameState.Text = "Click Zone 5 (2, 1)";
                    DrawMark(2, 1);
                }
                else if (e.X < (this.DisplayRectangle.Width / 3) && e.Y >= ((2 * this.DisplayRectangle.Height) / 3))
                {
                    gameState.Text = "Click Zone 6 (0, 2)";
                    DrawMark(0, 2);
                }
                else if (e.X >= (this.DisplayRectangle.Width / 3) && e.X < ((2 * this.DisplayRectangle.Width) / 3) && e.Y >= ((2 * this.DisplayRectangle.Height) / 3))
                {
                    gameState.Text = "Click Zone 7 (1, 2)";
                    DrawMark(1, 2);
                }
                else if (e.X >= ((2 * this.DisplayRectangle.Width) / 3) && e.Y >= ((2 * this.DisplayRectangle.Height) / 3))
                {
                    gameState.Text = "Click Zone 8 (2, 2)";
                    DrawMark(2, 2);
                }
            }
        }

        private void FlipCoin()
        {
            Random rnd = new Random();
            int flip = rnd.Next(2);

            if (flip == 1)
            {
                playerTurn = 'O';
                MessageBox.Show("Player O wins the coin toss");
            }
            else
            {
                playerTurn = 'X';
                MessageBox.Show("Player X wins the coin toss");
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemNewGame_Click(object sender, EventArgs e)
        {
            if(startedGame == false)
            {
                startedGame = true;
                menuItemEndGame.Enabled = true;
                menuItemNewGame.Enabled = false;
                menuItemPlayCPU.Enabled = false;
                menuItemAdvanceCPU.Enabled = false;
                menuItemSuperCPU.Enabled = false;

                FlipCoin();

                if (playerTurn == 'X' && vsCPU == true)
                {
                    if(advCPU == false)
                        CPUMove();
                    else if(advCPU == true)
                        AdvanceCPUMove();
                }
            }
        }

        private void menuItemEndGame_Click(object sender, EventArgs e)
        {
            for(int index = 0; index < 3; index++)
            {
                for(int jdex = 0; jdex < 3; jdex++)
                {
                    field[index, jdex].State = '_';
                }
            }

            startedGame = false;
            menuItemEndGame.Enabled = false;
            menuItemNewGame.Enabled = true;
            menuItemPlayCPU.Enabled = true;
            menuItemAdvanceCPU.Enabled = true;
            menuItemSuperCPU.Enabled = true;

            Invalidate(new Rectangle(1, 25, this.DisplayRectangle.Width - 3, this.DisplayRectangle.Height - 49));
        }

        private void menuItemPlayCPU_Click(object sender, EventArgs e)
        {
            if (menuItemPlayCPU.Checked == false)
            {
                menuItemPlayCPU.Checked = true;
                menuItemAdvanceCPU.Enabled = true;
                vsCPU = true;
                CPUMode.Text = "CPU Mode Random";
            }
            else
            {
                menuItemPlayCPU.Checked = false;
                menuItemAdvanceCPU.Enabled = false;
                menuItemAdvanceCPU.Checked = false;
                menuItemSuperCPU.Enabled = false;
                menuItemSuperCPU.Checked = false;
                vsCPU = false;
                advCPU = false;
                superCPU = false;
                CPUMode.Text = "CPU Mode Off";
            }
        }

        private void menuItemAdvanceCPU_Click(object sender, EventArgs e)
        {
            if (menuItemAdvanceCPU.Checked == false)
            {
                menuItemAdvanceCPU.Checked = true;
                menuItemSuperCPU.Enabled = true;
                advCPU = true;
                CPUMode.Text = "CPU Mode Adv";
            }
            else
            {
                menuItemAdvanceCPU.Checked = false;
                menuItemSuperCPU.Enabled = false;
                menuItemSuperCPU.Checked = false;
                advCPU = false;
                CPUMode.Text = "CPU Mode Random";
            }
        }

        private void menuItemSuperCPU_Click(object sender, EventArgs e)
        {
            if (menuItemSuperCPU.Checked == false)
            {
                menuItemSuperCPU.Checked = true;
                advCPU = true;
                superCPU = true;
                CPUMode.Text = "CPU Mode Super";
            }
            else
            {
                menuItemSuperCPU.Checked = false;
                superCPU = false;
                CPUMode.Text = "CPU Mode Adv";
            }
        }

        private void menuItemRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The goal of the game is to get three in a row\n"
                          + "The game modes are, \n2 Player mode\nVs. Easy Computer\nVs. Advance Computer\nVs. Super Computer\n"
                          + "The ways to win, get 3 in a row in horizontal, vertical, or diagonal.");
        }

        private void menuItemInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tic Tac Toe\nVer. 1.0\nBuild under .NET 4.5 prefer x86 CPU");
        }
    }
}
