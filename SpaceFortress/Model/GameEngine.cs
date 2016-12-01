using System;
using System.Collections;
using SpaceFortress.Model.WorldGenerator;
using SpaceFortress.View;
using System.Windows.Forms;

namespace SpaceFortress.Model
{
    public class GameEngine
    {
        private Planet myPlanet;
        private ArrayList myChars;
        private StartScreen myStartScreen;

        public GameEngine(StartScreen theStartScreen)
        {
            myPlanet = new Planet();
            myChars = new ArrayList();
            myStartScreen = theStartScreen;
        }

        public GameEngine(Planet thePlanet, ArrayList theChars)
        {
            myPlanet = thePlanet;
            myChars = theChars;
        }

        public void newInit()
        {
            //Application.Run(new WorldGenForm());
            WorldGenForm newWorld = new WorldGenForm(this);
            newWorld.Show();
        }

        public StartScreen getStartScreen()
        {
            return myStartScreen;
        }

        public Planet getPlanet()
        {
            return myPlanet;
        }
    }
}
