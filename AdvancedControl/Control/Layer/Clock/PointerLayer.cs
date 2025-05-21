using AdvancedControl.ControlBase;
using System.Windows;
using System.Windows.Media;

namespace AdvancedControl.Control.Layer.Clock
{
    public class PointerLayer : SingleLayer
    {
        /// <summary>圆心</summary>
        public Point Center { get; set; } = new Point(100, 100);

        /// <summary>半径</summary>
        public double Radius { get; set; } = 100;

        public double 时针角度 { get; set; } = 0;

        public double 分针角度 { get; set; } = 0;

        public double 秒针角度 { get; set; } = 0;

        public override void Init()
        {
            _时针.VectorList.Add(new Vector(0, 4));
            _时针.VectorList.Add(new Vector(-3, 44));
            _时针.VectorList.Add(new Vector(0, 60));
            _时针.VectorList.Add(new Vector(3, 44));

            _分针.VectorList.Add(new Vector(0, 4));
            _分针.VectorList.Add(new Vector(-3, 64));
            _分针.VectorList.Add(new Vector(0, 80));
            _分针.VectorList.Add(new Vector(3, 64));

            _时针画笔.Freeze();
            _分针画笔.Freeze();
            _红色秒针.Freeze();
            _灰色秒针.Freeze();
        }

        protected override void OnUpdate(DrawingContext dc)
        {
            绘制指针(dc, _时针, 时针角度, _时针画笔);
            绘制指针(dc, _分针, 分针角度, _分针画笔);

            double radian = DegreeToRadian(90 - 秒针角度);
            Vector start = new Vector(Math.Cos(radian) * Radius, Math.Sin(radian) * Radius);
            Vector end = new Vector(Math.Cos(radian) * (Radius - 100), Math.Sin(radian) * (Radius - 100));
            Point startPoint = new Point(Center.X + start.X, Center.Y - start.Y);
            Point endPoint = new Point(Center.X + end.X, Center.Y - end.Y);
            dc.DrawLine(_红色秒针, startPoint, endPoint);
        }

        private void 绘制指针(DrawingContext dc, Pointer pointer, double angle, Pen pen)
        {
            double center_x = Center.X;
            double center_y = Center.Y;

            // 旋转指针并获取旋转后的向量
            List<Vector> vectorList = pointer.Rotate(angle);
            // 将向量转换为点
            List<Point> pointList = new List<Point>();
            foreach (var item in vectorList)
            {
                Point point = new Point(center_x + item.X, center_y - item.Y);
                pointList.Add(point);
            }

            // 创建路径
            PathGeometry pathGeometry = new PathGeometry();
            // 添加线段
            PathFigure pathFigure = new PathFigure
            {
                StartPoint = pointList[0]
            };
            for (int index = 1; index < pointList.Count; index++)
            {
                LineSegment lineSegment = new LineSegment { Point = pointList[index] };
                pathFigure.Segments.Add(lineSegment);
            }
            pathFigure.IsClosed = true;
            pathGeometry.Figures.Add(pathFigure);
            // 绘制路径
            dc.DrawGeometry(Brushes.White, pen, pathGeometry);
        }

        private readonly Pointer _时针 = new Pointer();
        private readonly Pointer _分针 = new Pointer();

        private readonly Pen _时针画笔 = new Pen(new SolidColorBrush(Color.FromRgb(60, 60, 60)), 1.6);
        private readonly Pen _分针画笔 = new Pen(new SolidColorBrush(Color.FromRgb(60, 60, 60)), 1.6);
        private readonly Pen _红色秒针 = new Pen(new SolidColorBrush(Color.FromRgb(255, 0, 0)), 2);
        private readonly Pen _灰色秒针 = new Pen(new SolidColorBrush(Color.FromRgb(180, 180, 180)), 2);
    }
}