using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Paint
{
    internal class AddShapeCommand : ICommand
    {
        private Canvas _canvas;
        private Shape _shape;
        private List<Shape> _shapes;
        private double _initialX, _initialY;

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

                // Добавляем обработчики для перемещения фигуры
                _shape.MouseLeftButtonDown += OnShapeMouseDown;
                _shape.MouseMove += OnShapeMouseMove;
                _shape.MouseLeftButtonUp += OnShapeMouseUp;
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

        // Обработчики перемещения фигуры
        private void OnShapeMouseDown(object sender, MouseButtonEventArgs e)
        {
            var shape = sender as Shape;
            if (shape != null)
            {
                _initialX = e.GetPosition(_canvas).X - Canvas.GetLeft(shape);
                _initialY = e.GetPosition(_canvas).Y - Canvas.GetTop(shape);
                shape.CaptureMouse();
            }
        }

        private void OnShapeMouseMove(object sender, MouseEventArgs e)
        {
            var shape = sender as Shape;
            if (shape != null && shape.IsMouseCaptured)
            {
                double x = e.GetPosition(_canvas).X - _initialX;
                double y = e.GetPosition(_canvas).Y - _initialY;
                Canvas.SetLeft(shape, x);
                Canvas.SetTop(shape, y);
            }
        }

        private void OnShapeMouseUp(object sender, MouseButtonEventArgs e)
        {
            var shape = sender as Shape;
            if (shape != null)
            {
                shape.ReleaseMouseCapture();
            }
        }
    }
}
