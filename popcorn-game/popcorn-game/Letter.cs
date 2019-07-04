using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popcorn_game
{
    public class Letter
    {
        public Point point { get; set; }
        public static int WIDTH = 30;
        public static int HEIGHT = 30;
        public char letter { get; set; }
        public bool isHit { get; set; }
        
        public Letter(Point point)
        {
            Random r = new Random();
            letter = (char)r.Next('A', 'H');
            this.point = point;
            isHit = false;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.Pink);
            Brush font_brush = new SolidBrush(Color.White);
            Font font = new Font("Arial", 15);
            g.FillRectangle(brush, point.X, point.Y, WIDTH, HEIGHT);
            g.DrawString(letter.ToString(), font, font_brush, point.X + 5, point.Y + 5);
        }

        public void Move()
        {
            point = new Point(point.X, point.Y + 3);
        }
    }
}
