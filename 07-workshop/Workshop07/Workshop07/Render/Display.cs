using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Workshop07
{
    internal class Display: FrameworkElement
    {

        IGameModel _model;

        public void SetupModel(IGameModel model)
        {
            this._model = model;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (_model != null)
            {
                drawingContext.DrawGeometry(Brushes.Black, null, _model.LeftWall.Area);
                drawingContext.DrawGeometry(Brushes.Black, null, _model.RightWall.Area);
                drawingContext.DrawGeometry(Brushes.Black, null, _model.TopWall.Area);
                drawingContext.DrawGeometry(Brushes.Red, null, _model.Pad.Area);
                drawingContext.DrawGeometry(Brushes.Green, null, _model.Ball.Area);
            }
        }

    }
}
