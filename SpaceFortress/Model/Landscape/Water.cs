using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.Landscape
{
    class Water : AbstractTerrain
    {
        public Water(double theElevation)
        {
            create('~', theElevation);
        }
    }
}
