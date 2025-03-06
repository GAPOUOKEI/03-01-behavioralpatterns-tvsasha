using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Paint
{
    class RemoveShapeCommand : ICommand
    {
        private Canvas _canvas;
        private List<Shape> _shapes;
        private Shape _removedShape;

        public RemoveShapeCommand(Canvas canvas, List<Shape> shapes)
        {
            _canvas = canvas;
            _shapes = shapes;
        }

        public void Execute()
        {
            if (_shapes.Count > 0)
            {
                _removedShape = _shapes[^1];
                _canvas.Children.Remove(_removedShape);
                _shapes.RemoveAt(_shapes.Count - 1);
            }
        }

        public void Undo()
        {
            if (_removedShape != null)
            {
                _shapes.Add(_removedShape);
                _canvas.Children.Add(_removedShape);
            }
        }
    }
}
