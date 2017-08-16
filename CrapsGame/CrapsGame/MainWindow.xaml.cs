using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CrapsGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    /**~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
     **~ The dice images are based off of the PS1 and PS2 games ~
     **~ Devil Dice (1998) and Bombastic (2002)                 ~
     **~ © Shift                                                ~
     **~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
     **/
    public partial class MainWindow : Window
    {
        private Die die;
        private Rules rule;
        private bool gameStarted;
        private int playerWins;
        private int houseWins;
        private uint bank;
        private uint bid;
        private string[] files;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            files = new string[6];
            die = new Die(6);
            rule = new Rules();
            gameStarted = false;
            playerWins = 0;
            houseWins = 0;
            bank = 0u;
            bid = 0u;
            ALLINMAN.IsEnabled = false;
            Roll.IsEnabled = false;
            RollButton.IsEnabled = false;
            EndGame.IsEnabled = false;
            NewGameButton.Content = "New Game";
            UpdateBidBank();
            ResetFields();
            SetWins();            
            SetFiles();
            ResetDice();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            if(MessageBox.Show("Do you want to quit?", "Exit", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void UpdateBidBank()
        {
            PlayerBankTotal.Text = bank.ToString();
            PlayerBidBox.Text = bid.ToString();
        }

        private void SetWins()
        {
            PlayerWinTotal.Text = playerWins.ToString();
            HouseWinTotal.Text = houseWins.ToString();
        }

        private void ResetFields()
        {
            GameState.Content = "";
            DicePointLabel.Content = "";
            PointValue.Text = "0";
            FirstRoll.Text = "0";
            SecondRoll.Text = "0";
            TotalBox.Text = "0";
        }

        private void ResetDice()
        {
            DieImageOne.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\pic\0-Blank.png", UriKind.Absolute));
            DieImageTwo.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\pic\0-Blank.png", UriKind.Absolute));
            PointDieOnePic.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\pic\0-Blank.png", UriKind.Absolute));
            PointDieTwoPic.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + @"\pic\0-Blank.png", UriKind.Absolute));
        }

        private void SetFiles()
        {
            files[0] = ".\\pic\\1-DieOne.png";
            files[1] = ".\\pic\\2-DieTwo.png";
            files[2] = ".\\pic\\3-DieThree.png";
            files[3] = ".\\pic\\4-DieFour.png";
            files[4] = ".\\pic\\5-DieFive.png";
            files[5] = ".\\pic\\6-DieSix.png";
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame_Click(sender, e);
        }

        private void EndGame_Click(object sender, RoutedEventArgs e)
        {
            if (gameStarted == true && MessageBox.Show("Do you want to end the game?", "New Game", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ResetGame();
            }
        }

        private void ResetGame()
        {
            NewGameButton.Content = "New Game";
            gameStarted = false;
            Roll.IsEnabled = false;
            RollButton.IsEnabled = false;
            ALLINMAN.IsEnabled = false;
            EndGame.IsEnabled = false;
            PlayerBankTotal.IsEnabled = true;
            PlayerBidBox.IsEnabled = true;
            ResetDice();
            rule.ResetGame();
            rule.StartGame();
            ResetFields();
            playerWins = 0;
            houseWins = 0;
            SetWins();
            bank = 0;
            bid = 0;
            UpdateBidBank();
            RollNumberValue.Content = "0";
        }

        private void GameOver(object sender, RoutedEventArgs e)
        {
            if ((gameStarted == true && rule.PlayerLose == true && MessageBox.Show("The Game is over", "New Game", MessageBoxButton.OK) == MessageBoxResult.OK))
            {
                ResetGame();
            }
        }

        private void StartNewGame_Click(object sender, RoutedEventArgs e)
        {
            if(gameStarted == false)
            {
                gameStarted = true;
                GameState.Content = "";
            }

            if (rule.PlayerHasPoint == false)
            {
                RollNumberValue.Content = rule.RollNumber.ToString();
                if (!BankEnter()) return;
                if (!BidEnter()) return;
                PlayerBankTotal.IsEnabled = false;
                PlayerBidBox.IsEnabled = false;
                NewGameButton.Content = "Play Again";
                EndGame.IsEnabled = true;
                UpdateBidBank();
                ALLINMAN.IsEnabled = true;
                Roll.IsEnabled = true;
                RollButton.IsEnabled = true;
                ResetDice();
                rule.StartGame();
                ResetFields();
                SetWins();
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("The Game of Craps\n" +
                            "Build 1.0 under .NET Framework 4.5\n" +
                            "CPU type is x86 prefed\n\n" +
                            "The dice images are based off of the PS1 and PS2 games\n" +
                            "Devil Dice (1998) and Bombastic (2002)\n" +
                            "© Shift");
        }

        private void RuleInfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("A player rolls two dice where each die has six faces in the usual way\n" +
                            "(values 1 through 6).\n" +
                            "After the dice have come to rest the sum of the two upward faces is calculated.\n" +
                            "The first roll\n" + 
                            "\tIf the sum is 7 or 11 on the first throw the roller/player wins.\n" +
                            "\tIf the sum is 2, 3 or 12 the roller/player loses, that is the house wins.\n" +
                            "\tIf the sum is 4, 5, 6, 8, 9, or 10, that sum becomes\n" +
                            "\tthe roller/player's \"point\".\n" +
                            "Continue given the player's point\n" +
                            "\tNow the player must roll the \"point\" total before\n" +
                            "\trolling a 7 in order to win.\n" +
                            "\tIf they roll a 7 before rolling the point value they\n" + 
                            "\tgot on the first roll the roller/player loses (the 'house' wins).\n" +
                            "Player enters in a bank amount and bids from said bank,\n" +
                            "The Player wins two times the bid amount, if they lose they lose the bid,\n" + 
                            "when the Player loses all their bank the game is over");
        }

        private void AllIn_Click(object sender, RoutedEventArgs e)
        {
            if(bank > 0)
            {
                bid = bank;
                UpdateBidBank();
            }
        }

        private bool BankEnter()
        {
            uint n = 0u;

            if (uint.TryParse(PlayerBankTotal.Text, out n) == true && n > 0)
            {
                bank = n;
                return true;
            }
            else
            {
                MessageBox.Show("Please Enter in a Positve number for Bank");
                PlayerBankTotal.Focus();
                return false;
            }
        }

        private bool BidEnter()
        {
            uint n = 0u;

            if (uint.TryParse(PlayerBidBox.Text, out n) == true)
            {
                if (n > bank)
                {
                    MessageBox.Show("You are trying to bid more than you have, go all in or bid less");
                    PlayerBidBox.Focus();
                    return false;
                }
                else if (n == 0)
                {
                    MessageBox.Show("You must bid more than zero");
                    PlayerBidBox.Focus();
                    return false;
                }
                else
                {
                    bid = n;
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Please Enter in a Positve number for Bid");
                PlayerBidBox.Focus();
                return false;
            }
        }

        private void RollMenu_Click(object sender, RoutedEventArgs e)
        {
            if(gameStarted == true)
                Roll_Click(sender, e);
        }

        private void Roll_Click(object sender, RoutedEventArgs e)
        {
            if (gameStarted == true && rule.PlayerWin != true)
            {
                int rollOne = die.Roll();
                int rollTwo = die.Roll();

                DieImageOne.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + files[rollOne - 1], UriKind.Absolute));
                DieImageTwo.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + files[rollTwo - 1], UriKind.Absolute));

                FirstRoll.Text = rollOne.ToString();
                SecondRoll.Text = rollTwo.ToString();
                TotalBox.Text = (rollOne + rollTwo).ToString();
                
                if (rule.RollNumber < 1)
                    rule.FirstRoll(rollOne + rollTwo);
                else if (rule.RollNumber >= 1)
                    rule.NextRoll(rollOne + rollTwo);

                RollNumberValue.Content = rule.RollNumber.ToString();

                if(rule.PlayerWin == true)
                {
                    playerWins += 1;
                    PlayerWinTotal.Text = playerWins.ToString();
                    GameState.Content = "Win";
                }
                else if(rule.PlayerLose == true)
                {
                    houseWins += 1;
                    HouseWinTotal.Text = houseWins.ToString();
                    GameState.Content = "Lose";
                }
                else
                {
                    PointValue.Text = rule.PlayerPoint.ToString();
                    
                    if(rule.RollNumber == 1)
                    {
                        DicePointLabel.Content = "Point to Win";
                        PointDieOnePic.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + files[rollOne - 1], UriKind.Absolute));
                        PointDieTwoPic.Source = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + files[rollTwo - 1], UriKind.Absolute));
                    }
                }

                if (rule.PlayerWin == true || rule.PlayerLose == true)
                {
                    rule.Bid(ref bid, ref bank);
                    UpdateBidBank();

                    if (bank == 0)
                    {
                        MessageBox.Show("You busted the bank, it's not your night is it?, try again.");
                        GameOver(sender, e);
                    }

                    rule.ResetGame();
                    Roll.IsEnabled = false;
                    RollButton.IsEnabled = false;
                    PlayerBidBox.IsEnabled = true;
                }
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {  
                case Key.R: // Roll
                    RollMenu_Click(sender, e);
                    break;
                case Key.N: // New Game
                    StartNewGame_Click(sender, e);
                    break;
                case Key.E: // End game
                    EndGame_Click(sender, e);
                    break;
                case Key.Enter: // Entering Totals
                    if (PlayerBankTotal.IsFocused == true)
                        BankEnter();
                    else if (PlayerBidBox.IsFocused == true)
                        BidEnter();
                    else
                        MessageBox.Show("This button is for Player Bid and Bank entery");
                    break;
                case Key.X: // Exit
                    Exit_Click(sender, e);
                    break;
            }
        }
    }
}
