using System;
using System.Collections.Generic;
using System.Text;

namespace Corot
{
    class People
    {
        public People()
        {
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
        }

        public People(int engineering, int combat, int medical, int scavenging, int leadership, bool alive, bool injured, int special, string weapon, string tool)
        {
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
        }


        //Stats 0-20
       protected int engineering;
       protected int combat;
       protected int medical;
       protected int scavenging;
       protected int leadership;

        //Modifiers 
       protected bool alive;
       protected bool injured;
       protected int special;

        //Equipment
       protected string weapon;
       protected string tool;
    }
}
