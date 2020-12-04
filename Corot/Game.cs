using System;
using System.Collections.Generic;
using System.Text;
using static Corot.Events.RandomEvents;
using Corot.People;

namespace Corot
{
    class Game
    {
        private Random rand = new Random();
        private int Day;
        private int Population;
        private int Food;


        public int day { get { return Day; } set { Day = value; } }
        public int population { get { return Population; } set { Population = value; } }
        public int MaxPopulation { get; set; }
        public int food { get { return Food; } set { Food = value; } }

        public static List<Corot.People.People> townPopulation = new List<Corot.People.People>();
        public static int removal { get; set; }



        public string DailyEvent()
        {
            string dailyPrint = "";
            if (townPopulation.Count != 0)
            {
                int randomValue;
                randomDailyEventsEnum dailyEvent = new randomDailyEventsEnum();
                dailyEvent = RandomDailyEvent();
                switch (dailyEvent)
                {
                    case randomDailyEventsEnum.zombieAttack:
                        int attack = rand.Next(100);
                        BaseDefense baseDefense = new BaseDefense();
                        if (attack >= baseDefense.calculateDefense())
                        {
                            dailyPrint = "You were attacked";
                            int test = rand.Next(3 * ((population / 10)+1));
                            for (int i = 0; i <= test; i++)
                            {
                                randomValue = rand.Next(townPopulation.Count);
                                dailyPrint = dailyPrint + ($"\nDied: {Game.townPopulation[randomValue].name}");
                                Game.townPopulation.RemoveAt(randomValue);
                            }
                            population = Game.townPopulation.Count;

                            System.Diagnostics.Debug.WriteLine($"Population: {population}");
                        }
                        break;
                    case randomDailyEventsEnum.zombieHordeAttack:
                        break;
                    case randomDailyEventsEnum.survivorDied:
                        if (Corot.Research.Research.antiVenomComplete == false)
                        {
                            dailyPrint = "A disease outbreak occured";
                            for (int i = 0; i <= rand.Next((population/10)+1); i++)
                            {
                                randomValue = rand.Next(townPopulation.Count);
                                dailyPrint = dailyPrint + ($"\nDied: {Game.townPopulation[randomValue].name}");
                                Game.townPopulation.RemoveAt(randomValue);
                            }
                            population = Game.townPopulation.Count;

                            System.Diagnostics.Debug.WriteLine($"Population: {population}");
                        }
                        else
                        {
                            dailyPrint = "A disease outbreak was cured";
                        }
                        break;
                    case randomDailyEventsEnum.survivorFound:
                        int researchMultiplier = 1;
                        if (Corot.Research.Research.signsComplete == true)
                        {
                            researchMultiplier += 1;
                        }
                        if (Corot.Research.Research.radioComplete == true)
                        {
                            researchMultiplier += 1;
                        }
                        for (int i = 0; i < rand.Next(2 * researchMultiplier); i++)
                        {
                            People.People people = new People.People();
                            Game.townPopulation.Add(people);
                        }
                        population = Game.townPopulation.Count;
                        dailyPrint = dailyPrint + ("New people added");
                        break;
                    case randomDailyEventsEnum.extraFood:
                        Food += rand.Next(20);
                        dailyPrint = dailyPrint + ($"We found {Food} food");
                        break;
                    case randomDailyEventsEnum.rottedFood:
                        int rot = rand.Next((Food / 2));
                        Food -= rot;
                        dailyPrint = dailyPrint + ($"{rot} Food went bad");
                        break;
                    case randomDailyEventsEnum.boringDay:
                        dailyPrint = dailyPrint + ("Boring day");
                        break;
                    default:
                        break;
                }
            }
            return dailyPrint;
        }

        public void Research()
        {
            if (Corot.Research.Research.activeResearch == null)
            {
                
            }
            else
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 1;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 2;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 3;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 4;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 5;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 6;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 7;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 8;
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
                            Corot.Research.Research.activeResearch = null;
                            removal = 9;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
