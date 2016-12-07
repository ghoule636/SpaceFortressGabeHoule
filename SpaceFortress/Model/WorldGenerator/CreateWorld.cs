﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFortress.Model.Landscape;

namespace SpaceFortress.Model.WorldGenerator
{
    class CreateWorld
    {
        private static Random rand = new Random();

        private static int SMALL = 129;
        private static int MEDIUM = 257;
        private static int LARGE = 513;

        private Terrain[][] myTerrain;
        private double[][] myHeightMap;
        private int mySize;

        public Terrain[][] createMap(String theSize)
        {
            if (theSize == "Small")
            {
                mySize = SMALL;
            } else if (theSize == "Medium")
            {
                mySize = MEDIUM;
            } else if (theSize == "Large")
            {
                mySize = LARGE;
            }

            initArrays();

            generateHeightmap();

            return myTerrain;
        }

        private void initArrays()
        {
            myTerrain = new Terrain[mySize][];
            myHeightMap = new double[mySize][];

            for (int i = 0; i < mySize; i++)
            {
                myHeightMap[i] = new double[mySize];
                myTerrain[i] = new Terrain[mySize];
            }
        }

        /**
         * Generates initial corner values for diamond-square algorithm. 
         */
        private void seedMap()
        {
            myHeightMap[0][0] = rand.NextDouble() * 1000;
            myHeightMap[mySize - 1][0] = rand.NextDouble() * 1000;
            myHeightMap[0][mySize - 1] = rand.NextDouble() * 1000;
            myHeightMap[mySize - 1][mySize - 1] = rand.NextDouble() * 1000;
        }

        /**
         * Uses diamond-square algorithm to create a planet geography.
         */
        private void generateHeightmap()
        {
            seedMap();

            double h = 500.0;

            for (int sideLength = mySize - 1; sideLength >= 2; sideLength /= 2, h /= 2)
            {
                int halfSide = sideLength / 2;
                // square algorithm
                for(int x = 0; x < mySize - 1; x += sideLength)
                {
                    for (int y = 0; y < mySize - 1; y += sideLength)
                    {
                        double avg = myHeightMap[x][y] +
                            myHeightMap[x + sideLength][y] +
                            myHeightMap[x][y + sideLength] +
                            myHeightMap[x + sideLength][y + sideLength];
                        avg /= 4.0;

                        myHeightMap[x + halfSide][y + halfSide] = avg + (rand.NextDouble() * 2 * h) - h;

                    }
                }
                // diamond algorithm
                for (int x  = 0; x < mySize - 1; x += halfSide)
                {
                    for (int y = (x + halfSide) % sideLength; y < mySize - 1; y += sideLength)
                    {
                        double avg = myHeightMap[(x - halfSide + mySize - 1) % (mySize - 1)][y] +
                            myHeightMap[(x + halfSide) % (mySize - 1)][y] +
                            myHeightMap[x][(y + halfSide) % (mySize - 1)] +
                            myHeightMap[x][(y - halfSide + mySize - 1) % (mySize - 1)];
                        avg /= 4.0;

                        avg = avg + (rand.NextDouble() * 2 * h) - h;
                        myHeightMap[x][y] = avg;

                        if (x == 0)
                        {
                            myHeightMap[mySize - 1][y] = avg;
                        }
                        if (y == 0)
                        {
                            myHeightMap[x][mySize - 1] = avg;
                        }
                    }
                }
            }
            //foreach (double[] row in myHeightMap)
            //{
            //    foreach (double d in row)
            //    {
            //        Console.Write(d.ToString("F") + " ");

            //    }
            //    Console.WriteLine();
            //}
        }

        private void generateOcean()
        {
            ArrayList heightArr = new ArrayList();


            foreach (double[] row in myHeightMap) {
                foreach (double d in row)
                {
                    heightArr.Add(d);
                }
            }

            heightArr.Sort();

            //double waterline = heightArr.GetRange(42, 1);
        }


    }
}
