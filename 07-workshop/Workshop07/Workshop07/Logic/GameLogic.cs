using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop07
{
    internal class GameLogic : IGameLogic
    {
        private static int[] randomSpeedValues = { -1, 1 };
        private IGameModel model;

        static Random r = new Random();

        int areaHeight;
        int areaWidth;

        public Ball BallBuilder()
        {
            return new Ball(r.Next(40, areaWidth - 40), r.Next(40, areaHeight - 40), 30, randomSpeedValues[r.Next(2)], randomSpeedValues[r.Next(2)]);
        }

        public GameLogic(int areaWidth, int areaHeight, IGameModel model)
        {
            this.areaWidth = areaWidth;
            this.areaHeight = areaHeight;
            this.model = model;
            this.model.LeftWall = new Wall(areaWidth, areaHeight, Direction.LEFT);
            this.model.RightWall = new Wall(areaWidth, areaHeight, Direction.RIGHT);
            this.model.TopWall = new Wall(areaWidth, areaHeight, Direction.UP);
            this.model.Ball = BallBuilder();
            this.model.Pad = new Pad(areaWidth, areaHeight);
        }

        public void TimeStep()
        {
            if (model.Ball.IsCollision(model.LeftWall))
            {
                model.Ball.Collision(Direction.LEFT);
            } else if (model.Ball.IsCollision(model.RightWall))
            {
                model.Ball.Collision(Direction.RIGHT);
            } else if (model.Ball.IsCollision(model.TopWall))
            {
                model.Ball.Collision(Direction.UP);
            } else if (model.Ball.IsCollision(model.Pad))
            {
                model.Ball.Collision(Direction.DOWN);
            }
            if (!model.Ball.Move(areaHeight))
            {
                this.model.Ball = BallBuilder();
            }
        }

        public void PadStep(Direction direction)
        {
            model.Pad.Step(direction);
        }
    }
}
