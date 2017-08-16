using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.Interfaces
{
    interface IPolyomino
    {
        int X { get; set; }

        int Y { get; set; }

        char Type { get; set; }

        int Tier { get; set; }

        byte[,] Shape { get; set; }

        byte[][,] Rotations { get; set; }

        byte[,] RightRotation();

        byte[,] LeftRotation();
    }

    interface IPolyominoFactory
    {
        IPolyomino BuildTetrominos(string type);

        IPolyomino BuildSmallMinos(string type);

        IPolyomino BuildPentominos(string type);
    }
}
