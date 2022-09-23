using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Workshop07
{
    internal class Pad : GameItem
    {
        private double X;
        private int displayWidth;
        private int displayHeight;
        private int length;

        public Pad(int displayWidth, int displayHeight)
        {
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.length = displayWidth / 6;
            this.X = displayWidth / 2 - length;
        }

        public override Geometry Area
        {
            get
            {
                return new RectangleGeometry(new Rect(X, displayHeight - 5, length, 5));
            }
        }

        public void Step(Direction direction)
        {
            switch(direction)
            {
                case Direction.LEFT:
                    if (X - 10 > 5)
                    {
                        X -= 10;
                    } else
                    {
                        X = 5;
                    }
                    break;
                case Direction.RIGHT:
                    if (X + 10 < displayWidth - 5 - length)
                    {
                        X += 10;
                    } else
                    {
                        X = displayWidth - 5 - length;
                    }
                    break;
            }
        }
    }
}
