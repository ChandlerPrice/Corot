using System;
using System.Collections.Generic;
using System.Text;
using Corot;


namespace Corot.Research
{
    class Research
    {
        public static bool zombieVitalsComplete { get; set; } = false;
        public static bool headshotComplete { get; set; } = false;
        public static bool antiVenomComplete { get; set; } = false;
        public static bool signsComplete { get; set; } = false;
        public static bool diplomacyComplete { get; set; } = false;
        public static bool radioComplete { get; set; } = false;
        public static bool bunkBedsComplete { get; set; } = false;
        public static bool pesticidesComplete { get; set; } = false;
        public static bool fortifyWallsComplete { get; set; } = false;

        public static string activeResearch { get; set; }
        public static int researchPoints { get; set; }
        public static int maxResearch { get; set; }
        public static int totalResearchDone { get; set; } = 0;
    }
}
