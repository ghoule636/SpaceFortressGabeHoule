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
using SpaceFortress.Model.Landscape;

namespace SpaceFortress.View
{
    public partial class WorldGenForm : Form
    {
        private GameEngine myGame;
        private Planet myPlanet;
        private int mapScale;
        private bool showingPlanet;

        public WorldGenForm(GameEngine theGame)
        {
            InitializeComponent();
            myGame = theGame;
            myPlanet = theGame.getPlanet();
            PlanetSizeCmbBox.DataSource = myPlanet.getSizes();
            mapScale = 50;
            showingPlanet = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            myPlanet.setName(textBox1.Text);
        }

        private void WorldGenForm_Load(object sender, EventArgs e)
        {
            PlanetDrawPanel.BackColor = Color.White;
            PlanetDrawPanel.Hide();
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
                myPlanet.setTerrain(new CreateWorld().createMap(myPlanet.getSize()));
                showingPlanet = true;
                PlanetDrawPanel.Height = this.Height - 100;
                PlanetDrawPanel.Width = this.Width - 100;
                int sizeMod;
                if (PlanetDrawPanel.Height > PlanetDrawPanel.Width)
                {
                    sizeMod = PlanetDrawPanel.Height;
                } else
                {
                    sizeMod = PlanetDrawPanel.Width;
                }

                mapScale = sizeMod / myPlanet.getTerrain().Length;
                PlanetDrawPanel.Show();
                drawPlanet();
            }
        }

        private void drawPlanet()
        {
            Graphics graphics = PlanetDrawPanel.CreateGraphics();
            Terrain[][] drawPlanet = myPlanet.getTerrain();
            Brush drawBrush = null;
            //int startPoint = 10;
            int endWidthPoint = PlanetDrawPanel.Width - (int)(PlanetDrawPanel.Width * 0.05);
            int endHeightPoint = PlanetDrawPanel.Height - (int)(PlanetDrawPanel.Height * 0.05);

            graphics.Clear(Color.White);

            //Rectangle rectangle = new Rectangle(startPoint, startPoint, endWidthPoint, endHeightPoint);
            //graphics.DrawRectangle(Pens.Red, rectangle);
            Console.Write("scale: " + mapScale);
            Console.Write("width: " + PlanetDrawPanel.Width);
            Console.Write("mapWidth: " + myPlanet.getTerrain().Length);
            Console.WriteLine();

            for (int i = 0; i < drawPlanet.Length; i += 1)
            {
                for (int j = 0; j < drawPlanet[0].Length; j += 1)
                {
                    Rectangle rect = new Rectangle(i * mapScale, j * mapScale, mapScale, mapScale);

                    if (drawPlanet[i][j].GetType().Equals(typeof(Ocean)))
                    {
                        drawBrush = new SolidBrush(Color.DarkBlue);
                    } else if (drawPlanet[i][j].GetType().Equals(typeof(Mountain)))
                    {
                        drawBrush = new SolidBrush(Color.Gray);
                    }
                    else if (drawPlanet[i][j].GetType().Equals(typeof(Hill)))
                    {
                        drawBrush = new SolidBrush(Color.SaddleBrown);
                    }
                    else if (drawPlanet[i][j].GetType().Equals(typeof(Plains)))
                    {
                        drawBrush = new SolidBrush(Color.ForestGreen);
                    } else
                    {
                        drawBrush = new SolidBrush(Color.Red);
                    }


                    graphics.FillRectangle(drawBrush, rect);
                }
            }

            //for (int i = startPoint; i < endWidthPoint + startPoint; i += mapScale)
            //{
            //    Point gridTop = new Point(i, startPoint);
            //    Point gridBottom = new Point(i, endHeightPoint + startPoint);
            //    graphics.DrawLine(Pens.Black, gridTop, gridBottom);
            //}
            //for (int j = startPoint; j < endHeightPoint + startPoint; j += mapScale)
            //{
            //    Point gridStart = new Point(startPoint, j);
            //    Point gridEnd = new Point(endWidthPoint + startPoint, j);
            //    graphics.DrawLine(Pens.Black, gridStart, gridEnd);
            //}

        }

        private void WorldGenForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void WorldGenForm_SizeChanged(object sender, EventArgs e)
        {
            if(showingPlanet)
            {
                mapScale = PlanetDrawPanel.Width / myPlanet.getTerrain().Length;
                drawPlanet();
            }
        }
    }
}
