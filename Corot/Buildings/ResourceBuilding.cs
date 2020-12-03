using System;
using System.Collections.Generic;
using System.Text;

namespace Corot
{

    class ResourceBuilding
    {
       public Resource resource;
        public ResourceBuilding()
        {
        }
    }



    class Farm : ResourceBuilding
    {
        public Farm()
        {
            resource.food += 1;
        }
    }

    class SawMill : ResourceBuilding
    {
        public SawMill()
        {
            resource.buildingMaterials += 1;
        }

    }

    class WaterPlant : ResourceBuilding
    {
        public WaterPlant()
        {
            resource.water += 1;
        }

    }
}
