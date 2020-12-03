using System;
using System.Collections.Generic;
using System.Text;
using static Corot.Events.RandomEvents;

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

        public static List<People> townPopulation = new List<People>();



        public void DailyEvent()
        {
            randomDailyEventsEnum dailyEvent = new randomDailyEventsEnum();
            dailyEvent = RandomDailyEvent();
            switch (dailyEvent)
            {
                case randomDailyEventsEnum.zombieAttack:
                    break;
                case randomDailyEventsEnum.zombieHordeAttack:
                    break;
                case randomDailyEventsEnum.survivorDied:
                    Population -= rand.Next(3);
                    break;
                case randomDailyEventsEnum.survivorFound:
                    Population += rand.Next(3);
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
    }
}
