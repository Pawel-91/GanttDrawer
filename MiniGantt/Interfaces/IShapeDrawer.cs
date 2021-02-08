using MiniGantt.Shapes.Interfaces;

namespace MiniGantt.Interfaces
{
    public interface IShapeDrawer<T,U> where U : IShape
    {
        void Draw(T DrawingContext, U legRectangle);
    }
}
