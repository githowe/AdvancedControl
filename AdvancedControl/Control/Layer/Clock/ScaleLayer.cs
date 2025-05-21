using AdvancedControl.ControlBase;
using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Clock
{
    public class ScaleLayer : SingleLayer
    {
        /// <summary>圆心</summary>
        public Point Center { get; set; } = new Point(100, 100);

        /// <summary>半径</summary>
        public double Radius { get; set; } = 100;

        /// <summary>刻度线颜色</summary>
        public Color LineColor { get; set; } = Color.FromRgb(0, 0, 0);

        /// <summary>细分刻度线颜色</summary>
        public Color SubLineColor { get; set; } = Color.FromArgb(64, 0, 0, 0);

        public int LineLength { get; set; } = 6;

        public int SubLineLength { get; set; } = 6;

        public override void Init()
        {
            _pen = new Pen(new SolidColorBrush(LineColor), 2);
            _pen.Freeze();
            _subPen = new Pen(new SolidColorBrush(SubLineColor), 1);
            _subPen.Freeze();
        }

        protected override void OnUpdate(DrawingContext dc)
        {
            double angleDelta = 360 / 12;
            for (int counter = 0; counter < 12; counter++)
            {
                double angle = 90 - counter * angleDelta;
                double radian = DegreeToRadian(angle);
                Vector start = new Vector(Math.Cos(radian) * Radius, Math.Sin(radian) * Radius);
                Vector end = new Vector(Math.Cos(radian) * (Radius - LineLength), Math.Sin(radian) * (Radius - LineLength));
                Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);
                Point endPoint = new Point(Center.X + end.X, Center.Y - end.Y);
                // 绘制主刻度
                dc.DrawLine(_pen, startPoint, endPoint);
                // 绘制细分刻度
                DrawSubScale(dc, angle, angle + angleDelta);
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
            double angleDelta = totalAngle / 5;
            // 循环绘制
            for (int counter = 0; counter < 4; counter++)
            {
                double angle = startAngle - (counter + 1) * angleDelta;
                double radian = DegreeToRadian(angle);
                Vector start = new Vector(Math.Cos(radian) * Radius, Math.Sin(radian) * Radius);
                Vector end = new Vector(Math.Cos(radian) * (Radius - SubLineLength), Math.Sin(radian) * (Radius - SubLineLength));
                Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);
                Point endPoint = new Point(Center.X + end.X, Center.Y - end.Y);
                dc.DrawLine(_subPen, startPoint, endPoint);
            }
        }

        private Pen _pen;
        private Pen _subPen;
    }
}