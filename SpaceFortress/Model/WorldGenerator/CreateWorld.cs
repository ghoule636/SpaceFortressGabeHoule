using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFortress.Model.Landscape;

namespace SpaceFortress.Model.WorldGenerator
{
    static class CreateWorld
    {
        private static int small = 128;
        private static int medium = 256;
        private static int large = 512;

        public static Terrain[][] createMap(String theSize)
        {
            Terrain[][] result = new Terrain[0][];
            float[][] tempEleArr = new float[0][];

            if (theSize == "Small")
            {
                result = new Terrain[small][];
                tempEleArr = new float[small][];


            } else if (theSize == "Medium")
            {
                result = new Terrain[medium][];
                tempEleArr = new float[medium][];
            }
            else if (theSize == "Large")
            {
                result = new Terrain[large][];
                tempEleArr = new float[large][];

            }

            generateHeightmap(tempEleArr);

            return result;

        }

        private static void generateHeightmap(float[][] elevationArr)
        {

        }
    }
}
