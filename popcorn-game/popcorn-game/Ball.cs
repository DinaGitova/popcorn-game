using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace popcorn_game
{
    public class Ball
    {
        public enum Direction { UP, DOWN, LEFT, RIGHT}
        public Point Center { get; set; }
        public static int RADIUS = 4;
        public Direction direction { get; set; }

        public Ball()
        {
            Center = new Point(300, 520);
            direction = Direction.DOWN;
        }
        public void Draw(Graphics g)
        {
            Brush brush = new SolidBrush(Color.AntiqueWhite);
            g.FillEllipse(brush, Center.X - RADIUS, Center.Y - RADIUS, RADIUS * RADIUS, RADIUS * RADIUS);
            brush.Dispose();
        }
        public void Move()
        {
            if( direction == Direction.DOWN)
            {
                Center = new Point(Center.X, Center.Y + 10);
            }
            if( direction == Direction.UP)
            {
                Center = new Point(Center.X, Center.Y - 10);
            }
            if (direction == Direction.LEFT)
            {
                Center = new Point(Center.X + 10, Center.Y - 10);
            }
            if (direction == Direction.RIGHT)
            {
                Center = new Point(Center.X - 10, Center.Y - 10);
            }
        }
        public void changeDirection(Point paddle, int width, int border_width, int border_height)
        {
            // ball hits paddle
            if (Center.X > paddle.X && Center.X < paddle.X + width && paddle.Y - 10 == Center.Y)
            {
                int difference = paddle.X + width - Center.X;
                if ( difference >= 0  && difference < 45 ) direction = Direction.LEFT;
                if ( difference >= 45 && difference <= 55) direction = Direction.UP;
                if ( difference > 55 && difference < 100) direction = Direction.RIGHT;

            }
            // ball hits border
            if(Center.X > 10 && Center.X < border_width &&  10 == Center.Y) direction = Direction.DOWN;
           

        }
    }
}
