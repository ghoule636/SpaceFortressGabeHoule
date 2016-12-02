﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.Landscape
{
    class Mountain : AbstractTerrain
    {
        public Mountain(float theElevation, float theMoisture)
        {
            create('^', theElevation, theMoisture);
        }
    }
}
