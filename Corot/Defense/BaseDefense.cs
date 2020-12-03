using System;
using System.Collections.Generic;
using System.Text;

namespace Corot
{
    class BaseDefense
    {

        int defense;
        int zombies = 100;
        //int horde;
        int buildings = 3;
        int defenseBuildings = 1;
        int danger = 0;
        List<Corot.People.People> guardingPeople = new List<Corot.People.People>();



        public int calculateDefense()
        {
            //Defense is calculated as each person that is idle/ on guard duty & their combat skills, as well as the defense of certain buildings plus the flat bonus of wall quality
            defense = 1 + buildings + (defenseBuildings * 8);
            for (int i = 0; i < Game.townPopulation.Count; i++)
            {
                if (Game.townPopulation[i].job == Corot.People.Jobs.guardingWorkers.ToString())
                {
                    guardingPeople.Add(Game.townPopulation[i]);
                }
            }

            for (int i=0; i < guardingPeople.Count; i++)
            {
                defense = defense + guardingPeople[i].combat;
                System.Diagnostics.Debug.WriteLine($"Defense: {defense}");
            }

            System.Diagnostics.Debug.WriteLine($"Total Defense: {defense}");

            danger = zombies / (defense * 2);

            System.Diagnostics.Debug.WriteLine($"Danger: {danger}");
            return danger;
        }

    }
}
