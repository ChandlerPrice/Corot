using System;
using System.Collections.Generic;
using System.Text;

namespace Corot.People
{
    class People
    {
        Random random = new Random();
        int randName;
        public People()
        {
            randName = random.Next(1, 10);

            switch (randName)
            {
                case 1:
                    name = Name.Billy;
                    break;
                case 2:
                    name = Name.Bob;
                    break;
                case 3:
                    name = Name.Brandon;
                    break;
                case 4:
                    name = Name.Chandler;
                    break;
                case 5:
                    name = Name.Gage;
                    break;
                case 6:
                    name = Name.Jack;
                    break;
                case 7:
                    name = Name.John;
                    break;
                case 8:
                    name = Name.Phil;
                    break;
                case 9:
                    name = Name.Spencer;
                    break;
                case 10:
                    name = Name.Tatheim;
                    break;
            }
            engineering = random.Next(3)+1;
            combat = random.Next(3) + 1;
            medical = random.Next(3) + 1;
            scavenging = random.Next(3) + 1;
            leadership = random.Next(3) + 1;
            alive = true;
            injured = false;
            special = 0;
            weapon = "N/A";
            tool = "N/A";
            job = Jobs.Guard;
        }

        public enum Name
        {
            Bob,
            John,
            Phil,
            Jack,
            Billy,
            Gage,
            Brandon,
            Chandler,
            Spencer,
            Tatheim
        }

        public enum Jobs
        {
            Guard,
            Fighter,
            Farmer,
            Scavenger,
            Scientist,
            Scout
        }

        public People(Name name, int engineering, int combat, int medical, int scavenging, int leadership, bool alive, bool injured, int special, string weapon, string tool, Jobs job)
        {
            this.name = name;
            this.engineering = engineering;
            this.combat = combat;
            this.medical = medical;
            this.scavenging = scavenging;
            this.leadership = leadership;
            this.alive = alive;
            this.injured = injured;
            this.special = special;
            this.weapon = weapon;
            this.tool = tool;
            this.job = job;
        }


        //Stats 0-20
       public int engineering { get; set; }
       public int combat { get; set; }
       public int medical { get; set; }
       public int scavenging { get; set; }
       public int leadership { get; set; }

        //Modifiers 
        public bool alive { get; set; }
        public bool injured { get; set; }
        public int special { get; set; }
        public Jobs job { get; set; }

        //Equipment
        public string weapon { get; set; }
        public string tool { get; set; }

        //Other
        public Name name { get; set; }
    }
}
