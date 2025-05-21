using AdvancedControl.ControlBase;
using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Clock
{
    public class AxleLayer : SingleLayer
    {
        /// <summary>圆心</summary>
        public Point Center { get; set; } = new Point(100, 100);

        protected override void OnUpdate(DrawingContext dc)
        {
            dc.DrawEllipse(new SolidColorBrush(Color.FromRgb(60, 60, 60)), null, Center, 6, 6);
            dc.DrawEllipse(new SolidColorBrush(Color.FromRgb(255, 255, 255)), null, Center, 4, 4);
        }
    }
}