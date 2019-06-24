using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace popcorn_game
{
    public class Paddle
    {
        public Point point;
        public static int WIDTH = 100;
        public static int HEIGHT = 10;

        public Paddle()
        {
            point = new Point(250, 550);
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Aquamarine);
            g.FillRectangle(brush, point.X, point.Y, WIDTH, HEIGHT);
        }

        public void Move(Keys key, int border_width, int border_X)
        {
            if (key == Keys.Left && point.X > border_X)
            {
                point = new Point(point.X - 10, point.Y);
            }
            else if (key == Keys.Right && point.X + WIDTH <= border_width)
            {
                point = new Point(point.X + 10, point.Y);
            }
        }

    }
}
