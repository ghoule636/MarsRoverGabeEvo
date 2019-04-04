using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverGabeEvo
{
    class Rover
    {
        private enum CardinalDirections { N, W, S, E }
        private int myX;
        private int myY;
        private int myOrientation;
        private int myId;

        public Rover(int theX, int theY, string theDirection, int theId)
        {
            //exception if x and y are outside the plateau
            myX = theX;
            myY = theY;
            myOrientation = (int)Enum.Parse(typeof(CardinalDirections), theDirection);
            myId = theId;
        }

        public void move()
        {
            switch (myOrientation)
            {
                case 0:
                    if (myY > Plateau.getHeight())
                    {

                    }
                    myY++;
                    
                    break;
            }
        }

        public void turnLeft()
        {
            if (myOrientation == 3)
            {
                myOrientation = 0;
            }
            else
            {
                myOrientation++;
            }
        }
        public void turnRight()
        {
            if (myOrientation == 0)
            {
                myOrientation = 3;
            }
            else
            {
                myOrientation--;
            }
        }

        public override string ToString()
        {
            CardinalDirections orientationValue = (CardinalDirections)myOrientation;
            string directionValue = orientationValue.ToString();
            return String.Format("{0} {1} {2}", myX, myY, directionValue);
        }
    }
}
