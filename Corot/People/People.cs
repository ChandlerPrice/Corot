using System;
using System.Collections.Generic;
using System.Text;

namespace Corot.People
{
    abstract class People
    {
        //Stats
        int engineering;
        int combat;
        int medical;
        int scavenging;
        int leadership;

        //Modifiers
        bool alive;
        bool injured;
        int special;

        //Equiptment
        string weapon;
        string tool;

        /*
         Potential
        int happiness;
         */
    }
}
