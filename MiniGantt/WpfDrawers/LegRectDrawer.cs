using MiniGantt.Interfaces;
using MiniGantt.Shapes.Interfaces;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace MiniGantt.WpfDrawers
{
    public class LegRectDrawer : IShapeDrawer<DrawingContext, IRectangleShape>
    {
        public void Draw(DrawingContext context, IRectangleShape legRectangle)
        { 
                RectangleGeometry rectangle = new RectangleGeometry(legRectangle.Rect);
          
                GeometryDrawing geometryDrawing = new GeometryDrawing(
                    legRectangle.ShapeColor,
                    legRectangle.Border,
                    rectangle);

                context.DrawDrawing(geometryDrawing);

                if (!string.IsNullOrWhiteSpace(legRectangle.Text))
                {
                    DrawText(context, legRectangle);
                }
        }

        private void DrawText(DrawingContext context, IRectangleShape rectangle)
        {
            FormattedText text = new FormattedText(rectangle.Text,
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                rectangle.Size,
                rectangle.TextColor,
                1.0)
            {
                TextAlignment = TextAlignment.Center,
                MaxTextWidth = rectangle.Rect.Width
            };

            context.DrawText(text, new Point(rectangle.Left.X, rectangle.Left.Y - text.Height / 2));
        }
    }
}
