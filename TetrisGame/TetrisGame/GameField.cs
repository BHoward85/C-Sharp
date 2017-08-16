using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using TetrisGame.Classes;
using TetrisGame.Supports;
using TetrisGame.Interfaces;

namespace TetrisGame
{
    [Serializable]
    class GameField
    {
        private IPolyomino[] tetrominoSet;
        private IPolyomino active;
        private IPolyominoFactory tf;
        private char[,] field;
        private int level;
        private int score;
        private Random rng;
        private string[] list;
        Thread t;

        public GameField()
        {
            list = new string[] { "1B", "2I", "3I", "3L", "3J"};
            tetrominoSet = new IPolyomino[list.Length];
            tf = new TetrominoFactory();
            field = new char[19,8];
            level = 0;
            score = 0;
            rng = new Random();
            BuildTetrominoSet();
        }

        private void SetField()
        {
            for(int row = 0; row < 19; row++)
            {
                for(int col = 0; col < 8; col++)
                {
                    field[row, col] = '_';
                }
            }
        }

        private void BuildTetrominoSet()
        {
            for(int index = 0; index < list.Length; index++)
            {
                tetrominoSet[index] = tf.BuildSmallMinos(list[index]);
            }
        }

        public void Run()
        {
            while(true)
            {
                active = tetrominoSet[rng.Next(tetrominoSet.Length)];

                while(true)
                {
                    
                }
            }
        }

        private void MoveDown()
        {

        }
    }
}
