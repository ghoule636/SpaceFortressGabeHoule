﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.Landscape
{
    class Ocean : AbstractTerrain
    {
        public Ocean(double theElevation)
        {
            create('~', theElevation);
        }
    }
}
