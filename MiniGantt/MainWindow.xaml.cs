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

        public MainWindow(IShapeDrawer<DrawingContext, IRectangleShape> rectDrawer, IShapeDrawer<DrawingContext, IArrowShape> arrowDrawer)
        {
            InitializeComponent();

            _rectDrawer = rectDrawer;
            _arrowDrawer = arrowDrawer;

            LegRectangle background = new LegRectangle(0, 0, 100, 100)
            {
                ShapeColor = Brushes.Transparent
            };

            using var drawingContext = DGroup.Append();
            rectDrawer.Draw(drawingContext, background);
        }

        private void AddRectButton_Click(object sender, RoutedEventArgs e)
        {
            List<IRectangleShape> rectangles = new List<IRectangleShape>
            {
                new LegRectangle(40, 10, 20, 20, "shape1"),
                new LegRectangle(0, 30, 20, 20, "shape2"),
                //new LegRectangle(80, 30, 20, 20, "shape3")
            };

            List<IArrowShape> arrows = new List<IArrowShape>
            {
                new Arrow(rectangles[1].Right, rectangles[0].Left),
                //new Arrow(rectangles[0].Right, rectangles[2].Left)
            };

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
        }
    }
}
