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
using System.Drawing.Drawing2D;

namespace SpaceFortress.View
{
    public partial class WorldGenForm : Form
    {
        private GameEngine myGame;
        private Planet myPlanet;
        private int mapScale;
        private int zoomLevel;
        private bool showingPlanet;
        private int selectionX;
        private int selectionY;
        private int cameraX;
        private int cameraY;
        private int mouseDownX;
        private int mouseDowny;
        private bool isMouseDown;
        private Rectangle selectionBox;

        public WorldGenForm(GameEngine theGame)
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.DoubleBuffered = true;
            myGame = theGame;
            myPlanet = theGame.getPlanet();
            PlanetSizeCmbBox.DataSource = myPlanet.getSizes();
            isMouseDown = false;
            mapScale = 50;
            zoomLevel = 1;
            selectionX = 0;
            selectionY = 0;
            cameraX = 0;
            cameraY = 0;
            showingPlanet = false;

            selectionBox = new Rectangle(selectionX * mapScale, selectionY * mapScale, mapScale, mapScale);

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
                CreateWorld newPlanet = new CreateWorld();

                this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WorldGenForm_KeyPress);
                this.PlanetDrawPanel.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.PlanetDrawPanel_Scroll);

                this.PlanetDrawPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
                this.PlanetDrawPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
                this.PlanetDrawPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);

                PlanetDrawPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawPlanet);

                myPlanet.setTerrain(newPlanet.createMap(myPlanet.getSize()));
                myPlanet.setMap(newPlanet.getMap());

                showingPlanet = true;
                PlanetDrawPanel.Height = this.Height - 100;
                PlanetDrawPanel.Width = this.Width - 100;
                int sizeMod;
                if (PlanetDrawPanel.Height < PlanetDrawPanel.Width)
                {
                    sizeMod = PlanetDrawPanel.Height;
                }
                else
                {
                    sizeMod = PlanetDrawPanel.Width;
                }

                mapScale = sizeMod / myPlanet.getTerrain().Length;

                PlanetDrawPanel.Show();
                PlanetDrawPanel.Focus();
                PlanetDrawPanel.Invalidate();
                //drawPlanet();
            }
        }

        private void drawPlanet(object sender, PaintEventArgs e)
        {

            //    private void panel1_Paint(object sender, PaintEventArgs e)
            //{
            //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //    e.Graphics.FillEllipse(Brushes.Red, new Rectangle(10, 10, 32, 32));
            //}
            //Graphics graphics = PlanetDrawPanel.CreateGraphics();

            Terrain[][] drawPlanet = myPlanet.getTerrain();
            int endWidthPoint = PlanetDrawPanel.Width - (int)(PlanetDrawPanel.Width * 0.05);
            int endHeightPoint = PlanetDrawPanel.Height - (int)(PlanetDrawPanel.Height * 0.05);

            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(myPlanet.getMap(), new Point(0, 0));

            Pen drawPen = new Pen(Color.Red);

            e.Graphics.DrawRectangle(drawPen, selectionBox);
        }


        private void WorldGenForm_SizeChanged(object sender, EventArgs e)
        {
            if (showingPlanet)
            {
                //mapScale = PlanetDrawPanel.Width / myPlanet.getTerrain().Length;

                int sizeMod;
                if (PlanetDrawPanel.Height < PlanetDrawPanel.Width)
                {
                    sizeMod = PlanetDrawPanel.Height;
                }
                else
                {
                    sizeMod = PlanetDrawPanel.Width;
                }
                mapScale = sizeMod / myPlanet.getTerrain().Length;
                selectionBox.Width = mapScale + zoomLevel;
                selectionBox.Height = mapScale + zoomLevel;
                PlanetDrawPanel.Invalidate();
                //drawPlanet();
            }
        }

        private void randomizeBtnClick(object sender, EventArgs e)
        {
            CreateWorld newPlanet = new CreateWorld();

            myPlanet.setTerrain(newPlanet.createMap(myPlanet.getSize()));
            //this.drawPlanet();
            PlanetDrawPanel.Invalidate();
            PlanetDrawPanel.Focus();
        }

        private void WorldGenForm_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == 'w')
            {
                selectionY -= 1;
            }
            else if (e.KeyChar == 's')
            {
                selectionY += 1;
            }
            else if (e.KeyChar == 'a')
            {
                selectionX -= 1;
            }
            else if (e.KeyChar == 'd')
            {
                selectionX += 1;
            }
            selectionBox.Width = mapScale;
            selectionBox.Height = mapScale;
            selectionBox.X = selectionX * mapScale;
            selectionBox.Y = selectionY * mapScale;
            PlanetDrawPanel.Invalidate();
            //this.drawPlanet();
            PlanetDrawPanel.Focus();
        }

        private void PlanetDrawPanel_Click(object sender, EventArgs e)
        {
            this.Focus();
            Console.WriteLine("hi");
        }

        private void PlanetDrawPanel_Scroll(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.Delta);
            Console.WriteLine("hello!");

            //zoomLevel += e.Delta;

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            Console.WriteLine("Mouse down!");
            mouseDownX = e.X;
            mouseDowny = e.Y;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Console.WriteLine("hi?");
                int xDiff = mouseDownX - e.X;
                int yDiff = mouseDowny - e.Y;

                xDiff *= -1;
                yDiff *= -1;

                cameraX += xDiff;
                cameraY += yDiff;
                Invalidate();
            }
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}
