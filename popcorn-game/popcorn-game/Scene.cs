﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popcorn_game
{
    public class Scene
    {
        //bricks properties
        public List<Brick> bricks;
        int width = 60; int height = 20;
        Point point = new Point(20, 60);
        //border properties
        int border_width = 560;
        int border_height = 600;
        int border_X = 10;
        int border_Y = 10;
        int counter = 0;
        public List<Letter> letters;
        Paddle paddle;
        Ball ball;
        public int points { get; set; }
        public int lives { get; set; }
        public bool canShoot { get; set; }
        List<Bullet> bullets;
        public bool GameOver { get; set; }
        public int pointValue { get; set; }

        public Scene()
        {
            bricks = new List<Brick>();
            paddle = new Paddle();
            ball = new Ball();
            letters = new List<Letter>();
            counter = 0;
            points = 0;
            lives = 3;
            canShoot = false;
            bullets = new List<Bullet>();
            GameOver = false;
            pointValue = 10;
        }
        public void addBricks() 
        {
            //Level 1 - brick formation
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j % 2 == 0) bricks.Add(new Brick(point.X + i * width, point.Y + j * height, Color.Magenta));
                    else bricks.Add(new Brick(point.X + i * width, point.Y + j * height, Color.Aquamarine));
                    point = new Point(point.X, point.Y + 10);
                }
                point = new Point(20 * (i + 2), 60);
            }

        }
        public void level2() 
        {
            //Level 2 - brick formation
            pointValue = 20;
            ball = new Ball();
            paddle = new Paddle();
            letters.Clear();
            bullets.Clear();
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            point = new Point(20, 40);
            int k = 2; int s = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (i == 4)
                    {
                        if (j % 2 == 0) bricks.Add(new Brick(point.X, point.Y + j * height, Color.Magenta));
                        point = new Point(point.X, point.Y + 10);
                    }
                    else
                    {
                        if (j % 2 == 0) bricks.Add(new Brick(point.X, point.Y + j * height, Color.Magenta));
                        else bricks.Add(new Brick(20 + 60 * s, point.Y + j * height, Color.Aquamarine));
                        point = new Point(point.X, point.Y + 10);
                    }
                }
                point = new Point(20 + k * width, 40);
                k += 2; s += 2;
            }
            
        }

        public void level3() 
        {
            //Level 3 - bricks formation
            pointValue = 30;
            ball = new Ball();
            paddle = new Paddle();
            letters.Clear();
            bullets.Clear();
            int milliseconds = 2000;
            Thread.Sleep(milliseconds);
            point = new Point(20, 60);
            int s = 2;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {

                    if (j % 2 == 0) bricks.Add(new Brick(point.X + i * width, point.Y + j * height, Color.Magenta));
                    else bricks.Add(new Brick(point.X + i * width, point.Y + j * height, Color.Aquamarine));
                    point = new Point(point.X, point.Y + 10);
                }
                if (i % 2 == 0) { point = new Point(20 * (i + 2), 60 * s); }
                else point = new Point(20 * (i + 2), 60);


            }
        }

        public void Draw(Graphics g)
        {
            // drawing the border
            Pen pen = new Pen(Color.Aquamarine, 5);
            g.DrawRectangle(pen, border_X, border_Y, border_width, border_height);
            pen.Dispose();
            // ------
            foreach (Brick b in bricks)
            {
                b.Draw(g);
            }
            paddle.Draw(g);
            ball.Draw(g);
            if (letters.Count != 0)
            {
                foreach (Letter l in letters)
                {
                    l.Draw(g);
                }
            }
            foreach (Bullet b in bullets)
            {
                b.Draw(g);
            }
        }

        public void Move(Keys key)
        {
            paddle.Move(key, border_width, border_X);
        }
        public void Move()
        {
            ball.changeDirection(paddle.point, Paddle.WIDTH, border_width, border_height);
            ball.brickCollision(bricks);
            foreach (Bullet b in bullets) b.brickCollision(bricks);        
            removeBricks();
            removeBullets();
            deadBall();
            ball.Move();
            foreach (Letter l in letters)
            {
                l.Move();
            }
            paddle.letterCollision(letters);
            removeLetters();
            foreach (Bullet b in bullets)
            {
               b.Move();
            }
            if (bricks.Count == 0) GameOver = true; 
        }

        public void deadBall()
        {
            // If the ball fell, restart and decrease lives
            if (ball.isDead)
            {

                if (lives > 1)
                {
                    lives--;
                    ball = new Ball();
                    removeGifts();
                    letters.Clear();
                    bullets.Clear();
                    paddle = new Paddle();
                }

                else GameOver = true;
            }
        }
        public void removeBricks()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                if (bricks[i].isDead)
                {
                    counter++;
                    if (counter % 5 == 0) letters.Add(new Letter(bricks[i].point));
                    bricks.RemoveAt(i);
                    points += pointValue;
                }
            }
        }
        public void removeBullets()
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].isHit) bullets.RemoveAt(i);
            }
        }
        public void removeLetters()
        {
            for (int i = 0; i < letters.Count; i++)
            {
                if (letters[i].isHit)
                {
                    points += 20;
                    if (letters[i].letter == 'A') slowerBall();
                    else if (letters[i].letter == 'B') { removeGifts(); paddle.Color = Color.DarkBlue; canShoot = true; }
                    else if (letters[i].letter == 'C') fasterBall();
                    else if (letters[i].letter == 'D') loseLife();
                    else if (letters[i].letter == 'E') extendPaddle();
                    else if (letters[i].letter == 'F') addScore();
                    else if (letters[i].letter == 'G') addLife();

                    letters.RemoveAt(i);
                }
            }
        }

        // Functions for each letter
        public void loseLife()
        {
            removeGifts();
            if (lives > 1) lives--;
            else GameOver = true;
        }

        public void addLife()
        {
            removeGifts();
            lives++;
        }

        public void addScore()
        {
            removeGifts();
            points += 50;
        }
        public void extendPaddle()
        {
            removeGifts();
            Paddle.WIDTH = 150;
            paddle.Color = Color.Pink;
        }
        public void shoot()
        {
            if(canShoot)
            {
                bullets.Add(new Bullet(new Point(paddle.point.X + Paddle.WIDTH/2, paddle.point.Y)));
            }
        }

        public void fasterBall()
        {
            removeGifts();
            paddle.Color = Color.Red;
            if (ball.speed_X < 0) ball.speed_X = -10;
            else if(ball.speed_X > 0) ball.speed_X = 10;
            if(ball.speed_Y < 0) ball.speed_Y = -10;
            else if(ball.speed_Y > 0) ball.speed_Y = 10;
        }
        public void slowerBall()
        {
            removeGifts();
            paddle.Color = Color.Green;
            if (ball.speed_X < 0) ball.speed_X = -5;
            else if (ball.speed_X > 0) ball.speed_X = 5;
            if (ball.speed_Y < 0) ball.speed_Y = -5;
            else if (ball.speed_Y > 0) ball.speed_Y = 5;
        }

        public void removeGifts() // If a different letter is collected, remove previous changes 
        {
            if (Paddle.WIDTH == 150) Paddle.WIDTH = 100;
            paddle.Color = Color.Aquamarine;
            canShoot = false;
            if (ball.speed_X < 0) ball.speed_X = -7;
            else if (ball.speed_X > 0) ball.speed_X = 7;
            if (ball.speed_Y < 0) ball.speed_Y = -7;
            else if (ball.speed_Y > 0) ball.speed_Y = 7;
        }
        
    }
}
