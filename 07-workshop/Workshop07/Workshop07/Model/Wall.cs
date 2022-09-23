using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Workshop07
{
    internal class Wall : GameItem
    {
        private int displayWidth;
        private int displayHeight;
        private Direction direction;

        public Wall(int displayWidth, int displayHeight, Direction direction)
        {
            this.displayWidth = displayWidth;
            this.displayHeight = displayHeight;
            this.direction = direction;
        }

        public override Geometry Area
        {
            get
            {
                switch(direction)
                {
                    case Direction.UP:
                        return new RectangleGeometry(new Rect(0, 0, displayWidth, 5));
                    case Direction.LEFT:
                        return new RectangleGeometry(new Rect(0, 0, 5, displayHeight));
                    case Direction.RIGHT:
                        return new RectangleGeometry(new Rect(displayWidth - 5, 0, 5, displayHeight));
                }
                return new RectangleGeometry(new Rect(0, 0, displayWidth, 5));
            }
        }
    }
}
