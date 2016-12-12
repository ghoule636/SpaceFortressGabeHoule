using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.Landscape
{
    class Plains : AbstractTerrain
    {
        public Plains(double theElevation)
        {
            create('_', theElevation);
        }
    }
}
