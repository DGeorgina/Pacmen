using System;
using System.Drawing;

namespace Pacman
{
    public class Positioner
    {
        public Point Center { get; set; }

        public Random random { get; set; } = new Random();
        public int width { get; set; }
        public int height { get; set; }

        public float Velocity { get; set; }
        public float Angle { get; set; }

        public Rectangle horizontal { get; set; }//the horizontal black line 
        public Rectangle vertical { get; set; }//the vertical black line
        private float velocityX;
        private float velocityY;
        public Positioner(int width, int height)
        {   
                Velocity = 5;
                Angle = 30;
                velocityX = (float)Math.Cos(Angle) * Velocity;
                velocityY = (float)Math.Sin(Angle) * Velocity;
            
            this.width = width;
            this.height = height;

            int flag = random.Next(1, 3);
            int x, y;
            if (flag == 1)//put the center of the black figure in the first Pac-Man's field
                 x = random.Next(100, width - 500);//so that the x coordinate is not exactly over the Pac-Man,because if it is the game will end before it starts
            else
                 x = random.Next(500, width-50);//put the center of the black figure in the first Pac-Man's field

            y = random.Next(100, height - 50);
            Center = new Point(x, y);
            updateRectangles();
        }
        public void updateRectangles()
        {
             horizontal = new Rectangle(0, Center.Y - 2, width, 4);
             vertical = new Rectangle(Center.X + 2, 0, 4, height);
        }
        public void draw(Graphics g)
        {
            Brush b = new SolidBrush(Color.Black);
            g.FillRectangle(b, horizontal);
            g.FillRectangle(b, vertical);
        }

        public void Move()
        {
            
                float nextX = Center.X + velocityX;
                float nextY = Center.Y + velocityY;
                if (nextX -2 <= 70 || (nextX + 2 >= width-70))
                {
                    velocityX = -velocityX;
                }
                if (nextY - 2 <= 70 || (nextY + 2 >= height-70))
                {
                    velocityY = -velocityY;
                }
            Center = new Point((int)(Center.X + velocityX), (int)(Center.Y + velocityY));
            updateRectangles();
        }
    }
}
