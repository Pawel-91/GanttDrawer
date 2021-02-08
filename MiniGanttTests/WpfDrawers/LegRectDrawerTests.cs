using System.Linq;
using System.Windows;
using System.Windows.Media;
using MiniGantt.Shapes;
using MiniGantt.Shapes.Interfaces;
using MiniGantt.WpfDrawers;
using NUnit.Framework;

namespace MiniGanttTests.WpfDrawers
{
    [TestFixture(Description ="Tests for WpfDrawer.LegRectDrawer")]
    public class LegRectDrawerTests
    {
        private DrawingGroup drawingGroup;

        [SetUp]
        public void Setup()
        {
            drawingGroup = new DrawingGroup();
            drawingGroup.Children.Clear();
        }

        [Test]
        public void DrawRectangle_Test()
        {
            // Arrange
            LegRectDrawer rectDrawer = new LegRectDrawer();

            IRectangleShape rectangle = new LegRectangle(
                10, 10, 20, 20);

            Rect expectedRectangle = new Rect(10, 10, 20, 20);

            // Act
            var drawingContext = drawingGroup.Append();
            rectDrawer.Draw(drawingContext, rectangle);

            drawingContext.Close();
            var actual = drawingGroup.Children[0] as GeometryDrawing;

            // Assert
            Assert.AreEqual(expectedRectangle, actual.Bounds);
        }

        [Test]
        public void DrawRectangleWithText_Test()
        {
            // Arrange
            LegRectDrawer rectDrawer = new LegRectDrawer();

            IRectangleShape rectangle = new LegRectangle(
                10, 10, 20, 20, "Test Text");

            Rect expectedRectangle = new Rect(10, 10, 20, 20);
            string expectedText = "Test Text";

            // Act
            var drawingContext = drawingGroup.Append();
            rectDrawer.Draw(drawingContext, rectangle);

            drawingContext.Close();
            var actualRect = drawingGroup.Children[0] as GeometryDrawing;

            var actualText = new string(((drawingGroup.Children[1] as DrawingGroup)
                .Children[0] as GlyphRunDrawing).GlyphRun.Characters.ToArray());

            // Assert
            Assert.AreEqual(expectedRectangle, actualRect.Bounds);
            Assert.AreEqual(expectedText, actualText);
        }
    }
}
