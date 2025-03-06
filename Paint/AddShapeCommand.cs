using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint
{
    internal class AddShapeCommand : ICommand
    {
        private Canvas _canvas;
        private Shape _shape;
        private List<Shape> _shapes;

        public AddShapeCommand(Canvas canvas, List<Shape> shapes, string shapeType)
        {
            _canvas = canvas;
            _shapes = shapes;
            _shape = shapeType switch
            {
                "Круг" => new Ellipse { Width = 50, Height = 50, Fill = Brushes.Blue },
                "Квадрат" => new Rectangle { Width = 50, Height = 50, Fill = Brushes.Red },
                _ => null
            };
        }

        public void Execute()
        {
            if (_shape != null)
            {
                _shapes.Add(_shape);
                Canvas.SetLeft(_shape, 100);
                Canvas.SetTop(_shape, 100);
                _canvas.Children.Add(_shape);
            }
        }

        public void Undo()
        {
            if (_shapes.Count > 0)
            {
                _canvas.Children.Remove(_shape);
                _shapes.Remove(_shape);
            }
        }
    }
}
