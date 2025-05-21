using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Instrument
{
    /// <summary>
    /// 刻度图层
    /// </summary>
    public class ScaleLayer : InstrumentLayer
    {
        /// <summary>线宽</summary>
        public double LineWidth { get; set; } = 2;

        public double SubLineWidth { get; set; } = 1;

        /// <summary>线长</summary>
        public double LineLength { get; set; } = 16;

        public double SubLineLength { get; set; } = 8;

        /// <summary>线颜色</summary>
        public Color LineColor { get; set; } = Color.FromRgb(0, 0, 0);

        /// <summary>主刻度数量</summary>
        public int MainScaleCount { get; set; } = 11;

        /// <summary>细分刻度数量</summary>
        public int SubScaleCount { get; set; } = 4;

        /// <summary>刻度线偏移。正数为朝内偏移</summary>
        public int LineOffset = 0;

        public override void Init()
        {
            _pen = new Pen(new SolidColorBrush(LineColor), LineWidth);
            _pen.Freeze();
            _subPen = new Pen(new SolidColorBrush(LineColor), SubLineWidth);
            _subPen.Freeze();
        }

        protected override void OnUpdate(DrawingContext dc)
        {
            // 总角度
            double totalAngle = Math.Abs(EndAngle - StartAngle);
            // 角度增量
            double angleDelta = totalAngle / (MainScaleCount - 1);
            // 循环绘制。使用顺时针方向绘制
            for (int counter = 0; counter < MainScaleCount; counter++)
            {
                double angle = StartAngle - counter * angleDelta;
                double radian = DegreeToRadian(angle);
                Vector start = new Vector(Math.Cos(radian) * (Radius - LineOffset), Math.Sin(radian) * (Radius - LineOffset));
                Vector end = new Vector(Math.Cos(radian) * (Radius - LineLength - LineOffset), Math.Sin(radian) * (Radius - LineLength - LineOffset));
                Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);
                Point endPoint = new Point(Center.X + end.X, Center.Y - end.Y);
                // 绘制主刻度
                dc.DrawLine(_pen, startPoint, endPoint);
                // 绘制细分刻度
                if (counter < MainScaleCount - 1) DrawSubScale(dc, angle, angle + angleDelta);
            }
        }

        /// <summary>
        /// 绘制细分刻度
        /// </summary>
        private void DrawSubScale(DrawingContext dc, double startAngle, double endAngle)
        {
            // 总角度
            double totalAngle = Math.Abs(endAngle - startAngle);
            // 角度增量
            double angleDelta = totalAngle / (SubScaleCount + 1);
            // 循环绘制
            for (int counter = 0; counter < SubScaleCount; counter++)
            {
                double angle = startAngle - (counter + 1) * angleDelta;
                double radian = DegreeToRadian(angle);
                Vector start = new Vector(Math.Cos(radian) * (Radius - LineOffset), Math.Sin(radian) * (Radius - LineOffset));
                Vector end = new Vector(Math.Cos(radian) * (Radius - SubLineLength - LineOffset), Math.Sin(radian) * (Radius - SubLineLength - LineOffset));
                Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);
                Point endPoint = new Point(Center.X + end.X, Center.Y - end.Y);
                dc.DrawLine(_subPen, startPoint, endPoint);
            }
        }

        private Pen _pen;
        private Pen _subPen;
    }
}