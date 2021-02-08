using MiniGantt.Shapes.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace MiniGantt.Shapes
{
    public class Arrow : IArrowShape
    {
        private Point _start;
        private Point _end;

        public Point Left => Start.X < End.X ? Start : End; 

        public Point Right => Start.X > End.X ? Start : End;

        public Brush ShapeColor { get; set; } = Brushes.Black;

        public double HeadLength { get; set; } = 5;

        public double HeadAngle { get; set; } = 30;
        public Point Start { get => _start; set => _start = value; }
        public Point End { get => _end; set => _end = value; }
        public double Thickness { get; set; } = 1;

        public Arrow(double x1, double x2, double y1, double y2)
        {
            Start = new Point(x1, y1);
            End = new Point(x2, y2);
        }

        public Arrow(Point start, Point end)
        {
            Start = start;
            End = end;
        }
    }
}
