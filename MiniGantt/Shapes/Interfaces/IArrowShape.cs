using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace MiniGantt.Shapes.Interfaces
{
    public interface IArrowShape : IShape
    {
        Point Start { get; }

        Point End { get; }

        double Thickness { get; set; }

        public double HeadLength { get; set; }

        public double HeadAngle { get; set; } 
    }
}
