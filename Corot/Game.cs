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
        public int food { get { return Food; } set { Food = value; } }

        public static List<Corot.People.People> townPopulation = new List<Corot.People.People>();



        public string DailyEvent()
        {
            string dailyPrint = "";
            MainWindow main = new MainWindow();
            if (townPopulation.Count != 0)
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
                        for (int i = 0; i < rand.Next(3); i++)
                        {
                            randomValue = rand.Next(townPopulation.Count);
                            dailyPrint = dailyPrint + ($"   Died: {Game.townPopulation[randomValue].name}     ");
                            //main.peopleInfoList.Items.Add($"Died: {Game.townPopulation[randomValue].name}");
                            System.Diagnostics.Debug.WriteLine($"Died: {randomValue}");
                            Game.townPopulation.RemoveAt(randomValue);
                        }
                        population = Game.townPopulation.Count;

                        System.Diagnostics.Debug.WriteLine($"Population: {population}");
                        break;
                    case randomDailyEventsEnum.survivorFound:
                        for (int i = 0; i < rand.Next(3); i++)
                        {
                            People.People people = new People.People();
                            Game.townPopulation.Add(people);
                        }
                        population = Game.townPopulation.Count;
                        dailyPrint = dailyPrint + ("    New people added    ");
                        //main.peopleInfoList.Items.Add("New people added");
                        System.Diagnostics.Debug.WriteLine("New people added");
                        System.Diagnostics.Debug.WriteLine($"Population: {population}");
                        break;
                    case randomDailyEventsEnum.extraFood:
                        Food += rand.Next(10);
                        dailyPrint = dailyPrint + ("    Found food  ");
                        //main.peopleInfoList.Items.Add("Found Food");
                        break;
                    case randomDailyEventsEnum.rottedFood:
                        Food -= rand.Next(10);
                        dailyPrint = dailyPrint + ("    Food went bad   ");
                        //main.peopleInfoList.Items.Add("Food went bad");
                        break;
                    case randomDailyEventsEnum.boringDay:
                        break;
                    default:
                        break;
                }
            }
            return dailyPrint;
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
