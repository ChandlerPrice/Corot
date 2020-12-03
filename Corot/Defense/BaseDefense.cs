using System;
using System.Collections.Generic;
using System.Text;

namespace Corot
{
    class BaseDefense
    {

        int defense;
        int zombies = 50;
        //int horde;
        int buildings = 4;
        int defenseBuildings = 1;
        int danger = 0;
        List<Corot.People.People> idlePeople = new List<Corot.People.People>();



        public int calculateDefense()
        {
            //Defense is calculated as each person that is idle/ on guard duty & their combat skills, as well as the defense of certain buildings plus the flat bonus of wall quality
            defense = 1 + buildings + (defenseBuildings * 8);
            for (int i = 0; i < Game.townPopulation.Count; i++)
            {
                if (Game.townPopulation[i].idle)
                {
                    idlePeople.Add(Game.townPopulation[i]);
                }
            }

            if (Game.townPopulation.Count <= 0)
            {
                System.Diagnostics.Debug.WriteLine("No People in list");
            }
            else
            {
                //listObj[index].[property]
                for (int i=0; i < idlePeople.Count; i++)
                {
                    defense = defense + idlePeople[i].combat;
                    System.Diagnostics.Debug.WriteLine($"Defense: {defense}");
                }
            }
            System.Diagnostics.Debug.WriteLine($"Total Defense: {defense}");

            danger = zombies / (defense * 2);

            System.Diagnostics.Debug.WriteLine($"Danger: {danger}");
            return danger;
        }

    }
}
