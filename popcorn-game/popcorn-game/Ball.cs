using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace popcorn_game
{
    public class Ball
    {
        public Point Center { get; set; }
        public static int RADIUS = 4;
        public int speed_X { get; set; }
        public int speed_Y { get; set; }
        public bool isDead { get; set; }
        // Sound effects
        public SoundPlayer paddle_sound = new SoundPlayer(Properties.Resources.effect_paddle);
        public SoundPlayer brick_sound = new SoundPlayer(Properties.Resources.effect_brick);
        public SoundPlayer border_sound = new SoundPlayer(Properties.Resources.effect_border);
        public SoundPlayer lose_sound = new SoundPlayer(Properties.Resources.effect_lose);

        public Ball()
        {
            Center = new Point(300, 520);
            speed_X = speed_Y = 7;
        }

        public Ball(Point Center, int speed_X, int speed_Y)
        {
            this.Center = Center;
            this.speed_X = speed_X;
            this.speed_Y = speed_Y;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.AntiqueWhite);
            g.FillEllipse(brush, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * RADIUS, RADIUS * RADIUS);
            brush.Dispose();
        }
        public void Move()
        {
            Center = new Point(Center.X + speed_X, Center.Y + speed_Y);
        }
        public void changeDirection(Point paddle, int width, int border_width, int border_height)
        {
            // check if ball hits paddle
            if (Center.X >= paddle.X && Center.X < paddle.X + width && Center.Y >= paddle.Y - 10 && Center.Y <= paddle.Y + 10)
            {
                paddle_sound.Play();
                if ((Center.X < paddle.X && speed_X > 0) || (Center.X > paddle.X + Paddle.WIDTH && speed_X < 0))
                speed_X *= -1;
                speed_Y *= -1;
            }
            // check if ball hits border
            if (Center.X <= 20 || Center.X + RADIUS >= border_width) { speed_X *= -1; border_sound.Play(); }
            if (Center.Y <= 20) { speed_Y *= -1; border_sound.Play(); }
            if (Center.Y + RADIUS >= border_height && Center.Y + RADIUS <= border_height + border_width)
            {
                lose_sound.Play();
                int milliseconds = 2500;
                Thread.Sleep(milliseconds);
                isDead = true;
            }
        }
        public void brickCollision(List<Brick> bricks)
        {
            // check if ball hits a brick
            foreach(Brick b in bricks)
            {
                if (Center.X - RADIUS<= b.point.X + Brick.WIDTH && Center.X - RADIUS >= b.point.X && Center.Y -RADIUS <= b.point.Y + Brick.HEIGHT && Center.Y - RADIUS>= b.point.Y ||
                    (Center.X + RADIUS >= b.point.X && Center.X + RADIUS <= b.point.X + Brick.WIDTH && Center.Y + RADIUS >= b.point.Y && Center.Y + RADIUS <= b.point.Y +Brick.HEIGHT))
                {
                    brick_sound.Play();
                    b.isDead = true;
                    speed_Y *= -1;
                }
            }
        }
    }
}
