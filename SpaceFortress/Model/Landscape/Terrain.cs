using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.Landscape
{
    public interface Terrain
    {
        char getType();

        float getElevation();

        float getMoisture();
    }
}
