using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Workshop07
{
    internal class Ball : GameItem
    {
        private double centerX;
        private double centerY;
        private int radius;

        private double speedX;
        private double speedY;

        private double speedMultiplier = 1;

        public Ball(int centerX, int centerY, int radius, int speedX, int speedY)
        {
            this.centerX = centerX;
            this.centerY = centerY;
            this.radius = radius;
            this.speedX = speedX;
            this.speedY = speedY;
        }

        public bool Move(int totalHeight)
        {
            centerX += (speedX * speedMultiplier);
            centerY += (speedY * speedMultiplier);
            speedMultiplier += 0.003;
            if (centerY > totalHeight)
            {
                return false;
            }
            return true;
        }

        public void Collision(Direction direction)
        {
            double temp = speedX;
            switch(direction)
            {
                case Direction.DOWN:
                    speedX = speedY;
                    speedY = -temp;
                    break;
                case Direction.UP:
                    speedY = -speedY;
                    break;
                case Direction.RIGHT:
                    speedX = -speedX;
                    break;
                case Direction.LEFT:
                    speedX = -speedX;
                    break;
            }
        }

        public override Geometry Area
        {
            get
            {
                return new EllipseGeometry(new Point(centerX, centerY), radius, radius);
            }
        }


    }
}
