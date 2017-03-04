using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFortress.Model.Landscape;
using System.Drawing;

namespace SpaceFortress.Model.WorldGenerator
{
    public class Planet
    {
        private Terrain[][] myWorld;
        private Bitmap myMap;
        private String myName;
        private String mySize;
        private String[] mySizes;

        private double myMaxHeight;
        private double myMinHeight;
        private double myWaterLevel;
        private double myOceanDepth;

        public Planet()
        {
            myWorld = new Terrain[0][];
            myMap = new Bitmap(1, 1);
            myName = "";
            mySizes = new String[] { "Small", "Medium", "Large" };
            mySize = mySizes[0];
            myMaxHeight = (double)Int64.MinValue;
            myMinHeight = (double)Int64.MaxValue;
            myWaterLevel = (double)Int64.MinValue;
            myOceanDepth = (double)Int64.MaxValue;
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

            //proceed to process information about the new terrain

            for (int i = 0; i < myWorld[0].Length; i++)
            {
                for (int j = 0; j < myWorld.Length; j++)
                {
                    double tempHeight = myWorld[i][j].getElevation();

                    if (myWorld[i][j].GetType().Equals(typeof(Water)))
                    {                
                        if (tempHeight > myWaterLevel)
                        {
                            myWaterLevel = tempHeight;
                        }
                        else if (tempHeight < myOceanDepth)
                        {
                            myOceanDepth = tempHeight;
                        }
                    }

                    if (tempHeight > myMaxHeight)
                    {
                        myMaxHeight = tempHeight;                    
                    }
                    else if (tempHeight < myMinHeight)
                    {
                        myMinHeight = tempHeight;
                    }
                }
            }
        }

        public void setMap(Bitmap theMap)
        {
            myMap = theMap;
        }

        public Bitmap getMap()
        {
            return myMap;
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

        public double getMaxHeight()
        {
            return myMaxHeight;
        }

        public double getMinHeight()
        {
            return myMinHeight;
        }

        public double getWaterLevel()
        {
            return myWaterLevel;
        }

        public double getOceanDepth()
        {
            return myOceanDepth;
        }

        public Bitmap getMap()
        {
            return myMap;
        }

        public void setMap(Bitmap theMap)
        {
            myMap = theMap;
        }

    }
}