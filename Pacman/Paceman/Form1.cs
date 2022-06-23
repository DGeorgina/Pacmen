using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pacman
{
    public partial class Form1 : Form
    {

        public static readonly int TIMER_INTERVAL = 150;//if we want to make the pacman to run faster/slower we just need to change this value
        public static readonly int WORLD_WIDTH = 10;//10 eating objects per row for one pacman
        public static readonly int WORLD_HEIGHT = 10;//10 eating objects per column for one pacman
        public  Rectangle rectangle1 { get; set; } = new Rectangle(2, 1,400,400);// bounds of the first player 
        public  Rectangle rectangle2 { get; set; } = new Rectangle(410, 1, 400, 400);//bounds of the second player
      
        public List<Rectangle> rectangles1 { get; set; }//eating objects of the first player 
        public List<Rectangle> rectangles2 { get; set; }//eating objects of the second player

        public PacMan pacman1 { get; set; }
        public PacMan pacman2 { get; set; }
        public Positioner positioner { get; set; }

        public int timeInSeconds { get; set; } //the game ends after a certain amount of time passes,no matter if there's a winner or not
        public Form1()
        {
            InitializeComponent();   
            this.Width=829;
            this.Height = 518;
            DoubleBuffered = true;
            newGame();
        }

        public void newGame()
        {
            pacman1 = new PacMan(0,rectangle1.Size.Width-PacMan.radius,rectangle1.Size.Height-PacMan.radius,new Point(20,23),Color.Red);
            pacman2=new PacMan(430,rectangle2.Size.Width-PacMan.radius+405, rectangle2.Size.Height-PacMan.radius,new Point(430,23),Color.Blue);

            positioner = new Positioner(this.Width, rectangle1.Height);

            rectangles1 = new List<Rectangle>();
            rectangles2 = new List<Rectangle>();

            timeInSeconds = 180;
            lblTimeLeft.Text = "03:00";

            // start the timer     
            timer1.Interval= TIMER_INTERVAL;
            
            //put the initial eating objects in the lists
            for (int i = 0; i < WORLD_HEIGHT; i++)
                for (int j = 0; j < WORLD_WIDTH; j++)
                {
                    Rectangle r = new Rectangle(j * PacMan.radius * 2 + (PacMan.radius * 2 - 20) / 2 - 9, i * PacMan.radius * 2 + (PacMan.radius * 2 - 20) / 2 - 9, 2 * PacMan.radius, 2 * PacMan.radius);
                    rectangles1.Add(r);
                    Rectangle r2 = new Rectangle(j * PacMan.radius * 2 + (PacMan.radius * 2 - 20) / 2 + 400, i * PacMan.radius * 2 + (PacMan.radius * 2 - 20) / 2 - 9, 2 * PacMan.radius, 2 * PacMan.radius);
                    rectangles2.Add(r2);
                }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.LightGray);

            g.DrawRectangle(new Pen(Color.Blue,4), rectangle1);//drawing the field of the first pacman
            g.DrawRectangle(new Pen(Color.Red, 4), rectangle2);//drawing the field of the second pacman

            for (int i = 0; i < rectangles1.Count; i++)//drawing the eating objects of the first pacman
                g.DrawEllipse(new Pen(Color.Red), rectangles1[i]);

            for (int i = 0; i < rectangles2.Count; i++)//drawing the eating objects of the first pacman
                g.DrawEllipse(new Pen(Color.Blue), rectangles2[i]);

            positioner.draw(g);
            pacman1.Draw(g);
            pacman2.Draw(g);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                pacman2.direction = PacMan.DIRECTION.up;
            else if (e.KeyCode == Keys.Down)
                pacman2.direction = PacMan.DIRECTION.down;
            else if (e.KeyCode == Keys.Left)
                pacman2.direction = PacMan.DIRECTION.left;
            else if (e.KeyCode == Keys.Right)
                pacman2.direction = PacMan.DIRECTION.right;

            if (e.KeyCode == Keys.W)
                pacman1.direction = PacMan.DIRECTION.up;
            else if (e.KeyCode == Keys.S)
                pacman1.direction = PacMan.DIRECTION.down;
            else if (e.KeyCode == Keys.A)
                pacman1.direction = PacMan.DIRECTION.left;
            else if (e.KeyCode == Keys.D)
                pacman1.direction = PacMan.DIRECTION.right;
            Invalidate();
        }
        private double distance(Point p1, Point p2){return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));   }
        private void endGame(string msg)
        {
            timer1.Stop();
            timerClock.Stop();
            DialogResult result = MessageBox.Show(msg+"\nDali sakate nova igra?", "KRAJ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                newGame();
                Invalidate();
            }
            else
                this.Close();
        }
        private void checkIfEndGame()
        {
            //checking for positioner's victims
            Rectangle pacMan1sRectangle = new Rectangle(pacman1.position.X - PacMan.radius, pacman1.position.Y - PacMan.radius, 2 * PacMan.radius, 2 * PacMan.radius);
            Rectangle pacMan2sRectangle = new Rectangle(pacman2.position.X - PacMan.radius, pacman2.position.Y - PacMan.radius, 2 * PacMan.radius, 2 * PacMan.radius);

            bool firstPlayerIntersects = positioner.horizontal.IntersectsWith(pacMan1sRectangle)||positioner.vertical.IntersectsWith(pacMan1sRectangle);
            bool secondPlayerIntersects = positioner.horizontal.IntersectsWith(pacMan2sRectangle) || positioner.vertical.IntersectsWith(pacMan2sRectangle) ;

            if ((firstPlayerIntersects && !secondPlayerIntersects) || (rectangles1.Count > 0 && rectangles2.Count == 0))
                endGame("Vtoriot igrac e pobednik.");
            else if ((!firstPlayerIntersects && secondPlayerIntersects) || (rectangles2.Count > 0 && rectangles1.Count == 0))
                endGame("Prviot igrac e pobednik.");
            else if (!firstPlayerIntersects && !secondPlayerIntersects && rectangles1.Count == 0 && rectangles2.Count == 0)
                endGame("Site se pobednici.");
            else if ((firstPlayerIntersects && secondPlayerIntersects) || (rectangles2.Count == 0 && rectangles1.Count == 0) )
                endGame("Nema pobednik");
        }
        private void timer1_Tick(object sender, EventArgs e)
        { 
            for (int i=0;i<rectangles1.Count;i++) 
                if (distance(pacman1.position, new Point(rectangles1[i].X + PacMan.radius, rectangles1[i].Y + PacMan.radius))<2*PacMan.radius-8)
                    rectangles1.Remove(rectangles1[i]);
            
            for (int i = 0; i < rectangles2.Count; i++)
                if (distance(pacman2.position, new Point(rectangles2[i].X + PacMan.radius, rectangles2[i].Y + PacMan.radius)) < 2 * PacMan.radius - 8)
                    rectangles2.Remove(rectangles2[i]);

            positioner.Move();
            pacman1.Move();
            pacman2.Move();
            Invalidate();
            checkIfEndGame();
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            timeInSeconds--;
            lblTimeLeft.Text = String.Format("{0:00}:{1:00}", timeInSeconds / 60, timeInSeconds % 60);
            if (timeInSeconds == 0) endGame("Vremeto istece!");
        }

        private void btnNewGame_MouseClick(object sender, MouseEventArgs e)
        {
            newGame();
            btnPause_Click(null, null);
            Invalidate();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timerClock.Start();
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            timerClock.Stop();
            timer1.Stop();
        }

       

    }
}
