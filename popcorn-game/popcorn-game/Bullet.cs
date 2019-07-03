using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popcorn_game
{
    public class Bullet
    {
        public Point point { get; set; }
        public static int RADIUS = 2;
        public bool isHit { get; set; }

        public Bullet(Point point)
        {
            this.point = point;
            isHit = false;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.White);
            g.FillEllipse(brush, point.X, point.Y, RADIUS * RADIUS, RADIUS * RADIUS);
        }

        public void Move()
        {
            point = new Point(point.X, point.Y - 10);
        }
        public void brickCollision(List<Brick> bricks)
        {
            foreach (Brick b in bricks)
            {
                if (point.X <= b.point.X + Brick.WIDTH && point.X >= b.point.X && point.Y <= b.point.Y + Brick.HEIGHT && point.Y >= b.point.Y)
                {
                    b.isDead = true;
                    isHit = true;
                }
            }
        }
    }
}
