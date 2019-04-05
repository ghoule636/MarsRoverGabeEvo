using System;
using System.Collections.Generic;

namespace MarsRoverGabeEvo
{
    class Program
    {
        static string line;
        static string[] processLine;
        static Boolean errorOccured = false;
        static int count = 0;
        static List<Rover> roverList = new List<Rover>();

        /**
         * Initializes the plateau with a height and width. 
         */
        private static void initPlateau()
        {
            try
            {
                processLine = line.Split(' ');
                if (processLine.Length != 2)
                {
                    throw new Exception();
                }
                else
                {
                    int x = int.Parse(processLine[0]);
                    int y = int.Parse(processLine[1]);
                    Plateau.setSize(x, y);
                } 
            }
            catch (Exception e)
            {
                errorOccured = true;
                if (e is PlateauSizeException)
                {
                    Console.WriteLine(e.Message);
                }
                else
                {
                    Console.WriteLine("Plateau dimensions must be properly formatted!");
                }
            }
        }
        /**
         * Reads from RoverInput.txt and initializes the plateau then creates and moves the rovers listed in the input file.
         */
        private static void initMars()
        {
            System.IO.StreamReader roverInput = new System.IO.StreamReader("./RoverInput.txt");
            //read the first line and set the size of the plateau.
            if ((line = roverInput.ReadLine()) != null)
            {
                initPlateau();
            }
            else
            {
                Console.WriteLine("Input file must contain plateau dimensions!");
                errorOccured = true;
            }
            //read the rest of the lines; creating rovers and moving them.
            while ((line = roverInput.ReadLine()) != null && !errorOccured) // reading rover starting position and orientation
            {
                if (line != "")
                {
                    processLine = line.Split(' ');
                    try // Creating the rover here
                    {
                        int x = int.Parse(processLine[0]);
                        int y = int.Parse(processLine[1]);
                        roverList.Add(new Rover(x, y, processLine[2], count));
                    }
                    catch (Exception e) // error occured when reading the rover coordinates or placing the rovers on the plateau.
                    {
                        errorOccured = true;
                        if (e is RoverPositionException)
                        {
                            Console.WriteLine(e.Message);
                        }
                        else
                        {
                            Console.WriteLine("Rover coordinates must be properly formatted!");
                        }
                    }
                    if ((line = roverInput.ReadLine()) != null && line != "" && !errorOccured) // read rover instructions here
                    {
                        try // follow instructions for the newly created rover.
                        {
                            roverList[count].executeInstructions(line);
                            Console.WriteLine(String.Format("Rover {0} end position: {1}", count + 1, roverList[count]));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            errorOccured = true;
                        }
                    }
                    else if (line == "")
                    {
                        errorOccured = true;
                        Console.WriteLine(String.Format("Input file for Rover {0} did not contain instructions!", count + 1));
                    }
                    count++;
                }
            }
            roverInput.Close();
        }

        static void Main(string[] args)
        {
            initMars();
            Console.WriteLine("Press return to exit.");
            Console.Read();
        }
    }
}
