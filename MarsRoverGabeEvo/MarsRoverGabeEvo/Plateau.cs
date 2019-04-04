using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverGabeEvo
{
    class Plateau
    {
        private static string[,] plateau;

        private Plateau() {}

        public static void setSize(int width, int height)
        {
            //check for negative or too large? values for plateau
            plateau = new string[width, height];
        }

        public static int getHeight()
        {
            return plateau.GetLength(0);
        }

        public static int getWidth()
        {
            return plateau.GetLength(1);
        }

    }
}
