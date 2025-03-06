using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Paint
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Shape> shapes = new();
        private Canvas drawingCanvas;
        private Stack<ICommand> commandHistory = new();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExecuteCommand(ICommand command)
        {
            command.Execute();
            commandHistory.Push(command);
        }

        private void UndoLastCommand()
        {
            if (commandHistory.Count > 0)
            {
                var command = commandHistory.Pop();
                command.Undo();
            }
        }

        private void AddCircle_Click(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(new AddShapeCommand(DrawingCanvas, shapes, "Круг"));
        }

        private void AddSquare_Click(object sender, RoutedEventArgs e)
        {
            ExecuteCommand(new AddShapeCommand(DrawingCanvas, shapes, "Квадрат"));
        }


        private void RemoveShape_Click(object sender, RoutedEventArgs e)
        {
            //ExecuteCommand(new RemoveShapeCommand(DrawingCanvas, shapes));
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            UndoLastCommand();
        }

    }
}