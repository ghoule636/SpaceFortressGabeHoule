using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceFortress.Model.WorldGenerator
{
    public class Planet
    {
        private ArrayList myWorld;
        private String myName;
        private String mySize;
        private String[] mySizes;

        public Planet()
        {
            myWorld = new ArrayList();
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
