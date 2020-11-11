using System;
using System.Collections.Generic;
using System.Text;

namespace Corot.Events
{
    class RandomEvents
    {
        public enum randomDailyEventsEnum
        {
            zombieAttack,
            zombieHordeAttack,
            survivorDied,
            survivorFound,
            extraFood,
            rottedFood,
            boringDay
        }

        private static List<randomDailyEventsEnum> dailyEvents = new List<randomDailyEventsEnum>()
        {
            randomDailyEventsEnum.zombieAttack, randomDailyEventsEnum.zombieHordeAttack, randomDailyEventsEnum.survivorDied,
            randomDailyEventsEnum.survivorFound, randomDailyEventsEnum.extraFood, randomDailyEventsEnum.rottedFood,
            randomDailyEventsEnum.boringDay
        };

        public static randomDailyEventsEnum RandomDailyEvent()
        {
            Random random = new Random();
            int r = random.Next(dailyEvents.Count);

            return dailyEvents[r];
        }


    }
}
