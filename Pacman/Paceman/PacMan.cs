using System.Drawing;

namespace Pacman
{
    public class PacMan
    {
        public enum DIRECTION { left,right, up, down };
        public Point position{ get; set; }//the center of the pacman
        public DIRECTION  direction { get; set; }

        public static int  radius  = 20;
        public bool isOpenMouth { get; set; }
        public Brush brush { get; set; }
        public int leftLimit { get; set; }//the left limit of the field where the pacman may walk
        public int rightLimit { get; set; }//the right limit of the field where the pacman may walk
        public int bottomLimit { get; set; }//the bottom limit of the field where the pacman may walk
                                            //the top limit is always 0
        public PacMan(int left,int right,int bottom,Point position,Color color)
        {
            leftLimit = left;
            rightLimit = right;
            bottomLimit = bottom;
            this.position = position;
            brush = new SolidBrush(color);
            direction=DIRECTION.right;
            isOpenMouth = true;
        }

        public void ChangeDirection(DIRECTION direction)
        {
            this.direction = direction;
        }

        public void Move()
        {
            int value = 15;
            if (direction == DIRECTION.right)
            {
                int newX = position.X + value;
                if (newX > rightLimit) newX = leftLimit;//if it exceeds the right limit of the field put him on the left limit
                position = new Point(newX, position.Y);
            }else if (direction == DIRECTION.left)
            {
                int newX = position.X - value;
                if (newX <leftLimit) newX = rightLimit;
                position = new Point(newX, position.Y);

            }else if (direction == DIRECTION.up)
            {
                int newY = position.Y - value;
                if (newY <0) newY = bottomLimit;
                position = new Point(position.X, newY);
            }
            else
            {
                int newY = position.Y + value;
                if (newY > bottomLimit) newY = 0;
                position = new Point(position.X, newY);
            }
            isOpenMouth = !isOpenMouth;
        }

        public void Draw(Graphics g)
        {
            if (isOpenMouth==false)
            {
                g.FillEllipse(brush, position.X - radius, position.Y - radius, 2*radius, 2*radius);
            }
            else
            {
                if (direction == DIRECTION.right)              
                    g.FillPie(brush, position.X - radius, position.Y - radius, 2*radius, 2*radius, 60,290);
                else if(direction==DIRECTION.left)
                    g.FillPie(brush, position.X - radius, position.Y - radius, 2 * radius, 2 * radius, 190,280 );
                else if(direction==DIRECTION.up)
                    g.FillPie(brush, position.X - radius, position.Y - radius, 2 * radius, 2 * radius, -70, 300);
                else
                    g.FillPie(brush, position.X - radius, position.Y - radius, 2 * radius, 2 * radius, 115, 300);
            }
        }
    } 
}
