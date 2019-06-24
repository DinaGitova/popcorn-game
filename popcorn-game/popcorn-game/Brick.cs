using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popcorn_game
{
   public class Brick
    {
        public Point point { get; set; }
        public static int WIDTH = 60;
        public static int HEIGHT = 20;
        public Color color { get; set; }
        
        public Brick(int x, int y, Color color)
        {
            point = new Point(x, y);
            this.color = color;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(color);
            g.FillRectangle(brush, point.X, point.Y, WIDTH, HEIGHT);
        }
        
    }
}
