using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popcorn_game
{
    public class Scene
    {
        //bricks properties
        List<Brick> bricks;
        int width = 60; int height = 20;
        Point point = new Point(20, 60);
        //border properties
        int border_width = 560;
        int border_height = 600;
        int border_X = 10;
        int border_Y = 10;
        Paddle paddle;
        Ball ball;

        public Scene()
        {
            bricks = new List<Brick>();
            paddle = new Paddle();
            ball = new Ball();
        }
        public void addBricks()
        {
            for(int i = 0; i < 7; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if( j % 2 == 0) bricks.Add(new Brick(point.X + i * width, point.Y + j * height, Color.Magenta));
                    else bricks.Add(new Brick(point.X + i * width, point.Y + j * height, Color.Aquamarine));
                    point = new Point(point.X, point.Y + 10);
                }
                point = new Point(20*(i+2), 60);
            }
        }

        public void Draw(Graphics g)
        {
            // drawing the border
            Pen pen = new Pen(Color.Aquamarine, 5);
            g.DrawRectangle(pen, border_X, border_Y, border_width, border_height);
            pen.Dispose();
            //
            foreach(Brick b in bricks)
            {
                b.Draw(g);
            }
            paddle.Draw(g);
            ball.Draw(g);
        }

        public void Move(Keys key)
        {
            paddle.Move(key, border_width, border_X);
        }
        public void Move()
        {
            ball.changeDirection(paddle.point, Paddle.WIDTH, border_width, border_height);
            ball.Move();
        }
    }
}
