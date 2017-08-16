using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using TetrisGame.Classes;
using TetrisGame.Supports;
using TetrisGame.Interfaces;
using System.Timers;

namespace TetrisGame
{
    public partial class MainWindow : Form
    {
        delegate void SetGameOverText(string text);
        // Const Data Set
        private const int ADV_HEIGHT = 29;
        private const int ADV_WIDTH = 16;
        private const int ADV_PLAY_HEIGHT = 27;
        private const int ADV_PLAY_WIDTH = 14;
        private const int NORM_PLAY_HEIGHT = 25;
        private const int NORM_PLAY_WIDTH = 12;
        private const int DRAW_HEIGHT = 540;
        private const int DRAW_WIDTH = 240;
        
        // Minos
        private IPolyomino[] tetrominoSet;
        private IPolyomino active;
        private IPolyomino nextMino;
        private IPolyominoFactory tf;
        private string[] advList;
        private string[] normList;

        // Draw Maps
        private char[,] field;
        private char[,] nextMinoPic;

        // Game Data
        private IGameMode mode;
        private int level;
        private int minoTier;
        private int toNextLevel;
        private int score;
        private int lines;
        private bool gameOver;
        private bool gameStarted;
        private bool gamePaused;
        private bool advMode;
        private Random rng;
        System.Timers.Timer tm;
        private double time;
        private ScoreBoard sb;
        private StreamReader saveIn;
        private StreamWriter saveOut;
        private string playersName;

        public MainWindow()
        {
            InitializeComponent();

            normList = new string[] { "4T", "4Z", "4S", "4I", "4O", "4J", "4L" };

            advList = new string[] { "1O", "2I", "3I", "3V"
                                , "4T", "4Z", "4S", "4I", "4O", "4J", "4L"
                                , "5I", "5B", "5D", "5L", "5J", "5P", "5K"
                                , "5N", "5U", "5W", "5G", "5Q", "5S", "5Z"
                                , "5T", "5H", "5Y", "5V"};

            active = new Polyomino();
            tf = new TetrominoFactory();
            field = new char[ADV_HEIGHT, ADV_WIDTH];
            nextMinoPic = new char[5, 5];
            time = 1000;
            level = 1;
            score = 0;
            lines = 0;
            minoTier = 1;
            toNextLevel = 10;
            rng = new Random();
            sb = new ScoreBoard();
            playersName = playerNameBox.Text;
                        
            gameOver = false;
            gameStarted = false;
            gamePaused = false;
            advMode = false;
            mode = new NormalMode(normList);
            modeValue.Text = "Normal";
            
            mode.SetField(ref field);

            tm = new System.Timers.Timer(time);
            tm.Elapsed += AutoDownMove_Tick;
            tm.AutoReset = true;
            tm.Enabled = true;

            SetStyle(ControlStyles.DoubleBuffer
                   | ControlStyles.AllPaintingInWmPaint
                   | ControlStyles.UserPaint, true);

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            menuItemEndGame.Enabled = false;
            menuItemNormal_Click(sender, e);
            menuItemResetGame.Enabled = false;
            menuItemPause.Enabled = false;
            //menuItemScorceBoards.Visible = false;
        }

        private void EndGame()
        {
            tm.Stop();
            menuItemLoad.Enabled = true;
            menuItemSave.Enabled = true;
            menuItemPause.Enabled = false;

            if (menuItemPause.Checked == true)
                menuItemPause.Checked = false;

            mode.SetField(ref field);
            ClearNextMinoField();

            level = 1;
            score = 0;
            minoTier = 1;
            lines = 0;
            if (advMode)
                toNextLevel = 5;
            else
                toNextLevel = 10;

            gameOver = false;
            gameStarted = false;
            gamePaused = false;
            RedrawField();
            Invalidate(new Rectangle(420, 80, 100, 100));
        }

        private void RunGame()
        {
            FindNextMino();
            menuItemLoad.Enabled = false;
            menuItemSave.Enabled = false;
            menuItemPause.Enabled = true;

            nextMino.Y = 0;
            nextMino.X = 7;
            active = nextMino;

            FindNextMino();

            PlaceActiveBackOnField();
            PlaceNextMinoPic();
            RedrawField();
            Invalidate(new Rectangle(420, 80, 100, 100));
            tm.Start();
            gameStarted = true; 
            gameStateLabel.Text = "Game ON!";
        }

        private void FindNextMino()
        {
            while (advMode)
            {
                nextMino = mode.GetNextMino();

                if (nextMino.Tier <= minoTier)
                    break;
            }

            if (!advMode)
            {
                nextMino = mode.GetNextMino();
            }
        }

        private void AutoDownMove_Tick(object sender, ElapsedEventArgs e)
        {
            if(gameStarted)
                DownMove();
        }

        private void RedrawField()
        {
            Invalidate(new Rectangle(150, 40, DRAW_WIDTH, DRAW_HEIGHT));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graph = e.Graphics;
            Pen pen = new Pen(Color.Black, 3);
            Pen blockPen = new Pen(Color.Black, 1);
            Pen redPen = new Pen(Color.Red, 3);

            graph.DrawRectangle(pen, 150, 40, DRAW_WIDTH, DRAW_HEIGHT);
            for (int row = 40, nrow = 0; nrow < ADV_PLAY_HEIGHT; nrow++, row = row + 20)
            {
                for (int col = 150, ncol = 2; ncol < ADV_PLAY_WIDTH; ncol++, col = col + 20)
                {
                    graph.FillRectangle(GetColor(nrow, ncol, field), col, row, 20, 20);
                    graph.DrawRectangle(blockPen, col, row, 20, 20);
                    //graph.DrawString(field[nrow, ncol].ToString(), new Font("Arial", 6, FontStyle.Bold), Brushes.Black, col + 8, row + 4);
                }
            }

            graph.DrawRectangle(redPen, 150, 40, 240, 100);

            for (int row = 80, n = 0; n < 5; row += 20, n++)
            { 
                for (int col = 420, m = 0; m < 5; col += 20, m++)
                {
                    graph.FillRectangle(GetColor(n, m, nextMinoPic), col, row, 20, 20);
                    graph.DrawRectangle(blockPen, col, row, 20, 20);
                }
            }

            mode.NextLevel(ref time, ref level, ref minoTier, ref toNextLevel, ref NextLevelValue);
            tm.Interval = time;
            CurrentLevel.Text = level.ToString();
            CurrentLineValue.Text = lines.ToString();
            ScoreValue.Text = score.ToString();
            base.OnPaint(e);
        }


        // Support functions
        private void ClearNextMinoField()
        {
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    nextMinoPic[row, col] = '_';
                }
            }
        }

        private Brush GetColor(int row, int col, char[,] array)
        {
            char c = array[row, col];

            switch (c)
            {
                case 'B':
                    return Brushes.MediumVioletRed;
                case 'D':
                    return Brushes.OrangeRed;
                case 'G':
                    return Brushes.OliveDrab;
                case 'H':
                    return Brushes.Teal;
                case 'I':
                    return Brushes.Cyan;
                case 'J':
                    return Brushes.Blue;
                case 'K':
                    return Brushes.Crimson;
                case 'L':
                    return Brushes.Orange;
                case 'N':
                    return Brushes.Gold;
                case 'O':
                    return Brushes.Yellow;
                case 'P':
                    return Brushes.Violet;
                case 'Q':
                    return Brushes.YellowGreen;
                case 'S':
                    return Brushes.Green;
                case 'T':
                    return Brushes.Purple;
                case 'U':
                    return Brushes.SkyBlue;
                case 'V':
                    return Brushes.MediumPurple;
                case 'W':
                    return Brushes.BlueViolet;
                case 'Y':
                    return Brushes.Indigo;
                case 'Z':
                    return Brushes.Red;
                case '*':
                    return Brushes.Gray;
                case '!':
                    return Brushes.Firebrick;
                case '?':
                    return Brushes.Black;
                default:
                    return Brushes.Tan;
            }
        }

        private void GetNextMino()
        {
            mode.CheckForClearLines(ref field, ref lines, ref score, ref level, ref toNextLevel);
           
            if(!mode.GameOverCheck(ref field, ref gameOver))
            {
                active = nextMino;

                FindNextMino();

                active.Y = 0;
                active.X = 7;
                PlaceActiveBackOnField();
                RedrawField();
                PlaceNextMinoPic();
                Invalidate(new Rectangle(420, 80, 100, 100));
            }
            else if (gameStarted == true)
            {
                gameStateLabel.Text = "Game Over, Man!, Game Over!";
                GameOverText("Game Over");
                tm.Stop();
                tm.Enabled = false;
                gameStarted = false;

                BlackOutField();

                SetPlayer();
            }
        }

        private void GameOverText(string text)
        {
            if (this.modeValue.InvokeRequired)
            {
                SetGameOverText a = new SetGameOverText(GameOverText);
                this.Invoke(a, text);
            }
            else
                modeValue.Text = text;
        }

        private async void BlackOutField()
        {

            for (int row = ADV_PLAY_HEIGHT - 1; row >= 0; row--)
            {
                for (int col = ADV_PLAY_WIDTH - 1; col >= 2; col--)
                {
                    if (field[row, col] == '_')
                        field[row, col] = '!';
                    else if (field[row, col] != '_' && field[row, col] != '*')
                        field[row, col] = '?';
                }
                RedrawField();
                await Task.Delay(25);
            }
        }

        private void SetPlayer()
        {
            sb.CurLevel = level;
            sb.CurScore = score;
            sb.CurLines = lines;
            sb.CurAdvMode = advMode;
            sb.PlayersNameTag = playersName;
            sb.EnterData();
        }

        private void PlaceNextMinoPic()
        {
            for (int row = 0; row < 5; row++ )
            {
                for (int col = 0; col < 5; col++)
                {
                    nextMinoPic[row, col] = '_';
                }
            }

            for (int row = 0, nrow = 0; row < 5 && nrow < nextMino.Shape.GetLength(0); row++, nrow++)
            {
                for (int col = 0, ncol = 0; col < 5 && ncol < nextMino.Shape.GetLength(0); col++, ncol++)
                {
                    nextMinoPic[row, col] = nextMino.Shape[nrow, ncol].ToTypeChar(nextMino.Type);
                }
            }
        }

        private void ClearActiveFromField()
        {
            for (int ydex = active.Y, row = 0; ydex < active.Shape.GetLength(0) + active.Y && ydex < ADV_HEIGHT && row < active.Shape.GetLength(0); ydex++, row++)
            {
                for (int xdex = active.X, col = 0; xdex < active.Shape.GetLength(0) + active.X && xdex <= ADV_WIDTH && xdex >= 0 && col < active.Shape.GetLength(0); xdex++, col++)
                {
                    if (active.Shape[row, col] == 1)
                        field[ydex, xdex] = '_';
                }
            }
        }

        private void PlaceActiveBackOnField()
        {
            for (int ydex = active.Y, row = 0; ydex < active.Shape.GetLength(0) + active.Y && ydex < ADV_HEIGHT && row < active.Shape.GetLength(0); ydex++, row++)
            {
                for (int xdex = active.X, col = 0; xdex < active.Shape.GetLength(0) + active.X && xdex <= ADV_WIDTH && xdex >= 0 && col < active.Shape.GetLength(0); xdex++, col++)
                {
                    if (active.Shape[row, col] == 1)
                        field[ydex, xdex] = active.Shape[row, col].ToTypeChar(active.Type);
                }
            }
        }

        // Rotations
        private void RightRotate()
        {
            if (CanRightRotate())
            {
                MoveMino();
                RedrawField();
            }
        }

        private bool CanRightRotate()
        {
            bool test = true;

            ClearActiveFromField();
            active.Shape = active.RightRotation();

            for (int xdex = active.X, col = 0; xdex < active.X + active.Shape.GetLength(0) && col < active.Shape.GetLength(0) && xdex <= ADV_WIDTH && xdex >= 0; xdex++, col++)
            {
                for (int ydex = active.Y, row = 0; ydex < active.Shape.GetLength(0) + active.Y && ydex < ADV_HEIGHT; ydex++, row++)
                {
                    if (active.Shape[row, col] == 1)
                    {
                        if (active.Shape[row, col] == 1 && (field[ydex, xdex] != '_' || field[ydex, xdex] == '*'))
                        {
                            test = false;
                            goto FailedMove;
                        }
                    }
                }
            }

        FailedMove:
            if (test == false)
            {
                active.Shape = active.LeftRotation();
                PlaceActiveBackOnField();
            }

            return test;
        }

        private void LeftRotate()
        {
            if(CanLeftRotate())
            {
                MoveMino();
                RedrawField();
            }
        }

        private bool CanLeftRotate()
        {
            bool test = true;

            ClearActiveFromField();
            active.Shape = active.LeftRotation();

            for (int xdex = active.X, col = 0; xdex < active.X + active.Shape.GetLength(0) && col < active.Shape.GetLength(0) && xdex <= ADV_WIDTH && xdex >= 0; xdex++, col++)
            {
                for (int ydex = active.Y, row = 0; ydex < active.Shape.GetLength(0) + active.Y && ydex < ADV_HEIGHT; ydex++, row++)
                {
                    if (active.Shape[row, col] == 1)
                    {
                        if (active.Shape[row, col] == 1 && (field[ydex, xdex] != '_' || field[ydex, xdex] == '*'))
                        {
                            test = false;
                            goto FailedMove;
                        }
                    }
                }
            }

        FailedMove:
            if (test == false)
            {
                active.Shape = active.RightRotation();
                PlaceActiveBackOnField();
            }

            return test;
        }

        // Left Movement opts
        private void LeftMove()
        {
            if (CheckLeftMove())
            {
                ClearActiveFromField();

                if (active.X - 1 >= 0)
                {
                    active.X -= 1;
                    MoveMino();
                }
                else
                {
                    PlaceActiveBackOnField();
                    RedrawField();
                }
                RedrawField();
            }
        }

        private bool CheckLeftMove()
        {
            bool test = true;

            ClearActiveFromField();

            // Check Move to the left
            
            for (int xdex = active.X - 1 , col = 0; xdex < active.X + active.Shape.GetLength(0) - 1 && col < active.Shape.GetLength(0) && xdex >= 0; xdex++, col++)
            {
                for (int ydex = active.Y, row = 0; ydex < active.Shape.GetLength(0) + active.Y && ydex < ADV_HEIGHT; ydex++, row++)
                {
                    if (active.Shape[row, col] == 1)
                    {
                        if (active.Shape[row, col] == 1 && (field[ydex, xdex] != '_' || field[ydex, xdex] == '*'))
                        {
                            test = false;
                            goto FailedMove;
                        }
                    }
                }
            }

        FailedMove:
            if (test == false)
            {
                PlaceActiveBackOnField();
            }

            return test;
        }

        // Right Movement opts
        private void RightMove()
        {
            if (CheckRightMove())
            {
                ClearActiveFromField();

                if (active.X + active.Shape.GetLength(0) <= ADV_WIDTH)
                {
                    active.X += 1;
                    MoveMino();
                }
                else
                {
                    PlaceActiveBackOnField();
                    RedrawField();
                }
                RedrawField();
            }
        }

        private bool CheckRightMove()
        {
            bool test = true;

            ClearActiveFromField();

            // Checks the move to the right
            for (int xdex = active.X + 1, col = 0; xdex < active.X + active.Shape.GetLength(0) + 1 && col < active.Shape.GetLength(0) && xdex <= 16; xdex++, col++)
            {
                for (int ydex = active.Y, row = 0; ydex < active.Shape.GetLength(0) + active.Y && ydex < ADV_HEIGHT; ydex++, row++)
                {
                    if (active.Shape[row, col] == 1)
                    {
                        if (active.Shape[row, col] == 1 && (field[ydex, xdex] != '_' || field[ydex, xdex] == '*'))
                        {
                            test = false;
                            goto FailedMove;
                        }
                    }
                }
            }

        FailedMove:
            if (test == false)
            {
                PlaceActiveBackOnField();
            }

            return test;
        }

        // DownWard Movement opts
        private void DownMove()
        {
            lock(new object())
            {
                if (CheckDownMove() == true)
                {
                    ClearActiveFromField();

                    if (active.Y + active.Shape.GetLength(0) + 1 <= ADV_HEIGHT)
                    {
                        active.Y += 1;
                        MoveMino();
                    }
                    else
                    {
                        PlaceActiveBackOnField();
                        RedrawField();
                        GetNextMino();
                    }
                    RedrawField();
                }
                else
                {
                    RedrawField();
                    GetNextMino();
                }
            }
        }

        private bool CheckDownMove()
        {
            bool test = true;

            ClearActiveFromField();

            for (int ydex = active.Y + active.Shape.GetLength(0), row = active.Shape.GetLength(0) - 1; ydex < ADV_HEIGHT && ydex >= active.Y && row >= 0; ydex--, row--)
            {
                for (int xdex = active.X + active.Shape.GetLength(0) - 1, col = active.Shape.GetLength(0) - 1; xdex >= active.X && col >= 0; xdex--, col--)
                {
                    if (active.Shape[row, col] == 1)
                    {
                        if (active.Shape[row, col] == 1 && (field[ydex, xdex] != '_' || field[ydex, xdex] == '*'))
                        {
                            test = false;
                            goto FailedMove;
                        }
                    }
                }
            }

            FailedMove:
            if (test == false)
            {
                PlaceActiveBackOnField();
            }

            return test;
        }


        /// <summary>
        /// Moves the Mino based on its X,Y values
        /// </summary>
        private void MoveMino()
        {
            PlaceActiveBackOnField();
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            tm.Dispose();
        }

        private void SlamDown()
        {
            if(gameStarted == true)
            {
                while (CheckDownMove())
                {
                    DownMove();
                }
                DownMove();
            }
        }

        private void PauseGame()
        {
            if(gamePaused)
            {
                gamePaused = false;
                menuItemPause.Checked = false;
                menuItemLoad.Enabled = false;
                menuItemSave.Enabled = false;

                if(advMode)
                    modeValue.Text = "Advance";
                else
                    modeValue.Text = "Normal";

                tm.Start();
            }
            else
            {
                gamePaused = true;
                menuItemPause.Checked = true;
                menuItemLoad.Enabled = true;
                menuItemSave.Enabled = true;
                modeValue.Text = "Pause";
                tm.Stop();
            }
        }

        private void NextLevel()
        {
            int tempNextLevel = 0;
            mode.NextLevel(ref time, ref level, ref minoTier, ref tempNextLevel, ref NextLevelValue);
            tm.Interval = time;
            toNextLevel += tempNextLevel;
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameOver == false)
            {

                switch (e.KeyCode)
                {
                    case Keys.Down:
                        if(!gamePaused)
                            DownMove();
                        break;
                    case Keys.Left:
                        if (!gamePaused)
                            LeftMove();
                        break;
                    case Keys.Right:
                        if (!gamePaused)
                            RightMove();
                        break;
                    case Keys.A: // Rotate Mino left
                        if (!gamePaused)
                            LeftRotate();
                        break;
                    case Keys.S: // Rotate Mino Right
                        if (!gamePaused)
                            RightRotate();
                        break;
                    case Keys.Space: // Quick Drop
                        if (!gamePaused)
                            SlamDown();
                        break;
                    case Keys.Home: // Skip level
                        if (!gamePaused)
                            NextLevel();
                        break;
                    case Keys.P:
                        PauseGame();
                        break;
                }
            }
        }

        private void menuItemPause_Click(object sender, EventArgs e)
        {
            PauseGame();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemNewGame_Click(object sender, EventArgs e)
        {
            playersName = playerNameBox.Text;
            playerNameBox.Enabled = false;
            this.Focus();
            RunGame();

            menuItemResetGame.Enabled = true;
            menuItemEndGame.Enabled = true;
            menuItemNewGame.Enabled = false;
            menuItemNormal.Enabled = false;
            menuItemAdvance.Enabled = false;
        }

        private void RerunGame()
        {
            playerNameBox.Text = playersName;
            playerNameBox.Enabled = false;
            this.Focus();
            tm.Interval = time;
            RunGame();
            PauseGame();
            menuItemResetGame.Enabled = true;
            menuItemEndGame.Enabled = true;
            menuItemNewGame.Enabled = false;
            menuItemNormal.Enabled = false;
            menuItemAdvance.Enabled = false;
        }

        private void menuItemEndGame_Click(object sender, EventArgs e)
        {
            playerNameBox.Enabled = true;
            EndGame();

            NextLevelValue.Text = "0";
            CurrentLineValue.Text = "0";
            CurrentLevel.Text = "0";

            if (advMode)
            {
                modeValue.Text = "Advance";
                toNextLevel = 5;
            }
            else
            {
                modeValue.Text = "Normal";
                toNextLevel = 10;
            }

            score = 0;
            lines = 0;
            level = 1;
            minoTier = 1;
            time = 1000;
            tm.Interval = time;

            menuItemResetGame.Enabled = false;
            menuItemEndGame.Enabled = false;
            menuItemNewGame.Enabled = true;
            menuItemAdvance.Enabled = true;
            menuItemNormal.Enabled = true;
        }

        private void menuItemNormal_Click(object sender, EventArgs e)
        {
            menuItemNormal.Checked = true;
            menuItemAdvance.Checked = false;

            toNextLevel = 10;
            score = 0;
            lines = 0;
            level = 1;
            minoTier = 1;

            mode = new NormalMode(normList);
            mode.SetField(ref field);
            RedrawField();
            advMode = false;
            modeValue.Text = "Normal";
        }

        private void menuItemAdvance_Click(object sender, EventArgs e)
        {
            menuItemNormal.Checked = false;
            menuItemAdvance.Checked = true;

            toNextLevel = 5;
            score = 0;
            lines = 0;
            level = 1;
            minoTier = 1;
            mode = new AdvanceMode(advList);
            mode.SetField(ref field);
            RedrawField();
            advMode = true;
            modeValue.Text = "Advance";
        }

        private void menuItemNormalMode_Click(object sender, EventArgs e)
        {
            sb.ShowNormalScores();
        }

        private void menuItemAdvanceMode_Click(object sender, EventArgs e)
        {
            sb.ShowAdvanceScores();
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saver = new SaveFileDialog();
            DialogResult dr;

            saver.InitialDirectory = Directory.GetCurrentDirectory();
            dr = saver.ShowDialog();

            if(dr.ToString() == "OK")
            {
                saveOut = new StreamWriter(saver.FileName);
                SaveGame();
            }
        }

        private void SaveGame()
        {
            saveOut.WriteLine("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}", advMode, level, minoTier, score, lines, toNextLevel, time, playersName);
            ClearActiveFromField();

            for(int row = 0; row < ADV_HEIGHT; row++)
            {
                for(int col = 0; col < ADV_WIDTH; col++)
                {
                    if(col == 0)
                        saveOut.Write("{0}", field[row, col]);
                    else
                        saveOut.Write(",{0}", field[row, col]);
                }
                saveOut.WriteLine();
            }

            PlaceActiveBackOnField();
            saveOut.Flush();
            saveOut.Close();
        }

        private void menuItemLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog loader = new OpenFileDialog();
            DialogResult dr;


            if (gameStarted)
                menuItemEndGame_Click(sender, e);

            loader.InitialDirectory = Directory.GetCurrentDirectory();
            dr = loader.ShowDialog();

            if(dr.ToString() == "OK")
            {
                saveIn = new StreamReader(loader.FileName);
                LoadGame();
            }
        }

        private void LoadGame()
        {
            string temp = saveIn.ReadLine();
            string[] ara = temp.Split(':');
            
            advMode = bool.Parse(ara[0]);
            level = int.Parse(ara[1]);
            minoTier = int.Parse(ara[2]);
            score = int.Parse(ara[3]);
            lines = int.Parse(ara[4]);
            toNextLevel = int.Parse(ara[5]);
            time = double.Parse(ara[6]);
            playersName = ara[7];

            for (int index = 0; index < ADV_HEIGHT; index++)
            {
                string[] tempRow = saveIn.ReadLine().Split(',');

                for(int jdex = 0; jdex < ADV_WIDTH; jdex++)
                {
                    field[index, jdex] = char.Parse(tempRow[jdex]);
                }
            }

            RedrawField();

            if (advMode)
            {
                mode = new AdvanceMode(advList);
                menuItemNormal.Checked = false;
                menuItemAdvance.Checked = true;
                modeValue.Text = "Advance";
            }
            else
            {
                mode = new NormalMode(normList);
                menuItemNormal.Checked = true;
                menuItemAdvance.Checked = false;
                modeValue.Text = "Normal";
            }

            RerunGame();
        }

        private void menuItemResetGame_Click(object sender, EventArgs e)
        {
            menuItemEndGame_Click(sender, e);
            menuItemNewGame_Click(sender, e);
        }

        private void menuItemHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advance Tetris\n"
                          + "There are two game modes\n"
                          + "* Normal Mode: Orginal Tetris\n"
                          + "* Advance Mode: Play with up to 29 Minos\n"
                          + "\nLoad and Save options alow you to save your game and load it\n"
                          + "at later time to continue you game\n"
                          + "\nNew game: starts a new game with the player selected mode\n"
                          + "Reset game: restarts the game\n"
                          + "End game: ends the current game\n\n"
                          + "The game is over when any non-active mino is inside the red box at the top\n"
                          + "The main way to score is to clear lines by making a row with out gaps\n"
                          + "The more rows clear in play, the more points are scored\n"
                          + "one row = 100 * level, and for each extra row is 50 more points\n\n"
                          + "Controls:\n- Left and Right arrow keys move the mino to the left or to the right\n"
                          + "- Down arrow key moves the mino down on row\n"
                          + "- Space Bar slams the active mino down\n"
                          + "- A key rotates the mino to right\n"
                          + "- S key rotates the mino to left\n"
                          + "- P key Pauses the game\n"
                          + "- Ctrl + R: resets the game\n"
                          + "- Ctrl + G: starts a new game\n"
                          + "- Ctrl + D: ends current game\n"
                          + "- Ctrl + X: Exit the game");
        }

        private void menuItemGameInfo_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advance Tetris\n"
                          + "Build 1.0 under 4.5 .NET Framework\n"
                          + "Using C# 5.0 CPU set to x86 prefer\n"
                          + "By Brad Howard\n"
                          + "Tetris © The Tetris Company, LLC");
        }
    }
}
