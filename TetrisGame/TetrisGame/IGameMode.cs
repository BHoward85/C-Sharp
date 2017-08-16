using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TetrisGame.Interfaces
{
    interface IGameMode
    {
        void NextLevel(ref double time, ref int level, ref int minoTier, ref int toNextLevel, ref Label NextLevelValue);

        int CheckNextLevel(int level);

        bool GameOverCheck(ref char[,] field, ref bool gameOver);

        void SetField(ref char[,] field);

        IPolyomino GetNextMino();

        void CheckForClearLines(ref char[,] field, ref int lines, ref int score, ref int level, ref int toNextLevel);

        void ClearLines(ref char[,] field, int row);
    }
}
