using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            World myWorld = new World(20);
            
            // Need to find a way to display the World
            // Something like:
            // myWorld.DisplayWorld();


            for (int i = 0; i < 40; i++)
            {
                myWorld.ApplyTheRulesOfTheGame();
                Console.WriteLine("Generation {0}", i + 1);
                System.Threading.Thread.Sleep(1000);
            }

            Console.ReadLine();
        }
    }
}
