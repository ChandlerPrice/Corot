using System;
using System.Collections.Generic;
using System.Text;

namespace Corot
{
    class BaseDefense
    {
        Game game = new Game();

        int defense;
        //int zombies;
        //int horde;

        public int calculateDefense()
        {
            //Defense is calculated as each person that is idle/ on guard duty & their combat skills, as well as the defense of certain buildings plus the flat bonus of wall quality
            defense = 1;
            if (game.population > 0)
            {
                foreach (People element in game.townPopulation)
                {
                    Console.WriteLine($"Person: {element}");
                }
            }
            else
            {
                Console.WriteLine("No People in list");
            }
            Console.WriteLine($"Defense: {defense}");
            return defense;
        }

    }
}
