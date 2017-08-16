using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Interfaces;
using TetrisGame.Structs;
using TetrisGame.Classes;
using TetrisGame.Supports;

namespace TetrisGame
{
    class TetrominoFactory : IPolyominoFactory
    {
        private IPolyomino mino = new Polyomino();
        
        public IPolyomino BuildSmallMinos(string type)
        {
            switch(type) // Monomino, Domino, Tromino
            {
                case "1O": // 1
                    mino = Build_1O(type[1]);
                    break;
                case "2I": // 2
                    mino = Build_2I(type[1]);
                    break;
                case "3I": // 3
                    mino = Build_3I(type[1]);
                    break;
                case "3V": // 3
                    mino = Build_3V(type[1]);
                    break;
            }

            return mino;
        }

        public IPolyomino BuildTetrominos(string type)
        {
            switch(type) // 7
            {
                case "4I": // 4
                    mino = Build_4I(type[1]);
                    break;
                case "4J": // 4
                    mino = Build_4J(type[1]);
                    break;
                case "4L": // 4
                    mino = Build_4L(type[1]);
                    break;
                case "4O": // 4
                    mino = Build_4O(type[1]);
                    break;
                case "4S": // 4
                    mino = Build_4S(type[1]);
                    break;
                case "4T": // 4
                    mino = Build_4T(type[1]);
                    break;
                case "4Z": // 4
                    mino = Build_4Z(type[1]);
                    break;
            }

            return mino;
        }

        public IPolyomino BuildPentominos(string type)
        {
            switch(type) // 18
            {
                case "5I":
                    mino = Build_5I(type[1]);
                    break;
                case "5B":
                    mino = Build_5B(type[1]);
                    break;
                case "5D":
                    mino = Build_5D(type[1]);
                    break;
                case "5L":
                    mino = Build_5L(type[1]);
                    break;
                case "5J":
                    mino = Build_5J(type[1]);
                    break;
                case "5P":
                    mino = Build_5P(type[1]);
                    break;
                case "5K":
                    mino = Build_5K(type[1]);
                    break;
                case "5N":
                    mino = Build_5N(type[1]);
                    break;
                case "5U":
                    mino = Build_5U(type[1]);
                    break;
                case "5W":
                    mino = Build_5W(type[1]);
                    break;
                case "5G":
                    mino = Build_5G(type[1]);
                    break;
                case "5Q":
                    mino = Build_5Q(type[1]);
                    break;
                case "5S":
                    mino = Build_5S(type[1]);
                    break;
                case "5Z":
                    mino = Build_5Z(type[1]);
                    break;
                case "5T":
                    mino = Build_5T(type[1]);
                    break;
                case "5H":
                    mino = Build_5H(type[1]);
                    break;
                case "5Y":
                    mino = Build_5Y(type[1]);
                    break;
                case "5V":
                    mino = Build_5V(type[1]);
                    break;
            }

            return mino;
        }

        // Order 1-3

        private IPolyomino Build_1O(char type)
        {
            IPolyomino tet = new Polyomino(type, 1);
            byte[,] shape = new byte[1, 1] {{1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_2I(char type)
        {
            IPolyomino tet = new Polyomino(type, 1);
            byte[,] shape = new byte[2, 2] {{1,1}
                                           ,{0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_3V(char type)
        {
            IPolyomino tet = new Polyomino(type, 1);
            byte[,] shape = new byte[2, 2] {{1,0}
                                           ,{1,1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_3I(char type)
        {
            IPolyomino tet = new Polyomino(type, 1);
            byte[,] shape = new byte[3, 3] {{0,0,0}
                                           ,{1,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        // Order 4 Minos

        private IPolyomino Build_4I(char type)
        {
            IPolyomino tet = new Polyomino(type, 1);
            byte[,] shape = new byte[4, 4] {{0,0,0,0}
                                           ,{0,0,0,0}
                                           ,{1,1,1,1}
                                           ,{0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_4J(char type)
        {
            IPolyomino tet = new Polyomino(type, 2);
            byte[,] shape = new byte[3, 3] {{1,0,0}
                                           ,{1,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_4L(char type)
        {
            IPolyomino tet = new Polyomino(type, 2);
            byte[,] shape = new byte[3, 3] {{0,0,1}
                                           ,{1,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_4T(char type)
        {
            IPolyomino tet = new Polyomino(type, 2);
            byte[,] shape = new byte[3, 3] {{0,1,0}
                                           ,{1,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_4S(char type)
        {
            IPolyomino tet = new Polyomino(type, 3);
            byte[,] shape = new byte[3, 3] {{0,1,1}
                                           ,{1,1,0}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_4Z(char type)
        {
            IPolyomino tet = new Polyomino(type, 3);
            byte[,] shape = new byte[3, 3] {{1,1,0}
                                           ,{0,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_4O(char type)
        {
            IPolyomino tet = new Polyomino(type, 1);
            byte[,] shape = new byte[2, 2] {{1,1}
                                           ,{1,1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        // Order 5 Mino
        
        private IPolyomino Build_5I(char type)
        {
            IPolyomino tet = new Polyomino(type, 4);
            byte[,] shape = new byte[5, 5] {{0,0,0,0,0}
                                           ,{0,0,0,0,0}
                                           ,{1,1,1,1,1}
                                           ,{0,0,0,0,0}
                                           ,{0,0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5B(char type)
        {
            IPolyomino tet = new Polyomino(type, 5);
            byte[,] shape = new byte[3, 3] {{0,1,1}
                                           ,{1,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5D(char type)
        {
            IPolyomino tet = new Polyomino(type, 5);
            byte[,] shape = new byte[3, 3] {{1,1,0}
                                           ,{1,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5L(char type)
        {
            IPolyomino tet = new Polyomino(type, 4);
            byte[,] shape = new byte[4, 4] {{0,0,0,0}
                                           ,{0,0,0,1}
                                           ,{1,1,1,1}
                                           ,{0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5J(char type)
        {
            IPolyomino tet = new Polyomino(type, 4);
            byte[,] shape = new byte[4, 4] {{0,0,0,0}
                                           ,{1,0,0,0}
                                           ,{1,1,1,1}
                                           ,{0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5P(char type)
        {
            IPolyomino tet = new Polyomino(type, 8);
            byte[,] shape = new byte[3, 3] {{0,1,0}
                                           ,{1,1,1}
                                           ,{0,1,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5K(char type)
        {
            IPolyomino tet = new Polyomino(type, 9);
            byte[,] shape = new byte[4, 4] {{0,0,0,0}
                                           ,{0,0,1,1}
                                           ,{1,1,1,0}
                                           ,{0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5N(char type)
        {
            IPolyomino tet = new Polyomino(type, 9);
            byte[,] shape = new byte[4, 4] {{0,0,0,0}
                                           ,{1,1,0,0}
                                           ,{0,1,1,1}
                                           ,{0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5U(char type)
        {
            IPolyomino tet = new Polyomino(type, 8);
            byte[,] shape = new byte[3, 3] {{1,0,1}
                                           ,{1,1,1}
                                           ,{0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5W(char type)
        {
            IPolyomino tet = new Polyomino(type, 9);
            byte[,] shape = new byte[3, 3] {{1,0,0}
                                           ,{1,1,0}
                                           ,{0,1,1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5G(char type)
        {
            IPolyomino tet = new Polyomino(type, 8);
            byte[,] shape = new byte[3, 3] {{0,1,0}
                                           ,{0,1,1}
                                           ,{1,1,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5Q(char type)
        {
            IPolyomino tet = new Polyomino(type, 8);
            byte[,] shape = new byte[3, 3] {{0,1,0}
                                           ,{1,1,0}
                                           ,{0,1,1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5S(char type)
        {
            IPolyomino tet = new Polyomino(type, 10);
            byte[,] shape = new byte[3, 3] {{0,1,1}
                                           ,{0,1,0}
                                           ,{1,1,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5Z(char type)
        {
            IPolyomino tet = new Polyomino(type, 10);
            byte[,] shape = new byte[3, 3] {{1,1,0}
                                           ,{0,1,0}
                                           ,{0,1,1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5T(char type)
        {
            IPolyomino tet = new Polyomino(type, 6);
            byte[,] shape = new byte[3, 3] {{0,1,0}
                                           ,{0,1,0}
                                           ,{1,1,1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5H(char type)
        {
            IPolyomino tet = new Polyomino(type, 7);
            byte[,] shape = new byte[4, 4] {{0,0,0,0}
                                           ,{0,1,0,0}
                                           ,{1,1,1,1}
                                           ,{0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5Y(char type)
        {
            IPolyomino tet = new Polyomino(type, 7);
            byte[,] shape = new byte[4, 4] {{0,0,0,0}
                                           ,{0,0,1,0}
                                           ,{1,1,1,1}
                                           ,{0,0,0,0}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private IPolyomino Build_5V(char type)
        {
            IPolyomino tet = new Polyomino(type, 7);
            byte[,] shape = new byte[3, 3] {{1,0,0}
                                           ,{1,0,0}
                                           ,{1,1,1}};

            tet.Shape = shape;
            tet.Rotations = SetRotations(shape, tet.Rotations);

            return tet;
        }

        private static byte[][,] SetRotations(byte[,] space, byte[][,] rotations)
        {
            for (int index = 0; index < 4; index++)
            {
                byte[,] shift = GetRotation(space);
                rotations[index] = shift;
                space = shift;
            }

            return rotations;
        }

        private static byte[,] GetRotation(byte[,] space)
        {
            byte[,] newArray = new byte[space.GetLength(0), space.GetLength(0)];

            for (int i = (space.GetLength(0) - 1); i >= 0; --i)
            {
                for (int j = 0; j < space.GetLength(0); ++j)
                {
                    newArray[j, (space.GetLength(0) - 1) - i] = space[i, j];
                }
            }

            return newArray;
        }
    }
}
