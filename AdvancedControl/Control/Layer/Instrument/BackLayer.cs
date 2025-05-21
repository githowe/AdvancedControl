using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Instrument
{
    public class BackLayer : InstrumentLayer
    {
        /// <summary>线宽</summary>
        public double LineWidth { get; set; } = 2;

        /// <summary>线颜色</summary>
        public Color LineColor { get; set; } = Color.FromRgb(0, 0, 0);

        public override void Init()
        {
            _pen = new Pen(new SolidColorBrush(LineColor), LineWidth);
            _pen.Freeze();
        }

        protected override void OnUpdate(DrawingContext dc)
        {
            double center_x = Center.X;
            double center_y = Center.Y;
            double radius = Radius - LineWidth / 2;

            double startRadian = DegreeToRadian(StartAngle);
            double endRadian = DegreeToRadian(EndAngle);

            // 向量
            Vector startVecotr = new Vector(Math.Cos(startRadian) * radius, Math.Sin(startRadian) * radius);
            Vector endVecotr = new Vector(Math.Cos(endRadian) * radius, Math.Sin(endRadian) * radius);

            // 圆弧起点
            Point startPoint = new Point(center_x + startVecotr.X, center_y - startVecotr.Y);
            // 创建路径
            PathGeometry pathGeometry = new PathGeometry();
            PathFigure pathFigure = new PathFigure
            {
                StartPoint = startPoint
            };
            // 圆弧终点
            Point endPoint = new Point(center_x + endVecotr.X, center_y - endVecotr.Y);
            // 创建圆弧
            ArcSegment arcSegment = new ArcSegment
            {
                Point = endPoint,
                Size = new Size(radius, radius),
                SweepDirection = SweepDirection.Clockwise,
                IsLargeArc = Math.Abs(EndAngle - StartAngle) > 180,
            };
            // 添加圆弧到路径
            pathFigure.Segments.Add(arcSegment);
            pathGeometry.Figures.Add(pathFigure);
            // 绘制路径
            dc.DrawGeometry(null, _pen, pathGeometry);
        }

        private Pen _pen;
    }
}