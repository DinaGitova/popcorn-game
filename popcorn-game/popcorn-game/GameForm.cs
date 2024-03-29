﻿using System;
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
        int level = 1;
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
            // Checks key pressed - Space to shoot, ESC to open HelpMenu, Left/Right to move paddle
            if (e.KeyCode == Keys.Space) scene.shoot();
            else if (e.KeyCode == Keys.Escape)
            {
                help = new HelpMenuForm();
                timer.Enabled = false;
                if (help.ShowDialog(this) == DialogResult.Cancel) { timer.Enabled = true; }
                else { this.Hide(); }
            }
            else scene.Move(e.KeyCode);
            Invalidate(true);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Move ball and update labels 
            scene.Move();
            lblLives.Text = scene.lives.ToString();
            lblPoints.Text = scene.points.ToString();
            lblLevel.Text = level.ToString();
            GameOver();
            Invalidate(true);
        }

        private void toolStripStatusLabel1_Paint(object sender, PaintEventArgs e)
        {
            toolStripStatusLabel1.Text = "Number of bricks left: " + scene.bricks.Count.ToString();
        }


        
        public  void GameOver()
        {
            // Loads next level if possible or prints Game over/You Won message
            if(scene.GameOver)
            {
                timer.Stop();
                if (scene.bricks.Count == 0)
                {
                    if(level == 1)
                    {
                        scene.GameOver = false;
                        level++;
                        scene.level2();
                        timer.Start();
                    }
                    else if (level == 2)
                    {
                        scene.GameOver = false;
                        level++;
                        scene.level3();
                        timer.Start();
                    }
                    else
                    {
                        lblGameOver.Visible = true;
                        lblGameOver.Text = "Congratulations " + TitleForm.text.ToString() + ", you won!\nYour score is: " + scene.points.ToString() + "\nPress ESC to exit ";
                    }
                }
                else
                {
                    lblGameOver.Visible = true;
                    lblGameOver.Text = "Game Over " + TitleForm.text.ToString() + ", you lost!\nYour score is: " + scene.points.ToString() + "\nPress ESC to exit ";
                }
            }
        }
       
    }
}
