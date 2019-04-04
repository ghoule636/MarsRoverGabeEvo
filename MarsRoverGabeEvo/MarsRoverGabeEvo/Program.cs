using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverGabeEvo
{
    class Program
    {
        static void Main(string[] args)
        {
            Plateau.setSize(5, 4);
            Rover test = new Rover(1, 1, "N", 1);
            Console.WriteLine(test);
            test.turnLeft();
            Console.WriteLine(test);
            Console.WriteLine("Press return to exit.");
            Console.Read();
        }
    }
}
