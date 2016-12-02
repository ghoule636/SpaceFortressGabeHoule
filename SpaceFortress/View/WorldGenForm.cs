using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceFortress.Model;
using SpaceFortress.Model.WorldGenerator;

namespace SpaceFortress.View
{
    public partial class WorldGenForm : Form
    {
        private GameEngine myGame;
        private Planet myPlanet;

        public WorldGenForm(GameEngine theGame)
        {
            InitializeComponent();
            myGame = theGame;
            myPlanet = theGame.getPlanet();
            PlanetSizeCmbBox.DataSource = myPlanet.getSizes();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            myPlanet.setName(textBox1.Text);
        }

        private void WorldGenForm_Load(object sender, EventArgs e)
        {
        }

        private void WorldGenForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Closes the application if this window is closed.
            myGame.getStartScreen().Dispose();
        }

        private void PlanetSizeCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            myPlanet.setSize(PlanetSizeCmbBox.SelectedIndex);
        }

        private void nameTextBox1_Validated(object sender, System.EventArgs e)
        {
            if (IsNameValid(textBox1.Text))
            {
                // Clear the error, if any, in the error provider.
                errorProvider1.SetError(this.textBox1, String.Empty);
            }
            else
            {
                // Set the error if the name is not valid.
                errorProvider1.SetError(this.textBox1, "Name is required.");
            }
        }

        private bool IsNameValid(String theName)
        {
            bool result = false;

            if (theName.Length > 0)
            {
                result = true;
            }

            return result;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (myPlanet.getName() != "")
            {
                textBox1.Hide();
                label1.Hide();
                PlanetSizeCmbBox.Hide();
                label2.Hide();
                NextBtn.Enabled = false;
                myPlanet.setTerrain(CreateWorld.createMap(myPlanet.getSize()));
                MapGenInfo.Text = myPlanet.getTerrain().GetLength(0).ToString();
            }
        }
    }
}
