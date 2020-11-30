using System;
using System.Collections.Generic;
using System.Text;

namespace Corot
{
    class People
    {
        public People()
        {
            name = "Bob";
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
