using AdvancedControl.ControlBase;
using System.Windows;

namespace AdvancedControl.Control.Layer.Instrument
{
    public abstract class InstrumentLayer : SingleLayer
    {
        /// <summary>圆心</summary>
        public Point Center { get; set; } = new Point(100, 100);

        /// <summary>半径</summary>
        public double Radius { get; set; } = 100;

        /// <summary>起始角度</summary>
        public double StartAngle { get; set; } = 210;

        /// <summary>结束角度</summary>
        public double EndAngle { get; set; } = -30;
    }
}