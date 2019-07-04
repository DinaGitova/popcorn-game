using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popcorn_game
{
    public partial class GameForm : Form
    {
        Scene scene;
        HelpMenuForm help;
        public GameForm()
        {
            InitializeComponent();
            scene = new Scene();
            scene.addBricks();
            DoubleBuffered = true;
            lblName.Text = TitleForm.text.ToString();
            timer.Start();
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            scene.Draw(e.Graphics);
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space) scene.shoot();
            else if (e.KeyCode == Keys.Escape)
            {
                help = new HelpMenuForm();
                timer.Enabled = false;
                if (help.ShowDialog(this) == DialogResult.Cancel) timer.Enabled = true;
                else { this.Hide(); }
            }
            else scene.Move(e.KeyCode);
            Invalidate(true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            scene.Move();
            lblLives.Text = scene.lives.ToString();
            lblPoints.Text = scene.points.ToString();
            Invalidate(true);
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {
            if (scene.GameOver) toolStripStatusLabel1.Text = "GAME OVER";
            else toolStripStatusLabel1.Text = "Points: " + scene.points.ToString();
        }

        private void toolStripStatusLabel2_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel2.Text = "Lives: " + scene.lives.ToString();
        }

        

       
    }
}
