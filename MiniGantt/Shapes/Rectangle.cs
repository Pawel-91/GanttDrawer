using MiniGantt.Shapes.Interfaces;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace MiniGantt.Shapes
{
    public class LegRectangle : IRectangleShape
    {
        private readonly Rect _rect;
        public Point Left => new Point(Rect.Left, Rect.Top + Rect.Height / 2);

        public Point Right => new Point(Rect.Right, Rect.Top + Rect.Height / 2);

        public string Text { get; set; }
        public Brush ShapeColor { get; set; } = Brushes.LightGray;
        public double Size { get; set; } = 2;
        public Brush TextColor { get; set; } = Brushes.Black;
        public Rect Rect => _rect;
        public Pen Border { get; set; }

        public LegRectangle(Rect rect, string text = null)
        {
            _rect = rect;
            Text = text;
        }

        public LegRectangle(double x, double y, double width, double height, string text = null)
        {
            _rect = new Rect(x, y, width, height);
            Text = text;
        }
       
    }
}
