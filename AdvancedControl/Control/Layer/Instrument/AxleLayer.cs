using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Instrument
{
    /// <summary>
    /// 轴图层
    /// </summary>
    public class AxleLayer : InstrumentLayer
    {
        protected override void OnUpdate(DrawingContext dc)
        {
            dc.DrawEllipse(new SolidColorBrush(Color.FromRgb(255, 0, 0)), null, Center, 6, 6);
            dc.DrawEllipse(new SolidColorBrush(Color.FromRgb(255, 255, 255)), null, Center, 4, 4);
        }
    }
}