using System;

namespace MarsRoverGabeEvo
{
    public class Rover
    {
        private enum CardinalDirections { N, W, S, E }
        private int myX;
        private int myY;
        private int myOrientation;
        private int myId;

        public Rover(int theX, int theY, string theDirection, int theId)
        {
            if (theX > Plateau.getWidth() || theX < 0)
            {
                throw new RoverPositionException("Rover x coordinate is out of bounds!");
            } else if (theY > Plateau.getHeight() || theY < 0)
            {
                throw new RoverPositionException("Rover y coordinate is out of bounds!");

            }
            myX = theX;
            myY = theY;
            myOrientation = (int)Enum.Parse(typeof(CardinalDirections), theDirection);
            myId = theId;
        }
        /**
         * Moves the rover one space forward in the current orientation.
         * Will not have any effect if the rover is at the edge of the plateau 
         * and it's orientation will take it off the map
         */
        public void move()
        {
            switch (myOrientation)
            {
                case 0://move north
                    if (myY < Plateau.getHeight())
                    {
                        myY++;
                    }
                    break;
                case 1://move west
                    if (myX > 0)
                    {
                        myX--;
                    }
                    break;
                case 2://move south
                    if (myY > 0)
                    {
                        myY--;
                    }
                    break;
                case 3://move east
                    if (myX < Plateau.getWidth())
                    {
                        myX++;
                    }
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

        public void executeInstructions(string instructions)
        {
            foreach (char c in instructions)
            {
                switch (c)
                {
                    case 'L':
                        turnLeft();
                        break;
                    case 'R':
                        turnRight();
                        break;
                    case 'M':
                        move();
                        break;
                    default:
                        throw new Exception("Invalid instruction!");
                }
            }
        }

        public override string ToString()
        {
            CardinalDirections orientationValue = (CardinalDirections)myOrientation;
            string directionValue = orientationValue.ToString();
            return String.Format("{0} {1} {2}", myX, myY, directionValue);
        }
    }
    public class RoverPositionException : Exception
    {
        public RoverPositionException(string message) : base(message)
        {

        }
    }
}
