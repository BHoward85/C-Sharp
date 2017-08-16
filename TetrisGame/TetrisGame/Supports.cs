using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.Supports
{
    public static class Ext
    {
        public static char ToTypeChar(this byte bit, char type)
        {
            return bit == 1 ? type : '_';
        }

        public static string ComplexArrayToString(this byte[][,] set)
        {
            string s = "";

            for (int index = 0; index < 4; index++)
            {
                for (int jdex = 0; jdex < 4; jdex++)
                {
                    for (int kdex = 0; kdex < 4; kdex++)
                    {
                        s += set[index][jdex, kdex].ToString();
                    }
                    s += "\n";
                }
                s += "~~~~\n";
            }

            return s;
        }

        public static char[,] ByteArrayToCharArray(this byte[,] oldAra)
        {
            char[,] newAra = new char[oldAra.Length, oldAra.GetLength(0)];

            for (int index = 0; index < newAra.Length; index++)
            {
                for (int jdex = 0; jdex < newAra.GetLength(0); jdex++)
                {
                    newAra[index, jdex] = Convert.ToChar(oldAra[index, jdex]);
                }
            }

            return newAra;
        }

        public static byte[,] CharArrayToByteArray(this char[,] oldAra)
        {
            byte[,] newAra = new byte[oldAra.Length, oldAra.GetLength(0)];

            for (int index = 0; index < newAra.Length; index++)
            {
                for (int jdex = 0; jdex < newAra.GetLength(0); jdex++)
                {
                    newAra[index, jdex] = Convert.ToByte(oldAra[index, jdex]);
                }
            }

            return newAra;
        }
    }
}
