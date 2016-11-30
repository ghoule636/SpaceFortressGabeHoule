using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.WorldGenerator
{
    public class Planet
    {
        private ArrayList world;
        private int myWidth;
        private int myHeight;

        public Planet()
        {
            world = new ArrayList();
            myWidth = 0;
            myHeight = 0;
        }

        public Planet getPlanet()
        {
            return this;
        }

        public int getWidth()
        {
            return myWidth;
        }

        public int getHeight()
        {
            return myHeight;
        }
    }
}
