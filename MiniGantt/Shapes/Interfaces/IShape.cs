using System.Windows;
using System.Windows.Media;

namespace MiniGantt.Shapes.Interfaces
{
    public interface IShape
    {
        Point Left { get; }
        Point Right { get; }
        Brush ShapeColor { get; set; }
    }
}
