using System.Windows.Media;

namespace MiniGantt.Shapes.Interfaces
{
    /// <summary>
    /// IShape with FormattedText inside
    /// </summary>
    public interface ITextShape : IShape
    {
        string Text { get; set; }
        double Size { get; set; }
        Brush TextColor { get; set; }
        Pen Border { get; set; }
    }
}
