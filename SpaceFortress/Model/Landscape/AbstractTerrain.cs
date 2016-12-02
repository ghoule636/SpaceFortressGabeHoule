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
        private float myElevation;
        private float myMoisture;

        public void create(char theType, float theElevation, float theMoisture)
        {
            myElevation = theElevation;
            myType = theType;
            myMoisture = theMoisture;
        }

        public char getType()
        {
            return myType;
        }

        public float getElevation()
        {
            return myElevation;
        }

        public float getMoisture()
        {
            return myMoisture;
        }
    }
}
