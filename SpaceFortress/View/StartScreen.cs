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

namespace SpaceFortress.View
{
    public partial class StartScreen : Form
    {
        public GameEngine myGame;

        public StartScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }


        private void StartScreen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            myGame = new GameEngine(this);
            myGame.newInit();

            this.Hide();
        }
    }
}
