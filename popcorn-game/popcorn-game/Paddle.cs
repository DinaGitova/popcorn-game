﻿using System;
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
        public Point point { get; set; }
        public static int WIDTH = 100;
        public static int HEIGHT = 10;
        public Color Color { get; set; }

        public Paddle()
        {
            point = new Point(250, 550);
            Color = Color.Aquamarine;
        }

        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color);
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

        public void letterCollision(List<Letter> letters)
        {
            foreach (Letter l in letters)
            {
                if (l.point.X >= point.X && l.point.X <= point.X + WIDTH && l.point.Y + Letter.HEIGHT >= point.Y && l.point.Y + Letter.HEIGHT <= point.Y + 5)
                {
                    l.isHit = true;
                }
            }
        }
    }
}
