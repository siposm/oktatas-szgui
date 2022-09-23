using System;
using Workshop06.Model;
using Workshop06.Service;

namespace Workshop06.Logic
{
    public class GameLogic : IGameLogic
    {

        private IGameModel model;
        private IGameOverService gameOverService;

        private static Random random = new Random();

        public GameLogic(IGameModel model, IGameOverService gameOverService)
        {
            this.model = model;
            this.gameOverService = gameOverService;
        }
        public void HandleStep(ClickData coordinate)
        {
            int y = (int)Math.Floor(coordinate.X / (coordinate.TotalWidth / model.GameState.GetLength(1)));
            int x = (int)Math.Floor(coordinate.Y / (coordinate.TotalHeight / model.GameState.GetLength(0)));
            if (isSpaceEmpty(x, y))
            {
                model.GameState[x, y] = RectangleType.PLAYER;
            }
            
            if (!hasEmptySpace())
            {
                // FOR SURE GAME OVER
                if (isEnemyWin())
                {
                    gameOverService.DoEnemyWin();
                } else if (isPlayerWin())
                {
                    gameOverService.DoPlayerWin();
                } else
                {
                    // TIE
                    gameOverService.DoTie();
                }
            } else
            {
                if (isPlayerWin())
                {
                    gameOverService.DoPlayerWin();
                } else
                {
                    randomEnemyStep();
                    if (isEnemyWin())
                    {
                        gameOverService.DoEnemyWin();
                    } else if (!hasEmptySpace())
                    {
                        gameOverService.DoTie();
                    }
                }
            }
        }

        private bool isSpaceEmpty(int x, int y)
        {
            return model.GameState[x, y] == RectangleType.EMPTY;
        }

        private bool hasEmptySpace()
        {
            foreach (var item in model.GameState)
            {
                if (item == RectangleType.EMPTY)
                {
                    return true;
                }
            }
            return false;
        }

        private bool isPlayerWin()
        {
            return hasStreak(RectangleType.PLAYER);
        }

        private bool isEnemyWin()
        {
            return hasStreak(RectangleType.ENEMY);
        }

        private bool hasStreak(RectangleType rectangleType)
        {
            bool streakFound = false;

            for (int i = 0; i < model.GameState.GetLength(0) && !streakFound; i++)
            {
                int rowCount = 0;
                for (int j = 0; j < model.GameState.GetLength(1) && !streakFound; j++)
                {
                    if (model.GameState[i,j] == rectangleType)
                    {
                        rowCount++;
                    }
                }

                if (rowCount == 3)
                {
                    streakFound = true;
                }
            }

            if (!streakFound)
            {
                for (int i = 0; i < model.GameState.GetLength(1) && !streakFound; i++)
                {
                    int columnCount = 0;
                    for (int j = 0; j < model.GameState.GetLength(0) && !streakFound; j++)
                    {
                        if (model.GameState[j, i] == rectangleType)
                        {
                            columnCount++;
                        }
                    }

                    if (columnCount == 3)
                    {
                        streakFound = true;
                    }
                }
            }

            if (!streakFound)
            {
                int counter = 0;
                for (int i = 0; i < model.GameState.GetLength(0); i++)
                {
                    if (model.GameState[i,i] == rectangleType)
                    {
                        counter++;
                    }
                }

                if (counter == 3)
                {
                    streakFound = true;
                }

                counter = 0;

                for (int i = 0; i < model.GameState.GetLength(0); i++)
                {
                    if (model.GameState[i, model.GameState.GetLength(1) - 1 - i] == rectangleType)
                    {
                        counter++;
                    }
                }

                if (counter == 3)
                {
                    streakFound = true;
                }
            }


            return streakFound;
        }

        private void randomEnemyStep()
        {
            int x;
            int y;

            do
            {
                x = random.Next(model.GameState.GetLength(0));
                y = random.Next(model.GameState.GetLength(1));
            } while (!isSpaceEmpty(x, y));

            model.GameState[x, y] = RectangleType.ENEMY;
        }
    }
}
