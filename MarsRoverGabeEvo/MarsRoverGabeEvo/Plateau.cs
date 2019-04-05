using System;

namespace MarsRoverGabeEvo
{
    public class Plateau
    {
        private static int plateauHeight;
        private static int plateauWidth;

        private Plateau() {}

        public static void setSize(int width, int height)
        {
            if (width < 1 || width > int.MaxValue)
            {
                throw new PlateauSizeException("Plateau width must be greater than 0 and less than max int!");
            } else if (height < 1 || height > int.MaxValue)
            {
                throw new PlateauSizeException("Plateau height must be greater than 0 and less than max int!");
            }
            plateauHeight = height;
            plateauWidth = width;
        }

        public static int getHeight()
        {
            return plateauHeight;
        }

        public static int getWidth()
        {
            return plateauWidth;
        }
    }

    public class PlateauSizeException : Exception
    {
        public PlateauSizeException(string message): base(message)
        {

        }
    }
}
