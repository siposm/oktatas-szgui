using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Workshop06.Model;

namespace Workshop06.Renderer
{
    public class Display : FrameworkElement
    {

        IGameModel model;
        Size size;

        public void Resize(Size size)
        {
            this.size = size;
        }

        public void SetupModel(IGameModel model)
        {
            this.model = model;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (model != null && size.Width > 50 && size.Height > 50)
            {
                double rectWidth = size.Width / model.GameState.GetLength(1);
                double rectHeight = size.Height / model.GameState.GetLength(0);

                drawingContext.DrawRectangle(Brushes.White, new Pen(Brushes.White, 0),
                    new Rect(0, 0, size.Width, size.Height));

                ImageBrush brush = new ImageBrush();

                for (int i = 0; i < model.GameState.GetLength(0); i++)
                {
                    for (int j = 0; j < model.GameState.GetLength(1); j++)
                    {
                        switch (model.GameState[i, j])
                        {
                            case RectangleType.PLAYER:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri(Path.Combine("Images", "x.jpg"), UriKind.RelativeOrAbsolute)));
                                break;
                            case RectangleType.ENEMY:
                                brush = new ImageBrush
                                    (new BitmapImage(new Uri(Path.Combine("Images", "o.png"), UriKind.RelativeOrAbsolute)));
                                break;
                            case RectangleType.EMPTY:
                                brush = new ImageBrush();
                                break;
                            default:
                                break;
                        }

                        drawingContext.DrawRectangle(brush
                                    , new Pen(Brushes.Black, 1),
                                    new Rect(j * rectWidth, i * rectHeight, rectWidth, rectHeight)
                                    );
                    }
                }
            }
        }

    }
}
