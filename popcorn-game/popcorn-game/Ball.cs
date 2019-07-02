using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace popcorn_game
{
    public class Ball
    {
        public Point Center { get; set; }
        public static int RADIUS = 4;
        public int speed_X { get; set; }
        public int speed_Y { get; set; }
        public SoundPlayer paddle_sound = new SoundPlayer(Properties.Resources.effect_paddle);
        public SoundPlayer brick_sound = new SoundPlayer(Properties.Resources.effect_brick);
        public SoundPlayer border_sound = new SoundPlayer(Properties.Resources.effect_border);


        public Ball()
        {
            Center = new Point(300, 520);
            speed_X = speed_Y = 5;
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
            // ball hits paddle
            if (Center.X > paddle.X && Center.X < paddle.X + width && paddle.Y - 10 == Center.Y)
            {
                paddle_sound.Play();
                if ((Center.X < paddle.X && speed_X > 0) || (Center.X > paddle.X + Paddle.WIDTH && speed_X < 0)) speed_X *= -1;
                speed_Y *= -1;
            }
            // ball hits border
            if (Center.X <= 15 || Center.X + RADIUS >= border_width) { speed_X *= -1; border_sound.Play(); }
            if (Center.Y <= 15) { speed_Y *= -1; border_sound.Play(); }
        }
        public void brickCollision(List<Brick> bricks)
        {
            foreach(Brick b in bricks)
            {
                if (Center.X <= b.point.X + Brick.WIDTH && Center.X >= b.point.X && Center.Y <= b.point.Y + Brick.HEIGHT && Center.Y >= b.point.Y)
                {
                    brick_sound.Play();
                    b.isDead = true;
                    speed_Y *= -1;
                }
            }
        }
    }
}
