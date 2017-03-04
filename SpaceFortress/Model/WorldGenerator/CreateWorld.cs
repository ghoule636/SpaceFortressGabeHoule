using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceFortress.Model.Landscape;
using System.Collections.Generic;
using System.Drawing;

namespace SpaceFortress.Model.WorldGenerator
{
    class CreateWorld
    {
        private static Random rand = new Random();

        private static int SMALL = 129;
        private static int MEDIUM = 257;
        private static int LARGE = 513;
        private static double WATER_LEVEL = 0.6;
        private static double HILL_LINE = 0.9;
        private static double TREE_LINE = 0.98;

        private Terrain[][] myTerrain;
        private double[][] myHeightMap;
        private Bitmap myBitmap;
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

            generateGeography();

            createBitMap();

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

        public Bitmap getBitmap()
        {
            return myBitmap;
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
                        avg += (rand.NextDouble() * 2 * h) - h;
                        myHeightMap[x + halfSide][y + halfSide] = avg;
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
                        avg += (rand.NextDouble() * 2 * h) - h;
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
        }

        private void generateGeography()
        {
            List<double> heightArr = new List<double>();

            foreach (double[] row in myHeightMap) {
                foreach (double d in row)
                {
                    heightArr.Add(d);
                }
            }

            heightArr.Sort();

            double waterline = heightArr[(int) (heightArr.Count * WATER_LEVEL)];
            double treeline = heightArr[(int) (heightArr.Count * TREE_LINE)];
            double hillline = heightArr[(int)(heightArr.Count * HILL_LINE)];

            for (int i = 0; i < myHeightMap[0].Length; i++)
            {
                for (int j = 0; j < myHeightMap.Length; j++)
                {
                    double temp = myHeightMap[i][j];

                    // create geography types
                    if (temp < waterline)
                    {
                        myTerrain[i][j] = new Water(temp);
                    }
                    else if (temp > hillline && temp < treeline)
                    {
                        myTerrain[i][j] = new Hill(temp);
                    }
                    else if (temp > treeline) 
                    {
                        myTerrain[i][j] = new Mountain(temp);
                    } else
                    {
                        myTerrain[i][j] = new Plains(temp);
                    }
                }
            }
        }

        private void createBitMap()
        {
            int scaleOffset = 1;
            Bitmap map = new Bitmap(mySize * scaleOffset, mySize * scaleOffset);
            Graphics mapG = Graphics.FromImage(map);

            Brush OceanBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 200));
            Brush MountainBrush = new SolidBrush(Color.DarkGray);
            Brush PlainsBrush = new SolidBrush(Color.ForestGreen);
            Brush HillBrush = new SolidBrush(Color.SaddleBrown);

            for (int i = 0; i < myTerrain.Length; i += 1)
            {
                for (int j = 0; j < myTerrain[0].Length; j += 1)
                {
                    Rectangle rect = new Rectangle(i * scaleOffset, j * scaleOffset, scaleOffset, scaleOffset);
                    //gridY++;

                    Terrain temp = myTerrain[i][j];

                    //int colorVal = (int) (255 * (Math.Abs(temp.getElevation() / myPlanet.getMaxHeight())));
                    //drawBrush = new SolidBrush(Color.FromArgb(255, colorVal, colorVal, colorVal));

                    if (temp.GetType().Equals(typeof(Water)))
                    {
                        //int colorVal = (int)(100 * (Math.Abs(temp.getElevation() / myPlanet.getWaterLevel()) + .0001));
                        mapG.FillRectangle(OceanBrush, rect);
                    }
                    else if (temp.GetType().Equals(typeof(Mountain)))
                    {
                        mapG.FillRectangle(MountainBrush, rect);
                    }
                    else if (temp.GetType().Equals(typeof(Hill)))
                    {
                        mapG.FillRectangle(HillBrush, rect);
                    }
                    else if (temp.GetType().Equals(typeof(Plains)))
                    {
                        //int colorVal = (int)(255 * (Math.Abs(temp.getElevation() / myPlanet.getMaxHeight()) + .0001));
                        //drawBrush = new SolidBrush(Color.FromArgb(255, 0, colorVal, 0));

                        mapG.FillRectangle(PlainsBrush, rect);
                    }
                    else
                    {
                        mapG.FillRectangle(new SolidBrush(Color.Red), rect);
                    }

                    //e.Graphics.FillRectangle(drawBrush, rect);
                }
                //gridX++;
                //gridY = 0;
            }



            //while (white <= 100)
            //{
            //    mapG.FillRectangle(Brushes.Red, 0, red, 200, 10);
            //    mapG.FillRectangle(Brushes.White, 0, white, 200, 10);
            //    red += 20;
            //    white += 20;
            //}

            myBitmap = map;

        }



    }
}
