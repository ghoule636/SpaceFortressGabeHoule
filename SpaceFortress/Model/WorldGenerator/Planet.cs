using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFortress.Model.Landscape;

namespace SpaceFortress.Model.WorldGenerator
{
    public class Planet
    {
        private Terrain[][] myWorld;
        private String myName;
        private String mySize;
        private String[] mySizes;

        public Planet()
        {
            myWorld = new Terrain[0][];
            myName = "";
            mySizes = new String[] { "Small", "Medium", "Large" };
            mySize = mySizes[0];
        }

        public String getName()
        {
            return myName;
        }

        public void setName(String theName)
        {
            myName = theName;
        }

        public Terrain[][] getTerrain()
        {
            return myWorld;
        }

        public void setTerrain(Terrain[][] theWorld)
        {
            myWorld = theWorld;
        }

        public String[] getSizes()
        {
            return mySizes;
        }

        public void setSize(int theIndex)
        {
            mySize = mySizes[theIndex];
        }

        public String getSize()
        {
            return mySize;
        }
    }
}