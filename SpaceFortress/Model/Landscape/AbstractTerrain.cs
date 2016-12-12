using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.Landscape
{
    abstract class AbstractTerrain : Terrain
    {
        private char myType;
        private double myElevation;
        private double myMoisture;

        public void create(char theType, double theElevation)
        {
            myElevation = theElevation;
            myType = theType;
        }

        public char getType()
        {
            return myType;
        }

        public double getElevation()
        {
            return myElevation;
        }

        public double getMoisture()
        {
            return myMoisture;
        }
    }
}
