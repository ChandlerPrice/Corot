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
            randName = random.Next(10);
            switch (randName)
            {
                case 1:
                    name = Names.Billy.ToString();
                    break;
                case 2:
                    name = Names.Bob.ToString();
                    break;
                case 3:
                    name = Names.Brandon.ToString();
                    break;
                case 4:
                    name = Names.Chandler.ToString();
                    break;
                case 5:
                    name = Names.Gage.ToString();
                    break;
                case 6:
                    name = Names.Jack.ToString();
                    break;
                case 7:
                    name = Names.John.ToString();
                    break;
                case 8:
                    name = Names.Phil.ToString();
                    break;
                case 9:
                    name = Names.Spencer.ToString();
                    break;
                case 10:
                    name = Names.Tatheim.ToString();
                    break;
                default:
                    break;
            }
            engineering = 1;
            combat = 1;
            medical = 1;
            scavenging = 1;
            leadership = 1;
            alive = true;
            injured = false;
            special = 0;
            weapon = "N/A";
            tool = "N/A";
            idle = false;
        }

        public enum Names
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

        public People(string name, int engineering, int combat, int medical, int scavenging, int leadership, bool alive, bool injured, int special, string weapon, string tool, bool idle)
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
            this.idle = idle;
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
        public bool idle { get; set; }

        //Equipment
        public string weapon { get; set; }
        public string tool { get; set; }

        //Other
        public string name { get; set; }
    }
}
