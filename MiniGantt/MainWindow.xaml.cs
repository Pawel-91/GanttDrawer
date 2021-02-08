using MiniGantt.Interfaces;
using MiniGantt.Shapes;
using MiniGantt.Shapes.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MiniGantt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IShapeDrawer<DrawingContext, IRectangleShape> _rectDrawer;
        private readonly IShapeDrawer<DrawingContext, IArrowShape> _arrowDrawer;
        private bool _temp = false;

        public MainWindow(IShapeDrawer<DrawingContext, IRectangleShape> rectDrawer, IShapeDrawer<DrawingContext, IArrowShape> arrowDrawer)
        {
            InitializeComponent();

            _rectDrawer = rectDrawer;
            _arrowDrawer = arrowDrawer;
        }

        private void AddRectButton_Click(object sender, RoutedEventArgs e)
        {
            DGroup.Children.Clear();

            LegRectangle background = new LegRectangle(0, 0, 100, 100)
            {
                ShapeColor = Brushes.Transparent
            };

            List<IRectangleShape> rectangles = new List<IRectangleShape>
            {
                background,
                new LegRectangle(40, 10, 20, 20, "shape1"),
                new LegRectangle(0, 30, 20, 20, "shape2"),
            };
            List<IArrowShape> arrows = new List<IArrowShape>
            {
                new Arrow(rectangles[2].Right, rectangles[1].Left)
            };

            if (_temp)
            {
                rectangles.Add(new LegRectangle(80, 30, 20, 20, "shape3")
                {
                    ShapeColor = Brushes.DarkRed,
                    TextColor = Brushes.White
                });
                arrows.Add(new Arrow(rectangles[1].Right, rectangles[3].Left)
                {
                    ShapeColor = Brushes.Green
                });
            }

            var drawingContext = DGroup.Append();

            foreach (var rect in rectangles)
            {
                _rectDrawer.Draw(drawingContext, rect);
            }

            foreach (var arrow in arrows)
            {
                _arrowDrawer.Draw(drawingContext, arrow);
            }

            drawingContext.Close();
            _temp = true;
        }
    }
}
