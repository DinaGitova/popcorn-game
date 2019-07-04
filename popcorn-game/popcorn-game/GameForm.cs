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
        public static bool inGame = false;
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
                inGame = true;
                if (help.ShowDialog(this) == DialogResult.Cancel) { timer.Enabled = true; inGame = false; }
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
            GameOver();
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

        
        public  void GameOver()
        {
            if(scene.GameOver)
            {
                lblGameOver.Visible = true;
                timer.Stop();
                if (scene.bricks.Count == 0) lblGameOver.Text = "Congratulations " + TitleForm.text.ToString() + ", you won!\n Your score is:" + scene.points.ToString(); 
                else
                {
                    lblGameOver.Text = "Game Over " + TitleForm.text.ToString() + ", you lost!\n Your score is: " + scene.points.ToString();
                }
            }
        }
       
    }
}
