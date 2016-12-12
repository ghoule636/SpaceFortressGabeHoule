using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.Landscape
{
    class Hill : AbstractTerrain
    {
        public Hill(double theElevation)
        {
            create('n', theElevation);
        }
    }
}
