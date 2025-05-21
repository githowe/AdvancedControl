using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Instrument
{
    /// <summary>
    /// 指针图层
    /// </summary>
    public class PointerLayer : InstrumentLayer
    {
        /// <summary>线宽</summary>
        public double LineWidth { get; set; } = 2;

        /// <summary>线长</summary>
        public double LineLength { get; set; } = 116;

        /// <summary>线颜色</summary>
        public Color LineColor { get; set; } = Color.FromRgb(255, 0, 0);

        public double Percent { get; set; } = 0;

        public override void Init()
        {
            _pen = new Pen(new SolidColorBrush(LineColor), LineWidth);
            _pen.Freeze();
        }

        public void UpdateBrush()
        {
            _pen = new Pen(new SolidColorBrush(LineColor), LineWidth);
            _pen.Freeze();
        }

        protected override void OnUpdate(DrawingContext dc)
        {
            // 总角度
            double totalAngle = Math.Abs(EndAngle - StartAngle);
            // 指针角度
            double pointerAngle = StartAngle - totalAngle * Percent;

            double radian = DegreeToRadian(pointerAngle);
            Vector start = new Vector(Math.Cos(radian) * Radius, Math.Sin(radian) * Radius);
            Vector end = new Vector(Math.Cos(radian) * (Radius - LineLength), Math.Sin(radian) * (Radius - LineLength));
            Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);
            Point endPoint = new Point(Center.X + end.X, Center.Y - end.Y);
            dc.DrawLine(_pen, startPoint, endPoint);
        }

        private Pen _pen;
    }
}