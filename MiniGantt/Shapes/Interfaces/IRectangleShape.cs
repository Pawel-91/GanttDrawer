using System.Windows;

namespace MiniGantt.Shapes.Interfaces
{
    public interface IRectangleShape : ITextShape
    {
        public Rect Rect { get; }
    }
}
