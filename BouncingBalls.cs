using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace WindowsFormGraphics
{
    class Ball
    {
        public PointF Position;
        public PointF Velocity;
    }

    class BouncingBalls : WFGMainWindow
    {
        private Brush _myBrush = new SolidBrush(Color.Yellow);

        private List<Ball> _balls = new List<Ball>();

        public BouncingBalls() : base(Width:256, Height:256, BackgroundColour:Color.White, Title:"Bouncing Balls Demo - WFG")
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                PointF position = new PointF(rand.Next(10, 246), rand.Next(10, 246));
                PointF direction = new PointF((float) ((rand.NextDouble() * 2f) - 1f), (float) ((rand.NextDouble() * 2f) - 1f));

                Ball b = new Ball();
                b.Velocity = direction;
                b.Position = position;
                _balls.Add(b);
            }    
        }

        public override void Update()
        {
            foreach (var ball in _balls)
            {
                if (ball.Position.X < 0)
                {
                    ball.Velocity.X *= -1;
                }
                else if (ball.Position.X > 256 - 20)
                {
                    ball.Velocity.X *= -1;
                }

                if (ball.Position.Y < 0)
                {
                    ball.Velocity.Y *= -1;
                }
                else if (ball.Position.Y > 256 - 45)
                {
                    ball.Velocity.Y *= -1;
                }

                ball.Position = ball.Position.Add(ball.Velocity);
            }
        }

        public override void Draw(Graphics g)
        {
            foreach (var ball in _balls)
            {
                g.FillEllipse(_myBrush, ball.Position.X - 5f, ball.Position.Y - 5f, 10, 10);
            }
        }
    }
}
