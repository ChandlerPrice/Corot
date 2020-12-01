using System;
using System.Collections.Generic;
using System.Text;
using static Corot.Events.RandomEvents;

namespace Corot
{
    class Game
    {
        private Random rand = new Random();
        People person = new People();
        private int Day;
        private int Population;
        private int Food;


        public int day { get { return Day; } set { Day = value; } }
        public int population { get { return Population; } set { Population = value; } }
        public int food { get { return Food; } set { Food = value; } }

        public static List<People> townPopulation = new List<People>();



        public void DailyEvent()
        {
            int randomValue;
            randomDailyEventsEnum dailyEvent = new randomDailyEventsEnum();
            dailyEvent = RandomDailyEvent();
            switch (dailyEvent)
            {
                case randomDailyEventsEnum.zombieAttack:
                    break;
                case randomDailyEventsEnum.zombieHordeAttack:
                    break;
                case randomDailyEventsEnum.survivorDied:
                    //Population -= rand.Next(3);
                    for (int i=0; i < 3; i++)
                    {
                        randomValue = rand.Next(townPopulation.Count);
                        System.Diagnostics.Debug.WriteLine($"Died: {randomValue}");
                        Game.townPopulation.RemoveAt(randomValue);
                    }
                    break;
                case randomDailyEventsEnum.survivorFound:
                    //Population += rand.Next(3);
                    for (int i = 0; i < 3; i++)
                    {
                        Game.townPopulation.Add(person);
                    }
                    break;
                case randomDailyEventsEnum.extraFood:
                    Food += rand.Next(10);
                    break;
                case randomDailyEventsEnum.rottedFood:
                    Food -= rand.Next(10);
                    break;
                case randomDailyEventsEnum.boringDay:
                    break;
                default:
                    break;
            }
        }

        public void Research()
        {
            switch (Corot.Research.Research.activeResearch)
            {
                case "zombieVitals":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.zombieVitalsComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "headshot":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.headshotComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "antivenom":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.antiVenomComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "signs":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.signsComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "diplomacy":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.diplomacyComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "radio":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.radioComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "bunkBeds":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.bunkBedsComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "pesticides":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.pesticidesComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                case "fortifyWalls":
                    if (Corot.Research.Research.maxResearch > 0)
                    {
                        Corot.Research.Research.maxResearch -= Corot.Research.Research.researchPoints;
                    }
                    else
                    {
                        Corot.Research.Research.maxResearch = 100 * (Corot.Research.Research.totalResearchDone + 1);
                        Corot.Research.Research.fortifyWallsComplete = true;
                        Corot.Research.Research.totalResearchDone += 1;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
