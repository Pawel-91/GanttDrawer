using MiniGantt.Interfaces;
using MiniGantt.Shapes;
using MiniGantt.Shapes.Interfaces;
using System.Windows;
using System.Windows.Media;

namespace MiniGantt.WpfDrawers
{
    class ArrowDrawer : IShapeDrawer<DrawingContext, IArrowShape>
    {
        public void Draw(DrawingContext context, IArrowShape arrow)
        {
            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures.Add(CreateArrowLine(arrow.Start, arrow.End, arrow.Thickness));
            pathGeometry.Figures.Add(CreateArrowHead(arrow.Start, arrow.End, arrow));

            Pen pen = new Pen(arrow.ShapeColor, arrow.Thickness);
            pen.Freeze();

            context.DrawGeometry(arrow.ShapeColor, pen, pathGeometry);
        }

        private PathFigure CreateArrowLine(Point startPoint, Point endPoint, double thickness)
        {
            PathFigure lineFigure = new PathFigure();
            PolyLineSegment lineSegment = new PolyLineSegment();
            Vector thicknessCorrection = CalculateThicknessCorrection(startPoint, endPoint, thickness);

            lineFigure.Segments.Add(lineSegment);
            lineFigure.StartPoint = startPoint;
            lineSegment.Points.Add(endPoint + thicknessCorrection);

            return lineFigure;
        }

        private PathFigure CreateArrowHead(Point lineStartPoint, Point lineEndPoint, IArrowShape arrow)
        {
            Matrix rotationMatrix = new Matrix();
            Vector vector = lineStartPoint - lineEndPoint;  // create a vector containing deference between start and end points 
            Vector thicknessCorrection = CalculateThicknessCorrection(lineStartPoint, lineEndPoint, arrow.Thickness);

            vector.Normalize();                             // normalization creates unit vector - we need to keep vectors orientation (without value, which is equal to line's length)
            vector *= arrow.HeadLength;                           // vector * scalar - defines the new length of the vector (which we use to build our arrow's head)

            PathFigure headFigure = new PathFigure();
            headFigure.Segments.Clear();                            // we don't want any other segments in our arrow head pathFigure
            PolyLineSegment headSegment = new PolyLineSegment();    // lets create a new line segment in pathFigure
            headFigure.Segments.Add(headSegment);                   // and add it to our figure

            headSegment.Points.Clear();
            rotationMatrix.Rotate(arrow.HeadAngle / 2);                        // lets create a rotation matrix for the half of the arrow angle
            headFigure.StartPoint = lineEndPoint + vector * rotationMatrix;    // starting point - we use matrix to rotate our vector (with the same orientation as arrow's main line).
                                                                               // Then we transle the end point of arrow line by rotated vector
            headSegment.Points.Add(lineEndPoint + thicknessCorrection);        // And we adding the end point of main arrow's to line segment, moved to the left by line thickness

            rotationMatrix.Rotate(-arrow.HeadAngle);                           // lets update the rotation matrix for the second part of arrow's head
            headSegment.Points.Add(lineEndPoint + vector * rotationMatrix);    // and add it with the calculations similar to those above
            headFigure.IsClosed = true;                                        // we want the arrow to be closed (like a triangle) don't we?

            return headFigure;
        }

        private Vector CalculateThicknessCorrection(Point startPoint, Point endPoint, double thickness)
        {
            Vector unitVector = startPoint - endPoint;
            unitVector.Normalize();

            return (unitVector * thickness);
        }
    }
}
