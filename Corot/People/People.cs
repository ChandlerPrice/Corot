using System;
using System.Collections.Generic;
using System.Text;

namespace Corot.People
{
    abstract class People
    {
        //Stats 0-?
        int engineering;
        int combat;
        int medical;
        int scavenging;
        int leadership;

        //Modifiers 
        bool alive;
        bool injured;
        int special;

        //Equipment
        string weapon;
        string tool;

        /*
         Potential
        int happiness;
         */
    }
}
